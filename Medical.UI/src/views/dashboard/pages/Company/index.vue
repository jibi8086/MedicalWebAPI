<template>
  <v-data-table
    :headers="headers"
    :items="companyDetails"
    sort-by="calories"
    class="elevation-1"
    :height="height"
  >
    <template v-slot:top>
      <v-toolbar
        flat
      >
        <v-toolbar-title>Company Details</v-toolbar-title>
        <v-divider
          class="mx-4"
          inset
          vertical
        />
        <v-spacer />
        <v-dialog
          v-model="dialog"
          persistent
          max-width="700px"
        >
          <template v-slot:activator="{ on, attrs }">
            <v-btn
              color="primary"
              dark
              class="mb-2"
              v-bind="attrs"
              v-on="on"
            >
              Add Company
            </v-btn>
          </template>
          <v-card>
            <v-card-title>
              <span class="text-h5">{{ formTitle }}</span>
            </v-card-title>
            <v-form
              ref="form"
              v-model="valid"
            >
              <v-card-text>
                <v-container>
                  <v-row>
                    <v-col
                      cols="12"
                      sm="6"
                      md="4"
                    >
                      <v-text-field
                        v-model="editedItem.companyName"
                        label="Company name"
                        :rules="nameRules"
                        required
                      />
                    </v-col>
                    <v-col
                      cols="12"
                      sm="6"
                      md="4"
                    >
                      <v-text-field
                        v-model="editedItem.companyCode"
                        label="Company code"
                        :rules="nameRules"
                        required
                      />
                    </v-col>
                    <v-col
                      cols="12"
                      sm="6"
                      md="4"
                    >
                      <v-text-field
                        v-model="editedItem.companyEmail"
                        label="Company email"
                        :rules="emailRules"
                        required
                      />
                    </v-col>
                    <v-col
                      cols="12"
                      sm="6"
                      md="4"
                    >
                      <v-text-field
                        v-model="editedItem.place"
                        label="Place"
                        :rules="nameRules"
                        required
                      />
                    </v-col>
                    <v-col
                      cols="12"
                      sm="6"
                      md="4"
                    >
                      <v-text-field
                        v-model="editedItem.city"
                        label="City"
                        required
                      />
                    </v-col>
                    <v-col
                      cols="12"
                      sm="6"
                      md="4"
                    >
                      <v-text-field
                        v-model="editedItem.state"
                        label="State"
                      />
                    </v-col> <v-col
                      cols="12"
                      sm="6"
                      md="4"
                    >
                      <v-text-field
                        v-model="editedItem.country"
                        label="Country"
                      />
                    </v-col> <v-col
                      cols="12"
                      sm="6"
                      md="4"
                    >
                      <v-text-field
                        v-model="editedItem.zipCode"
                        label="zipCode"
                      />
                    </v-col>
                  </v-row>
                </v-container>
              </v-card-text>
            </v-form>
            <v-card-actions>
              <v-spacer />
              <v-btn
                color="blue darken-1"
                text
                @click="close"
              >
                Cancel
              </v-btn>
              <v-btn
                color="blue darken-1"
                text
                @click="save"
              >
                Save
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
        <v-dialog
          v-model="dialogDelete"
          max-width="500px"
        >
          <v-card>
            <v-card-title class="text-h5">
              Are you sure you want to delete this item?
            </v-card-title>
            <v-card-actions>
              <v-spacer />
              <v-btn
                color="blue darken-1"
                text
                @click="closeDelete"
              >
                Cancel
              </v-btn>
              <v-btn
                color="blue darken-1"
                text
                @click="deleteItemConfirm"
              >
                OK
              </v-btn>
              <v-spacer />
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-toolbar>
    </template>
    <template v-slot:[`item.actions`]="{ item }">
      <v-icon
        small
        class="mr-2"
        @click="editItem(item)"
      >
        mdi-pencil
      </v-icon>
      <v-icon
        small
        @click="deleteItem(item)"
      >
        mdi-delete
      </v-icon>
    </template>
    <template v-slot:no-data>
      <v-btn
        color="primary"
        @click="initialize"
      >
        Reset
      </v-btn>
    </template>
  </v-data-table>
