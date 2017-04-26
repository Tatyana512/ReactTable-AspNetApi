    
    
class Helper {  
    loadDataByUrl(url, withoutCredentials, type) {
        let self = this;
        return new Promise((resolve, regect) => {
            let xhr = new XMLHttpRequest();
            if (!withoutCredentials) {
                xhr.withCredentials = true;
            }
            xhr.onload = xhr.onError = function () {
                if (this.status == 200) {
                    let _response = JSON.parse(xhr.responseText);
                    resolve(_response)
                }
               // self.checkAccessError(this.status);
            };
            xhr.open(type ? type : "GET", url, true);
           // xhr.setRequestHeader('token1', this.getCookie('token'));
            xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
            xhr.send();
        })
    }
}

const helper = new Helper();

export default helper