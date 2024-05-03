const { env } = require('process');

const target = 'https://localhost:32770';

const PROXY_CONFIG = [
  {
    context: [
      "/WeatherForecast",
    ],
    target,
    secure: false
  }
]

module.exports = PROXY_CONFIG;