</template>
<script>
  import { mapActions } from 'vuex'
  export default {
    data: () => ({
      valid: false,
      dialog: false,
      dialogDelete: false,
      headers: [
        {
          text: 'Company Name',
          align: 'start',
          sortable: false,
          value: 'companyName',
        },
        { text: 'companyCode', value: 'companyCode' },
        { text: 'companyEmail', value: 'companyEmail' },
        { text: 'place', value: 'place' },
        { text: 'city', value: 'city' },
        { text: 'district', value: 'district' },
        { text: 'Actions', value: 'actions', sortable: false },
      ],
      desserts: [],
      editedIndex: -1,
      editedItem: {
        companyName: '',
        companyCode: '',
        companyEmail: '',
        place: '',
        city: '',
        district: '',
        state: '',
        country: '',
        zipCode: '',
      },
      defaultItem: {
        companyName: '',
        companyCode: '',
        companyEmail: '',
        place: '',
        city: '',
        district: '',
        state: '',
        country: '',
        zipCode: '',
      },
      email: '',
      emailRules: [
        v => !!v || 'E-mail is required',
        v => /.+@.+/.test(v) || 'E-mail must be valid',
      ],
      nameRules: [
        v => !!v || 'Name is required',
        v => (v && v.length <= 50) || 'Name must be less than 50 characters',
      ],
      companyDetails: [],
    }),

    computed: {
      formTitle () {
        return this.editedIndex === -1 ? 'Company Details' : 'Edit Company Details'
      },
      height () {
        switch (this.$vuetify.breakpoint.name) {
          case 'xs': return '220px'
          case 'sm': return '400px'
          case 'md': return '400px'
          case 'lg': return '600px'
          case 'xl': return '760px'
          default:return '500px'
        }
      },
    },

    watch: {
      dialog (val) {
        if (val && this.$refs.form !== undefined) {
          this.$refs.form.resetValidation()
        }
        val || this.close()
      },
      dialogDelete (val) {
        val || this.closeDelete()
      },
    },

    created () {
      const _self = this
      this.GetCompanyDetails().then(function (response) {
        if (response.success) {
          _self.companyDetails = response.data
        }
      })
    },

    methods: {
      ...mapActions(['CreateCompany', 'GetCompanyDetails']),

      editItem (item) {
        this.editedIndex = this.desserts.indexOf(item)
        this.editedItem = Object.assign({}, item)
        this.dialog = true
      },

      deleteItem (item) {
        this.editedIndex = this.desserts.indexOf(item)
        this.editedItem = Object.assign({}, item)
        this.dialogDelete = true
      },

      deleteItemConfirm () {
        this.desserts.splice(this.editedIndex, 1)
        this.closeDelete()
      },

      close () {
        this.dialog = false
        this.$nextTick(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        })
      },

      closeDelete () {
        this.dialogDelete = false
        this.$nextTick(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        })
      },

      save () {
        if (this.$refs.form.validate()) {
          const company = {}
          company.companyName = this.editedItem.companyName
          company.companyCode = this.editedItem.companyCode
          company.companyEmail = this.editedItem.companyEmail
          company.place = this.editedItem.place
          company.city = this.editedItem.city
          company.district = this.editedItem.district
          company.state = this.editedItem.state
          company.country = this.editedItem.country
          company.zipCode = this.editedItem.zipCode
          console.log(company)
          const _self = this
          this.CreateCompany(company).then(function (response) {
            if (response.success) {
              _self.GetCompanyDetails().then(function (response) {
                if (response.success) {
                  _self.companyDetails = response.data
                }
              })
              _self.close()
            }
          })

          // if (this.editedIndex > -1) {
          //   Object.assign(this.desserts[this.editedIndex], this.editedItem)
          // } else {
          //   this.desserts.push(this.editedItem)
          // }
          // this.close()
        }
      },
    },
  }
</script>
