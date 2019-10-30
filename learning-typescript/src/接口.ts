function printLabel(labelledObj: { label: string }): void {
    console.log(labelledObj.label)
}

// 因为 myObj 拥有 label 属性，且类型一致， 所以 printLabel 可以接受此参数
let myObj = { size: 10, label: 'Size 10 Object' }
printLabel(myObj)

// 可选属性
interface SquareConfig {
    color?: string
    width?: number
}

function createSquare(config: SquareConfig): { color: string, area: number } {
    let newSquare = { color: 'white', area: 100 }

    if (config.color) {
        newSquare.color = config.color
    }

    if (config.width) {
        newSquare.area = Math.pow(config.width, 2)
    }

    return newSquare
}

let mySquare = createSquare({ color: 'black' })


// 只读属性
interface Point {
    readonly x: number
    readonly y: number
}

let point: Point = { x: 1, y: 2 }
// point.x = 1 readonly
// point.y = 3 readonly


// 只读泛型数组

let arr: Array<number> = [1, 2, 3]
let rdArray: ReadonlyArray<number> = arr

console.log(rdArray[0])

arr.push(0)
arr[0] = 1

console.log(rdArray[0])
// rdArray.push() 不存在此方法
// rdArray[0]  = 1 error

// 函数类型

interface IApiService {
    Search(source: string): boolean
    Single(id: string): Object
}

let myApi: IApiService

class ApiService implements IApiService {
    Search(source: string): boolean {
        return false
    }

    Single(id: string): Object {
        return {}
    }
}

let apiService: IApiService = new ApiService()
apiService.Search('123')







