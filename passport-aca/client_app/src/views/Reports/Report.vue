<template >
    <div class="h-screen bg-white overflow-hidden flex">
        <asideComponent></asideComponent>
        <div class="flex-1 bg-gray-50 w-0 overflow-y-auto">
            <div class="max-w-4xl  mx-auto  flex flex-col md:px-8 xl:px-0">
                <navComponent></navComponent>
                <main class="flex-1 relative focus:outline-none ">
                    <div class="py-6">
                        <div class="px-4 sm:px-6 md:px-0">
                            <h1 class="text-xl font-semibold text-primary-blue">التقرير</h1>
                        </div>
                        <div class="px-4 sm:px-6 md:px-0">
                            <!-- Replace with your content -->
                            <div class="py-4">
                                <div class="grid grid-cols-3 gap-8">

                                    <button class="bg-white p-4 hover:shadow focus:outline-none group">
                                        <div class="flex justify-between items-start">
                                            <div class="">
                                                <p class="text-gray-900">إجمالي المعاملات</p>
                                                <p class="font-bold text-primary-blue text-3xl mt-2 text-right">
                                                    {{ Reports.count_Of_all_transaction }}
                                                </p>
                                            </div>
                                            <div class="w-16 h-16 -mt-8 bg-primary-golden flex justify-center items-center">
                                                <svg class="h-6 w-6 stroke-current text-primary-blue group-hover:text-red-600" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                    <path d="M7.86 2H16.14L22 7.86V16.14L16.14 22H7.86L2 16.14V7.86L7.86 2Z" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                                                    <path d="M14.7187 8H9.28123C9.17288 8 9.07386 8.05813 9.02737 8.14983C8.98082 8.24116 8.99469 8.34934 9.06294 8.4281L11.7319 11.5L9.0626 14.572C8.99435 14.6507 8.98082 14.7592 9.02737 14.8502C9.07386 14.9419 9.17288 15 9.28123 15H14.7187C14.874 15 15 14.8824 15 14.7375V13.8625C15 13.7176 14.874 13.6 14.7187 13.6C14.5635 13.6 14.4375 13.7176 14.4375 13.8625V14.475H9.87147L12.3124 11.6656C12.396 11.5693 12.396 11.4311 12.3124 11.3348L9.87147 8.525H14.4375V9.13754C14.4375 9.28244 14.5635 9.40004 14.7187 9.40004C14.874 9.40004 15 9.28244 15 9.13754V8.2625C15 8.1176 14.874 8 14.7187 8Z" fill="black" stroke-width="1.1"/>
                                                </svg>
                                            </div>
                                        </div>
                                    </button>

                                    <button class="bg-white p-4 hover:shadow focus:outline-none group">
                                        <div class="flex justify-between items-start">
                                            <div class="">
                                                <p class="text-gray-900">المعاملات المستلمة</p>
                                                <p class="font-bold text-primary-blue text-3xl mt-2 text-right">
                                                    {{ Reports.count_Of_received }}
                                                </p>
                                            </div>

                                            <div class="w-16 h-16 -mt-8 bg-primary-golden flex justify-center items-center">
                                                <svg  class="h-6 w-6 stroke-current text-primary-blue group-hover:text-red-600" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                    <path d="M7.86 2H16.14L22 7.86V16.14L16.14 22H7.86L2 16.14V7.86L7.86 2Z" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                                                    <path d="M17 9L10.8125 15L8 12.2727" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                                                </svg>
                                            </div>
                                        </div>
                                    </button>

                                    <button class="bg-white p-4 hover:shadow focus:outline-none group">
                                        <div class="flex justify-between items-start">
                                            <div class="">
                                                <p class="text-gray-900">المعاملات المحجوزة</p>
                                                <p class="font-bold text-primary-blue text-3xl mt-2 text-right">
                                                    {{ Reports.count_Of_booking }}
                                                </p>
                                            </div>
                                            <div class="w-16 h-16 -mt-8 bg-primary-golden flex justify-center items-center">
                                                <svg class="h-6 w-6 stroke-current text-primary-blue group-hover:text-red-600" width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                    <path d="M7.86 2H16.14L22 7.86V16.14L16.14 22H7.86L2 16.14V7.86L7.86 2Z"  stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                                                    <path d="M12 8V12"  stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                                                    <path d="M12 16H12.01"  stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                                                </svg>
                                            </div>
                                        </div>
                                    </button>

                                </div>
                            </div>
                            <!-- /End replace -->
                        </div>
                    </div>

                    <section>
                        <div class="px-4 sm:px-6 md:px-0 flex justify-between items-center">
                            <h1 class="text-xl font-semibold text-primary-blue">إحصائيات المستخدمين</h1>
                        </div>

                        <div class="w-full mt-4 rounded-md overflow-hidden divide-y-2 divide-gray-200">
                            <div class="flex items-center bg-white w-full">
                                <div class="w-3/12 py-4 pr-2">
                                    المستخدم
                                </div>
                                <div class="w-3/12 text-center">
                                    إجمالي المعاملات
                                </div>
                                <div class="w-3/12 text-center">
                                    المعاملات المستلمة
                                </div>
                                <div class="w-3/12 text-center pl-2">
                                    المعاملات المحجوزة
                                </div>
                            </div>

                            <div class="divide-y divide-gray-200">

                                <div v-for="user in usersReport" :key="user.userNameReport" class="w-full bg-white hover:shadow flex items-center">
                                    <div class="w-3/12 py-4 pr-2 font-semibold text-black">
                                        {{ user.userNameReport }}
                                    </div>
                                    <div class="w-3/12 text-center">
                                        {{ user.totalReport }}
                                    </div>
                                    <div class="w-3/12 text-center">
                                        {{ user.receivedReport }}
                                    </div>
                                    <div class="w-3/12 text-center pl-2">
                                        {{ user.bookedReport }}
                                    </div>
                                </div>
                            
                            </div>

                            <div class="bg-white px-2 py-3 flex items-center justify-between">
                                
                                <div class="flex-1 flex items-center justify-between">
                                    <div>
                                        <p class="text-sm text-gray-700">
                                            عرض
                                            <span class="font-medium">1</span>
                                            إلى
                                            <span class="font-medium">10</span>
                                            من
                                            <span class="font-medium">97</span>
                                            النتائج
                                        </p>
                                    </div>
                                    <div>
                                        <nav class="relative z-0 inline-flex rounded-md shadow-sm -space-x-px" aria-label="Pagination">

                                            <a href="#" class="relative inline-flex items-center px-2 py-2 rounded-r-md border border-gray-300 bg-white text-sm font-medium text-gray-500 hover:bg-gray-50">
                                                <span class="sr-only">Next</span>
                                                <!-- Heroicon name: solid/chevron-right -->
                                                <svg class="h-5 w-5" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                                                    <path fill-rule="evenodd" d="M7.293 14.707a1 1 0 010-1.414L10.586 10 7.293 6.707a1 1 0 011.414-1.414l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0z" clip-rule="evenodd" />
                                                </svg>
                                            </a>
                                            
                                            <!-- Current: "z-10 bg-indigo-50 border-indigo-500 text-indigo-600", Default: "bg-white border-gray-300 text-gray-500 hover:bg-gray-50" -->
                                            <a href="#" aria-current="page" class="z-10 bg-indigo-50 border-primary-blue text-primary-blue relative inline-flex items-center px-4 py-2 border text-sm font-medium">
                                                1
                                            </a>
                                            <a href="#" class="bg-white border-gray-300 text-gray-500 hover:bg-gray-50 relative inline-flex items-center px-4 py-2 border text-sm font-medium">
                                                2
                                            </a>
                                            <a href="#" class="bg-white border-gray-300 text-gray-500 hover:bg-gray-50 hidden md:inline-flex relative items-center px-4 py-2 border text-sm font-medium">
                                                3
                                            </a>
                                            <span class="relative inline-flex items-center px-4 py-2 border border-gray-300 bg-white text-sm font-medium text-gray-700">
                                                ...
                                            </span>
                                            <a href="#" class="bg-white border-gray-300 text-gray-500 hover:bg-gray-50 hidden md:inline-flex relative items-center px-4 py-2 border text-sm font-medium">
                                                8
                                            </a>
                                            <a href="#" class="bg-white border-gray-300 text-gray-500 hover:bg-gray-50 relative inline-flex items-center px-4 py-2 border text-sm font-medium">
                                                9
                                            </a>
                                            <a href="#" class="bg-white border-gray-300 text-gray-500 hover:bg-gray-50 relative inline-flex items-center px-4 py-2 border text-sm font-medium">
                                                10
                                            </a>

                                            <a href="#" class="relative inline-flex items-center px-2 py-2 rounded-l-md border border-gray-300 bg-white text-sm font-medium text-gray-500 hover:bg-gray-50">
                                                <span class="sr-only">Previous</span>
                                                <!-- Heroicon name: solid/chevron-left -->
                                                <svg class="h-5 w-5" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                                                    <path fill-rule="evenodd" d="M12.707 5.293a1 1 0 010 1.414L9.414 10l3.293 3.293a1 1 0 01-1.414 1.414l-4-4a1 1 0 010-1.414l4-4a1 1 0 011.414 0z" clip-rule="evenodd" />
                                                </svg>
                                            </a>
                                            
                                        </nav>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </section>
                </main>
            </div>
        </div>
    </div>
