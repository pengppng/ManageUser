const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:5200';

const PROXY_CONFIG = [
  {
    context: [
      "/api/v1"
    ],
    target:"http://localhost:5200",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
