import React from 'react'
import ReactDOM from 'react-dom';
import {connect} from 'react-redux'
import ReactTable from 'react-table'
import PopUp from './PopUp'
import helper from './../helper'

class TablePage extends React.Component {
    constructor(props) {
        super(props);   
         this.state={
            popupVisible: false,
            chooseItem: null,
            loadData: false
         }   
           this.closeWnd = this.closeWnd.bind(this);
           this.Load = this.Load.bind(this)
          } 
   closeWnd(){     
      this.setState({
         popupVisible: false,
         chooseItem: null        
      })
     this.Load();
  }     


  Load(){   
     helper.loadDataByUrl('http://localhost:2747/api/v1/items/'+ 'getItems').then((response)=>{
        if(response){          
          this.data = response;
          this.setState({
            loadData: true
          })
        }
     })
  
   }
   componentWillMount(){
        this.Load();
   }
 
    render() {
            let _currentStatePopup = "popUp__not__active";
             if(this.state.popupVisible !== false){
                    _currentStatePopup = "popUp__active"
             }                     
                      
                var columns = [
                 {
                   header: 'Id',
                   accessor: 'Id'
                 },   
                {
                  header: 'Название',
                  accessor: 'Name'
                }, {
                  header: 'Сумма',
                  accessor: 'Count'         
                }, 
                {
                  header: 'Дата',
                  accessor: 'DateTime'           
                }];
        return  (<div><ReactTable
                data={this.data}
                columns={columns}
                getTdProps={(state, rowInfo, column, instance) => {
                return {
                  onClick: e => {
                           if(rowInfo){
                              let _row = rowInfo.row;                    
                              this.setState({
                                popupVisible: true,
                                chooseItem: _row
                              })         
                     }else{
                         this.setState({
                            popupVisible: true,
                             chooseItem: null
                         })   
                     }               
                  }
                }
              }} 
        /> <PopUp active={_currentStatePopup}  chooseItem={this.state.chooseItem} closeWnd={this.closeWnd} loadItems={this.load} /></div>);
  }
}

export default TablePage




