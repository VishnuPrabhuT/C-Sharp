const path = require("path");

module.exports = {
  outputDir: path.resolve(__dirname, "../wwwroot/"),
  chainWebpack: config => {
    config.resolve.alias.set("@api", path.resolve(__dirname, "./src/api"));
    if (config.plugins.has("extract-css")) {
      const extractCSSPlugin = config.plugin("extract-css");
      extractCSSPlugin &&
        extractCSSPlugin.tap(() => [
          {
            filename: "[name].css",
            chunkFilename: "[name].css"
          }
        ]);
    }
  },
  configureWebpack: {
    output: {
      filename: "[name].js",
      chunkFilename: "[name].js"
    }
  },
  pluginOptions: {
    quasar: {
      theme: "mat"
    }
  }
};
