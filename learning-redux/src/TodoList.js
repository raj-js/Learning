import React, { Component } from 'react'
import 'antd/dist/antd.css'
import { Row, Col, Input, Button, List } from "antd"

import { inputChangeAction, addTodoAction, deleteTodoAction } from "./store/actionCreators"
import store from './store'

class TodoList extends Component {

    constructor(props) {
        super(props)

        this.state = store.getState()

        this.inputChange = this.inputChange.bind(this)
        this.storeChange = this.storeChange.bind(this)
        this.addTodo = this.addTodo.bind(this)

        store.subscribe(this.storeChange)
    }

    render() {
        return (
            <div>
                <Row type="flex" justify="center" align="top">
                    <Col span={10}>
                        <Input
                            placeholder={this.state.todo}
                            onChange={this.inputChange}
                            value={this.state.todo}
                        />
                    </Col>
                    <Col span={2}>
                        <Button
                            style={{ float: "right" }}
                            onClick={this.addTodo}
                        >Add</Button>
                    </Col>
                </Row>
                <br></br>
                <Row type="flex" justify="center" align="top">
                    <Col span={12}>
                        <List
                            size="small"
                            header={<div>Todos</div>}
                            bordered
                            dataSource={this.state.todos}
                            renderItem={(item, index) => (
                                <List.Item onClick={this.deleteTodo.bind(this, index)}>{item}</List.Item>
                            )}
                        />
                    </Col>
                </Row>
            </div>
        )
    }

    inputChange(e) {
        store.dispatch(inputChangeAction(e.target.value))
    }

    storeChange() {
        this.setState(store.getState())
    }

    addTodo() {
        store.dispatch(addTodoAction(this.state.todo))
    }

    deleteTodo(index) {
        store.dispatch(deleteTodoAction(index))
    }
}

export default TodoList