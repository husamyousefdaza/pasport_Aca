<template>
    <div class="hidden md:flex md:flex-shrink-0">
        <div class="w-64 flex flex-col">
            <!-- Sidebar component, swap this element with another sidebar if you like -->
            <div class="border-l border-gray-200 pt-5 pb-4 flex flex-col flex-grow overflow-y-auto">
                <div class="flex-shrink-0 px-4 flex items-center">
                    <img class="h-10 w-auto" src="../assets/img/logo-aca.png" alt="logo" />

                </div>
                <div class="flex-grow mt-5 flex flex-col">
                    <nav class="flex-1 bg-white px-2 space-y-1">
                        <!-- Current: "bg-gray-100 text-gray-900", Default: "text-gray-600 hover:bg-gray-50 hover:text-gray-900" -->
                        <router-link v-if=" this.role.includes('dash')" :to="{ name: 'Dashboard' }" class="text-gray-600 hover:bg-gray-50 hover:text-gray-900 group rounded-md py-2 px-2 flex items-center text-sm font-medium">
                            <!--
                                Heroicon name: outline/home

                                Current: "text-gray-500", Default: "text-gray-400 group-hover:text-gray-500"
                            -->
                            <svg class="text-gray-500 ml-3 h-6 w-6" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" aria-hidden="true">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 12l2-2m0 0l7-7 7 7M5 10v10a1 1 0 001 1h3m10-11l2 2m-2-2v10a1 1 0 01-1 1h-3m-6 0a1 1 0 001-1v-4a1 1 0 011-1h2a1 1 0 011 1v4a1 1 0 001 1m-6 0h6" />
                            </svg>
                            لوحة التحكم
                        </router-link>

                        <router-link  :to="{ name: 'Transactions' }" class="text-gray-600 hover:bg-gray-50 hover:text-gray-900 group rounded-md py-2 px-2 flex items-center text-sm font-medium">
                            <!-- Heroicon name: outlineAdministrators -->
                            <svg class="text-gray-400 group-hover:text-gray-500 ml-3 h-6 w-6 fill-current" viewBox="0 0 512.002 512.002" >
                                <path d="M360.241,384.596l-213.365-0.031c-5.885,0-10.667,4.771-10.667,10.667c0,5.885,4.771,10.667,10.667,10.667l213.365,0.031
                                    c5.885,0,10.667-4.771,10.667-10.667C370.907,389.377,366.137,384.596,360.241,384.596z"/>
                                <path d="M317.543,427.263h-128c-5.896,0-10.667,4.771-10.667,10.667c0,5.896,4.771,10.667,10.667,10.667h128
                                    c5.896,0,10.667-4.771,10.667-10.667C328.209,432.033,323.439,427.263,317.543,427.263z"/>
                                <path d="M256.001,128.002c-64.698,0-117.333,52.635-117.333,117.333s52.635,117.333,117.333,117.333
                                    s117.333-52.635,117.333-117.333S320.699,128.002,256.001,128.002z M161.079,256.002h41.807
                                    c1.181,29.056,7.182,57.952,17.599,78.342C188.316,321.461,165.091,291.665,161.079,256.002z M202.887,234.669h-41.807
                                    c4.012-35.663,27.237-65.458,59.406-78.342C210.069,176.717,204.068,205.613,202.887,234.669z M256.001,341.336
                                    c-12.221,0-29.409-33.047-31.573-85.333h63.146C285.41,308.289,268.222,341.336,256.001,341.336z M224.428,234.669
                                    c2.164-52.286,19.352-85.333,31.573-85.333s29.409,33.047,31.573,85.333H224.428z M291.517,334.345
                                    c10.417-20.391,16.418-49.286,17.599-78.342h41.807C346.911,291.665,323.686,321.461,291.517,334.345z M309.116,234.669
                                    c-1.181-29.056-7.182-57.952-17.599-78.342c32.169,12.884,55.395,42.68,59.406,78.342H309.116z"/>
                                <path d="M405.334,64.002h-21.333V41.96c0-23.306-19.721-42.193-42.667-41.958c-3.278,0.034-6.147,0.488-9.531,1.344
                                    L104.383,64.233c-22.452,1.216-40.382,19.688-40.382,42.436v362.667c0,23.531,19.135,42.667,42.667,42.667h298.667
                                    c23.531,0,42.667-19.135,42.667-42.667V106.669C448.001,83.138,428.866,64.002,405.334,64.002z M337.282,21.96
                                    c12.448-3.177,25.385,6.906,25.385,20v22.042H185.259L337.282,21.96z M426.668,469.336c0,11.76-9.573,21.333-21.333,21.333
                                    H106.668c-11.76,0-21.333-9.573-21.333-21.333V106.669c0-11.76,9.573-21.333,21.333-21.333h298.667
                                    c11.76,0,21.333,9.573,21.333,21.333V469.336z"/>
                            </svg>
                            المعاملات
                        </router-link>

                        <router-link v-if="this.role.includes('user')" :to="{ name: 'Administrators' }" class="text-gray-600 hover:bg-gray-50 hover:text-gray-900 group rounded-md py-2 px-2 flex items-center text-sm font-medium">
                            <!-- Heroicon name: outline/Administrators -->
                            <svg class="text-gray-400 group-hover:text-gray-500 ml-3 h-6 w-6" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" aria-hidden="true">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 4.354a4 4 0 110 5.292M15 21H3v-1a6 6 0 0112 0v1zm0 0h6v-1a6 6 0 00-9-5.197M13 7a4 4 0 11-8 0 4 4 0 018 0z" />
                            </svg>
                            المستخدمين
                        </router-link>

              
                    </nav>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {

    mounted() {

        this.role = sessionStorage.getItem('user_role');

    },

    data() {

        return {

        role:[]

        }
    },
}
</script>

<style>
nav a.router-link-exact-active {
    --tw-bg-opacity: 1;
    background-color: rgba(243, 244, 246, var(--tw-bg-opacity));

    --tw-text-opacity: 1;
    color: rgba(17, 24, 39, var(--tw-text-opacity));
  }
</style>