/**
 * @type {import('next').NextConfig}
 */
const nextConfig = {
  basePath: process.env.CI ? "/BTD-Mod-Helper" : "",
  assetPrefix: process.env.CI ? "/BTD-Mod-Helper/" : "",
  images: {
    unoptimized: true,
  },
  output: "export",
  env: {
    NEXT_PUBLIC_BASE_PATH: process.env.CI ? "/BTD-Mod-Helper" : "",
  },
};

module.exports = nextConfig;
