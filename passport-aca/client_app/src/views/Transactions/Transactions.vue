  
<template>
    <div v-on:keyup.enter="Search" class="">
        <div class="h-screen bg-white overflow-hidden flex">
            <asideComponent></asideComponent>
            <div class="flex-1 bg-gray-200 w-0 overflow-y-auto pb-10">
              <navComponent></navComponent>
              <div class="flex items-center w-full  justify-center  ">
                <span class="text-base font-medium text-gray-800">
                  التاريخ :
                </span>

                <span class="flex items-center mr-4">
                  من
                  <input type="date" min="2000-01-01" max="2040-12-30" id="date_from" v-model="date_from" class="
                        block
                        mr-2
                        w-full
                        rounded-md
                        h-10
                        border border-gray-200
                        hover:shadow-sm
                        focus:outline-none focus:border-gray-300
                        px-2
                      " />
                </span>

                <span class="flex items-center mr-4">
                  إلي
                  <input type="date" min="2000-01-01" max="2040-12-30" id="date_to" v-model="date_to" class="
                        block
                        mr-2
                        w-full
                        rounded-md
                        h-10
                        border border-gray-200
                        hover:shadow-sm
                        focus:outline-none focus:border-gray-300
                        px-2
                      " />
                </span>
              </div>

                <div class="mx-4    flex flex-col md:px-8 xl:px-0">
                    

                    
               
                    <main class="flex-1 relative focus:outline-none">
                        <div class="py-6 px-4 sm:px-6 md:px-0 flex justify-between items-center">

                            
                            <h1 class="text-xl font-semibold text-primary-blue ml-2">المعاملات</h1>

                            

           
              <div class="relative w-full">
                <button @click="filter = !filter" :class="filter ? 'shadow-md' : ''" class="
                      rounded-t-md
                      border border-b-0
                      hover:text-blue-600 hover:font-bold
                      group
                      w-full
                      p-2
                      bg-white
                      flex
                      items-center
                      justify-between
                      focus:outline-none
                    ">
                  <span class="flex items-center">
                    <svg class="w-6 h-6 ml-2 stroke-current group-hover:stroke-2" fill="none" stroke="currentColor"
                      viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                      <path stroke-linecap="round" stroke-linejoin="round"
                        d="M3 4a1 1 0 011-1h16a1 1 0 011 1v2.586a1 1 0 01-.293.707l-6.414 6.414a1 1 0 00-.293.707V17l-4 4v-6.586a1 1 0 00-.293-.707L3.293 7.293A1 1 0 013 6.586V4z">
                      </path>
                    </svg>
                    فرز
                  </span>

                  <span class="">
                    <svg class="w-6 h-6 stroke-current group-hover:stroke-2" fill="none" stroke="currentColor"
                      viewBox="0 0 24 24">
                      <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="{2}" d="M19 9l-7 7-7-7" />
                    </svg>
                  </span>
                </button>

                <div v-if="filter" class="
                      rounded-b-md
                      shadow-md
                      absolute
                      top-10
                      w-full
                      border border-t-0
                      z-40
                      bg-white
                      px-4
                      py-8
                    ">
                  <div class="
                        grid grid-cols-1
                        gap-y-6 gap-x-4
                        sm:grid-cols-6
                        max-w-4xl
                        mx-auto
                      ">
                    <div class="sm:col-span-2">
                      <label for="mail_id" class="block text-base font-semibold text-gray-800">
                        رقم المعاملة
                      </label>
                      <input  v-model="transaction_number" type="number" min="1" max="5000" id="mail_id" class="
                            block
                            mt-2
                            h-10
                            w-full
                            rounded-md
                            border border-gray-300
                            hover:shadow-sm
                            focus:outline-none focus:border-gray-300
                            px-2
                          " />
                    </div>

          
                    <div class="sm:col-span-2">
                      <label for="measure" class="block text-base font-semibold text-gray-800">
                        الإجراء
                      </label>

                      <div @click="measureselect = !measureselect" class="relative">
                        <button    id="measure" class="
                              text-right
                              block
                              mt-2
                              w-full
                              rounded-md
                              h-10
                              border
                              text-sm
                              bg-white
                              border-gray-300
                              hover:shadow-sm
                              focus:outline-none focus:border-gray-300
                              p-2
                            ">
                            {{ measureNameSelected  }}
                        </button>

                        <div  v-if="measureselect"   class="
                              border
                              text-sm
                              bg-white
                              border-gray-300
                              p-2
                              absolute
                              w-full
                              z-20
                              shadow
                              h-24
                              overflow-y-scroll
                              rounded-b-md
                            ">
                          <button  class="
                                block
                                focus:outline-none
                                w-full
                                my-1
                                text-right
                              "    
                                @click="
                               measureNameSelected = '';
                            "
                          >
                            الكل
                          </button>

                          <button class="
                                block
                                focus:outline-none
                                w-full
                                my-1
                                text-right
                              "
                              
                              @click="
                              measureNameSelected = measure.measuresName;
                           
                              
                            "
                              v-for="measure in T_type"
                            :key="measure.id"

                            >
                            {{ measure.measuresName }}
                          </button>
                        </div>
                      </div>
                    </div>

                
                    <div class="sm:col-span-2">
                      <label for="classification" class="block text-base font-semibold text-gray-800">
                        التصنيف
                      </label>
                                    
                      <div  @click="classselect = !classselect" class="relative">
                        <button  id="classification" class="
                              text-right
                              block
                              mt-2
                              w-full
                              rounded-md
                              h-10
                              border
                              text-sm
                              bg-white
                              border-gray-300
                              hover:shadow-sm
                              focus:outline-none focus:border-gray-300
                              p-2
                            ">
                            {{ classNameSelected }}
                        </button>

                        <div v-if="classselect"  class="
                              border
                              text-sm
                              bg-white
                              border-gray-300
                              p-2
                              absolute
                              w-full
                              z-20
                              shadow
                              h-24
                              overflow-y-scroll
                              rounded-b-md
                            ">
                          <button class="
                                block
                                focus:outline-none
                                w-full
                                my-1
                                text-right
                              "        @click="
                               classNameSelected = '';
                            ">
                            الكل
                          </button>

                          <button class="
                                block
                                focus:outline-none
                                w-full
                                my-1
                                text-right
                              "   
                                   @click="
                              classNameSelected = class1.className;
                              
                            "
                              v-for="class1 in class2"
                            :key="class1.id"

                            >
                            {{ class1.className }}
                          </button>
                        </div>
                      </div>
                    </div>

                    <div class="sm:col-span-2">
                      <label for="summary" class="block text-base font-semibold text-gray-800">
                       إسم صاحب الجواز
                      </label>
                      <input v-model="pass_name" type="text"  id="summary" class="
                            block
                            mt-2
                            w-full
                            rounded-md
                            h-10
                            text-sm
                            border border-gray-300
                            hover:shadow-sm
                            focus:outline-none focus:border-gray-300
                            p-2
                          " />
                    </div>


                    <div v-if=" this.role.includes('who')" class="sm:col-span-2">
                      <label for="summary" class="block text-base font-semibold text-gray-800">
                      من طرف من
                      </label>
                      <input v-model="from_who" type="text"  id="summary" class="
                            block
                            mt-2
                            w-full
                            rounded-md
                            h-10
                            text-sm
                            border border-gray-300
                            hover:shadow-sm
                            focus:outline-none focus:border-gray-300
                            p-2
                          " />
                    </div>


                    <!-- <div class="sm:col-span-2" v-if="mailType != 1">
                      <label
                        for="side"
                        class="block text-base font-semibold text-gray-800"
                      >
                        الجهات الخارجية
                      </label>

                      <div class="relative">
                        <button
                          @click="sideselect = !sideselect"
                          id="side"
                          class="
                            text-right
                            block
                            mt-2
                            w-full
                            rounded-md
                            h-10
                            border
                            text-sm
                            bg-white
                            border-gray-300
                            hover:shadow-sm
                            focus:outline-none focus:border-gray-300
                            p-2
                          "
                        >
                          {{ sideNameSelected }}
                        </button>

                        <div
                          v-if="sideselect"
                          class="
                            border
                            text-sm
                            bg-white
                            border-gray-300
                            p-2
                            absolute
                            w-full
                            z-20
                            shadow
                            h-24
                            overflow-y-scroll
                            rounded-b-md
                          "
                        >
                          <button
                            class="
                              block
                              focus:outline-none
                              w-full
                              my-1
                              text-right
                            "
                            @click="
                              selectsides('', 'الكل');
                              sideselect = !sideselect;
                            "
                          >
                            الكل
                          </button>

                          <button
                            class="
                              block
                              focus:outline-none
                              w-full
                              my-1
                              text-right
                            "
                            @click="
                              selectsides(side.id, side.section_Name);
                              sideselect = !sideselect;
                            "
                            v-for="side in sides"
                            :key="side.id"
                          >
                            {{ side.section_Name }}
                          </button>
                        </div>
                      </div>
                    </div> -->


                    <div class="sm:col-span-2">
                                            <label for="date" class=" block text-base font-semibold text-gray-800">
                                                تاريخ التصوير
                                            </label>
                                            <input v-model="pic_date" type="checkbox"  id="pic_date" class="     block
                            mt-2
                            h-10
                            w-full
                            rounded-md
                            border border-gray-300
                            hover:shadow-sm
                            focus:outline-none focus:border-gray-300
                            px-2">
                                        </div>



                    <div class="sm:col-span-2">
                      <label for="finacial_recipt_number" class="block text-base font-semibold text-gray-800">
                        رقم الإيصال المالي
                      </label>
                      <input v-model="finacial_recipt_number2" type="number" min="1" max="5000"
                        id="finacial_recipt_number2" class="
                            block
                            mt-2
                            h-10
                            w-full
                            rounded-md
                            border border-gray-300
                            hover:shadow-sm
                            focus:outline-none focus:border-gray-300
                            px-2
                          " />
                    </div>

                    <div class="sm:col-span-2">
                        <label
                          for="s-number"
                          class="block text-base font-semibold text-gray-800"
                        >
                     الرقم الوطني
                        </label>
                        <input
                        v-model="national_number"
                          type="number"
                          min="1"
                          id="s-number"
                          class="block mt-2 h-10 w-full rounded-md border border-gray-300 hover:shadow-sm focus:outline-none focus:border-gray-300 px-2"
                        />
                    </div>


                    <div class="sm:col-span-2">
                      <label for="summary" class="block text-base font-semibold text-gray-800">
                       إسم المستلم
                      </label>
                      <input v-model="rec_name" type="text"  id="summary" class="
                            block
                            mt-2
                            w-full
                            rounded-md
                            h-10
                            text-sm
                            border border-gray-300
                            hover:shadow-sm
                            focus:outline-none focus:border-gray-300
                            p-2
                          " />
                    </div>

                    <div class="sm:col-span-2">
                                            <label for="date2" class=" block text-base font-semibold text-gray-800">
                                                تاريخ الإستلام
                                            </label>
                                            <input v-model="rec_date" type="checkbox" id="date2" class="     block
                            mt-2
                            h-10
                            w-full
                            rounded-md
                            border border-gray-300
                            hover:shadow-sm
                            focus:outline-none focus:border-gray-300
                            px-2">
                                        </div>

          
                    <div class="sm:col-span-6 mt-2 flex justify-between">

                    

                      <div class="mt-6">



           
                        <button 
                        @click="Search() ;filter = !filter"
                        
                        id="search_button" class="
                        px-8
                    mr-2
                    bg-green-700
                    text-green-50
                    rounded-md
                    py-2
                    border border-green-300
                    hover:bg-green-800
                    focus:outline-none
                    flex
                    items-center
                    justify-center
                    col-span-2
                            ">

                            <span class="text-sm font-bold block ml-1"> بحث</span>
                        </button>
                        
                      </div>

                      <div class="mt-6">
                    
                    <button 
                    @click="   
                       search_reset()"
                    
                    id="search_button" class="
                    px-8
                mr-2
                bg-green-700
                text-green-50
                rounded-md
                py-2
                border border-green-300
                hover:bg-green-800
                focus:outline-none
                flex
                items-center
                justify-center
                col-span-2
                        ">

                        <span class="text-sm font-bold block ml-1"> جديد</span>
                    </button>
                    
                  </div>
                    
                    
                    </div>
                      <!-- <div class="sm:col-span-2">
                      <label
                        for="by_date_of_reply"
                        class="block text-base font-semibold text-gray-800"
                      >
                        حسب تاريخ الرد
                      </label>
                      <input
                        v-model="by_date_of_reply"
                        type="checkbox"
                        id="by_date_of_reply"
                        class="
                          block
                          mt-2
                          h-10
                          w-10
                          overflow-hidden
                          rounded-md
                          border border-gray-300
                          hover:shadow-sm
                          focus:outline-none focus:border-gray-300
                          px-2
                        "
                      />
                    </div> -->
                  </div>
                </div>
              </div>


              <button  v-if="this.role.includes('print')" @click="pr()" class="
                    px-8
                    mr-2
                    bg-green-700
                    text-green-50
                    rounded-md
                    py-2
                    border border-green-300
                    hover:bg-green-800
                    focus:outline-none
                    flex
                    items-center
                    justify-center
                    col-span-2
                  " >
                <span class="text-sm font-bold block ml-1"> طباعة </span>

                <svg class="
                      h-5
                      w-5
                      mr-1
                      text-white
                      block
                      fill-current
                      hover:text-blue-500
                    " id="Capa_1" enable-background="new 0 0 512 512" height="512" viewBox="0 0 512 512" width="512"
                  xmlns="http://www.w3.org/2000/svg">
                  <g>
                    <path
                      d="m437 129h-14v-54c0-41.355-33.645-75-75-75h-184c-41.355 0-75 33.645-75 75v54h-14c-41.355 0-75 33.645-75 75v120c0 41.355 33.645 75 75 75h14v68c0 24.813 20.187 45 45 45h244c24.813 0 45-20.187 45-45v-68h14c41.355 0 75-33.645 75-75v-120c0-41.355-33.645-75-75-75zm-318-54c0-24.813 20.187-45 45-45h184c24.813 0 45 20.187 45 45v54h-274zm274 392c0 8.271-6.729 15-15 15h-244c-8.271 0-15-6.729-15-15v-148h274zm89-143c0 24.813-20.187 45-45 45h-14v-50h9c8.284 0 15-6.716 15-15s-6.716-15-15-15h-352c-8.284 0-15 6.716-15 15s6.716 15 15 15h9v50h-14c-24.813 0-45-20.187-45-45v-120c0-24.813 20.187-45 45-45h362c24.813 0 45 20.187 45 45z" />
                    <path
                      d="m296 353h-80c-8.284 0-15 6.716-15 15s6.716 15 15 15h80c8.284 0 15-6.716 15-15s-6.716-15-15-15z" />
                    <path
                      d="m296 417h-80c-8.284 0-15 6.716-15 15s6.716 15 15 15h80c8.284 0 15-6.716 15-15s-6.716-15-15-15z" />
                    <path
                      d="m128 193h-48c-8.284 0-15 6.716-15 15s6.716 15 15 15h48c8.284 0 15-6.716 15-15s-6.716-15-15-15z" />
                  </g>
                </svg>
              </button>
            </div>

            <div class=" flex">
                            <router-link :to="{ name: 'TransactionsForm' }" class="border border-primary-blue hover:text-primary-golden hover:border-primary-golden duration-300 bg-white px-4 py-2 rounded-md text-primary-blue font-medium focus:outline-none">
                                إضافة +
                            </router-link>
                        </div>  

                        <div class="w-full mt-4 rounded-md overflow-hidden divide-y-2 divide-gray-200">
                            <div class="flex items-center bg-white w-full">
                                <div class="w-1/12  text-center">
                                      رقم المعاملة
                                </div>
                                <div class="w-4/12 text-center">
                                    الاسم
                                </div>
                                <div class="w-3/12 text-center">
                                    الإجراء
                                </div>
                                <div class="w-3/12 text-center">
                                    تاريخ التصوير
                                </div>
                                <div class="w-1/12 pl-2 text-center">
                                    رقم الإيصال المالي
                                </div>
                            </div>

                            <div class="divide-y divide-gray-200 min-h-72 bg-white">
                                <router-link :to="{ name: 'TransactionsFormEdit', params: { transaction: transaction.id },}" v-for="transaction in Transactions" :key="transaction.id" class="w-full bg-white hover:shadow flex items-center">
                                    <div class="w-1/12  font-semibold text-black text-center">
                                        {{ transaction.transaction_number }}
                                    </div>
                                    <div class="w-4/12 text-center">
                                        {{ transaction.full_name }}
                                    </div>
                                    <div class="w-3/12 text-center">
                                        {{ transaction.passport_status }}
                                    </div>
                                    <div class="w-3/12 text-center">
                                        {{ transaction.picture_date}}
                                    </div>
                                    
                                    <div class="w-1/12  text-center  pl-2">
                                        {{ transaction.finacial_recipt_number }}
                                    </div>
                                </router-link>
                            </div>
