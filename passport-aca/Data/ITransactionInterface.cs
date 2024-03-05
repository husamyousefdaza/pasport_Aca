using passport_aca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passport_aca.Data
{
    public interface ITransactionInterface
    {
        Task<MassageInfo> AddTransaction(TransactionInfo transactionInfo);

        Task<PageingDtocs> search(int pageNumber, int pageSize, DateTime? date_from, DateTime? date_to, int? trnsacton_number, string? passport_status, string? classification, string? full_name, string? from_who, bool? picture_date , int? finacial_recipt_number, long? nationality_number, string? resevedName, bool? delivery_date);


        Task<TransactionInfoDto> GetTransaction(int id);

        Task<MassageInfo> UpdateTransaction(TransactionInfo transaction);

        Task<MassageInfo> DeleteTransaction(int id);

        Task<List<TransactionInfo>> GetAlltransactions();

        Task<List<reports>> UsersReport();

        Task<Numbers_Of_Reports> Numbers_Of_Reports();
      

        Task<List<TransactionViewModel>> GetLastFive();

        Task<PageingDtocs> GetAll(int pageNumber, int pageSize);
        Task<ReportDto> UsersReport(int page,int pageSiz);
    }
}
