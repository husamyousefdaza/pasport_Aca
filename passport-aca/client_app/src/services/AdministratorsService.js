import axios from 'axios';

export default {

    GetAllAdministrators(page, pagesize) {
        return axios.get(`/Administrator/GetAllAdministrator?page=${page}&pageSize=${pagesize}`)
    },


    GetAllRoles() {
        return axios.get(`/Administrator/GetAllRoles`);
        //   return axios.get(`http://mail:82/api/Role/GetAll`);
    },



    GetAdministrator(id) {
        return axios.get(`/Administrator/GetAdministrator/${id}`)
    },

    AddAdministrator(AdministratorInfo) {
        return axios.post(`/Administrator/AddAdministrator`, AdministratorInfo)
    },

    UpdateAdministrator(AdministratorInfo) {
        return axios.put(`/Administrator/UpdateAdministrator`, AdministratorInfo)
    },

    DeleteAdministrator(id) {
        return axios.put(`/Administrator/DeleteAdministrator/${id}`);
    },

}