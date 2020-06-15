<template>
    <div>
        <header class="masthead" style="background-image: url('https://images.unsplash.com/photo-1493770348161-369560ae357d?ixlib=rb-1.2.1&auto=format&fit=crop&w=1050&q=80')
    ">
            <div class="overlay"></div>
            <div class="container">
                <div class="row">
                    <div class="col-lg-8 col-md-10 mx-auto">
                        <div class="site-heading">
                            <h1>Food Blog</h1>
                            <span class="subheading">Najukusniji recepti na jednom mestu!</span>
                        </div>
                    </div>
                </div>
            </div>
        </header>
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-md-10 mx-auto">
                    <div 
                        class="post-preview"
                        v-for="recipe in recipes"
                        :key="recipe.id"
                    >
                        <router-link :to="{name: 'recipe', params: { id: recipe.id }}">
                            <h2 class="post-title">
                                {{ recipe.name }}
                            </h2>
                            <h3 class="post-subtitle">
                                {{ recipe.keyword }}
                            </h3>
                        </router-link>
                        <p class="post-meta">
                            Posted by
                            <a href="#">Admin</a>
                            on {{ formatedDate(recipe.postedOn) }}
                        </p>

                        <hr />
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
// @ is an alias to /src
    import HelloWorld from '@/components/HelloWorld.vue'

    import axios from 'axios';

    export default {
        name: 'home',
        components: {
            HelloWorld
        },
        data() {
            return {
                recipes: []
            }
        },
        methods: {
            formatedDate(date) {
                return new Date(date.replace('T', ' ')).toDateString()
            }
        },
        created() {
            axios.get('http://localhost:5000/api/r/recipe/')
                .then(response => {
                    this.recipes = response.data
                })
                .catch(e => {
                    console.error(e)
                })
        }
    }
</script>
