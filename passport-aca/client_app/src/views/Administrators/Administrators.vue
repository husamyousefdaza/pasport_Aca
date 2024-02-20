<template >
<div>
    <div class="h-screen bg-white overflow-hidden flex">
        <asideComponent></asideComponent>
        <div class="flex-1 bg-gray-50 w-0 overflow-y-auto">
            <div class="max-w-4xl  mx-auto  flex flex-col md:px-8 xl:px-0">
                <navComponent></navComponent>
                <main class="flex-1 relative focus:outline-none">
                    <div class="py-6 px-4 sm:px-6 md:px-0 flex justify-between items-center">
                        <h1 class="text-xl font-semibold text-primary-blue">المستخدمين</h1>
                        <router-link :to="{ name: 'AdministratorsForm' }" class="border border-primary-blue hover:text-primary-golden hover:border-primary-golden duration-300 bg-white px-4 py-2 rounded-md text-primary-blue font-medium focus:outline-none">
                            إضافة +
                        </router-link>
                    </div>

                    <div class="w-full mt-4 rounded-md overflow-hidden divide-y-2 divide-gray-200">
                        <div class="flex items-center bg-white w-full">
                            <div class="w-4/12 py-4 pr-2">
                                الاسم
                            </div>
                        
                        </div>

                        <div class="divide-y divide-gray-200 min-h-80 bg-white">
                            <router-link :to="{ name: 'AdministratorsFormEdit', params: { administrato: administrato.id },}" v-for="administrato in Administrators" :key="administrato.id" class="w-full bg-white hover:shadow flex items-center">
                                <div class="w-4/12 py-4 pr-2 font-semibold text-black">
                                    {{ administrato.name }}
                                </div>
                           
                            </router-link>
                        </div>

                        <div class="bg-white px-2 py-3 ">
                            <pagination dir="rtl" v-model="page" :per-page="pagesize" :records="totalOfTransaction" @paginate="getAdministrators"/>
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
        this.getAdministrators();
    },

    components: {
        asideComponent,
        navComponent,
        svgLoadingComponent
    },

    data() {
        return {
            Administrators:{},
            loading: false,
            screenFreeze: false,

            page: 1,
            pagesize: 6,
            totalOfTransaction : 0
        };
    },
    
    methods: {
        getAdministrators() {
            this.screenFreeze = true;
            this.loading = true;
            this.$http.AdministratorsService
                .GetAllAdministrators(this.page, this.pagesize)
                .then((res) => {
                    setTimeout(() => {
                        this.screenFreeze = false;
                        this.loading = false;
                        this.Administrators = res.data.listofUser;

                        this.totalOfTransaction = res.data.total;

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