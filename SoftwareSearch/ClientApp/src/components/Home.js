import React, { Component } from 'react';
import SearchResults from './SearchResults/SearchResults'
import SearchInput from './SearchInput/SearchInput'

export class Home extends Component {

    constructor(props) {
        super(props);
        this.state = { softwareItems: [] };
        this.handleSearchResultsReceived = this.handleSearchResultsReceived.bind(this);
    }

    handleSearchResultsReceived(results) {
        this.setState({ softwareItems: results });
    }

    render() {
        return (
            <div className="section">
                <SearchInput handleSearchResultsReceived={this.handleSearchResultsReceived} />
                <SearchResults softwareItems={this.state.softwareItems} />
            </div>
        );
    }
}
