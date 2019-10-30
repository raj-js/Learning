// 只读属性
interface Point {
    readonly x: number
    readonly y: number
}

let point: Point = { x: 1, y : 2 }

// point.x = 2 error

// readonly vs. const 
// 如果想要声明不可修改的属性 使用 readonly 
// 如果想要声明不可修改的变量(常量) 使用 const 

interface Square {
    color?: string
    width?: number
}

function createSquare(square: Square): {color: string; area: number} {
    let def: Square = { color: 'black', width: 10 }

    if (square.color) 
        def.color = square.color

    if (square.width)
        def.width = square.width

    return { color: def.color, area: Math.pow(def.width, 2) }
}

let square = createSquare({ color: 'red' } as Square)

// square['area']

// 接口可以多继承

// 当接口继承了一个类类型时，它会继承类的成员但不包括其实现。
