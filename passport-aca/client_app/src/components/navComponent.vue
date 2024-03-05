<template>
     <div
    class="
      relative
      z-60
      flex-shrink-0
      h-16
      w-full
      border-b border-gray-200
      flex

      mt-6
    "
  >


    <div class="relative md:mr-6 ml-4">
        <div>
          <!--  @click="userProcedure = !userProcedure" -->
          <button
            type="button"
            class="
              max-w-xs
              flex
              items-center
              text-sm
              rounded-full
              focus:outline-none
              focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500
            "
            @click="prepare_logout()"
            id="user-menu-button"
            aria-expanded="false"
            aria-haspopup="true"
          >
            <span class="sr-only">Logout</span>
            <svg
              class="w-6 h-6"
              fill="none"
              stroke="currentColor"
              viewBox="0 0 24 24"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth="{2}"
                d="M17 16l4-4m0 0l-4-4m4 4H7m6 4v1a3 3 0 01-3 3H6a3 3 0 01-3-3V7a3 3 0 013-3h4a3 3 0 013 3v1"
              />
            </svg>

            <!-- <img class="h-8 w-8 rounded-full" src="https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixlib=rb-1.2.1&ixqx=9iaFDkXMqu&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80" alt=""> -->
          </button>
        </div>
    </div>




                   
  <div
      v-if="alert_prepare_logout"
      class="
        w-screen
        h-full
        flex
        justify-center
        items-center
        mt-6
        z-90
        overflow-hidden
        bg-black bg-opacity-70
      "
    >
      <div
        class="
          bg-yellow-100
          rounded-md
          w-full
          py-10
          flex 
          justify-center
          items-center

          mt-6
        "
      >
        <div class="">
          <svg
            class="w-12 h-12 stroke-current text-red-600"
            fill="none"
            stroke="currentColor"
            viewBox="0 0 24 24"
            xmlns="http://www.w3.org/2000/svg"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-3L13.732 4c-.77-1.333-2.694-1.333-3.464 0L3.34 16c-.77 1.333.192 3 1.732 3z"
            ></path>
          </svg>
        </div>
        <p class="text-xl font-bold mt-4 ml-4">هل انت متأكد الخروج؟</p>
        

        <div class="">
          <button
            @click="Logout"
            class="
              bg-red-600
              hover:bg-red-700 hover:shadow-lg
              duration-200
              rounded
              text-white
              w-32
              py-1
              ml-2
            "
          >
           نعم
          </button>
          <button
            @click="alert_prepare_logout = false"
            class="
              bg-gray-400
              hover:bg-gray-700 hover:shadow-lg
              duration-200
              rounded
              text-white
              w-32
              py-1
              mr-2
            "
          >
            إلغاء
          </button>
        </div>
      </div>
    </div>

   </div>
</template>

<script>
export default {
    data() {
        return {
            userProcedure: false,
            toggleMenu: false,

            searchMenu: false,
            closeSearchMenu: false,

            searchFor: "",

            resultOfSearch: "",

            finacial_recipt_number: {},

            transaction_number: {},

            full_name: {},
            passport_number: {},

            alert_prepare_logout:false,
        
        
        };
    },

    methods: {



        Logout() {
      localStorage.removeItem("user_id");
      localStorage.removeItem("user_role");
     
      this.$router.push("/");
    },

    prepare_logout() {
      this.alert_prepare_logout = true;
    },


        search() {
            this.closeSearchMenu = true;

            if (this.searchFor == "") {
                this.searchMenu = false;
                this.closeSearchMenu = false;
                return;
            }
            
            this.searchMenu = true;
            var text = this.searchFor;

            this.$http.TransactionsService
            .ayoub(text)
                .then((res) => {
                    this.resultOfSearch = res.data;


                    this.finacial_recipt_number = this.resultOfSearch.finacial_recipt_number;
                    this.transaction_number = this.resultOfSearch.transaction_number;
                    this.full_name = this.resultOfSearch.full_name;
                    this.passport_number = this.resultOfSearch.passport_number;

                    if (
                        this.finacial_recipt_number == 0 &&
                        this.transaction_number == 0 &&
                        this.full_name == 0 &&
                        this.passport_number == 0
                        ) {
                            this.searchMenu = false;
                        }
                })
                .catch((err) => {
                    console.log(err);
                });
        },

        canselSearch() {
            this.searchFor = "";
            this.searchMenu = false;
            this.closeSearchMenu = false;
        },

        toggle_menu() {
            document.querySelector("#overlay").classList.toggle("hidden");
            document.body.classList.toggle("overflow-y-hidden");
            document.getElementById("menu").classList.toggle("hidden");
        },

        toggle_search() {
            document.querySelector("#overlaySearch").classList.toggle("hidden");
            document.body.classList.toggle("overflow-y-hidden");
            document.getElementById("searchMobile").classList.toggle("hidden");
        },
    },
}
</script>

<style>

</style>