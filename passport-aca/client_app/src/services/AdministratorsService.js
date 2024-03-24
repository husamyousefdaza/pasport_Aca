import axios from 'axios';

export default {

    GetAllAdministrators(page, pagesize) {
       // return axios.get(`/Administrator/GetAllAdministrator?page=${page}&pageSize=${pagesize}`)
        return axios.get(`/api/Administrator/GetAllAdministrator?page=${page}&pageSize=${pagesize}`)
    },


    GetAllAdministrators1() {
       // return axios.get(`/Administrator/GetAllAdministrators`)
        return axios.get(`/api/Administrator/GetAllAdministrators`)
       
    },



    GetAllRoles() {
       // return axios.get(`/Administrator/GetAllRoles`)
        return axios.get(`/api/Administrator/GetAllRoles`);
        //   return axios.get(`http://mail:82/api/Role/GetAll`);
    },



    GetAdministrator(id) {
       // return axios.get(`/Administrator/GetAdministrator/${id}`)
        return axios.get(`/api/Administrator/GetAdministrator/${id}`)
    },

    AddAdministrator(AdministratorInfo) {
        //return axios.post(`/Administrator/AddAdministrator`, AdministratorInfo)
        return axios.post(`/api/Administrator/AddAdministrator`, AdministratorInfo)
    },

    UpdateAdministrator(AdministratorInfo) {
       // return axios.put(`/Administrator/UpdateAdministrator`, AdministratorInfo)
        return axios.put(`/api/Administrator/UpdateAdministrator`, AdministratorInfo)
    },

    DeleteAdministrator(id) {
       // return axios.put(`/Administrator/DeleteAdministrator/${id}`);
        return axios.put(`/api/Administrator/DeleteAdministrator/${id}`);
    },

}