import React, {Component,Fragment} from 'react'
import './style.css'
import TodoItem from './TodoItem';

class Todo extends Component {
    constructor(props) {
        super(props)

        this.state = {
            todo: '',
            todos: [
                'Learning React'
            ]
        }
    }

    render () {
        return (
            <Fragment>
                {/* 注释: className, htmlFor, dangerouslySetInnerHTML, 多行注释 */}
                <label htmlFor='todoInput'>Input Todo: </label>
                <input 
                    id='todoInput' 
                    className='input' 
                    value={ this.state.todo } 
                    onChange={ this.setTodo.bind(this) } 
                    ref={ input=>this.input=input } 
                />
                <button onClick={ this.addTodo.bind(this) }>Add</button> 

                <ul>
                    {
                        this.state.todos.map((v,i,s) => {
                            return (
                                <TodoItem key={i} index={i} content={v} onDel={ this.delTodo.bind(this) } />
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
        }, ()=> {
            console.log('set state callback')
        })
    }

    addTodo(e) {
        this.setState({
            todos: [...this.state.todos, this.state.todo]
        })
    }

    delTodo(i) {
        let todos = this.state.todos
        todos.splice(i, 1)

        this.setState({
            todos: todos
        })
    }
}

export default Todo
