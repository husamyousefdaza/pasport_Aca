<template>
    <div class="relative">
        <div class="h-screen bg-white overflow-hidden flex">
            <asideComponent></asideComponent>
            <div class="flex-1 bg-gray-200 w-0 overflow-y-auto pb-10">
                <div class="  mx-6 flex flex-col md:px-8 xl:px-0">
                    <navComponent></navComponent>
                    <main class="flex-1 relative focus:outline-none">
                        <div class="space-y-8 divide-y divide-gray-200 mt-6">
                            <div class="space-y-8 divide-y divide-gray-200">
                                <div>
                                    <div class="font-bold text-lg">
                                        {{ pageTitle }}
                                    </div>

                                    <div class="mt-6">
                                        <h3 class="text-lg leading-6 font-medium text-gray-900">
                                            معلومات عن المعاملة
                                        </h3>
                                      
                                    </div>

                                    <div class="mt-6 grid gap-y-6 gap-x-4 grid-cols-6">
                                        <div class="col-span-3 flex items-center justify-between">
                                            <label for="name" class=" text-sm font-medium text-gray-700 w-36">
                                                الاسم بالكامل
                                            </label>
                                            <input type="text" v-model="transactionInfo.full_name" id="name" autocomplete="name" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                        </div>

                                        <div class="col-span-3 flex items-center justify-between">
                                            <label for="birthdate" class=" text-sm font-medium text-gray-700 w-36">
                                                تاريخ الميلاد
                                            </label>
                                            <input type="date" v-model="transactionInfo.birthdate" id="birthdate" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                        </div>


                                        <label
                v-if="national_valid"
                for="national"
                class="font-medium text-red-700 col-span-6"
              >
                يجب أن يتكون الرقم الوطني من 12 خانة
              </label>

                                        <div class="col-span-3 flex items-center justify-between">
                                            <label for="nationality_number" class=" text-sm font-medium text-gray-700 w-36">
                                                الرقم الوطني
                                            </label>

                
                                            <input  type="number" onkeypress="return event.charCode >= 48 && event.charCode <= 57"  v-model="nationality_number" id="nationality_number" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                        </div>

                                        <div class="col-span-3 flex items-center justify-between">
                                            <label for="finacial_recipt_number" class=" text-sm font-medium text-gray-700 w-36">
                                                رقم الإيصال المالي
                                            </label>
                                            <input type="number" v-model="transactionInfo.finacial_recipt_number" id="finacial_recipt_number" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                        </div>

                                        
                                        <div class="col-span-3 flex items-center justify-between">
                                            <label for="from_who" class=" text-sm font-medium text-gray-700 w-36">
                                                من طرف من
                                            </label>
                                                                                                    
                                            <input type="text" v-model="transactionInfo.from_who" id="from_who" autocomplete="from_who" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                        </div>

                                  

      
               

              <div class="col-span-3 flex items-center justify-between">
                                            <label for="date_of_photography" class=" text-sm font-medium text-gray-700 w-36">
                                                تاريخ التصوير
                                            </label>
                                            <input type="date" v-model="transactionInfo.date_of_photography" id="date_of_photography" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                        </div>




                                        <div class="col-span-3 flex items-center justify-between">
                                            <label for="transaction_number" class=" text-sm font-medium text-gray-700 w-36">
                                                رقم المعاملة
                                            </label>

                                            <input type="number" v-model="transactionInfo.transaction_number" id="transaction_number" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                        </div>

                                        

      



                         <fieldset class=" w-full col-span-6  mt-1">



                            <div class="flex items-center justify-between">
  <legend class="text-sm font-medium text-gray-700 w-16">
    التصنيف
  </legend>



  <div class="flex items-center mr-8">
    <input v-model="transactionInfo.classification" id="first_time" type="radio" name="type1" class="h-4 w-4" value="أول مرة" />
    <label for="first_time" class="mr-2 block text-gray-800">
      أول مرة
    </label>
  </div>

  <div  class="flex items-center mr-6">
    <input v-model="transactionInfo.classification" id="renewal" type="radio" name="type1" class="h-4 w-4" value="تجديد" />
    <label for="renewal" class="mr-2 block text-gray-800">
      تجديد
    </label>
  </div>

  <div  class="flex items-center mr-6">
    <input v-model="transactionInfo.classification" id="damaged_replacement" type="radio" name="type1" class="h-4 w-4" value="بدل تالف" />
    <label for="damaged_replacement" class="mr-2 block text-gray-800">
      بدل تالف
    </label>
  </div>


  <div class="flex items-center mr-6">
    <input v-model="transactionInfo.classification" id="replacement_of_lost" type="radio" name="type1" class="h-4 w-4" value="بدل فاقد" />
    <label for="replacement_of_lost" class="mr-2 block text-gray-800">
      بدل فاقد
    </label>
  </div>

  <div  class="flex items-center mr-6">
    <input v-model="transactionInfo.classification" id="page_finisher" type="radio" name="type1" class="h-4 w-4" value="منتهي الصفحات" />
    <label for="page_finisher" class="mr-2 block text-gray-800">
      منتهي الصفحات
    </label>
  </div>

