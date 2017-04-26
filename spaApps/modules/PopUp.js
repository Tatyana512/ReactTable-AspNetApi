import React, {Component} from "react"
import {connect} from 'react-redux'
import helper from './../helper'

class PopUp extends Component {
     constructor(props) {
        super(props)
        this.state = {
           active: false,           
           id: null,
           name: null,
           count: null,
           datetime: null 
        }
        this.handleInputChange = this.handleInputChange.bind(this);
        this.Create = this.Create.bind(this);
        this.Edit = this.Edit.bind(this);
        this.Delete = this.Delete.bind(this);
        
     } 

      handleInputChange(event) {
                const target = event.target;
                const value = target.value;
                const name = target.name;                
                this.setState({
                     [name]: value
                });
      }
      componentWillReceiveProps(nextProps){
        if(nextProps.chooseItem){            
          this.setState({             
                id: nextProps.chooseItem.Id,
                name: nextProps.chooseItem.Name,
                count: nextProps.chooseItem.Count,
                datetime: nextProps.chooseItem.DateTime 
          })
        }else{
              this.setState({             
                id: '',
                name: '',
                count: '',
                datetime: ''
          })
        }              
      }

    Create(){
      var _name, _count, _date;
      if(this.state.name == null ||
         this.state.count == null || 
         this.state.datetime == null) {
         console.log('пустые значения сохранять нельзя. проверьте поля для заполнения');
      }            

      helper.loadDataByUrl('http://localhost:2747/api/v1/items/'+ 'createItem?name='+this.state.name+'&count='+this.state.count+'&date='+this.state.datetime).then((response)=>{
        if(response){
           console.log('запись сохранена')  
        }
     })
   }
   
   Edit(){
       helper.loadDataByUrl('http://localhost:2747/api/v1/items/'+ 'updateItem?id='+this.state.id + '&name='+this.state.name + '&count='+this.state.count + '&date='+ this.state.datetime).then((response)=>{
        if(response){            
            console.log('запись отредактирована');    
        }
     })
   }
   Delete(){
       helper.loadDataByUrl('http://localhost:2747/api/v1/items/'+ 'deleteItem?id='+this.state.id).then((response)=>{
        if(response){
            console.log('запись удалена');
        }
     })
   }


   render(){
    let _id = this.state.id;
    let _name=  this.state.name;
    let _sum = this.state.count;
    let _date =  this.state.datetime;
 

    return( <div className={this.props.active}> 
                   
            <div className="popupTitle"><span> Выберите действие:  </span><span onClick={this.props.closeWnd} className='clsPopupBtn'> X </span> </div>
            <div className="popupform">
               <div> <span className="fldRow"> Id </span> <span>  <input type='text' value={_id} name='id' onChange={this.handleInputChange}  /> </span> </div>
               <div> <span className="fldRow"> Наименование </span> <span> <input type='text' value={_name} name='name' onChange={this.handleInputChange}  /> </span></div>
               <div> <span className="fldRow"> Количество </span> <span><input type='text' value={_sum} name='count' onChange={this.handleInputChange}  /> </span> </div>
               <div> <span className="fldRow"> Дата </span> <span ><input type='text' value={_date} name='datetime'  onChange={this.handleInputChange}  /> </span></div>
               <div className="btnfields">
               <div> <button onClick={this.Create} className="btn btncreate"> Создать новую запись </button> </div>           
               <div> <button onClick={this.Edit} className="btn btnedit"> Редактировать </button></div>
               <div> <button onClick={this.Delete} className="btn btndelete"> Удалить </button> </div>
               </div>
            </div>    
      </div>)    
   }
}

export default PopUp