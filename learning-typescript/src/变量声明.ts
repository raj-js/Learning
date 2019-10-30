// 变量声明

// 在 javascript 中， 
// var 声明的变量可以在包含它的函数，模块, 命名空间或者
// 全局作用域内部任何位置呗访问

// let 声明的变量为块级作用域
// const 声明的是常量

// let vs. const
// 建议：最小特权原则， 除了你计划去修改的变量以外， 都使用 const 来声明

// 解构
// 解构实际上是 es6 中的一种新特性

// 解构数组
let input = [1, 2]

let [one, two] = input

// one = 1, two = 2

// 对象解构
let o = {
    a: 'a',
    b: 12,
    c: 'c'
}

let { a, b } = o

// a = o.a , b = o.b

// 属性重命名 
let { a: aa, b: bb } = o
// aa = o.a , bb = o.b  可以读作 将 a 作为 aa

// 默认值
function keepWholeObject(wholeObject: { a: string, b?: number }): void {
    // 使用解构来赋予默认值
    let { a, b = 1001 } = wholeObject
    // 此时， 如果 wholeObject.b 为 undefined , b 的值也会是 1001
}

// 函数声明

type C = { a: string, b: number }

function f({ a, b }: C) {
    //a , b
}


// 展开
// 展开符号 允许你讲一个数组展开为另外一个数组， 或者讲一个对象展开为另外一个对象

// 展开数组
let first = [1, 2]
let second = [3, 5]
let combine = [0, ...first, ...second]
// combin = [0,1,2,3,5] 浅拷贝

// 展开对象
let defaults = {
    food: 'spicy',
    price: '$$',
    ambiance: 'noisy'
}
let search = {
    ...defaults, food: 'rice'
}

// search = { food: 'rice', price: '$$, ambiance: 'noisy' }

// 这里的 food 会被覆盖， 另外， 展开对象仅包含对象自身可以枚举的属性
// 如果你展开一个对象实例， 你会丢失其方法
class Cc {
    p = 12
    m(): void { }
}

let cc = new Cc()
let clone = { ...cc }
clone.p // ok
// clone.m() error