<!-- 
                            <div class="bg-white px-2 py-3 ">
                                <pagination dir="rtl" v-model="page" :per-page="pagesize" :records="totalOfTransaction" @paginate="getTransaction"/>
                            </div> -->

                            <div class="bg-white px-2 py-3 ">
                                <pagination dir="rtl" v-model="page" :per-page="pagesize" :records="totalOfTransaction" @paginate="Search"/>
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



 
    var date = new Date();

var month = date.getMonth() + 1;
var day = date.getDate();



if (month < 10) month = "0" + month;
if (day < 10) day = "0" + day;

this.date_from = "2024" + "-" + "01" + "-" + "01";
this.date_to = date.getFullYear() + "-" + month + "-" + day;

this.role= sessionStorage.getItem('user_role');

      this.Search();

     //  this.GetLastFiveTransactions();
  },
  components: {
      asideComponent,
      navComponent,
      svgLoadingComponent
  },


  watch: {


    pic_date: function () {
  

      if(this.pic_date==true){

        this.rec_date=false
      }
    },

    rec_date: function () {
  

  if(this.rec_date==true){

    this.pic_date=false
  }
},

  },
  data() {
    return {

      role:["",""],
      finacial_recipt_number2:"",

      national_number:"",

      rec_date:false,

      rec_name:"",

      measureNameSelected:"",
      
      measureselect:false,


      classNameSelected  :"",
      
      classselect:false,

      pass_name:"",

      pic_date:false,

      from_who:"",


      T_type:[{id:1,measuresName:"تحت الإجراء"},{id:2,measuresName:"جاهزة"},{id:3,measuresName:"موقوفة"},{id:4,measuresName:"تم تسليمها"}],

      class2 :[{id:1,className:"أول مرة"},{id:2,className:"تجديد"},{id:3,className:"بدل تالف"},{id:4,className:"بدل فاقد"},{id:5,className:"منتهي الصفحات"}],

      transaction_number:"",

      date_from:"",

      date_to:"",
      
      dd:false,
        userId: this.$authenticatedUser.userId,
        name: this.$authenticatedUser.name,
        userName: this.$authenticatedUser.userName,
        validity: this.$authenticatedUser.validity,

        Transactions:{},
        loading: false,
        screenFreeze: false,

        page: 1,
        pagesize:10,
        totalOfTransaction : 0,

        filter: false,
    };
  },
  methods: {


    pr(){


      this.$router.push({
              name: "incoming_report",
              params: {
                dateFrom: this.date_from,
                dateTo: this.date_to,

                transaction_number: Number(this.transaction_number),
                measureNameSelected: this.measureNameSelected,
                classNameSelected:this.classNameSelected,
                pass_name: this.pass_name,
                from_who: this.from_who,
                pic_date: this.pic_date,
                finacial_recipt_number2:Number(this.finacial_recipt_number2),
                national_number: Number(this.national_number),
                rec_name: this.rec_name,
                rec_date: this.rec_date
              },
            });
    },


    Search(){

      this.Transactions = [],
                    this.totalOfTransaction = 0,

      this.screenFreeze = true;
        this.loading = true;
        this.$http.TransactionsService
            .Search(this.date_from,this.date_to,Number(this.transaction_number),this.measureNameSelected,this.classNameSelected,this.pass_name,this.from_who,this.pic_date,Number(this.finacial_recipt_number2),Number(this.national_number),this.rec_name,this.rec_date)
            .then((res) => {
                setTimeout(() => {
                    this.screenFreeze = false;
                    this.loading = false;
                    this.Transactions = res.data;
                    this.totalOfTransaction = res.data.totalOfTransaction
                }, 100);
                
            })
            .catch((err) => {
                setTimeout(() => {
                    this.screenFreeze = false;
                    this.loading = false;
                    console.log(err);
                }, 100);
                
                
            });



    },
    getTransaction() {
        this.screenFreeze = true;
        this.loading = true;
        this.$http.TransactionsService
            .GetAllTransactions(this.page, this.pagesize)
            .then((res) => {
                setTimeout(() => {
                    this.screenFreeze = false;
                    this.loading = false;
                    this.Transactions = res.data.transactionList;
                    this.totalOfTransaction = res.data.totalOfTransaction
                }, 100);
                
            })
            .catch((err) => {
                setTimeout(() => {
                    this.screenFreeze = false;
                    this.loading = false;
                    console.log(err);
                }, 100);
                
                
            });
    },
  },
}
</script>