</div>

                     </fieldset>





                                    </div>
                                </div>

                                <div class="pt-6">
                                    <div>
                                        <h3 class="text-lg leading-6 font-medium text-gray-900">
                                            إجراء المعاملة
                                        </h3>
                                      
                                    </div>

                                    <div class="mt-6 grid gap-y-6 gap-x-4 grid-cols-6">
                                        <!-- <div class="col-span-3 flex items-center justify-between">
                                            <label for="financialreceiptnumber" class=" text-sm font-medium text-gray-700 w-40">
                                                رقم الإيصال المالي
                                            </label>
                                            <input type="number" v-model="transactionInfo.finacial_recipt_number" id="financialreceiptnumber" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                        </div>

                                        <div class="col-span-3 flex items-center justify-between">
                                            <label for="transactionnumber" class=" text-sm font-medium text-gray-700 w-32">
                                                رقم المعاملة
                                            </label>
                                            <input type="number" v-model="transactionInfo.transaction_number" id="transactionnumber" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                        </div> -->


                                                                          
                 <fieldset class=" w-full col-span-3 mt-1">

                    
<div class="flex items-center justify-between">
        <legend class="text-sm font-medium text-gray-700 w-16">
            إجراء المعالة
        </legend>



        <div class="flex items-center mr-8">
            <input  id="Underprocedure" type="radio" v-model="transactionInfo.passport_status" name="type" class="h-4 w-4" value="تحت الإجراء" />
            <label for="Underprocedure" class="mr-2 block text-gray-800">
            تحت الإجراء
            </label>
        </div>

        <div  class="flex items-center mr-6">
            <input  id="ready" type="radio" v-model="transactionInfo.passport_status" name="type" class="h-4 w-4" value="جاهزة" />
            <label for="ready" class="mr-2 block text-gray-800">
            جاهزة
            </label>
        </div>

        <div  class="flex items-center mr-6">
            <input  id="stopped" type="radio" v-model="transactionInfo.passport_status" name="type" class="h-4 w-4" value="موقوفة" />
            <label for="stopped" class="mr-2 block text-gray-800">
            موقوفة
            </label>
        </div>

       


        <div class="flex items-center mr-6">
            <input  id="received" type="radio" v-model="transactionInfo.passport_status" name="type" class="h-4 w-4" value="تم تسليمها" />
            <label for="received" class="mr-2 block text-gray-800">
            تم تسليمها
            </label>
        </div>

        </div>


