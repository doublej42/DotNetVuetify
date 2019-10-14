<template>
  <v-card class="elevation-3 mt-3 pa-3">
    <v-card-title class="title justify-center">TITLE</v-card-title>
    <v-card-text></v-card-text>
  </v-card>
</template>

<script>
//uncomment for vuex state management
//import { mapState, mapGetters, mapMutations, mapActions } from "vuex";

export default {
  //Your local variables for use in the component
  data() {
    return {};
  },
  //calculated values, auto reactive
  //functionName: function(){}
  //functionName: { get: function() {}, set: function(value){}}
  computed: {},
  //perform actions, not reactive to variables used
  //functionName: function(arg1,arg2){}
  methods: {},
  /*  data passed in from external 
  propName: {
      type: Number,
      default: 42,
      required: false
  }
  */
  props: {},
  /* other components
    you need to import the component first
    'component-a': ComponentA,
  */
  components: {}
};
</script>
