// 基础类型

// 布尔值
let isDone: boolean = false

// 数字
let len: number = 0

// 字符串 
let str: string = 'str....'

str = `${str} ..1`

// 数组
let array: number[] = [1, 2, 2]
let strArr: string[] = ['str', 'str']

// 泛型数组
let generic: Array<number> = [1, 2, 3]

// 元组
let x: [string, number]
x = ['hello', 2]

// 枚举
enum Color {
    Red,
    Green,
    Yellow
}

let color: Color = Color.Green

// 枚举默认值
enum Status {
    Ready = 0,
    Running = 1,
    Complete = 2
}

let s: Status = Status.Complete

// Any
let something: any
something = 1
something = '123'

// Void
// void 与 any 类型相反, 表示没有任何类型， 
// 常用在函数没有返回值的时候
// 如果声明一个 void 类型的变量， 那么这个变量的值只能为 null 或者 undefined


// null 与 undefined
// 默认情况下 null 与 undefined 是所有类型的子类型， 
// 也就是你完全可以把 null 与 undefined 赋值给 number 类型的变量
// 如果你在某处想要传入一个 string 或者 null 或者 undefined
// 你可以联合使用类型 string | null | undefined

// Never 
// never 类型表示的是那些永不存在值的类型。
// 例如，never 类型是那些总会抛出异常或者根本就不会有返回值
// 的函数表达式函数或箭头函数表达式的返回值类型
// 变量也可能是 never 类型， 当它们 永不为真的类型保护所约束时
// never 类型是任何类型的子类型，， 然而， 没有类型是 never 的
// 的子类型或可以复制给 never 类型， 除了 never 本身， 及时是 any 也不能赋值给 never

function error(msg: string): never {
    throw new Error(msg)
}

function fail() {
    return error('something wrong')
}

function infiniteLoop(): never {
    while (true) { }
}

// Object
// object 表示非原始类型， 
// 也就是除了 number , string , boolean , 
// symbol, null, undefined 之外的类型
declare function create(o: object | null): void;

create({ prop: 0 })
create(null)

// create(42) error
// create('') error
// create(undefined) error

// 类型断言 
let someVal: any = 'this is a string'
let strLen: number = (<string>someVal).length
// 等价于
strLen = (someVal as string).length

