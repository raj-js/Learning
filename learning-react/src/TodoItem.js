import React, { Component } from 'react'
import PropTypes from 'prop-types'

class TodoItem extends Component {
    constructor(props) {
        super(props)

        this.handleClick = this.handleClick.bind(this)
    }

    render() {
        return (
            <li>
                {this.props.todo.date}
                <span dangerouslySetInnerHTML={{ __html: this.props.todo.content }}></span>
                {this.props.todo.state}
                <button onClick={this.handleClick}>Delete</button>
            </li>
        );
    }

    handleClick(e) {
        this.props.onDel(this.props.todo.id)
    }
}

// props 数据校验
TodoItem.propTypes = {
    todo: PropTypes.object,
    onDel: PropTypes.func
}

export default TodoItem;