var path = require("path");
const { VueLoaderPlugin } = require("vue-loader");
const HtmlWebpackPlugin = require("html-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const CopyWebpackPlugin = require("copy-webpack-plugin");

module.exports = {
  mode: "development",
  entry: {
    core: path.join(__dirname, "src", "main.js"),
    pricebook: path.join(__dirname, "src", "main.js")
  },
  output: {
    path: path.join(__dirname, "public"),
    filename: "[name].bundle.js"
  },
  module: {
    rules: [
      {
        test: /\.vue$/,
        loader: "vue-loader",
        options: {
          sourceMap: true
        }
      },
      {
        test: /\.js$/,
        loader: "babel-loader",
        include: path.join(__dirname, "src")
      },
      {
        test: /\.css$/,
        use: [
          process.env.NODE_ENV !== "production"
            ? "vue-style-loader"
            : MiniCssExtractPlugin.loader,
          "css-loader"
        ]
      },
      {
        test: /\.(woff|woff2)(\?v=\d+\.\d+\.\d+)?$/,
        use: {
          loader: "url-loader",
          options: {
            limit: 50000,
            mimetype: "application/font-woff",
            name: "./fonts/[name].[ext]"
          }
        }
      },
      {
        test: /\.(svg)$/,
        exclude: /fonts/ /* dont want svg fonts from fonts folder to be included */,
        use: [
          {
            loader: "svg-url-loader",
            options: {
              noquotes: true
            }
          }
        ]
      }
    ]
  },
  plugins: [
    new VueLoaderPlugin(),
    new MiniCssExtractPlugin({
      filename: "main.css"
    }),
    new HtmlWebpackPlugin({
      template: path.join(__dirname, "src", "index.html"),
      hash: false,
      filename: "index.html",
      chunks: ["core", "pricebook"]
    }),
    new HtmlWebpackPlugin({
      template: path.join(__dirname, "src", "index.html"),
      hash: false,
      filename: "pricebook.html",
      chunks: ["pricebook"]
    }),
    new CopyWebpackPlugin([
      {
        from: path.join(__dirname, "src", "assets"),
        to: path.join(__dirname, "public", "assets"),
        toType: "dir"
      }
    ])
  ],
  devServer: {
    contentBase: path.join(__dirname, "dist"),
    inline: true,
    stats: "errors-only"
  }
};
