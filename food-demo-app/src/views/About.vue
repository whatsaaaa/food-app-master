<template>
  <div class="about">
      <header class="masthead" style="background-image: url('https://images.unsplash.com/photo-1493770348161-369560ae357d?ixlib=rb-1.2.1&auto=format&fit=crop&w=1050&q=80')
    ">
          <div class="overlay"></div>
          <div class="container">
              <div class="row">
                  <div class="col-lg-8 col-md-10 mx-auto">
                      <div class="site-heading">
                          <h1>Admin Dashboard</h1>
                      </div>
                  </div>
              </div>
          </div>
      </header>

      <div class="container">
        <div class="row">
            <v-data-table 
                :headers="headers"
                :items="recipes"
                style="width: 100%;"
            >
                <template v-slot:top>
                    <v-toolbar flat color="white">
                        <v-toolbar-title>Recepti</v-toolbar-title>
                        <v-spacer></v-spacer>
                        
                        <v-dialog v-model="dialog" max-width="500px">
                            <template v-slot:activator="{ on, attrs }">
                                <v-btn color="primary"
                                       dark
                                       class="mb-2"
                                       v-bind="attrs"
                                       v-on="on">Novi Recept</v-btn>
                            </template>
                            <v-card>
                                <v-card-title>
                                    <span class="headline">{{ formTitle }}</span>
                                </v-card-title>

                                <v-card-text>
                                    <v-container>
                                        <v-row>
                                            <v-col cols="12" sm="12" md="12">
                                                <v-text-field v-model="editedItem.name" label="Naziv Recepta"></v-text-field>
                                            </v-col>
                                            <v-col cols="12" sm="12" md="12">
                                                <v-textarea v-model="editedItem.description" label="Opis Recepta"></v-textarea>
                                            </v-col>
                                            <v-col cols="12" sm="12" md="12">
                                                <v-text-field v-model="editedItem.keyword" label="Tag"></v-text-field>
                                            </v-col>
                                        </v-row>
                                    </v-container>
                                </v-card-text>

                                <v-card-actions>
                                    <v-spacer></v-spacer>
                                    <v-btn color="blue darken-1" text @click="close">Cancel</v-btn>
                                    <v-btn color="blue darken-1" text @click="save">Save</v-btn>
                                </v-card-actions>
                            </v-card>
                        </v-dialog>
                    </v-toolbar>
                </template>
                <template v-slot:item.actions="{ item }">
                    <v-icon small
                            class="mr-2"
                            @click="editItem(item)">
                        mdi-pencil
                    </v-icon>
                    <v-icon small
                            @click="deleteItem(item)">
                        mdi-delete
                    </v-icon>
                </template>
            </v-data-table>
        </div>
      </div>
  </div>
</template>

<script>
    import axios from 'axios';

    export default {
        data: () => ({
            dialog: false,
            headers: [
                {
                    text: 'Naziv Recepta',
                    align: 'start',
                    sortable: false,
                    value: 'name',
                },
                { text: 'Opis Recepta', value: 'description' },
                { text: 'Tag', value: 'keyword' },
                { text: 'Datum Objave', value: 'postedOn' },
                { text: 'Actions', value: 'actions', sortable: false },
            ],
            recipes: [],
            editedIndex: -1,
            editedItem: {
                name: '',
                description: '',
                keyword: '',
            },
            defaultItem: {
                name: '',
                description: '',
                keyword: '',
            },
        }),

        computed: {
            formTitle() {
                return this.editedIndex === -1 ? 'Novi Recept' : 'Izmeni Recept'
            },
        },

        watch: {
            dialog(val) {
                val || this.close()
            },
        },

        created() {
            this.initialize()
        },

        methods: {
            initialize() {
                axios.get('http://localhost:5000/api/r/recipe/')
                    .then(response => {
                        this.recipes = response.data
                    })
                    .catch(error => {
                        console.error(error)
                    })
            },

            editItem(item) {
                this.editedIndex = this.recipes.indexOf(item)
                this.editedItem = Object.assign({}, item)
                this.dialog = true
            },

            deleteItem(item) {
                const index = this.recipes.indexOf(item)
                const deleteY = confirm('Are you sure you want to delete this item?')

                if (deleteY) {
                    this.recipes.splice(index, 1)

                    axios.delete('http://localhost:5000/api/r/recipe/' + item.id)
                        .then(response => {
                            this.initialize()
                        })
                }
            },

            close() {
                this.dialog = false
                this.$nextTick(() => {
                    this.editedItem = Object.assign({}, this.defaultItem)
                    this.editedIndex = -1
                })
            },

            save() {
                if (this.editedIndex > -1) {
                    Object.assign(this.recipes[this.editedIndex], this.editedItem)
                    axios.put('http://localhost:5000/api/r/recipe/' + this.editedItem.id, this.editedItem)
                        .then(response => {
                            this.initialize()
                        })
                } else {
                    this.recipes.push(this.editedItem)
                    axios.post('http://localhost:5000/api/r/recipe/', this.editedItem)
                        .then(response => {
                            this.initialize()
                        })
                }
                this.close()
            },
        },
    }
</script>