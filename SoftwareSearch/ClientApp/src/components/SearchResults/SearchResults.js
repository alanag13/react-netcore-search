import React, { Component } from "react"

export default class SearchResults extends Component {

    renderSoftwareItem(item, i) {
        return (
            <tr key={i}>
                <td>{item.name}</td>
                <td>{item.version}</td>
            </tr>);
    }

    render() {
        return (
            <div>
                <div>
                    <span>Found {this.props.softwareItems.length} results.</span>
                </div>
                <table>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Version</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.props.softwareItems.map((item, i) => this.renderSoftwareItem(item, i))}
                    </tbody>
                </table>
            </div>
        );
    }
}