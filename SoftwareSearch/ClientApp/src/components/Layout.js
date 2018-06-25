import React, { Component } from 'react';


export class Layout extends Component {

    render() {
        return (
            <div className="main">
                <h1>Software Search</h1>
                {this.props.children}
            </div>
        );
    }
}
