import { INPUT_CHANGE, ADD_TODO, DELETE_TODO } from "./actionTypes"

const defaultState = {
    todo: 'todo...',
    todos: [
        'Racing car sprays burning fuel into crowd.',
        'Japanese princess to wed commoner.',
        'Australian walks 100km after outback crash.',
        'Man charged over missing wedding girl.',
        'Los Angeles battles huge wildfires.',
    ]
}

export default (state = defaultState, action) => {
    // reducer 只能接受 state, 不能修改 state
    let newState = JSON.parse(JSON.stringify(state))

    switch (action.type) {
        case INPUT_CHANGE:
            newState.todo = action.value
            break
        case ADD_TODO:
            newState.todo = ''
            newState.todos = [...newState.todos, action.value]
            break
        case DELETE_TODO:
            newState.todos.splice(action.value, 1)
            break
        default:
            break
    }

    return newState
}