<template>
  <div
    id="comItem_951183126"
    class="comItem"
    style="background-color: #fff; border-color: #777777"
  >
    <div class="comItemNC">
      50<img height="30" src="PeYa/logoChicoPY.png" />
    </div>
    <div class="comItemName">
      <i class="far fa-address-card"></i> Fedee G******** (Av Peron 435 4 -
      Campana, Campana)
    </div>
    <div class="comItemStat">
      <span class="Font12">Estado:</span>
      <span class="label label-default">Rendido</span>
      <span class="label label-info"
        ><i class="far fa-clock"></i> Entrega: 22:03 hs</span
      >
      <a
        id="LinkFacturar951183126"
        class="btn btn-default btn-xs btn_fc"
        role="button"
        onclick="alert('Apretaste Facturar(IdComanda)');"
        ><i class="fas fa-file-invoice-dollar"></i> Facturar</a
      >
    </div>
    <div class="comItemTimes">
      <span class="Font12">Tiempo:</span>
      <span class="label label-default"
        ><i class="fas fa-stopwatch"></i> 27'</span
      >
      <span class="label label-default ent_estim_list"
        >{{source.TiempoEstimado}}'</span
      >
    </div>
    <div class="comItemTot">
      {{source.Importe}}
      <span id="FPT951183126"
        ><i
          class="fas fa-money-bill pointer"
          style="color: #673ab7"
          title="Efectivo"
          onclick="fcn_formPagoCge(951183126, 1, 50, 'PEYA');"
        ></i
      ></span>
      <span
        id="LinkCobradoIcon951183126"
        class="glyphicon glyphicon-ok"
        aria-hidden="true"
        title="Comanda cobrada"
      ></span>
    </div>
    <div class="comItemActions">
      <a
        class="btn btn-success btn-xs"
        role="button"
        onclick="fcn_popup_revisar_comanda('951183126', '', '');"
        ><i class="far fa-eye"></i> Ver pedido</a
      >
      <a
        id="LinkReimprimir951183126"
        class="btn btn-primary btn-xs"
        role="button"
        onclick="fcn_popup_reimprimir_comanda('951183126');"
        ><i class="fas fa-print"></i> Reimprimir</a
      >
      <a
        id="LinkModificar951183126"
        class="btn btn-warning btn-xs"
        role="button"
        onclick="fcn_modifificar_pedido('951183126', '');"
        ><i class="far fa-edit"></i> Modificar</a
      >
      <a
        id="LinkAnular951183126"
        class="btn btn-danger btn-xs"
        role="button"
        onclick="fcn_popup_anular_comanda('951183126', 'X', '', '', '');"
        ><i class="far fa-trash-alt"></i> Anular</a
      >
    </div>
    <div class="comItemModif">
      <i class="fas fa-sticky-note" style="color: #00bcd4"></i> Salsas por favor
    </div>
    <div class="comItemModif">
      <i class="fas fa-angle-double-right txtNaranja"></i> Integración PEYA
      <i class="fas fa-angle-right txtNaranja"></i> ID 291347094
    </div>
  </div>
</template>

<script>
export default {
  name: "Comanda",
  props: {
    source: Object,
  },
};
</script>

<style>
</style>