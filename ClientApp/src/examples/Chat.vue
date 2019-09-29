<template>
  <v-card class="elevation-3 mt-3 pa-3">
    <v-card-title class="title justify-center">TITLE</v-card-title>
    <v-card-text>
        <v-text-field label="Room Name" v-model="roomName">
          <template v-slot:append-outer>
            <v-btn :disabled="roomName.length < 3" color="primary" @click="joinChannel">Join</v-btn>
            </template>
        </v-text-field>
      <v-list>
        <v-list-item v-for="message in messages" :key="message.key">
          <v-list-item-avatar>J</v-list-item-avatar>
          <v-list-item-content>
            <v-list-item-title v-text="message.sender"></v-list-item-title>
            <v-list-item-subtitle v-text="message.text"></v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-card-text>
  </v-card>
</template>

<script>
//uncomment for vuex state management
//import { mapState, mapGetters, mapMutations, mapActions } from "vuex";
import axios from 'axios'

export default {
  //Your local variables for use in the component
  data() {
    return {
      roomName: "",
      myMessage: "",
      messages: [],
      seqId: null
    };
  },
  //calculated values, auto reactive
  //functionName: function(){}
  //functionName: { get: function() {}, set: function(value){}}
  computed: {},
  //perform actions, not reactive to variables used
  //functionName: function(arg1,arg2){}
  methods: {
    joinChannel: function() {
      this.fetchData();
    },
    fetchData: function() {
      let result = axios.get('https://httprelay.io/mcast/z54unhji8',{
        withCredentials: true
      }).then(response => {
        console.log('fetchData',response)
      })
    }
  },
  /*  data passed in from external 
  propName: {
      type: Number,
      default: 42,
      required: false
  }
  */
  props: {},
  /* other components need
    you need to import the component first
    'component-a': ComponentA,
  */
  components: {}
};
</script>
