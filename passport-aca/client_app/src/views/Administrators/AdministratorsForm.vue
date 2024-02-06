<template >
    <div class="relative">
        <div class="h-screen bg-white overflow-hidden flex">
            <asideComponent></asideComponent>
            <div class="flex-1 bg-gray-50 w-0 overflow-y-auto">
                <div class="max-w-4xl  mx-auto flex flex-col md:px-8 xl:px-0">
                    <navComponent></navComponent>
                    <main class="flex-1 relative focus:outline-none space-y-8 divide-y divide-gray-200 mt-6">
                        <div class="space-y-8 divide-y divide-gray-200">
                            <div>
                                <div class="font-bold text-lg">
                                    {{ pageTitle }}
                                </div>

                                <div class="mt-6">
                                    <h3 class="text-lg leading-6 font-medium text-gray-900">
                                        معلومات عن المستخدم
                                    </h3>
                                    <p class="mt-1 text-sm text-gray-500">
                                        تتكون من (الاسم وكلمة المرور) وغيرها من معلومات.
                                    </p>
                                </div>

                                <div class="mt-6 grid gap-y-6 gap-x-4 grid-cols-6">
                                    <div class="col-span-3 flex items-center justify-between">
                                        <label for="name" class=" text-sm font-medium text-gray-700 w-32">
                                            الاسم بالكامل
                                        </label>
                                        <input type="text" v-model="Administrators.name" name="name" id="name" autocomplete="name" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                    </div>

                                    <div class="col-span-3 flex items-center justify-between">
                                        <label for="username" class=" text-sm font-medium text-gray-700 w-32">
                                            اسم المستخدم
                                        </label>
                                        <input type="text" v-model="Administrators.username" name="username" id="username" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                    </div>

                                    <div class="col-span-3 flex items-center justify-between">
                                        <label for="password" class=" text-sm font-medium text-gray-700 w-32">
                                            كلمة المرور
                                        </label>
                                        <input type="password" v-model="Administrators.password" name="password" id="password" class="px-2 focus:outline-none focus:shadow hover:shadow-sm rounded-md w-full h-8 text-sm border-gray-300">
                                    </div>

                                    <div class="col-span-3">
                                        <div class="flex items-center justify-between">
                                            <label for="about" class="block text-sm font-medium text-gray-700 w-32">
                                                الصلاحية
                                            </label>
                                            <div class="w-full flex items-center">
                                                <div class="flex items-center">
                                                    <input id="Administrator" v-model="Administrators.validity" value="مسؤول" name="push_notifications" type="radio" class="h-4 w-4 border-gray-300">
                                                    <label for="Administrator" class="mr-2 text-sm font-medium text-gray-700">
                                                        مسؤول
                                                    </label>
                                                </div>


                                                <div class="flex items-center mr-8">
                                                    <input id="Dataentry" v-model="Administrators.validity" value="مدخل بيانات" name="push_notifications" type="radio" class="h-4 w-4 border-gray-300">
                                                    <label for="Dataentry" class="mr-2 text-sm font-medium text-gray-700">
                                                        مدخل بيانات
                                                    </label>
                                                </div>
                                                
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <div class="pt-5">
                            <div class="flex justify-end">
                                <router-link :to="{ name: 'Administrators' }" class="bg-white py-2 px-4 border border-gray-300 rounded-md shadow-sm text-sm font-medium text-gray-700 hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500">
                                    إلغاء
                                </router-link>

                                <button v-if="showDelete" @click="deleteAdministrator()" class="mr-3 inline-flex justify-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-red-600 hover:bg-red-500 duration-300 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500">
                                    حذف
                                </button>

                                <button @click="submit()" class="mr-3 inline-flex justify-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-primary-golden hover:bg-primary-blue duration-300 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500">
                                    {{ submitText }}
                                </button>
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
                        <router-link :to="{ name: 'Administrators' }" class="focus:outline-none">
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
                        <router-link :to="{ name: 'Administrators' }" class="py-2 px-8 border border-transparent shadow-sm text-sm font-medium rounded-md text-primary-golden border-primary-golden hover:bg-primary-golden hover:text-white duration-300 focus:outline-none">
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
                        <router-link :to="{ name: 'Administrators' }" class="focus:outline-none">
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
                        <router-link :to="{ name: 'Administrators' }" class="py-2 px-8 border border-transparent shadow-sm text-sm font-medium rounded-md text-primary-golden border-primary-golden hover:bg-primary-golden hover:text-white duration-300 focus:outline-none">
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
        loading: false,
        deleteAlert: false,
        screenFreeze: false,
        showDelete: false,
        AddEditAlert: false,

        AddEditMessage:'',
        pageTitle:'',
        submitText:'',

        Administrators:{
            name:'',
            username:'',
            password:'',
            validity:'',
        }
    };
  },
  methods: {
    checkAddOrUpdate(){
        this.screenFreeze = true;
        this.loading = true;
        
        var administratoId = this.$route.params.administrato;
        if (administratoId) {
            this.$http.AdministratorsService
                .GetAdministrator(administratoId)
                .then((res) => {
                    this.screenFreeze = false;
                    this.loading = false;
                    var respons = res.data;
                    this.Administrators.name = respons.name;
                    this.Administrators.username = respons.username;
                    this.Administrators.password = respons.password;
                    this.Administrators.validity = respons.validity;
                    
                })
                .catch((err) => {
                    this.screenFreeze = false;
                    this.loading = false;
                    console.log(err);
                });
            this.pageTitle = "تعديل بيانات المسؤول";
            this.submitText = "تعديل";
            this.showDelete = true;
        } else {

            this.screenFreeze = false;
            this.loading = false;
            this.showDelete = false;
            this.pageTitle = "إضافة مسؤول جديد";
            this.submitText = "إضافة";
        }
    },

    submit() {
        this.screenFreeze = true;
        this.loading = true;
        var administratoInfoToSend = {
            name : this.Administrators.name,
            username : this.Administrators.username,
            password : this.Administrators.password,
            validity : this.Administrators.validity,
        }

        if(this.$route.params.administrato){
            administratoInfoToSend.id = this.$route.params.administrato
            this.$http.AdministratorsService
                .UpdateAdministrator(administratoInfoToSend)
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
            this.$http.AdministratorsService
                .AddAdministrator(administratoInfoToSend)
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

    deleteAdministrator() {
        this.screenFreeze = true;
        this.loading = true;
        this.$http.AdministratorsService
            .DeleteAdministrator(this.$route.params.administrato)
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