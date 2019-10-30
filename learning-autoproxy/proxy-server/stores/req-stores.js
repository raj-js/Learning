const redis = require('redis')
const options = require('../configs/redis-options')

const store = null;

function initialize() {
    if (store == null || !store.connected) {
        store = redis.createClient(options.PORT, options.HOST,)

    }
}

module.exports = {
    save(req) {
        initialize()
    }
}