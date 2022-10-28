<template>
    <div class="view-container full-screen">
        <form class="h-100" @submit.prevent="handleLogin()">
            <div
                class="row flex-column h-100 align-items-center justify-content-start justify-content-lg-center"
            >
                <div class="col-auto mb-5">
                    <div class="telstar-logo large">
                        <img src="~@/assets/img/telstar-logo.png" />
                    </div>
                </div>
                <div class="col-12 col-lg-5 h-fit-content">
                    <CardContainer :blur="true">
                        <div class="row p-2 justify-content-center">
                            <div class="col-12 mb-2">
                                <div class="input-group input-group-lg">
                                    <input
                                        :placeholder="lang.placeholder.username"
                                        type="text"
                                        class="form-control"
                                        required="required"
                                    />
                                </div>
                            </div>
                            <div class="col-12 mb-5">
                                <div class="input-group input-group-lg">
                                    <input
                                        :placeholder="lang.placeholder.password"
                                        type="password"
                                        class="form-control"
                                        required="required"
                                    />
                                </div>
                            </div>
                            <div class="col-auto">
                                <button
                                    type="submit"
                                    class="btn btn-lg btn-telstar-primary px-5"
                                >
                                    {{ lang.login }}
                                </button>
                            </div>
                        </div>
                    </CardContainer>
                </div>
            </div>
        </form>
    </div>
</template>

<script>
import CardContainer from '@/components/CardContainer'
import lang from '@/utils/lang/langBroker'
import { login } from '@/state'

export default {
    name: 'LoginPage',
    components: { CardContainer },
    data() {
        return {
            lang: lang.current.Login,
        }
    },
    methods: {
        async handleLogin() {
            localStorage.setItem('isLoggedIn', '1')
            localStorage.setItem('loggedInUser', 'Jim')
            login.isLoggedIn = true
            login.loggedInUser = 'Jim'
            await this.$router.push('booking')
        },
    },
}
</script>

<style scoped></style>
