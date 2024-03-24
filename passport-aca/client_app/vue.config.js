module.exports = {
    outputDir: "../wwwroot/",
    //filenameHashing: false,
    devServer: {
        port: 8080,
        https: false,
        proxy: {
            "": {
             //   target: 'http://localhost:58956/',
            }
        }
    }
}