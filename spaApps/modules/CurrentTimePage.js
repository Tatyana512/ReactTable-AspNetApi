import React from 'react'
import Clock from './Clock'

export default React.createClass({
  getInitialState: function() {
    return { date: new Date() };
  },
  componentDidMount: function() {
    this.start();
  },
  start: function() {
    var self = this;
    (function tick() {
      self.setState({ date: new Date() });
      requestAnimationFrame(tick);
    }());
  },
  render: function() {
    return ( <Clock date={this.state.date} />);
  }
})





