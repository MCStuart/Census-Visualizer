import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import FetchData from './components/FetchData';
import { Counter } from './components/Counter';
import ThreeContainer from './components/ThreeContainer';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './components/NavMenu.css';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <div>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
            <Container>
                <ul className="navbar-nav flex-grow">
                  <NavItem>
                    <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                  </NavItem>
                  <NavItem>
                    <NavLink tag={Link} className="text-dark" to="/counter">Counter</NavLink>
                  </NavItem>
                  <NavItem>
                    <NavLink tag={Link} className="text-dark" to="/fetch-data">Fetch data</NavLink>
                  </NavItem>
                </ul>
            </Container>
          </Navbar>
        <ThreeContainer />
      <Layout>
        <Route exact path='/map' component={ThreeContainer} />
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
      </Layout>
      </div>
    );
  }
}
