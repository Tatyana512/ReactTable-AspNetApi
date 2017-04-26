import React from 'react'
import ReactDOM from 'react-dom';
import ReactTable from 'react-table'


export default class TablePage extends React.Component {
    constructor(props) {
        super(props);        
          } 
 
    render() {
                var data = [{
                  name: 'Example One',
                  sum: 26,
                  date: '2016-01-01 15:00:00'
                  }];
              
                var columns = [{
                  header: 'Название',
                  accessor: 'name'
                }, {
                  header: 'Сумма',
                  accessor: 'sum'         
                }, 
                {
                  header: 'Дата',
                  accessor: 'date'           
                }];
        return  <ReactTable
                data={data}
                columns={columns}
                getTdProps={(state, rowInfo, column, instance) => {
                return {
                  onClick: e => {
                    console.log('It was in this row:', rowInfo.rowValues)
                   
                  }
                }
  }} 

      />;
  }
}



