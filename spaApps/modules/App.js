import React from 'react'
import { Link } from 'react-router'
// import store from './../store/configStore'

export default React.createClass({
  render() {
    return (
      <div>
        <h1>Тестовое приложение</h1>
        <ul role="nav">
          <li><Link to="/tablepage">Таблица</Link></li>
          <li><Link to="/currenttimepage">Текущее время</Link></li>
        </ul>
      </div>
    )
  }
})