<template>
    <div id="recipe">
        <header class="masthead" style="background-image: url('https://images.unsplash.com/photo-1493770348161-369560ae357d?ixlib=rb-1.2.1&auto=format&fit=crop&w=1050&q=80')
    ">
            <div class="overlay"></div>
            <div class="container">
                <div class="row">
                    <div class="col-lg-8 col-md-10 mx-auto">
                        <div class="site-heading">
                            <h1>{{ recipe.name }}</h1>
                            <span class="subheading">{{ recipe.keyword }}</span>
                        </div>
                    </div>
                </div>
            </div>
        </header>

        <article>
            <div class="container">
                <div class="row">
                    <div class="col-lg-8 col-md-10 mx-auto">
                        <p>
                            {{ recipe.description }}
                        </p>
                    </div>
                </div>
            </div>
        </article>
    </div>
</template>

<script>
    import axios from 'axios';

    export default {
        name: 'recipe',
        props: ['id'],
        data() {
            return {
                recipe: {}
            }
        },
        created() {
            axios.get('http://localhost:5000/api/r/recipe/' + this.id)
                .then(response => {
                    this.recipe = response.data[0]
                })
                .catch(error => {
                    console.error(error)
                })
        }
    }
</script>