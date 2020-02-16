import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Searches } from './components/Search';
import { TopSearch } from './components/TopSearch';
import MediaDetails from './components/MediaDetails';
//import { Login } from './components/Login/login';
import './custom.css'

export default class App extends Component {
    static displayName = App.name;
    render() {
        return (
            <Layout>
                <Route exact path='/' component={Searches} />
                <Route path="/tracks/:id" component={MediaDetails} />
                <Route exact path='/Home' component={Searches} />
                <Route path='/TopSearch' component={TopSearch} />
            </Layout>
           
        );
    }
}
