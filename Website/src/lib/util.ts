export const parseBool = (str): boolean => {
  if (typeof str === "string" && str.toLowerCase() == "true") return true;

  return parseInt(str) > 0;
};

const CACHE_TTL_MS = 1000 * 60 * 60;
const LS_PREFIX = "cf:";

type OkEntry<T> = { kind: "ok"; timestamp: number; data: T; etag?: string };
type ErrEntry = {
  kind: "error";
  timestamp: number;
  status?: number;
  message: string;
};
type CacheEntry<T> = OkEntry<T> | ErrEntry;

const memoryCache = new Map<string, CacheEntry<any>>();

const readLS = <T>(key: string): CacheEntry<T> | undefined => {
  try {
    const raw = localStorage.getItem(LS_PREFIX + key);
    return raw ? (JSON.parse(raw) as CacheEntry<T>) : undefined;
  } catch {
    return undefined;
  }
};

const writeLS = <T>(key: string, value: CacheEntry<T>) => {
  try {
    localStorage.setItem(LS_PREFIX + key, JSON.stringify(value));
  } catch {}
};

const putMemory = <T>(key: string, entry: CacheEntry<T>) => {
  memoryCache.set(key, entry);
};

const makeError = (e: ErrEntry): Error => {
  const err = new Error(e.message);
  (err as any).status = e.status;
  return err;
};

const cachedFetch = async <T>(
  url: string,
  parser: (res: Response) => Promise<T>
): Promise<T> => {
  const now = Date.now();

  const mem = memoryCache.get(url) as CacheEntry<T> | undefined;
  if (mem && now - mem.timestamp < CACHE_TTL_MS) {
    if (mem.kind === "ok") return mem.data;
    throw makeError(mem);
  }

  const ls = readLS<T>(url);
  if (ls && now - ls.timestamp < CACHE_TTL_MS) {
    putMemory(url, ls);
    if (ls.kind === "ok") return ls.data;
    throw makeError(ls);
  }

  const etag =
    (ls && ls.kind === "ok" && ls.etag) || (mem && (mem as OkEntry<T>).etag);
  const headers: HeadersInit = etag ? { "If-None-Match": etag } : {};

  let res: Response;
  try {
    res = await fetch(url, { headers, cache: "no-cache" });
  } catch (e: any) {
    const entry: ErrEntry = {
      kind: "error",
      timestamp: now,
      message: e?.message ?? "Network error",
    };
    putMemory(url, entry);
    writeLS(url, entry);
    throw makeError(entry);
  }

  if (res.status === 304 && ls?.kind === "ok") {
    const refreshed: OkEntry<T> = { ...ls, timestamp: now };
    putMemory(url, refreshed);
    writeLS(url, refreshed);
    return ls.data;
  }

  if (!res.ok) {
    const entry: ErrEntry = {
      kind: "error",
      timestamp: now,
      status: res.status,
      message: `${res.status} ${res.statusText}`,
    };
    putMemory(url, entry);
    writeLS(url, entry);
    throw makeError(entry);
  }

  const data = await parser(res);
  const ok: OkEntry<T> = {
    kind: "ok",
    timestamp: now,
    data,
    etag: res.headers.get("ETag") ?? undefined,
  };
  putMemory(url, ok);
  writeLS(url, ok);
  return data;
};

export const getString = (url: string) => cachedFetch(url, (r) => r.text());
export const getJson = <T = unknown>(url: string) =>
  cachedFetch<T>(url, (r) => r.json());
