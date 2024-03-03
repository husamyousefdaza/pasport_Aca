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
           
            MassageInfo massageInfo = new MassageInfo();
            try {
                int year = DateTime.Now.Year;
              
                TransactionInfo nationality_number = new TransactionInfo();
                TransactionInfo finacial_recipt_number = new TransactionInfo();
                TransactionInfo transaction_number = new TransactionInfo();

                nationality_number = _data.transactions.FirstOrDefault(x => x.nationality_number == transactionInfo.nationality_number);
                finacial_recipt_number = _data.transactions.FirstOrDefault(x => x.finacial_recipt_number == transactionInfo.finacial_recipt_number);
                transaction_number = _data.transactions.FirstOrDefault(x => x.transaction_number == transactionInfo.transaction_number);
                if (nationality_number == null && finacial_recipt_number == null && transaction_number ==null)
                {
                    transactionInfo.create_at = DateTime.Now;

                    //transaction_number = await _data.transactions.OrderBy(x=>x.transaction_number).Where(x=>x.create_at.Date.Year == year).LastOrDefaultAsync();
                    //if (transaction_number != null) { transactionInfo.transaction_number = transaction_number.transaction_number + 1; } else { transactionInfo.transaction_number = 1; }

                    transactionInfo.transaction_number = transactionInfo.transaction_number;
                    transactionInfo.transaction_year = transactionInfo.create_at.Year;
                    transactionInfo.update_at = DateTime.Now;                   
                    transactionInfo.state = true;
                    await _data.transactions.AddAsync(transactionInfo);
                    massageInfo.Massage = " تمت عملية الاضافة بنجاح";
                    massageInfo.statuscode = 201;
                    await _data.SaveChangesAsync();
                    return massageInfo;
                }
                else if (nationality_number == null && finacial_recipt_number != null && transaction_number == null)
                {
                    massageInfo.Massage = "  رقم الايصال المالي موجود مسبقاً ..لم تنجح عملية الإضافة";
                    massageInfo.statuscode = 406;
                    return massageInfo;

                }
                else if (nationality_number != null && finacial_recipt_number == null && transaction_number == null)
                {

                    massageInfo.Massage = "  الرقم الوطني تم تكراره ..لم تنجح عملية الإضافة";
                    massageInfo.statuscode = 406;
                    return massageInfo;

                }
                else if (nationality_number == null && finacial_recipt_number == null && transaction_number != null)
                {

                    massageInfo.Massage = "  الرقم المعاملة تم تكراره ..لم تنجح عملية الإضافة";
                    massageInfo.statuscode = 406;
                    return massageInfo;

                }

                else
                {

                    massageInfo.Massage = "  الرقم الوطني و رقم الايصال المالي  و رقم المعاملة تم تكراره ..لم تنجح عملية الإضافة";
                    massageInfo.statuscode = 406;
                    return massageInfo;

                }
        

            } catch(Exception ex) {
                massageInfo.statuscode = 400;
                massageInfo.Massage = "خطأ في المدخلات";

                return massageInfo;

                throw;
            }
        }

        public async Task<Numbers_Of_Reports> Numbers_Of_Reports()
        {
            try
            {
                MassageInfo massageInfo = new MassageInfo();
                Numbers_Of_Reports count_of = new Numbers_Of_Reports();
                
              //  List<TransactionInfo> transactions = await _data.transactions.ToListAsync();

                List<TransactionInfo> stopped = await(from tr in _data.transactions
                                                                             where tr.passport_status == "موقوفة"
                                                                             select tr).ToListAsync();

                List<TransactionInfo> Count = await _data.transactions.ToListAsync();


                List<TransactionInfo> ready = await(from tr in _data.transactions
                                                                             where tr.passport_status == "جاهزة"
                                                                             select tr).ToListAsync();

                List<TransactionInfo> received = await(from tr in _data.transactions
                                                                             where tr.passport_status == "تم تسليمها"
                                                                             select tr).ToListAsync();

                List<TransactionInfo> underprocedure = await(from tr in _data.transactions
                                                                             where tr.passport_status == "تحت الإجراء"
                                                                               select tr).ToListAsync();

//                count_of.Count_Of_all_transaction = transactions.Count();

                count_of.Count_Of_received = received.Count();

                count_of.Count_Of_stopped = stopped.Count();

                count_of.Count_Of_ready = ready.Count();

                count_of.Count_Of_Underprocedure = underprocedure.Count();

                count_of.Count_Of_all_transaction = count_of.Count_Of_received + count_of.Count_Of_stopped + count_of.Count_Of_ready + count_of.Count_Of_Underprocedure;

                return count_of; 
            }
            catch (Exception ex)
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

        public async Task<List< TransactionViewModel>> search(DateTime? date_from, DateTime? date_to, int? trnsacton_number, string? passport_status, string? classification, string? full_name, string? from_who, bool? picture_date, int? finacial_recipt_number, long? nationality_number, string? resevedName, bool? delivery_date)
        {
            try
            {
                List<TransactionViewModel> fg = new List<TransactionViewModel>();

                bool transaction_num = false;
                bool pass_status = false;
                bool classifi = false;
                bool f_name = false; 
                bool nation_number = false;
                bool f_who = false;
                bool finacial_number = false;
                bool r_name = false;
                bool dev = false;
                bool pict = false;
                if ( delivery_date == false)
                {
                    dev = true;

                }
                else
                {
                    dev = false;

                }

                if ( picture_date == false)
                {
                    pict = true;

                }
                else
                {
                    pict = false;

                }


                if (trnsacton_number == 0) { transaction_num = true; } else { transaction_num = false; }
                if (passport_status == null) { pass_status = true; } else { pass_status = false; }
                if (classification == null) { classifi = true; } else { classifi = false; }
                if (full_name == null) { f_name = true; } else { f_name = false; }
                if (nationality_number == 0) { nation_number = true; } else { nation_number = false; }
                if (from_who == null) { f_who = true; } else { f_who = false; }               
                if (finacial_recipt_number == 0) { finacial_number = true; } else { finacial_number = false; }
                if (resevedName == null) { r_name = true; } else { r_name = false; } 


                var sersh = await _data.transactions.Where(x => (((x.create_at.Date >= date_from.Value.Date && x.create_at.Date <= date_to.Value.Date) && ( pict == true && dev == true)) || true)
                                   && (x.transaction_number == trnsacton_number || transaction_num==true)
                                   && (x.passport_status == passport_status || pass_status == true)
                                   && (x.classification == classification || classifi == true)
                                   && ((x.full_name.Contains(full_name) && f_name == false) || f_name == true)
                                   && (x.nationality_number == nationality_number || nation_number == true)
                                   && ((x.from_who.Contains(from_who) && f_who == false) || f_who == true)
                                   && (x.finacial_recipt_number == finacial_recipt_number || finacial_number == true)
                                   && ((x.resevedName.Contains(resevedName) && r_name == false) || r_name == true)
                                   && (((x.delivery_date.Date >= date_from.Value.Date && x.delivery_date.Date <= date_to.Value.Date) && (dev == false))  || dev == true)
                                   && (((x.picture_date.Date >= date_from.Value.Date && x.picture_date.Date <= date_to.Value.Date)   && (pict == false)) || pict == true)

                                     ).ToListAsync();
                                  
                foreach (var item in sersh)
                {

                  var fgg = new TransactionViewModel
                    {
                        finacial_recipt_number =item.finacial_recipt_number ,
                        delivery_date = item.delivery_date.ToString(),
                        fromWho = item.from_who,
                        full_name = item.full_name,
                        passport_status = item.passport_status,
                        picture_date = item.picture_date.ToString(),
                        transaction_number = item.transaction_number,
                        id = item.id
                    };
                    fg.Add(fgg);
                }

                return fg;
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
                TransactionInfo fullName_u = await _data.transactions.FirstOrDefaultAsync(x =>( x.full_name == transaction.full_name || x.passport_number == transaction.passport_number) && x.id != transaction.id);
                TransactionInfo passportNum_u = await _data.transactions.FirstOrDefaultAsync(x => (x.full_name == transaction.full_name || x.passport_number == transaction.passport_number) && x.id != transaction.id);
                TransactionInfo transactionNum_u = await _data.transactions.FirstOrDefaultAsync(x => (x.full_name == transaction.full_name || x.passport_number == transaction.passport_number) && x.id != transaction.id);

             //  TransactionInfo transaction_u = await _data.transactions.FirstOrDefaultAsync(x => x.full_name == transaction.full_name || x.passport_number == transaction.passport_number);


                if (transaction_update != null)
                {
                    if (transactionNum_u == null && fullName_u == null && passportNum_u == null)
                    {
                        transaction_update.full_name = transaction.full_name;

                        transaction_update.passport_number = transaction.passport_number;

                        transaction_update.picture_date = transaction.picture_date;

                        transaction_update.classification = transaction.classification;

                        transaction_update.finacial_recipt_number = transaction.finacial_recipt_number;

                        transaction_update.transaction_number = transaction.transaction_number;

                        transaction_update.delivery_date = transaction.delivery_date;

                        transaction_update.passport_status = transaction.passport_status;

                        transaction_update.update_at = DateTime.Now;

                        transaction_update.UserId = transaction.UserId;

                        transaction_update.date_of_birth = transaction.date_of_birth;

                        transaction_update.resevedName = transaction.resevedName;

                        transaction_update.nationality_number = transaction.nationality_number;

                        transaction_update.from_who = transaction.from_who;

                        _data.transactions.Update(transaction_update);
                        await _data.SaveChangesAsync();

                        massageInfo.Massage = "تمت عملية التعديل بنجاح  ";
                        massageInfo.statuscode = 203;
                        return massageInfo;

                    }
                    else if (transactionNum_u != null && fullName_u == null && passportNum_u == null)
                    {

                        transaction_update.full_name = transaction.full_name;

                        transaction_update.passport_number = transaction.passport_number;

                        transaction_update.picture_date = transaction.picture_date;

                        transaction_update.classification = transaction.classification;

                        transaction_update.finacial_recipt_number = transaction.finacial_recipt_number;

                        transaction_update.delivery_date = transaction.delivery_date;

                        transaction_update.passport_status = transaction.passport_status;

                        transaction_update.update_at = DateTime.Now;

                        transaction_update.UserId = transaction.UserId;

                        transaction_update.date_of_birth = transaction.date_of_birth;

                        transaction_update.resevedName = transaction.resevedName;

                        transaction_update.nationality_number = transaction.nationality_number;

                        transaction_update.from_who = transaction.from_who;

                        _data.transactions.Update(transaction_update);
                        await _data.SaveChangesAsync();

                        massageInfo.Massage = "لم تتم عملية التعديل علي حقل رقم المعاملة  الرجاء التأكد من عدم تكرار البيانات ";
                        massageInfo.statuscode = 203;
                        return massageInfo;

                    }
                    else if (transactionNum_u == null && fullName_u != null && passportNum_u == null)
                    {

                        transaction_update.passport_number = transaction.passport_number;

                        transaction_update.picture_date = transaction.picture_date;

                        transaction_update.classification = transaction.classification;

                        transaction_update.finacial_recipt_number = transaction.finacial_recipt_number;

                        transaction_update.transaction_number = transaction.transaction_number;

                        transaction_update.delivery_date = transaction.delivery_date;

                        transaction_update.passport_status = transaction.passport_status;

                        transaction_update.update_at = DateTime.Now;

                        transaction_update.UserId = transaction.UserId;

                        transaction_update.date_of_birth = transaction.date_of_birth;

                        transaction_update.resevedName = transaction.resevedName;

                        transaction_update.nationality_number = transaction.nationality_number;

                        transaction_update.from_who = transaction.from_who;

                        _data.transactions.Update(transaction_update);
                        await _data.SaveChangesAsync();

                        massageInfo.Massage = " لم تتم عملية التعديل علي حقل الاسم  الرجاء التأكد من عدم تكرار البيانات ";
                        massageInfo.statuscode = 203;
                        return massageInfo;
                    }
                    else if (transactionNum_u == null && fullName_u == null && passportNum_u != null) {
                        transaction_update.full_name = transaction.full_name;

                        transaction_update.passport_number = transaction.passport_number;

                        transaction_update.picture_date = transaction.picture_date;

                        transaction_update.classification = transaction.classification;

                        transaction_update.finacial_recipt_number = transaction.finacial_recipt_number;

                        transaction_update.transaction_number = transaction.transaction_number;

                        transaction_update.delivery_date = transaction.delivery_date;

                        transaction_update.passport_status = transaction.passport_status;

                        transaction_update.update_at = DateTime.Now;

                        transaction_update.UserId = transaction.UserId;

                        transaction_update.date_of_birth = transaction.date_of_birth;

                        transaction_update.resevedName = transaction.resevedName;

                        transaction_update.nationality_number = transaction.nationality_number;

                        transaction_update.from_who = transaction.from_who;

                        _data.transactions.Update(transaction_update);
                        await _data.SaveChangesAsync();

                        massageInfo.Massage = "لم تتم عملية التعديل علي حقل  رقم الجواز الرجاء التأكد من عدم تكرار البيانات  ";
                        massageInfo.statuscode = 203;
                        return massageInfo;
                    }
                    else
                    {


                        transaction_update.picture_date = transaction.picture_date;

                        transaction_update.classification = transaction.classification;

                        transaction_update.finacial_recipt_number = transaction.finacial_recipt_number;

                        transaction_update.delivery_date = transaction.delivery_date;

                        transaction_update.passport_status = transaction.passport_status;

                        transaction_update.update_at = DateTime.Now;

                        transaction_update.UserId = transaction.UserId;

                        transaction_update.date_of_birth = transaction.date_of_birth;

                        transaction_update.resevedName = transaction.resevedName;

                        transaction_update.nationality_number = transaction.nationality_number;

                        transaction_update.from_who = transaction.from_who;

                        _data.transactions.Update(transaction_update);
                        await _data.SaveChangesAsync();

                        massageInfo.Massage = " لم تتم عملية التعديل علي حقل الاسم ورقم المعاملة و رقم الجواز الرجاء التأكد من عدم تكرار البيانات";
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

                trnsactionDto.picture_date = c.picture_date;

                trnsactionDto.classification = c.classification;

                trnsactionDto.delivery_date = c.delivery_date;
               
                trnsactionDto.passport_number = c.passport_number;
               
                trnsactionDto.passport_status = c.passport_status;

                trnsactionDto.UserId = c.UserId;

                trnsactionDto.passport_status = c.passport_status;

                trnsactionDto.state = c.state;

                trnsactionDto.nationality_number = c.nationality_number;

                trnsactionDto.from_who = c.from_who;

                trnsactionDto.reason_of_stopping = c.reason_of_stopping;

                trnsactionDto.date_of_birth = c.date_of_birth;

                trnsactionDto.resevedName = c.resevedName;
            
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
                        
                        transaction_number = item.transaction_number,
                        fromWho =item.from_who,
                        delivery_date=item.delivery_date.ToString("yyyy-MM-dd"),
                        picture_date = item.picture_date.ToString("yyyy-MM-dd"),
                        finacial_recipt_number = item.finacial_recipt_number,
                        full_name = item.full_name,
                        id = item.id,

                        passport_status = item.passport_status,
                       

                    });
                    //var maper = new Mapper(config);

                    //var list = maper.Map<List<TransactionInfo>, List<TransactionViewModel>>(transaction);



                }

                return pageing;
            }
            catch (Exception ex)
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
                    picture_date = item.picture_date.ToString("yyyy-MM-dd"),
                    finacial_recipt_number=item.finacial_recipt_number,
                    full_name=item.full_name,
                    id=item.id,
                    
                    passport_status=item.passport_status,
                   
                    
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
