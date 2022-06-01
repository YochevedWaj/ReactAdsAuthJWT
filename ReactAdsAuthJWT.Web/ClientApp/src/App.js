import React, { Component } from 'react';
import { Route } from 'react-router';
import { AuthContextComponent } from './AuthContext';
import Layout from './Components/Layout';
import PrivateRoute from './Components/PrivateRoute';
import Home from './Pages/Home';
import Login from './Pages/Login';
import Signup from './Pages/Signup';
import Logout from './Pages/Logout';
import NewAd from './Pages/NewAd';
import MyAccount from './Pages/MyAccount';


export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <AuthContextComponent>
                <Layout>
                    <Route exact path='/' component={Home} />
                    <Route exact path='/signup' component={Signup} />
                    <Route exact path='/login' component={Login} />
                    <PrivateRoute exact path='/logout' component={Logout} />
                    <PrivateRoute exact path='/newad' component={NewAd} />
                    <PrivateRoute exact path='/myaccount' component={MyAccount} />
                </Layout>
            </AuthContextComponent>
        );
    }
}