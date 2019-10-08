import { INPUT_CHANGE, ADD_TODO, DELETE_TODO } from "./actionTypes"

export const inputChangeAction = value => ({
    type: INPUT_CHANGE,
    value: value
})

export const addTodoAction = todo => ({
    type: ADD_TODO,
    value: todo
})

export const deleteTodoAction = index => ({
    type: DELETE_TODO,
    value: index
})