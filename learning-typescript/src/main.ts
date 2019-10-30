import { sayHello } from './greet'

function hello(compiler: string) {
    console.log(`Hello from ${compiler}, ${sayHello(compiler)}`);
}

hello("typescript");