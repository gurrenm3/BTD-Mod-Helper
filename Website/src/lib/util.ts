export const parseBool = (str): boolean => {
  if (typeof str === "string" && str.toLowerCase() == "true") return true;

  return parseInt(str) > 0;
};

export const getString = async (url: string) => {
  try {
    const response = await fetch(url, { cache: "force-cache" });

    if (!response?.ok) {
      return Promise.reject();
    }

    return await response.text();
  } catch (e) {
    return Promise.reject();
  }
};
