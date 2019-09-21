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
                {this.props.date}
                <span dangerouslySetInnerHTML={{__html:this.props.content}}></span>
                <button onClick={ this.handleClick }>Delete</button>
            </li>
        );
    }

    handleClick(e) {
        this.props.onDel(this.props.index)
    }
}

// props 数据校验
TodoItem.propTypes = {
    date: PropTypes.string.isRequired,
    content: PropTypes.string,
    index: PropTypes.number,
    onDel: PropTypes.func
}

// props default
TodoItem.defaultProps = {
    date: new Date().toDateString()
}
 
export default TodoItem;