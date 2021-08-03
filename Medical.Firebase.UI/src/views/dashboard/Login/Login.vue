<template>
  <div id="app">
    <v-app>
      <v-dialog
        v-model="dialog"
        persistent
        max-width="600px"
        min-width="360px"
      >
        <div>
          <v-tabs
            v-model="tab"
            show-arrows
            background-color="deep-purple accent-4"
            icons-and-text
            dark
            grow
          >
            <v-tabs-slider color="purple darken-4" />
            <v-tab
              v-for="(item, index) in tabs"
              :key="index"
            >
              <v-icon large>
                {{ item.icon }}
              </v-icon>
              <div class="text-caption py-1">
                {{ item.name }}
              </div>
            </v-tab>
            <v-tab-item>
              <v-card class="px-4">
                <v-card-text>
                  <v-form
                    ref="loginForm"
                    v-model="valid"
                    lazy-validation
                  >
                    <v-row>
                      <v-col cols="12">
                        <v-text-field
                          v-model="loginEmail"
                          :rules="loginEmailRules"
                          label="E-mail"
                          required
                        />
                      </v-col>
                      <v-col cols="12">
                        <v-text-field
                          v-model="loginPassword"
                          :append-icon="show1 ? 'eye' : 'eye-off'"
                          :rules="[rules.required, rules.min]"
                          :type="show1 ? 'text' : 'password'"
                          name="input-10-1"
                          label="Password"
                          hint="At least 8 characters"
                          counter
                          @click:append="show1 = !show1"
                        />
                      </v-col>
                      <v-col
                        class="d-flex xsm"
                        cols="12"
                        sm="6"
                      />
                      <v-spacer />
                      <span style="color: #aa0f09">{{ invalidUser }}</span>
                      <v-col
                        class="d-flex xsm align-end"
                        cols="12"
                        sm="3"
                      >
                        <v-btn
                          x-large
                          block
                          :disabled="!valid"
                          color="success"
                          @click="validateLogin"
                        >
                          Login
                        </v-btn>
                      </v-col>
                    </v-row>
                  </v-form>
                </v-card-text>
              </v-card>
            </v-tab-item>
            <v-tab-item>
              <v-card class="px-4">
                <v-card-text>
                  <v-form
                    ref="registerForm"
                    v-model="valid"
                    lazy-validation
                  >
                    <v-row>
                      <v-col
                        cols="12"
                        sm="6"
                        md="6"
                      >
                        <v-text-field
                          v-model="firstName"
                          :rules="nameRules"
                          label="First Name"
                          maxlength="20"
                          required
                        />
                      </v-col>
                      <v-col
                        cols="12"
                        sm="6"
                        md="6"
                      >
                        <v-text-field
                          v-model="lastName"
                          :rules="nameRules"
                          label="Last Name"
                          maxlength="20"
                          required
                        />
                      </v-col>
                      <v-col cols="12">
                        <v-text-field
                          v-model="email"
                          :rules="emailRules"
                          label="E-mail"
                          required
                        />
                      </v-col>
                      <v-col cols="12">
                        <v-text-field
                          v-model="password"
                          :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
                          :rules="[rules.required, rules.min]"
                          :type="show1 ? 'text' : 'password'"
                          name="input-10-1"
                          label="Password"
                          hint="At least 8 characters"
                          counter
                          @click:append="show1 = !show1"
                        />
                      </v-col>
                      <v-col cols="12">
                        <v-text-field
                          v-model="verify"
                          block
                          :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
                          :rules="[rules.required, passwordMatch]"
                          :type="show1 ? 'text' : 'password'"
                          name="input-10-1"
                          label="Confirm Password"
                          counter
                          @click:append="show1 = !show1"
                        />
                      </v-col>
                      <v-spacer />
                      <v-col
                        class="d-flex ml-auto xsm"
                        cols="12"
                        sm="3"
                      >
                        <v-btn
                          x-large
                          block
                          :disabled="!valid"
                          color="success"
                          @click="validateRegister"
                        >
                          Register
                        </v-btn>
                      </v-col>
                    </v-row>
                  </v-form>
                </v-card-text>
              </v-card>
            </v-tab-item>
          </v-tabs>
        </div>
      </v-dialog>
    </v-app>
  </div>
</template>
<script>
// import UserDataService from '../../Services/UserDataService'
// import { mapState, mapActions } from 'vuex'
  export default {
    data: () => ({
      dialog: true,
      tab: 0,
      tabs: [
        { name: 'Login', icon: 'mdi-account' },
        { name: 'Register', icon: 'mdi-account-outline' },
      ],
      valid: true,

      firstName: '',
      lastName: '',
      email: '',
      password: '',
      verify: '',
      loginPassword: '',
      loginEmail: '',
      loginEmailRules: [
        (v) => !!v || 'Required',
        (v) => /.+@.+\..+/.test(v) || 'E-mail must be valid',
      ],
      emailRules: [
        (v) => !!v || 'Required',
        (v) => /.+@.+\..+/.test(v) || 'E-mail must be valid',
      ],

      show1: false,
      nameRules: [
        (v) => !!v || 'Name is required',
        (v) => (v && v.length <= 10) || 'Name must be less than 10 characters',
      ],
      rules: {
        required: (value) => !!value || 'Required.',
        min: (v) => (v && v.length >= 8) || 'Min 8 characters',
      },
      EmployeeDetails: [],
      invalidUser: '',
    }),
  // computed: {
  //   passwordMatch () {
  //     return () => this.password === this.verify || 'Password must match'
  //   },
  //   ...mapState({
  //     userDetails: 'userDetails',
  //   }),
  // },
  // methods: {
  //   ...mapActions(['setUserDetails']),
  //   onDataChange (items) {
  //     const _EmployeeDetails = []

  //     items.forEach((item) => {
  //       const key = item.key
  //       const data = item.val()
  //       _EmployeeDetails.push({
  //         key: key,
  //         FirstName: data.FirstName,
  //         LastName: data.LastName,
  //         Email: data.Email,
  //         Password: data.Password,
  //       })
  //     })

  //     this.EmployeeDetails = _EmployeeDetails
  //     const result = this.EmployeeDetails.some(
  //       (s) => s.Email === this.loginEmail && s.Password === this.loginPassword,
  //     )
  //     if (result) {
  //       var index = this.EmployeeDetails.findIndex(
  //         (x) => x.Email === this.loginEmail,
  //       )
  //       this.setUserDetails(this.EmployeeDetails[index])
  //       this.$router.push({ name: 'Home' })
  //       this.invalidUser = ''
  //     } else {
  //       this.invalidUser = '* Invalid user name or password'
  //     }
  //   },
  //   validateLogin () {
  //     if (this.$refs.loginForm.validate()) {
  //       console.log('test')
  //       UserDataService.getAll().on('value', this.onDataChange)

  //     // console.log(res);
  //     //   this.$router.push({ name: "Home"})
  //     }
  //   },
  //   validateRegister () {
  //     if (this.$refs.registerForm.validate()) {
  //       var data = {
  //         FirstName: this.firstName,
  //         LastName: this.lastName,
  //         Email: this.email,
  //         Password: this.password,
  //       }
  //       UserDataService.create(data)
  //         .then(() => {
  //           alert('Employee Registred')
  //         })
  //         .catch((e) => {
  //           console.log(e)
  //         })
  //     }
  //   },
  //   reset () {
  //     this.$refs.form.reset()
  //   },
  //   resetValidation () {
  //     this.$refs.form.resetValidation()
  //   },
  // },
  }
</script>
