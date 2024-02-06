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
                                            <input type="date" v-model="transactionInfo.passport_number" id="birthdate" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                        </div>

                                        <div class="col-span-3 flex items-center justify-between">
                                            <label for="passport" class=" text-sm font-medium text-gray-700 w-36">
                                                الرقم الوطني
                                            </label>
                                            <input type="number" v-model="transactionInfo.nationality_number" id="passport" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                        </div>

                                        <div class="col-span-3 flex items-center justify-between">
                                            <label for="recipientname" class=" text-sm font-medium text-gray-700 w-36">
                                                رقم الإيصال المالي
                                            </label>
                                            <input type="number" v-model="transactionInfo.recipients_name" id="recipientname" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                        </div>

                                        
                                        <div class="col-span-3 flex items-center justify-between">
                                            <label for="name2" class=" text-sm font-medium text-gray-700 w-36">
                                                من طرف من
                                            </label>
                                            <input type="text" v-model="transactionInfo.full_name" id="name2" autocomplete="name2" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                        </div>

                                  

      
               

              <div class="col-span-3 flex items-center justify-between">
                                            <label for="date" class=" text-sm font-medium text-gray-700 w-36">
                                                تاريخ التصوير
                                            </label>
                                            <input type="date" v-model="transactionInfo.delivery_date" id="date" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                        </div>


              <div class="col-span-3 flex items-center justify-between">
                                            <label for="transactionnumber" class=" text-sm font-medium text-gray-700 w-36">
                                                رقم المعاملة
                                            </label>
                                            <div
                                            class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full pt-2 h-8 text-sm border-gray-300 bg-white text-center"
                  >
                    22
                  </div>
                                        </div>





                         <fieldset class=" w-full col-span-6  mt-1">



                            <div class="flex items-center justify-between">
  <legend class="text-sm font-medium text-gray-700 w-16">
    التصنيف
  </legend>



  <div class="flex items-center mr-8">
    <input  id="internal" type="radio" name="type" class="h-4 w-4" value="1" />
    <label for="internal" class="mr-2 block text-gray-800">
      أول مرة
    </label>
  </div>

  <div  class="flex items-center mr-6">
    <input  id="internal_export2" type="radio" name="type" class="h-4 w-4" value="2" />
    <label for="internal_export2" class="mr-2 block text-gray-800">
      تجديد
    </label>
  </div>

  <div  class="flex items-center mr-6">
    <input  id="internal_export" type="radio" name="type" class="h-4 w-4" value="4" />
    <label for="internal_export" class="mr-2 block text-gray-800">
      بدل تالف
    </label>
  </div>


  <div class="flex items-center mr-6">
    <input  id="exter" type="radio" name="type" class="h-4 w-4" value="3" />
    <label for="exter" class="mr-2 block text-gray-800">
      بدل فاقد
    </label>
  </div>

  <div  class="flex items-center mr-6">
    <input  id="internal_export" type="radio" name="type" class="h-4 w-4" value="4" />
    <label for="internal_export" class="mr-2 block text-gray-800">
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
            <input  id="internal" type="radio" v-model="transactionInfo.passport_status" name="type" class="h-4 w-4" value="1" />
            <label for="internal" class="mr-2 block text-gray-800">
            تحت الإجراء
            </label>
        </div>

        <div  class="flex items-center mr-6">
            <input  id="internal_export2" type="radio" v-model="transactionInfo.passport_status" name="type" class="h-4 w-4" value="2" />
            <label for="internal_export2" class="mr-2 block text-gray-800">
            جاهزة
            </label>
        </div>

        <div  class="flex items-center mr-6">
            <input  id="stopped" type="radio" v-model="transactionInfo.passport_status" name="type" class="h-4 w-4" value="موقوف" />
            <label for="stopped" class="mr-2 block text-gray-800">
            موقوفة
            </label>
        </div>

       


        <div class="flex items-center mr-6">
            <input  id="exter" type="radio" v-model="transactionInfo.passport_status" name="type" class="h-4 w-4" value="3" />
            <label for="exter" class="mr-2 block text-gray-800">
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

                                        <div class="col-span-6" v-if="transactionInfo.passport_status == 'موقوف'">
                                            <div class="flex items-center justify-between">
                                                <label for="about" class="block text-sm font-medium text-gray-700 w-32">
                                                    سبب الإيقاف
                                                </label>
                                                <div class="w-full">
                                                    <textarea id="about" v-model="transactionInfo.reason_for_booking" rows="3" class="p-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full text-sm border-gray-300"></textarea>
                                                    <p class="text-sm text-gray-500">اكتب الأسباب.</p>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>




                                <div class="pt-6">
                                    <div>
                                        <h3 class="text-lg leading-6 font-medium text-gray-900">
                                            بيانات التسليم
                                        </h3>
                                      
                                    </div>

                                    <div class="mt-6 grid gap-y-2 gap-x-4 grid-cols-6">
                                                         
                     

                                        <div class="col-span-3 flex items-center justify-between">
                                            <label for="name3" class=" text-sm font-medium text-gray-700 w-36">
                                                اسم صاحب الجواز
                                            </label>
                                            <input type="text" v-model="transactionInfo.full_name" id="name4" autocomplete="name3" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                        </div>

                                        <div class="col-span-3 flex items-center justify-between">
                                            <label for="name4" class=" text-sm font-medium text-gray-700 w-36">
                                                اسم المستلم
                                            </label>
                                            <input type="text" v-model="transactionInfo.full_name" id="name4" autocomplete="name4" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                        </div>

                                        <div class="col-span-3 flex items-center justify-between">
                                            <label for="date2" class=" text-sm font-medium text-gray-700 w-36">
                                                تاريخ الإستلام
                                            </label>
                                            <input type="date" v-model="transactionInfo.passport_number" id="date2" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                        </div>

                                        <div class="col-span-3 flex items-center justify-between">
                                            <label for="number2" class=" text-sm font-medium text-gray-700 w-36">
                                                رقم الجواز
                                            </label>
                                            <input type="text" v-model="transactionInfo.full_name" id="number2" autocomplete="number2" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                        </div>

                               
                                    </div>
                                </div>


                            </div>

                            <div class="pt-5">
                                <div class="flex justify-end">
                                    <router-link :to="{ name: 'Transactions' }" class="bg-white py-2 px-4 border border-gray-300 rounded-md shadow-sm text-sm font-medium text-gray-700 hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500">
                                        إلغاء
                                    </router-link>

                                    <button v-if="showDelete" @click="deleteUser()" class="mr-3 inline-flex justify-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-red-600 hover:bg-red-500 duration-300 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500">
                                        حذف
                                    </button>

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
                            {{ AddEditMessage }}
                        </p>
                    </div>

                    <div class="">
                        <router-link :to="{ name: 'Transactions' }" class="py-2 px-8 border border-transparent shadow-sm text-sm font-medium rounded-md text-primary-golden border-primary-golden hover:bg-primary-golden hover:text-white duration-300 focus:outline-none">
                            رجوع
                        </router-link>
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
    this.checkAddOrUpdate();
  },
  components: {
      asideComponent,
      navComponent,
      svgLoadingComponent
  },
  data() {
    return {
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
        transactionInfo:{
            full_name:'',
            passport_number:'',
            recipients_name:'',
            delivery_date:'',
            finacial_recipt_number:'',
            transaction_number:'',
            notice:'',
            passport_status:'',
            reason_for_booking:'',
            nationality_number:'',
            UserId:this.$authenticatedUser.userId,
        }
    };
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
                this.transactionInfo.full_name = respons.full_name
                this.transactionInfo.passport_number = respons.passport_number
                this.transactionInfo.recipients_name = respons.recipients_name
                this.transactionInfo.delivery_date = respons.delivery_date
                this.transactionInfo.finacial_recipt_number = respons.finacial_recipt_number
                this.transactionInfo.transaction_number = respons.transaction_number
                this.transactionInfo.notice = respons.notice
                this.transactionInfo.passport_status = respons.passport_status
                this.transactionInfo.reason_for_booking = respons.reason_for_booking
                this.transactionInfo.nationality_number = respons.nationality_number

                
                
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
            passport_number: this.transactionInfo.passport_number,
            recipients_name: this.transactionInfo.recipients_name,
            delivery_date: this.transactionInfo.delivery_date,
            finacial_recipt_number: Number(this.transactionInfo.finacial_recipt_number),
            transaction_number: Number(this.transactionInfo.transaction_number),
            notice: this.transactionInfo.notice,
            passport_status: String(this.transactionInfo.passport_status),
            reason_for_booking: this.transactionInfo.reason_for_booking,
            nationality_number: this.transactionInfo.nationality_number,
            
            UserId:this.transactionInfo.UserId,
        }

        if(this.$route.params.transaction){
            transactionInfoToSend.id = this.$route.params.transaction
            this.$http.TransactionsService
                .UpdateTransaction(transactionInfoToSend)
                .then((res) => {
                    setTimeout(() => {
                        this.loading = false;

                        this.AddEditMessage = 'تمت عملية التعديل بنجاح.';

                        this.AddEditAlert = true;
                    }, 100);
                    console.log(res)
                })
                .catch((err) => {
                    setTimeout(() => {
                        this.loading = false;

                        this.AddEditMessage = 'حدث خطا ما الرجاء إعادة المحاولة في وقت لاحق.';

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

                        this.AddEditMessage = 'حدث خطا ما الرجاء إعادة المحاولة في وقت لاحق.';

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