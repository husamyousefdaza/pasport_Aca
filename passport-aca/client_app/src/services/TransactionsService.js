import axios from 'axios';

export default {


    Search(date_from,date_to,trnsacton_number, measureNameSelected,classification,pass_name,from_who,pic_date,finacial_recipt_number,national_number,rec_name,rec_date ){

        return axios.get(`/Transaction/Search?date_from=${date_from}&&date_to=${date_to}&&trnsacton_number=${trnsacton_number}&&passport_status=${measureNameSelected}&&classification=${classification}&&full_name=${pass_name}&&from_who=${from_who}&&picture_date=${pic_date}&&finacial_recipt_number=${finacial_recipt_number}&&nationality_number=${national_number}&&resevedName=${rec_name}&&delivery_date=${rec_date}`)
    },

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