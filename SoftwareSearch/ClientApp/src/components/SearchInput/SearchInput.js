import React, { Component } from 'react'
import { getSoftwareWithHigherVersion } from '../../services/SoftwareSearchService'

export default class SearchInput extends Component {
    constructor(props) {
        super(props);
        this.state = { searchTerm: "", errorMsg: "" };
    }

    onSearchTermChange(newSearchTerm) {
        this.setState({ searchTerm: newSearchTerm });
        if (this.validInput(newSearchTerm)) {
            this.setState({ errorMsg: "" });
            getSoftwareWithHigherVersion(newSearchTerm).then((json) => this.props.handleSearchResultsReceived(json)).catch(() =>
                this.setState({ errorMsg: "An error occured while trying to fetch software data from the server." })
            );
        }
        else {
            this.setState({ errorMsg: "Version number invalid. Enter up to 3 numbers separated by periods." });
        }
    }

    validInput(input) {
        let parts = input.split('.');
        parts = parts.filter((itm) => itm !== ""); //allow consecutive dots and/or trailing dots
        let valid = parts.length > 0;

        if (valid) {
            for (let i = 0; i < parts.length; i++) {
                if (isNaN(parts[i]) || !parts[i].trim()) {
                    valid = false;
                    break;
                }
            }
        }

        if (parts.length > 3) {
            valid = false;
        }

        return valid;
    }

    render() {
        return (
            <div>
                <span>Find software with versions greater than: </span>
                <input type="text" value={this.state.searchTerm} onChange={(e) => this.onSearchTermChange(e.target.value)} />
                <div>
                    <strong className="errorText">{this.state.errorMsg}</strong>
                </div>
            </div>
        );
    }
}

