module.exports = {
    summary: 'toutiao',
    *beforeSendRequest(req) {
        console.log(JSON.stringify(req));
        console.log('rule applyed -> beforeSendRequest')
    },
    *beforeSendResponse(req, resp) {
        console.log('rule applyed -> beforeSendResponse')
    }
}