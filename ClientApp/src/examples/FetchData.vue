<template>
  <v-card class="elevation-3 mt-3 pa-3">
    <v-card-title class="title justify-center">Remote Data</v-card-title>
    <v-card-text>
      <h2>This data comes from the SampleDataController</h2>
      <v-row>
        <v-col :md="8" :sm="12">
          <v-data-table
            :headers="headers"
            :items="weatherData"
            hide-default-footer
            :loading="loading"
            class="elevation-1"
          >
            <v-progress-linear v-slot:progress color="blue" indeterminate></v-progress-linear>
            <template v-slot:items="props">
              <td>{{ props.item.dateFormatted }}</td>
              <td>{{ props.item.temperatureC }}</td>
              <td>{{ props.item.temperatureF }}</td>
              <td>{{ props.item.summary }}</td>
            </template>
          </v-data-table>
        </v-col>
        <v-col :md="4" class="hidden-sm-and-down">
          <h3>Raw data:</h3>
          <p>
            <code style="width: 100%">{{weatherData}}</code>
          </p>
        </v-col>
      </v-row>
      <h3>Current Screen Size:</h3>
      <p class="d-flex d-sm-none">XS</p>
      <p class="d-none d-sm-flex d-md-none">SM</p>
      <p class="d-none d-md-flex d-lg-none">MD</p>
      <p class="d-none d-lg-flex d-xl-none">LG</p>
      <p class="d-none d-xl-flex">XL</p>
    </v-card-text>
    <v-card-actions>
      <v-btn @click="fetchWeatherData">Fetch Sample Data</v-btn>
    </v-card-actions>
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
      weatherData: [],
      loading: false,
      headers: [
        { text: "Date", value: "dateFormatted" },
        { text: "Temp. (C)", value: "temperatureC" },
        { text: "Temp. (F)", value: "temperatureF" },
        { text: "Summary", value: "summary" }
      ]
    };
  },
  //calculated values, auto reactive
  //functionName: function(){}
  //functionName: { get: function() {}, set: function(value){}}
  computed: {},
  //perform actions, not reactive to variables used
  //functionName: function(arg1,arg2){}
  methods: {
    fetchWeatherData: function() {
      this.loading = true;
      axios
        .get("/api/SampleData/WeatherForecasts")
        .then(response => {
          this.weatherData = response.data;
        })
        .finally(() => {
          this.loading = false;
        });
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
