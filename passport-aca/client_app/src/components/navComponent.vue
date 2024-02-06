<template>
   <div></div>
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
        
        
        };
    },

    methods: {
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