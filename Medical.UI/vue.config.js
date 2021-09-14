module.exports = {
  // devServer: {
  //   disableHostCheck: true,
  // },
  chainWebpack: config => {
    config.module.rule('eslint').use('eslint-loader').options({
      fix: true,
    })
 },
  transpileDependencies: ['vuetify'],

  pluginOptions: {
    i18n: {
      locale: 'en',
      fallbackLocale: 'en',
      localeDir: 'locales',
      enableInSFC: false,
    },
 },
}