<style>
    .VuePagination{
        width: 100%;
    }

    .VuePagination nav {
        display:flex;
        justify-content: space-between;
        align-items: center;
    }

    .pagination{
        display:flex;
    }

    .page-link{
        background-color:red;
    }

    .page-item{
        /* margin-left: .5rem;
        margin-right: .5rem;*/
    }

    .page-link {
        padding-left: 1rem;
        padding-right: 1rem;
        padding-top: 0.5rem;
        padding-bottom: 0.5rem;

        font-size: 0.875rem;
        line-height: 1.25rem;

        font-weight: 500;
        border-width: 1px;

        --tw-border-opacity: 1;
        border-color: rgba(209, 213, 219, var(--tw-border-opacity));

        --tw-bg-opacity: 1;
        background-color: rgba(255, 255, 255, var(--tw-bg-opacity));

        --tw-text-opacity: 1;
        color: rgba(107, 114, 128, var(--tw-text-opacity));
    }

    .page-link:hover{
        --tw-bg-opacity: 1;
        background-color: rgba(249, 250, 251, var(--tw-bg-opacity));
    }

    .active{
        background-color: #152b67;
        color: #fff;
    }

    .VuePagination nav ul{
        padding-top: 0.5rem;
        padding-bottom: 0.5rem;
        border-radius: 0.375rem;
        overflow: hidden;
    }
</style>