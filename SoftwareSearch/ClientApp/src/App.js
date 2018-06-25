import React, { Component } from 'react';
import { Route, BrowserRouter } from 'react-router-dom'
import { Layout } from './components/Layout';
import { Home } from './components/Home';

export default class App extends Component {

    render() {
        return (
            <Layout>
                <BrowserRouter>
                    <Route exact path='/' component={Home} />
                </BrowserRouter>
            </Layout>
        );
    }
}
