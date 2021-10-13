﻿var app = new Vue({
    el: '#app',
    data: {
        loading: false,
        productModel: {
            name: "Product Name",
            description: "Product description",
            value: 1.99
        },
        products:[]
    },
    methods: {
        getProducts: function () {
            this.loading = true;
            axios.get('/Admin/products')
                .then(res => {
                    console.log(res);
                    this.products = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                })
        },
        createProduct: function () {
            this.loading = true;
            axios.post("/Admin/products", this.productModel)
                .then(res => {
                    console.log(res.data);
                    this.products.push(res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                })
        }
    },
    computed: {
    }
});