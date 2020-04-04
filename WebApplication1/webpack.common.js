
var path = require('path');
var webpack = require('webpack');
const HtmlWebpackPlugin = require('html-webpack-plugin');



module.exports = {
    mode: 'development',
    // Path to the 'primary' script of your project, that references all other built resources

   // entry: './src/index.js', webpack 4 auto defines the entry point by defualt and goes to ./src/index.js
    entry: './src/index.js',
    output: {
        // Output directory and file name
        path: path.resolve(__dirname, 'dist'),
        filename: 'bundle.js'
    },
    plugins: [
        new webpack.ProvidePlugin({
            $: 'jquery',
            jQuery: 'jquery',
            'window.jQuery': 'jquery'
        }),
        new HtmlWebpackPlugin({
            inject: "body",
            filename: "../Views/Shared/_Layout.cshtml",
            template: "./Views/Shared/_Layout_Template.cshtml"
        })
    ],
    module: {
        rules: [
            {
                // This rule exports the files to the dist/assets folder and updates any paths in the css
                test: /\.(png|jpg|jpeg|gif|woff|woff2|ttf|eot|svg)(\?.*)?$/,
                loader: 'file-loader?name=../dist/assets/[name].[ext]'
            },
        ]
    }
};