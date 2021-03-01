<template>
<div>
  <MainMenu/>
  <img alt="Vue logo" src="./assets/logo.png" />
  <HelloWorld id="hello" ref="hwid" :msg="this.messagex"  test="Prueba de Prop y get" />
  <button @click="this.setNewValues()">Refresh Data</button>
  <button @click="this.ChangeComponent">CambiarComponente</button>
  <!--
  <div>
    <center>
      <h1>Todos los datos</h1>
      <div><FromApi :datos="this.dato"></FromApi></div>
      <h1>Todos los datos PARES</h1>
      <div><FromApi :datos="this.pares"></FromApi></div>
      <h1>Todos los datos IMPARES</h1>
      <div><FromApi :datos="this.impares"></FromApi></div>
    </center>
  </div>
  -->
  </div>
</template>

<script>
import HelloWorld from "./components/HelloWorld.vue";
import axios from "axios";
import FromApi from "./components/FromApi.vue";
import MainMenu from './components/MainMenu.vue';
import { createApp } from 'vue';

export default {
  name: "App",
  components: {
    HelloWorld,
    //FromApi,
    MainMenu,
  },

  data() {
    return {
      dato: null,
      pares: [],
      impares: [],
      messagex: "Aplicacion de Ejemplo para Lucho!!",
    };
  },

  mounted() {
    this.getComandas();
  },

  methods: {
    async getComandas() {
        await axios
          .get("http://localhost:8080/api/Comandas")
          .then((resp) => {
            this.dato = resp.data;
          })
          .catch((e) => console.log(e)),

      this.getComandasPares();
    },

    ChangeComponent(){

      createApp(FromApi).mount('#app')

    },

    getComandasPares() {

      this.pares = [];
      this.impares = [];

      for (var i = 0; i < this.dato.length; i++) {
        if (this.dato[i].comandaId % 2 == 0) {
          this.pares.push(this.dato[i]);
        } else {
          this.impares.push(this.dato[i]);
        }
      }
    },

    setNewValues(texto){
        texto = document.getElementById('itext').value;
        this.dato[5].fechaCierre = texto;
        this.messagex = texto;

        console.log(texto);

    },

  },
};
</script>


<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
