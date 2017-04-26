import React from 'react'
export default class Clock extends React.Component {
    constructor(props) {
        super(props);        
          } 
 
    render() {

            var d = this.props.date;
            var millis = d.getMilliseconds();
            var second = d.getSeconds();
            var minute = d.getMinutes();
            var hour = d.getHours(); 
            if(minute>=0 && minute< 10){
                minute = "0" + minute;
            }
            if (second>=0 && second< 10){
                second = '0' + second;
            }
         return (
       <span>
           <span className='timeCls'> {hour}:{minute}:{second} </span>
       </span>
    ); 
   

     }
  

}