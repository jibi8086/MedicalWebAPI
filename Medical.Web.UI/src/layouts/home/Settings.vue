<template>
  <v-menu
    v-model="menu"
    :close-on-content-click="false"
    bottom
    left
    max-width="90%"
    min-width="275"
    offset-x
    offset-y
    origin="top right"
    transition="scale-transition"
  >
    <template v-slot:activator="{ attrs, on }">
      <v-card
        id="settings"
        class="py-2 px-4"
        color="#0000004D"
        dark
        flat
        style="position: fixed; top: 164px; right: -35px;"
        width="100"
        v-bind="attrs"
        v-on="on"
      >
        <!-- <v-icon large>
          mdi-cog
        </v-icon> -->
        Order Now
      </v-card>
    </template>

    <v-card class="py-2">
      <base-title
        align="center"
        title="ORDER ON CALL"
        space="0"
        style="color:#076C33"
      />

      <v-card-text>
        <v-item-group
          v-model="currentThemePrimary"
          class="d-flex justify-center"
        >
   <base-title
        align="center"
        title="TIMING"
        space="0"
      />
        </v-item-group>
<v-item-group>
  <base-title
        align="center"
        title="10am to 7pm"
        space="0"
                style="color:#076C33"
      />
</v-item-group>
<v-item-group>
  <base-title
        align="center"
        title="9947530292"
        space="0"
      />
</v-item-group>
      </v-card-text>
    </v-card>
  </v-menu>
</template>

<script>
  export default {
    name: 'HomeSettings',

    data () {
      return {
        colors: [
          this.$vuetify.theme.currentTheme.primary,
          '#9368e9',
          '#F4511E',
        ],
        menu: false,
      }
    },

    computed: {
      currentThemePrimary: {
        get () {
          return this.$vuetify.theme.currentTheme.primary
        },
        set (val) {
          const target = this.$vuetify.theme.isDark ? 'dark' : 'light'

          this.$vuetify.theme.themes[target].primary = val
        },
      },
    },
  }
</script>
