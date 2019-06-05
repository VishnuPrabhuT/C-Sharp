const path = require("path");
const devMode = process.env.NODE_ENV !== "production";

const webpack = require("webpack");
const { VueLoaderPlugin } = require("vue-loader");
const HtmlWebpackPlugin = require("html-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

module.exports = {
  entry: {
    app: path.join(__dirname, "src", "main.js")
  },
  output: {
    path: path.join(__dirname, "..", "wwwroot"),
    filename: devMode ? "app.js" : "[name].bundle-[hash].js",
    chunkFilename: devMode ? "[name].bundle.js" : "[name].bundle-[hash].js"
  },

  resolve: {
    extensions: [".ts", ".js", ".json"]
  },
  module: {
    rules: [
      {
        test: /\.vue$/,
        loader: "vue-loader",
        options: {
          loaders: {
            sass: [
              {
                loader: "css-loader"
              },
              {
                loader: "sass-loader",
                options: {
                  indentedSyntax: true // Set to true to use indented SASS syntax.
                }
              }
            ]
          }
        }
      },
      // sass rules from vue webpack config
      {
        test: /\.sass$/,
        oneOf: [
          {
            resourceQuery: /\?vue/,
            use: [
              /* config.module.rule('sass').oneOf('vue').use('vue-style-loader') */
              {
                loader: MiniCssExtractPlugin.loader,
                options: {
                  sourceMap: true,
                  shadowMode: false
                }
              },
              /* config.module.rule('sass').oneOf('vue').use('css-loader') */
              {
                loader: "css-loader",
                options: {
                  sourceMap: devMode,
                  importLoaders: 2
                }
              },
              /* config.module.rule('sass').oneOf('vue').use('sass-loader') */
              {
                loader: "sass-loader",
                options: {
                  sourceMap: devMode,
                  indentedSyntax: true
                }
              }
            ]
          }
        ]
      },
      // sass rules from vue webpack config
      {
        test: /\.js$/,
        loader: "babel-loader",
        include: path.join(__dirname, "src")
      },
      {
        test: /\.ts?$/,
        use: "ts-loader",
        exclude: /node_modules/
      },
      {
        test: /\.css$/,
        use: [MiniCssExtractPlugin.loader, "css-loader"]
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
        exclude: /fonts/,
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
      filename: devMode ? "app.css" : "main-[hash].css",
      chunkFilename: devMode ? "[name].css" : "[name]-[hash].css"
    }),
    new HtmlWebpackPlugin({
      template: path.join(__dirname, "src", "index.html"),
      hash: devMode,
      filename: "index.html",
      chunks: ["app"]
    })
    // new CopyWebpackPlugin([
    //   {
    //     from: path.join(__dirname, "src", "assets"),
    //     to: path.join(__dirname, "public", "assets"),
    //     toType: "dir"
    //   }
    // ])
  ]
};
