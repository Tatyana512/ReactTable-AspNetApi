import React from 'react'
import { render } from 'react-dom'
import { Router, Route, hashHistory } from 'react-router'
import App from './modules/App'
import TablePage from './modules/TablePage'
import CurrentTimePage from './modules/CurrentTimePage'

render((
  <Router history={hashHistory}>
    <Route path="/" component={App}/>
    <Route path="/tablepage" component={TablePage}/>
    <Route path="/currenttimepage" component={CurrentTimePage}/>
  </Router>
), document.getElementById('app'))