</fieldset>

                 


                                        <!-- <div class="col-span-6 ">
                                            <div class="flex items-center justify-between">
                                                <label for="about" class="block text-sm font-medium text-gray-700 w-32">
                                                    الملاحظات
                                                </label>
                                                <div class="w-full">
                                                    <textarea id="about" v-model="transactionInfo.notice" rows="3" class="p-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full text-sm border-gray-300"></textarea>
                                                    <p class="text-sm text-gray-500">اكتب اي ملاحظات.</p>
                                                </div>
                                            </div>
                                        </div> -->

                                        <!-- <div class="col-span-6">
                                            <div class="flex items-center justify-between">
                                                <label for="about" class="block text-sm font-medium text-gray-700 w-32">
                                                    الحالة
                                                </label>
                                                <div class="w-full flex items-center">
                                                    <div class="flex items-center">
                                                        <input id="Ready" v-model="transactionInfo.passport_status" value="جاهز" type="radio" class="h-4 w-4 border-gray-300">
                                                        <label for="Ready" class="mr-2 text-sm font-medium text-gray-700">
                                                            جاهز
                                                        </label>
                                                    </div>

                                                 
                                                </div>
                                            </div>
                                        </div> -->

                                        <div class="col-span-6" v-if="transactionInfo.passport_status == 'موقوفة'">
                                            <div class="flex items-center justify-between">
                                                <label for="reason_of_stopping" class="block text-sm font-medium text-gray-700 w-32">
                                                    سبب الإيقاف
                                                </label>
                                                <div class="w-full">
                                                    <textarea id="reason_of_stopping" v-model="transactionInfo.reason_of_stopping" rows="3" class="p-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full text-sm border-gray-300"></textarea>
                                                    <p class="text-sm text-gray-500">اكتب الأسباب.</p>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>




                                <div v-if="this.role.includes('dil')"  class="pt-6">
                                    <div>
                                        <h3 class="text-lg leading-6 font-medium text-gray-900">
                                            بيانات التسليم
                                        </h3>
                                      
                                    </div>

                                    <div class="mt-6 grid gap-y-2 gap-x-4 grid-cols-6">
                                                         
                     

                                    

                                        <div class="col-span-3 flex items-center justify-between">
                                            <label for="resevedName" class=" text-sm font-medium text-gray-700 w-36">
                                                اسم المستلم
                                            </label>
                                            <input type="text" v-model="transactionInfo.resevedName" id="resevedName" autocomplete="resevedName" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                        </div>

                                        <div class="col-span-3 flex items-center justify-between">
                                            <label for="delivery_date" class=" text-sm font-medium text-gray-700 w-36">
                                                تاريخ الإستلام
                                            </label>
                                            <input type="date" v-model="transactionInfo.delivery_date" id="delivery_date" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                        </div>

                                        <div class="col-span-3 flex items-center justify-between">
                                            <label for="passport_number" class=" text-sm font-medium text-gray-700 w-36">
                                                رقم الجواز
                                            </label>
                                            <input type="text" v-model="transactionInfo.passport_number" id="passport_number" autocomplete="passport_number" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                        </div>

                               
                                    </div>
                                </div>


                            </div>

                            <div class="pt-5">
                                <div class="flex justify-end">
                                    <router-link :to="{ name: 'Transactions' }" class="bg-white py-2 px-4 border border-gray-300 rounded-md shadow-sm text-sm font-medium text-gray-700 hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500">
                                        إلغاء
                                    </router-link>

                                    <!-- <button v-if="showDelete" @click="deleteUser()" class="mr-3 inline-flex justify-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-red-600 hover:bg-red-500 duration-300 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500">
                                        حذف
                                    </button> -->

                                    <button @click="submit()" class="mr-3 inline-flex justify-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-primary-golden hover:bg-primary-blue duration-300 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500">
                                        {{ submitText }}
                                    </button>
                                </div>
                            </div>
                        </div>
                    </main>
                </div>
            </div>
        </div>

        <div v-if="screenFreeze" class="w-screen h-screen bg-black bg-opacity-30 absolute inset-0 z-50 flex justify-center items-center">
            <div v-if="loading" class="">
                <svgLoadingComponent></svgLoadingComponent>
            </div>

            <div v-if="AddEditAlert" class="shadow-2xl">
                <div class="w-96 h-60 bg-white rounded-lg p-4 flex flex-col justify-between items-center">
                    <div class="flex justify-between items-center w-full">
                        <p class="text-lg font-medium text-primary-golden">
                             المستخدمين
                        </p>
                        <button @click="AddEditAlert=false ,screenFreeze=false" class="focus:outline-none">
                            <svg class="w-6 h-6 stroke-current text-base hover:text-red-500 duration-300" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                <path d="M7.86 2H16.14L22 7.86V16.14L16.14 22H7.86L2 16.14V7.86L7.86 2Z"  stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                                <path d="M15 9L9 15"  stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                                <path d="M9 9L15 15"  stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                            </svg>
                        </button>
                    </div>

                    <div class="">
                        <p class="font-bold">
                            {{ AddEditMessage }}
                        </p>
                    </div>

                    <div class="">
                        <!-- <router-link :to="{ name: 'TransactionsForm' }" class="py-2 px-8 border border-transparent shadow-sm text-sm font-medium rounded-md text-primary-golden border-primary-golden hover:bg-primary-golden hover:text-white duration-300 focus:outline-none">
                            رجوع
                        </router-link> -->


                        <button @click="AddEditAlert=false ,screenFreeze=false " class="py-2 px-8 border border-transparent shadow-sm text-sm font-medium rounded-md text-primary-golden border-primary-golden hover:bg-primary-golden hover:text-white duration-300 focus:outline-none">
                            رجوع
                        </button>


                    </div>
                </div>
            </div>

            <div v-if="deleteAlert" class="shadow-2xl">
                <div class="w-96 h-60 bg-white rounded-lg p-4 flex flex-col justify-between items-center">
                    <div class="flex justify-between items-center w-full">
                        <p class="text-lg font-medium text-red-500">
                            حذف المستخدم
                        </p>
                        <router-link :to="{ name: 'Transactions' }" class="focus:outline-none">
                            <svg class="w-6 h-6 stroke-current text-base hover:text-red-500 duration-300" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                <path d="M7.86 2H16.14L22 7.86V16.14L16.14 22H7.86L2 16.14V7.86L7.86 2Z"  stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                                <path d="M15 9L9 15"  stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                                <path d="M9 9L15 15"  stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                            </svg>
                        </router-link>
                    </div>

                    <div class="">
                        <p class="font-bold">
                            تمت عملية الحدف بنجاح
                        </p>
                    </div>

                    <div class="">
                        <router-link :to="{ name: 'Transactions' }" class="py-2 px-8 border border-transparent shadow-sm text-sm font-medium rounded-md text-primary-golden border-primary-golden hover:bg-primary-golden hover:text-white duration-300 focus:outline-none">
                            رجوع
                        </router-link>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import asideComponent from '@/components/asideComponent.vue';
