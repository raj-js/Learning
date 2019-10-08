import React, { Component, Fragment } from 'react'
import './style.css'
import TodoItem from './TodoItem'
import axios from 'axios'

class Todo extends Component {
    constructor(props) {
        super(props)

        this.state = {
            todo: '',
            todos: []
        }
    }

    componentDidMount() {
        axios.get('https://easy-mock.com/mock/5d86417179393a29a5046ad0/todos/')
            .then(resp => {
                this.setState({
                    todos: resp.data
                })
            })
            .catch(console.error)
    }

    render() {
        return (
            <Fragment>
                {/* 注释: className, htmlFor, dangerouslySetInnerHTML, 多行注释 */}
                <label htmlFor='todoInput'>Input Todo: </label>
                <input
                    id='todoInput'
                    className='input'
                    value={this.state.todo.content}
                    onChange={this.setTodo.bind(this)}
                    ref={input => this.input = input}
                />
                <button onClick={this.addTodo.bind(this)}>Add</button>

                <ul>
                    {
                        this.state.todos.map((v, i, s) => {
                            return (
                                <TodoItem key={v.id} todo={v} onDel={this.delTodo.bind(this)} />
                            )
                        })
                    }
                </ul>
            </Fragment>
        )
    }

    setTodo(e) {
        this.setState({
            todo: this.input.value
        }, () => {
            console.log('set state callback')
        })
    }

    addTodo(e) {
        let todo = {
            id: new Date().valueOf(),
            content: this.state.todo,
            date: new Date().toString(),
            state: 0,
        }
        this.setState({
            todos: [...this.state.todos, todo]
        })
        this.input.value = ''
    }

    delTodo(id) {
        let todos = this.state.todos
        todos = todos.filter((v, i, s) => v.id !== id)

        this.setState({
            todos: todos
        })
    }
}

export default Todo
