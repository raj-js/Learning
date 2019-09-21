import React, { Component } from 'react'

class SubCmpt extends Component {

    componentWillReceiveProps() {
        console.log(`${new Date().valueOf()} component will receive props ${ this.props.value }`)
    }

    shouldComponentUpdate(nextProps, nextState) {
        return nextProps.value !== this.props.value
    }

    render() { 
        return (  
            <h1> { this.props.value } </h1>
        );
    }
}
 
export default SubCmpt