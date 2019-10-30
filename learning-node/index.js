function funA() {
    console.log('funA')
}

async function fun() {
    let resp = 0

    for (let i = 0; i < 3; i++ ) {
        console.log(`loop ${i}`)

        resp = await new Promise((resolve, reject) => {
            setTimeout(() => {
                resolve(`good ${i}`)
            }, i * 1000)
        })

        console.log(`resp -> ${resp}`)
    }

    return resp
}

fun().then(v => {
    console.log(v)
})

console.log('end')

