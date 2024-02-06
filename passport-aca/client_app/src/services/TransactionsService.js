import axios from 'axios';

export default {

    AddTransaction(transactionInfo) {
        return axios.post(`/Transaction/AddTransaction`, transactionInfo)
    },

    UpdateTransaction(transactionInfo) {
        return axios.put(`/Transaction/UpdateTransaction`, transactionInfo)
    },

    GetAllTransactions(page, pagesize) {
        return axios.get(`/Transaction/GetAllTransactions?page=${page}&pageSize=${pagesize}`)
    },

    GetTransaction(id) {
        return axios.get(`/Transaction/GetTransaction/${id}`)
    },

    DeleteTransaction(id) {
        return axios.delete(`/Transaction/DeleteTransaction/${id}`);
    },


    GetUsersReport() {
        return axios.get(`/Transaction/UsersReport`)
    },


    ayoub(search) {
        return axios.get('/Transaction/Search',  { params: { search } } )
    },

}