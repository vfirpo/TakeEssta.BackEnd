<template>
  <div>
    <table>
      <thead>
        <tr>
          <th>Id</th>
          <th>Caja Id</th>
          <th>Comanda Id</th>
          <th>Fcha de Creacion</th>
          <th>Fecha de Cierre</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="comanda in datos" :key="comanda.id">
          <td>{{ comanda.id }}</td>
          <td>{{ comanda.cajaId }}</td>
          <td>{{ comanda.comandaId }}</td>
          <td>{{ comanda.fechaCreacion }}</td>
          <td>{{ comanda.fechaCierre }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
//import axios from "axios";

export default {
  name: "FromApi",
  props: {
    datos: Object,
  },
};
</script>

<style>
tr,
td {
  border: 1px;
  border-width: 1px;
  border-style: solid;
}
</style>