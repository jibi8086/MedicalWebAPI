<template>
  <div>
    <div v-if="login">
      <router-view />
    </div>
    <div v-else>
      <section
        id="login"
        class="medi-login"
      >
        <div class="login-left">
          <h3 class="login-left__title">
            Medical App
          </h3>
          <p class="login-left__description">
            self care tag line
          </p>
        </div>
        <div class="login-right">
          <form>
            <h2 class="login-right__title">
              Login
            </h2>
            <input
              v-model="username"
              type="text"
              placeholder="Username"
            >
            <input
              v-model="password"
              type="password"
              placeholder="Password"
            >
            <a
              href=""
              class="login-forgotpassword"
            >
              forgot password?
            </a>
            <button @click="userLogin">
              Log in
            </button>
          </form>
        </div>
      </section>
    </div>
  </div>
</template>

<script>
  import { mapActions } from 'vuex'
  export default {
    name: 'App',
    data: () => ({
      login: false,
      username: '',
      password: '',
    }),
    mounted () {
      // alert('test')
    },
    methods: {
      ...mapActions(['AuthenticateUser']),
      userLogin: function () {
        const _self = this
        const userDetails = {}
        userDetails.userName = this.username
        userDetails.password = this.password
        this.AuthenticateUser(userDetails).then(function (response) {
          if (response.success) {
            _self.login = true
          }
        })
        // this.login = true
      },
    },
  }
</script>
<style scoped>
/* Delete this after page integration : start */
.medi-login{
  position: fixed;
    left: 0;
    right: 0;
    bottom: 0;
    top: 0;
    z-index: 999;
}
/* Delete this after page integration : end */
.medi-login{
  --main-login-color: #097969;
  --main-button-color: #1a6b5f;
  --login-border-color: #aaaeae42;
  --login-placeholder-color: #e3e4e4;
   --login-linear-gradient: linear-gradient(45deg, #2fe0c7, transparent);
    font-family:sans-serif;
     width: 100vw;
    height: 100vh;
    border: 1px solid #d5c7f2;;
    border-radius: 4px;
    display: flex;
    background-color: #fff;
    align-items: center;
    justify-content: space-around;
}

.medi-login .login-left{
  width: 30%;
    height: 100%;
    display: flex;
    flex-direction: column;
    justify-content: center;
    background-color: var(--main-login-color);
    padding: 5rem;
    color: #fff;
    text-shadow: 0px 0 3px #00000047;
    font-size: 2rem;
    text-align: center;
    outline: 2px solid #ffffff8f;
    outline-offset: -2rem;
    position:relative;
    overflow: hidden;
  }

  .medi-login .login-left::before{
    content: '';
    position: absolute;
    width: 6em;
    height: 6em;
    border-radius: 50%;
    top: -3em;
    right: -3rem;
     background: #0a9884;
  }
  .medi-login .login-left::after{
    content: '';
    position: absolute;
    width: 2em;
    height: 2em;
    border-radius: 50%;
    top: 2em;
    right: 7rem;
    background: var( --login-linear-gradient);
  }
  .medi-login .login-left .login-left__title{
    font-size: 2.55rem;
    letter-spacing: .25rem;
  }
  .medi-login .login-left .login-left__description{
    font-size: 1rem;
    margin: 0.5rem;
  }
  .medi-login .login-right{
    width: 70%;
    height: 100%;
    display: flex;
    justify-content: center;
    padding: 5rem;
    position:relative;
  }
   .medi-login .login-right::after{
    content: '';
    position: absolute;
    width: 8em;
    height: 30em;
    bottom: -7em;
    right: -4rem;
    background: linear-gradient(45deg, #069e87, #044037);
    transform: rotate(36deg);
    outline: 6px solid #1a6b5f;
    outline-offset: 20px;
    box-shadow: 0 0 10px 6px #0b5c5133;
  }

  .medi-login .login-right .login-forgotpassword{
     color: var(--main-login-color);
     margin:.5rem 0;
     text-align: right;
     font-weight: 600;
  }

  .medi-login .login-right .login-right__title{
    color: var(--main-login-color);
    font-size: 2.05em;
    margin-bottom: 2.5rem;
  }
  .medi-login .login-right form{
    display: flex;
    flex-direction: column;
    width: 50%;
    justify-content: center;
  }

  .medi-login .login-right form input{
    border: 1px solid var(--login-border-color);
    padding: 0.75rem 1.25rem;
    border-radius: 0.25rem;
    margin-bottom: 2.5rem;
    margin-top: 1rem;
    }
    .medi-login .login-right form input::placeholder{
      color:--login-placeholder-color;
      font-size:0.9rem;
      letter-spacing: 1px;
      text-transform: lowercase;
      }
      .medi-login .login-right form button{
      text-transform: uppercase;
      font-size:1.15rem;
      background-color:var(--main-button-color) ;
      color: #fff;
      padding: .75rem 1.25rem;
      border-radius: .5rem;
      margin: 1rem 0;

      }
</style>
