<template>
  <div dir="rtl" id="app">
    <!-- <div id="nav">
      <router-link class="bg-red-500" to="/">Home</router-link> |
      <router-link to="/about">About</router-link>
    </div> -->
    <router-view/>
  </div>
</template>


<script>

export default {
    
    created() {
        this.CheckLogin();
    },
    data() {
        return {
            state: 0,

            admin: false,
            isSideMenuOpen: false,
        }
    },

    methods: {
        
        CheckLogin() {

          if(localStorage.getItem("userId") == undefined || localStorage.getItem("userId") == 0 ){
            this.$router.replace("/");
          }else{
            this.$authenticatedUser.userId = localStorage.getItem("userId");
            // this.$router.replace("/dashboard");
          }


            // this.loding = true;
            // this.$http.CheckLogin()
            //     .then(res => {
            //         this.loding = false
            //         let data = res.data;
            //         if (data.result) {
            //             this.$authenticatedUser.userId = data.result.userId;
            //             this.$authenticatedUser.fullName = data.result.fullName;
            //             this.$authenticatedUser.userName = data.result.userName;
            //             this.$authenticatedUser.userPermissions = data.result.userPermissions;

            //             if (!this.$route.meta.Dashboard) {
            //                 this.$router.replace('/dashboard');
            //             }

            //             //                        this.state = 2;
            //         } else {
            //             this.$authenticatedUser.userId = 0;
            //             this.$authenticatedUser.fullName = '';
            //             this.$authenticatedUser.userName = '';
            //             this.$authenticatedUser.userPermissions = [];
            //             if (this.$route.meta.Dashboard) {
            //                 this.$router.replace('/login');
            //             }

            //             // this.state = 1;

            //         }
            //     })
            //     .catch(() => {
            //         this.loding = false
            //         this.$authenticatedUser.userId = 0;
            //         this.$authenticatedUser.fullName = '';
            //         this.$authenticatedUser.userName = '';
            //         this.$authenticatedUser.userPermissions = [];
            //         // this.state = 1;
            //         this.$router.replace('/login');

            //     })








        },
        
    },
}
</script>