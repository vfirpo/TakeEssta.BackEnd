var app = new Vue({
    el: '#app',
    data: {
      message: 'Hello Vue.js!',
      pepe: ' Pepe'
    },
    methods: {
      reverseMessage: function () {
        this.message = this.message.split('').reverse().join('')
        console.log(this.message)
        this.message= this.message + this.pepe
      }
    }
  })
  