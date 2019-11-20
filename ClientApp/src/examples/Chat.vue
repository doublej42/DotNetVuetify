<template>
  <v-card class="elevation-3 mt-3 pa-3">
    <v-card-title class="title justify-center">{{status}}</v-card-title>
    <v-card-text>
      <v-text-field label="Your Name" v-model="sender" v-if="status == 'Join a Channel'"></v-text-field>
      <v-text-field
        label="Room Name"
        v-model="roomName"
        v-if="status == 'Join a Channel'"
        v-on:keyup.enter="joinChannel"
      >
        <template v-slot:append-outer>
          <v-btn
            :disabled="roomName.length < 3 || sender.length < 3"
            color="primary"
            @click="joinChannel"
          >Join</v-btn>
        </template>
      </v-text-field>
      <v-list>
        <v-list-item v-for="message in messages" :key="message.key">
          <v-list-item-avatar>
            <v-avatar :color="colors[hashCode(message.sender)%colors.length]" size="36">
              <span class="white--text headline">{{message.sender.substring(0,1)}}</span>
            </v-avatar>
          </v-list-item-avatar>
          <v-list-item-content>
            <v-list-item-title v-text="message.sender"></v-list-item-title>
            <v-list-item-subtitle v-text="message.message"></v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-card-text>
    <v-text-field
      label="Message"
      v-model="message"
      v-on:keyup.enter="sendMessage"
      v-if="status != 'Join a Channel'"
    >
      <template v-slot:append-outer>
        <v-btn :disabled="roomName.length == 0" color="primary" @click="sendMessage" fab small>></v-btn>
      </template>
    </v-text-field>
  </v-card>
</template>

<script>
//uncomment for vuex state management
//import { mapState, mapGetters, mapMutations, mapActions } from "vuex";
import axios from "axios";

export default {
  //Your local variables for use in the component
  data() {
    return {
      roomName: "",
      sender: "",
      message: "",
      colors: ["red", "purple", "indigo", "blue", "cyan", "teal", "green"],
      messages: [],
      status: "Join a Channel"
      // Some sample messages
      // messages:
      // [
      // {
      //     sender: "Jeff",
      //     message: "Short message"
      //   },
      //   {
      //     sender: "Bob",
      //     message: "This is a much longer message used to test layout of the the longer messages"
      //   }
      // ],
      // status: "Sample Output"
    };
  },
  //calculated values, auto reactive
  //functionName: function(){}
  //functionName: { get: function() {}, set: function(value){}}
  computed: {
    hashedRoom: function() {
      return this.hashCode(this.roomName);
    }
  },
  //perform actions, not reactive to variables used
  //functionName: function(arg1,arg2){}
  methods: {
    joinChannel: function() {
      if (this.roomName.length >= 3 || this.sender.length >= 3) {
        this.status = "Joined: " + this.roomName;
        this.fetchData();
      }
    },
    fetchData: function() {
      if (this.status != "Joined: " + this.roomName) {
        //the roomName doesn't match so dont' fetch untill they click join again
        this.status = "Join a Channel";
        return;
      }
      axios.get("/api/relay/" + this.hashedRoom).then(response => {
        //add the new message to the list of messages. Everything will react to this.
        this.messages = response.data;
        //start another pull looking for more data
        setTimeout(this.fetchData,1000);
      });
    },
    sendMessage: function() {
      if (this.status != "Joined: " + this.roomName) {
        //the roomName doesn't match so dont' fetch untill they click join again
        this.status = "Join a Channel";
        return;
      }
      axios.post("/api/relay", {
        room: this.hashedRoom,
        sender: this.sender,
        message: this.message
      });
      this.message = "";
    },
    hashCode: function(s) {
      for (var i = 0, h = 0; i < s.length; i++)
        h = (Math.imul(31, h) + s.charCodeAt(i)) | 0;
      return Math.abs(h);
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
