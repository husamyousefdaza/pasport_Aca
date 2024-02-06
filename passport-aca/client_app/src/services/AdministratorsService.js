import axios from 'axios';

export default {

    GetAllAdministrators(page, pagesize) {
        return axios.get(`/Administrator/GetAllAdministrator?page=${page}&pageSize=${pagesize}`)
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