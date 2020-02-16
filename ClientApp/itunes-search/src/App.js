import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Router,Route } from 'react-router-dom';
import { Searches } from './components/Search';
import MediaDetails from './components/MediaDetails';
import { history } from './components/Auth/Helpers/history';
import { alertActions } from './components/Auth/alertActions';
import { PrivateRoute } from './components/PrivateRoute';
import { LoginPage } from './components/Auth/login';
import { RegisterPage } from './components/Auth/register';
import {TopSearch} from './components/TopSearch';

import './custom.css'

class App extends Component {
    constructor(props) {
        super(props);

        const { dispatch } = this.props;
        history.listen((location, action) => {
            // clear alert on location change
            dispatch(alertActions.clear());
        });
    }
    static displayName = App.name;
    render() {
        const { alert } = this.props;
        return (
            <div className="jumbotron">
                <div className="container">
                    <div className="col-sm-8 col-sm-offset-2">
                        {alert.message &&
                            <div className={`alert ${alert.type}`}>{alert.message}</div>
                        }
                        <Router history={history}>
                                <Route path="/login" component={LoginPage} />
                                <Route path="/register" component={RegisterPage} />
                                <PrivateRoute exact path="/search" component={Searches} />
                                <Route exact path="/" component={Searches} />
                                <Route path='/TopSearch' component={TopSearch} />
                                <Route path="/tracks/:id" component={MediaDetails} />
                        </Router>
                    </div>
                </div>
            </div>
            // <Layout>
            //     <Route exact path='/' component={Searches} />
            //     <Route path="/tracks/:id" component={MediaDetails} />
            //     <Route path='/TopSearch' component={TopSearch} />
            // </Layout>
           
        );
    }
}
function mapStateToProps(state) {
    const { alert } = state;
    return {
        alert,
    };
}

const connectedApp = connect(mapStateToProps)(App);
export { connectedApp as App }; 
