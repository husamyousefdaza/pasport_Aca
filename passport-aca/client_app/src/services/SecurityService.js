import axios from 'axios';

export default {
    //-------------------   Security -------------------//
    LoginFun(login) {
       // return axios.post('/Auth/LoginUser', login);
        return axios.post('/api/Auth/LoginUser', login);
    },

    Logout() {
       // return axios.delete('/Auth/Logout');
        return axios.delete('/api/Auth/Logout');
    },

    CheckLogin() {
        //return axios.get('/Auth/CheckLogin');
        return axios.get('/api/Auth/CheckLogin');
    },

}