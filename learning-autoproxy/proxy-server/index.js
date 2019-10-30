const anyproxy = require('anyproxy')
const exec = require('child_process').exec

if (!AnyProxy.utils.certMgr.ifRootCAFileExists()) {
    AnyProxy.utils.certMgr.generateRootCA((error, keyPath) => {
        // let users to trust this CA before using proxy
        if (!error) {
            const certDir = require('path').dirname(keyPath);
            console.log('The cert is generated at', certDir);
            const isWin = /^win/.test(process.platform);
            if (isWin) {
                exec('start .', { cwd: certDir });
            } else {
                exec('open .', { cwd: certDir });
            }
        } else {
            console.error('error when generating rootCA', error);
        }
    });
}

const proxyServer = new anyproxy.ProxyServer({
    port: 8001,
    rule: require('./rule'),
    webInterface: {
        enable: true,
        webPort: 8002,
        wsPort: 8003
    },
    throttle: 10000,
    forceProxyHttps: true,
    silent: false
})

proxyServer.on('error', error => {
    console.error(`anyproxy server error: ${error}`)
})

proxyServer.start()