</template>

<script>
import asideComponent from '@/components/asideComponent.vue';
import navComponent from '@/components/navComponent.vue';
export default {
  created() {},

  mounted() {
    this.GetNumbersOfReports();
    this.GetUsersReport();
  },

  components: {
      asideComponent,
      navComponent
  },

  data() {
    return {
        userId: this.$authenticatedUser.userId,
        name: this.$authenticatedUser.name,
        userName: this.$authenticatedUser.userName,
        validity: this.$authenticatedUser.validity,

        Reports:{
            count_Of_all_transaction:0,
            count_Of_received:0,
            count_Of_booking:0
        },
        loading: false,
        screenFreeze: false,

        usersReport: {}
    };
  },
  methods: {
        GetUsersReport() {
            this.screenFreeze = true;
            this.loading = true;
            this.$http.TransactionsService
                .GetUsersReport()
                .then((res) => {
                    setTimeout(() => {
                        this.screenFreeze = false;
                        this.loading = false;

                        this.usersReport = res.data;

                        console.log(this.usersReport)
                        // this.Reports.count_Of_all_transaction = res.data.count_Of_all_transaction;
                        // this.Reports.count_Of_booking = res.data.count_Of_booking;
                        // this.Reports.count_Of_received = res.data.count_Of_received;

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

        GetNumbersOfReports() {
            this.screenFreeze = true;
            this.loading = true;
            this.$http.DashboardService
                .NumbersOfReports()
                .then((res) => {
                    setTimeout(() => {
                        this.screenFreeze = false;
                        this.loading = false;

                        this.Reports.count_Of_all_transaction = res.data.count_Of_all_transaction;
                        this.Reports.count_Of_booking = res.data.count_Of_booking;
                        this.Reports.count_Of_received = res.data.count_Of_received;

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