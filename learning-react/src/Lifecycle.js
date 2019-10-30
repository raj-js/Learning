import React, { Component, Fragment } from 'react'
import SubCmpt from './SubCmpt'


class Lifecycle extends Component {
    constructor(props) {
        super(props);
        this.state = {
            value: 0
        }
    }

    componentDidMount() {

    }

    render() {
        console.log(`${new Date().valueOf()} render`)

        return (
            <Fragment>
                <SubCmpt value={this.state.value} />
                <button onClick={this.increment.bind(this)}>increment</button>
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