import navComponent from '@/components/navComponent.vue';
import svgLoadingComponent from '@/components/svgLoadingComponent.vue';
export default {
  created() {},
  mounted() {

    this.role= sessionStorage.getItem('user_role');

    this.checkAddOrUpdate();
  },
  components: {
      asideComponent,
      navComponent,
      svgLoadingComponent
  },
  data() {
    return {

        er1:[],

role:[],

        userId: this.$authenticatedUser.userId,
        name: this.$authenticatedUser.name,
        userName: this.$authenticatedUser.userName,
        validity: this.$authenticatedUser.validity,

        loading: false,
        deleteAlert: false,
        screenFreeze: false,
        showDelete: false,
        AddEditAlert: false,

        AddEditMessage:'',
        pageTitle:'',
        submitText:'',

        national_valid: false,
        nationality_number:"",

        transactionInfo:{

            full_name:'',
            passport_number:'',
            birthdate:"",
            
            delivery_date:"1111-11-11",
            finacial_recipt_number:'',
            transaction_number:'',
            classification:"أول مرة",
            date_of_photography:"",
            from_who:"",
            resevedName:"",
            passport_status:'تحت الإجراء',
            reason_of_stopping :"",
           
            nationality_number:'',

            

            UserId:Number(sessionStorage.getItem("user_id") ),
        }
    };
  },

  watch:{

    nationality_number : function() {
      if ((this.nationality_number.length > 12 || this.nationality_number.length <12 )&& this.nationality_number.length != 0) {
        this.national_valid = true;
      } else {
        this.national_valid = false;
      }
    },

  },
  methods: {
    checkAddOrUpdate(){
        this.screenFreeze = true;
        this.loading = true;
        
        var transactionId = this.$route.params.transaction;
        if (transactionId) {
          this.$http.TransactionsService
            .GetTransaction(transactionId)
            .then((res) => {
                this.screenFreeze = false;
                this.loading = false;
                var respons = res.data

                
                var date1 = new Date(respons.date_of_birth);
                var date2 = new Date(respons.picture_date);
                var date3 = new Date(respons.delivery_date);


                var month1 = date1.getMonth() + 1;
                var day1 = date1.getDate();

                var month2 = date2.getMonth() + 1;
                var day2 = date2.getDate();

               var month3 = date3.getMonth() + 1;
               var day3 = date3.getDate();



if (month1 < 10) month1 = "0" + month1;
if (day1 < 10) day1 = "0" + day1;

if (month2 < 10) month2 = "0" + month2;
if (day2 < 10) day2 = "0" + day2;

if (month3 < 10) month3 = "0" + month3;
if (day3 < 10) day3 = "0" + day3;




this.transactionInfo.birthdate  = date1.getFullYear() + "-" + month1 + "-" + day1;
this.transactionInfo.date_of_photography  = date2.getFullYear() + "-" + month2 + "-" + day2;
this.transactionInfo.delivery_date  = date3.getFullYear() + "-" + month3 + "-" + day3;





           
           
           
            
            
    


            



            
            
            
           
this.nationality_number = respons.nationality_number,
                this.transactionInfo.full_name = respons.full_name,
                this.transactionInfo.passport_number = respons.passport_number,
                
                
                
                this.transactionInfo.classification =  respons.classification  ,

                


                this.transactionInfo.from_who =  respons.from_who,

                this.transactionInfo.transaction_number =  respons.transaction_number,

                
                
                this.transactionInfo.finacial_recipt_number = respons.finacial_recipt_number
             
               
                this.transactionInfo.passport_status = respons.passport_status

                this.transactionInfo.resevedName= respons.resevedName ,
                this.transactionInfo.reason_of_stopping =  respons.reason_of_stopping

               

                
                
            })
            .catch((err) => {
                this.screenFreeze = false;
                this.loading = false;
                console.log(err);
            });
            this.pageTitle = "تعديل بيانات المعاملة";
            this.submitText = "تعديل";
            this.showDelete = true;
        } else {
            this.screenFreeze = false;
            this.loading = false;
            this.showDelete = false;
            this.pageTitle = "إضافة معاملة";
            this.submitText = "إضافة";
        }
    },
    submit() {
        this.screenFreeze = true;
        this.loading = true;
        var transactionInfoToSend = {



            full_name: this.transactionInfo.full_name,
            date_of_birth: this.transactionInfo.birthdate,
            nationality_number: this.nationality_number,
            finacial_recipt_number: Number(this.transactionInfo.finacial_recipt_number),
            from_who:this.transactionInfo.from_who,
            picture_date: this.transactionInfo.date_of_photography,
            passport_status: String(this.transactionInfo.passport_status),


            classification:  this.transactionInfo.classification,

            transaction_number:this.transactionInfo.transaction_number,

            resevedName:  this.transactionInfo.resevedName,
            passport_number: this.transactionInfo.passport_number,
            
            delivery_date: this.transactionInfo.delivery_date,

            reason_of_stopping:this.transactionInfo.reason_of_stopping,

          //  transaction_number: Number(this.transactionInfo.transaction_number),

            UserId:Number(sessionStorage.getItem("user_id") ),
        }

        if(this.$route.params.transaction){
            transactionInfoToSend.id = this.$route.params.transaction
            this.$http.TransactionsService
                .UpdateTransaction(transactionInfoToSend)
                .then((res) => {
                    setTimeout(() => {
                        this.loading = false;

                        this.AddEditMessage = res.data.message  || res.data.massage ;
                        
                        this.AddEditAlert = true;
                    }, 100);
                    console.log(res)
                })
                .catch((err) => {
                    setTimeout(() => {
                        this.loading = false;

                        this.AddEditMessage = err.data.message  || err.data.massage ;

                        this.AddEditAlert = true;

                    }, 100);
                    console.log(err)
                });
        }
        else{
            this.$http.TransactionsService
                .AddTransaction(transactionInfoToSend)
                .then((res) => {
                    setTimeout(() => {
                        this.loading = false;

                        this.AddEditMessage = 'تمت عملية الإضافة بنجاح.';

                        this.AddEditAlert = true;
                    }, 100);
                    console.log(res)
                })
                .catch((err) => {
                    setTimeout(() => {
                        this.loading = false;

                     
                        this.AddEditMessage = err.response.data.message  || err.response.data.massage ;

                        this.AddEditAlert = true;

                    }, 100);
                    console.log(err)
                });
        }

    },
    deleteUser() {
        this.screenFreeze = true;
        this.loading = true;
      this.$http.TransactionsService
        .DeleteTransaction(this.$route.params.transaction)
        .then((res) => {
            this.loading = false;
            this.deleteAlert = true;
            console.log(res);
        })
        .catch((err) => {
            this.loading = false;
            this.deleteAlert = true;
            console.log(err);
        });
    },
  },
}
</script>