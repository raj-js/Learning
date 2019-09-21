import React, { Component, Fragment } from 'react'
import SubCmpt from './SubCmpt'

class Lifecycle extends Component {
    constructor(props) {
        super(props);
        this.state = {  
            value: 0
        }
    }

    componentWillMount() {
        console.log(`${new Date().valueOf()} component will mount`)
    }

    componentDidMount() {
        console.log(`${new Date().valueOf()} component did mount`)
    }

    shouldComponentUpdate() {
        console.log(`${new Date().valueOf()} should component update`)

        return true
    }

    componentWillUpdate() {
        console.log(`${new Date().valueOf()} component will update`)
    }

    componentDidUpdate() {
        console.log(`${new Date().valueOf()} component did mount`)
    }

    componentWillUnmount() {
        console.log(`${new Date().valueOf()} component will unmount`)
    }

    render() { 
        console.log(`${new Date().valueOf()} render`)

        return (
            <Fragment>
                <SubCmpt value={ this.state.value } />
                <button onClick={ this.increment.bind(this) }>increment</button>
            </Fragment>
        );
    }

    increment() {
        this.setState({
            value: this.state.value + 1
        })
    }
}
 
export default Lifecycle