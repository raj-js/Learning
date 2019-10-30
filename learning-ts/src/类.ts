class Greeter {
    greeting: string

    constructor(msg: string) {
        this.greeting = msg
    }

    greet(): string {
        return `Hello ${this.greeting}`
    }
}

let greeter = new Greeter('Mr.Zhan')

greeter.greet()


