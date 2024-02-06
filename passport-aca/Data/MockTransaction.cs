using AutoMapper;
using Microsoft.EntityFrameworkCore;
using passport_aca.Model;
using Passpport_Raqaba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace passport_aca.Data
{
    public class MockTransaction : ITransactionInterface
    {
        public SearchModel result;
        public MockTransaction(AppDbCont data ) {

            _data = data;
            result = new SearchModel() ;
        }

        public AppDbCont _data {get; } ///ملاحظة

        
        public async Task<MassageInfo> AddTransaction(TransactionInfo transactionInfo)
        {
            DateTime date = transactionInfo.delivery_date.Date;
            MassageInfo massageInfo = new MassageInfo();
            try {

                TransactionInfo transaction_fullName = new TransactionInfo();
                TransactionInfo transaction_passport = new TransactionInfo();

               transaction_fullName = _data.transactions.FirstOrDefault(x => x.full_name == transactionInfo.full_name );
               transaction_passport = _data.transactions.FirstOrDefault(x => x.passport_number == transactionInfo.passport_number);

                if (transaction_fullName == null && transaction_passport == null)
                {
                    transactionInfo.create_at = DateTime.Now;
                    transactionInfo.update_at = DateTime.Now; 
                    transactionInfo.delivery_date = date;
                    transactionInfo.state = true;
                    await _data.transactions.AddAsync(transactionInfo);
                    massageInfo.Massage = " تمت عملية الاضافة بنجاح";
                    massageInfo.statuscode = 201;
                    await _data.SaveChangesAsync();
                    return massageInfo;
                }
                else if (transaction_fullName == null && transaction_passport != null)
                {
                    massageInfo.Massage = "  رقم الجواز موجود مسبقاً ..لم تنجح عملية الإضافة";
                    massageInfo.statuscode = 406;
                    return massageInfo;

                }
                else if (transaction_fullName != null && transaction_passport == null)
                {

                    massageInfo.Massage = "  اسم المستخدم تم تكراره ..لم تنجح عملية الإضافة";
                    massageInfo.statuscode = 406;
                    return massageInfo;

                }
                else {

                    massageInfo.Massage = "  اسم المستخدم و رقم الجواز تم تكراره ..لم تنجح عملية الإضافة";
                    massageInfo.statuscode = 406;
                    return massageInfo;

                }
        

            } catch(Exception ) {
                //massageInfo.statuscode = 400;
                //massageInfo.Massage = "خطأ في المدخلات";

                //return massageInfo;

                throw;
            }
        }

        public async Task<Numbers_Of_Reports> Numbers_Of_Reports()
        {
            try
            {
                Numbers_Of_Reports count_of = new Numbers_Of_Reports();
                
                List<TransactionInfo> transactions = await _data.transactions.ToListAsync();

                List<TransactionInfo> transaction1 = (List<TransactionInfo>)(from tr in transactions
                                                                             where tr.passport_status == "موقوف"
                                                                             select tr).ToList();

                List<TransactionInfo> Count = await _data.transactions.ToListAsync();


                List<TransactionInfo> transaction2 = (List<TransactionInfo>)(from tr in transactions
                                                                             where tr.passport_status == "جاهز"
                                                                             select tr).ToList();

                 count_of.Count_Of_received= transaction2.Count();

                count_of.Count_Of_all_transaction = Count.Count();

                count_of.Count_Of_booking = transaction1.Count();




                return count_of; 
            }
            catch (Exception)
            {

                throw;
            }
     }

        public async Task<MassageInfo> DeleteTransaction(int id)
        {
            try
            {
                MassageInfo massageInfo = new MassageInfo();
                TransactionInfo transaction = await _data.transactions.FindAsync(id);

                if (transaction != null)
                {

                    _data.transactions.Remove(transaction);
                    await _data.SaveChangesAsync();

                    massageInfo.Massage = " تمت عملية المسح";
                    massageInfo.statuscode = 200;

                    return massageInfo;
                }
                else {

                   massageInfo.Massage = " هذا المستخدم غير موجود ";
                    massageInfo.statuscode = 404;

                    return massageInfo;

                }
            }
            catch (Exception)
            {
               
                throw;
            }
        }

        public async Task<List<TransactionInfo>> GetAlltransactions()
        {
            try
            {
                TransactionInfo tr = new TransactionInfo(); 
                List<TransactionInfo> transaction = await _data.transactions.ToListAsync();
                List<TransactionInfo> e = new List<TransactionInfo>();

                foreach (var item in transaction)
                {
                    tr = item;
                    tr.delivery_date = item.delivery_date.Date;
                    e.Add(tr);
                }

                return e;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SearchModel> search(string id)
        {
            try
            {
                if (id != "")
                {
                    List<TransactionInfo> transactions = await _data.transactions.ToListAsync();
                    List<Dto> all = new List<Dto>();
                    foreach (var item in transactions)
                    {
                        all.Add(new Dto
                        {
                            finacial_recipt_number = item.finacial_recipt_number.ToString(),
                            full_name = item.full_name,
                            id = item.id,
                            passport_number = item.passport_number,
                            transaction_number = item.transaction_number.ToString(),
                            UserId = item.UserId
                        });
                    }




                    Regex s = new Regex(@"[0-9]");

                    string intergers = "";
                    string text = "";
                    var h = id.ToCharArray();
                    string d;

                    for (int i = 0; i < h.Length; i++)
                    {
                        if (s.IsMatch(h[i].ToString()))
                        {
                            intergers = intergers + h[i];
                        }
                        else
                        {
                            text = text + h[i].ToString();
                        }
                    }

                    if (!String.IsNullOrEmpty(intergers))
                    {
                        d = intergers;
                        result.transaction_number = (List<Dto>)(from transaction in all
                                                                where transaction.transaction_number.Contains(intergers)
                                                                select transaction).ToList();


                  



                        result.finacial_recipt_number = (List<Dto>)(from transaction in all
                                                                where transaction.finacial_recipt_number.Contains(intergers)
                                                                select transaction).ToList();

                       }

                        if (!String.IsNullOrEmpty(text))
                        {
                            result.full_name = (List<Dto>)(from transaction in all
                                                           where transaction.full_name.Contains(text)
                                                           select transaction).ToList();

                            result.passport_number = (List<Dto>)(from transaction in all
                                                                 where transaction.passport_number.Contains(text)
                                                                 select transaction).ToList();


                        }

                     

                        if (result.passport_number.Count > 0 || result.transaction_number.Count > 0 || result.full_name.Count > 0 || result.finacial_recipt_number.Count > 0)
                        {

                            result.Massage = "تم العثور علي نتائج لبحثك";
                            result.statuscode = 200;
                            return result;

                        }
                        else
                        {
                            result.Massage = "لم يتم العثور علي نتائج لبحثك";
                            result.statuscode = 404;
                            return result;
                        }
                    }
                    else
                    {

                        result.Massage = "الرجاء ادخال بيان للبحث عنه ";
                        result.statuscode = 204;
                        return result;
                    }
                   
                
              
            }


            catch (Exception)
            {
                throw;
            }   
        }

        public async Task<MassageInfo> UpdateTransaction(TransactionInfo transaction)
        {
            try
            {
                MassageInfo massageInfo = new MassageInfo();

                TransactionInfo transaction_update = await _data.transactions.FindAsync(transaction.id);
                TransactionInfo transaction_u = await _data.transactions.FirstOrDefaultAsync(x =>( x.full_name == transaction.full_name ||   x.passport_number == transaction.passport_number) && x.id != transaction.id);

             //   TransactionInfo transaction_u = await _data.transactions.FirstOrDefaultAsync(x => x.full_name == transaction.full_name || x.passport_number == transaction.passport_number);


                if (transaction_update != null)
                {
                    if (transaction_u == null)
                    {
                        transaction_update.full_name = transaction.full_name;
                        transaction_update.passport_number = transaction.passport_number;


                        transaction_update.recipients_name = transaction.recipients_name;



                        transaction_update.finacial_recipt_number = transaction.finacial_recipt_number;
                        transaction_update.transaction_number = transaction.transaction_number;
                        transaction_update.delivery_date = transaction.delivery_date;
                        transaction_update.notice = transaction.notice;
                        transaction_update.passport_status = transaction.passport_status;
                        transaction_update.reason_for_booking = transaction.reason_for_booking;
                        transaction_update.update_at = DateTime.Now;
                        transaction_update.UserId = transaction.UserId;

                        _data.transactions.Update(transaction_update);
                        await _data.SaveChangesAsync();

                        massageInfo.Massage = "تمت عملية التعديل بنجاح  ";
                        massageInfo.statuscode = 203;
                        return massageInfo;

                    }
                    else
                    {
                        transaction_update.recipients_name = transaction.recipients_name;

                        transaction_update.finacial_recipt_number = transaction.finacial_recipt_number;
                        transaction_update.transaction_number = transaction.transaction_number;
                        transaction_update.delivery_date = transaction.delivery_date;
                        transaction_update.notice = transaction.notice;
                        transaction_update.passport_status = transaction.passport_status;
                        transaction_update.reason_for_booking = transaction.reason_for_booking;
                        transaction_update.update_at = DateTime.Now.Date;
                        transaction_update.UserId = transaction.UserId;

                        _data.transactions.Update(transaction_update);
                        await _data.SaveChangesAsync();

                        massageInfo.Massage = "    لم تتم عملية التعديل علي حقل الاسم او رقم الجواز الرجاء التأكد من عدم تكرار البيانات";
                        massageInfo.statuscode = 203;

                        return massageInfo;

                    }
                }
                else
                {
                    // massageInfo.Massage = "المستخدم غير موجود ";
                    massageInfo.statuscode = 404;
                    return massageInfo;


                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        //public async Task<MassageInfo> UpdateTransaction(TransactionInfo transaction)
        //{
        //    try
        //    {
        //        MassageInfo massageInfo = new MassageInfo();

        //        TransactionInfo transaction_update = await _data.transactions.FindAsync(transaction.id);


        //        TransactionInfo transaction_update1 = await _data.transactions.FirstOrDefaultAsync(x => x.full_name != transaction.full_name && x.id != transaction.id && x.passport_number != transaction.passport_number);


        //        if (transaction_update != null)
        //        {
        //            if()


        //        }

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        public async Task<List<reports>> UsersReport()
        {
            try
            {

            var users = await _data.Administrator.ToListAsync();
            var transactions = await _data.transactions.ToListAsync();
            List<reports> list_reports = new List<reports>();

            foreach (Administrator user in users)
            {
                list_reports.Add(new reports()
                {
                    BookedReport = (from booked in transactions
                                    where booked.UserId == user.id && booked.passport_status == "موقوف"
                                    select booked).Count(),
                    ReceivedReport = (from received in transactions
                                      where received.UserId == user.id && received.passport_status == "جاهز"
                                      select received).Count(),
                    TotalReport = (from total in transactions
                                   where total.UserId == user.id
                                   select total).Count(),
                    UserNameReport = user.name

                });

            }
                return list_reports;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TransactionInfoDto> GetTransaction(int id)
        {
            try
            {
                TransactionInfo c =await _data.transactions.FindAsync(id);

                TransactionInfoDto trnsactionDto = new TransactionInfoDto();

                trnsactionDto.id = c.id;
                trnsactionDto.finacial_recipt_number = c.finacial_recipt_number;
                trnsactionDto.full_name = c.full_name;
                trnsactionDto.transaction_number = c.transaction_number;
                trnsactionDto.recipients_name = c.recipients_name;
                trnsactionDto.delivery_date = c.delivery_date.ToString("yyyy-MM-dd");
                trnsactionDto.passport_number = c.passport_number;
                trnsactionDto.notice = c.notice;
                trnsactionDto.passport_status = c.passport_status;
                trnsactionDto.reason_for_booking = c.reason_for_booking;
                trnsactionDto.UserId = c.UserId;
                trnsactionDto.passport_status = c.passport_status;
                trnsactionDto.state = c.state;
                trnsactionDto.nationality_number = c.nationality_number;
            
                return trnsactionDto;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<PageingDtocs> GetAll(int pageNumber, int pageSize)
        {
           

            try
            {
                PageingDtocs pageing = new PageingDtocs();
                pageing.TotalOfTransaction = _data.transactions.Count();
                List<TransactionInfo> transaction = await _data.transactions.OrderByDescending(x=>x.update_at).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
              //  transaction.Reverse();
                //var config = new MapperConfiguration(mc => mc.CreateMap<TransactionInfo, TransactionViewModel>());
              

                foreach (var item in transaction)
                {
                    pageing.TransactionList.Add(new TransactionViewModel()
                    {
                        delivery_date = item.delivery_date.ToString("yyyy-MM-dd"),
                        finacial_recipt_number = item.finacial_recipt_number,
                        full_name = item.full_name,
                        id = item.id,

                        passport_status = item.passport_status,
                        recipients_name = item.recipients_name,
                       

                    });
                    //var maper = new Mapper(config);

                    //var list = maper.Map<List<TransactionInfo>, List<TransactionViewModel>>(transaction);



                }

                return pageing;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<TransactionViewModel>> GetLastFive()
        {
            var c =await _data.transactions.OrderByDescending(x => x.update_at).Take(5).ToListAsync();

            List<TransactionViewModel> list = new List<TransactionViewModel>();

            foreach (var item in c)
            {
                list.Add(new TransactionViewModel()
                {
                    delivery_date = item.delivery_date.ToString("yyyy-MM-dd"),
                    finacial_recipt_number=item.finacial_recipt_number,
                    full_name=item.full_name,
                    id=item.id,
                    
                    passport_status=item.passport_status,
                    recipients_name=item.recipients_name
                    
                }) ;

            }


            //List<TransactionViewModel> l = new List<TransactionViewModel>();
            //var config = new MapperConfiguration(mc=>mc.CreateMap<TransactionInfo,TransactionViewModel>());

            //var maper = new Mapper(config);

            //var list = maper.Map<List<TransactionInfo>,List<TransactionViewModel>>(c);
         
            return list;





        }

        public async Task<ReportDto> UsersReport(int page, int pageSize)
        {
            ReportDto dto = new ReportDto();

         var c =await UsersReport();

            dto.total = c.Count();
        

            dto.List=  c.OrderBy(x=>x.UserNameReport).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return dto;


        }
    }
}
