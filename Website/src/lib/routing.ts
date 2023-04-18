import { useRouter } from "next/router";
import { isArray, isNaN } from "lodash";

export const useParam = <T extends string>(
  router: ReturnType<typeof useRouter>,
  param: string,
  sep: string = "/"
) => {
  const queryParam = router.query[param]!;
  const query = isArray(queryParam) ? queryParam.join(sep) : queryParam;
  return [
    query as T,
    (val: T) =>
      router.replace({ query: { ...router.query, [param]: val } }, undefined, {
        scroll: false,
      }),
  ] as const;
};

export const useParamArray = <T>(
  router: ReturnType<typeof useRouter>,
  param: string,
  def = [] as T[]
) => {
  const queryParam = router.query[param];
  return [
    queryParam
      ? isArray(queryParam)
        ? (queryParam as T[])
        : [queryParam as T]
      : def,
    (val: T[]) =>
      router.replace(
        {
          query: {
            ...router.query,
            [param]: val as string[],
          },
        },
        undefined,
        { scroll: false }
      ),
  ] as const;
};

export const useParamBool = (
  router: ReturnType<typeof useRouter>,
  param: string,
  def = false
) => {
  const queryParam = router.query[param];
  return [
    queryParam !== null && queryParam !== undefined
      ? queryParam == "true"
      : def,
    (val: boolean) =>
      router.replace(
        {
          query: {
            ...router.query,
            [param]: String(val),
          },
        },
        undefined,
        { scroll: false }
      ),
  ] as const;
};

export const useParamInt = (
  router: ReturnType<typeof useRouter>,
  param: string,
  def = 0
) => {
  const queryParam = router.query[param];

  return [
    isNaN(queryParam) || isNaN(parseInt(String(queryParam)))
      ? def
      : parseInt(String(queryParam)),
    (val: number) =>
      router.replace(
        {
          query: {
            ...router.query,
            [param]: String(val),
          },
        },
        undefined,
        { scroll: false }
      ),
  ] as const;
};
