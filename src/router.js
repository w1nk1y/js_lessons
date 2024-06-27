import { createRouter, createWebHistory } from "vue-router";

import mainComponent from "@/components/postS.vue"

import makePostComponent from "@/components/make.vue"

import viewComponent from "@/components/show.vue"

const routes = [
    {
        "path": "/",
        "component": mainComponent,
        "props": true
    },
    {
        "path": "/post/create",
        "component": makePostComponent
    },
    {
        "path": "/post/:id",
        "component": viewComponent,
        "name": "show",
        "props": true
    }
]

const router = createRouter({
    routes,
    history : createWebHistory()
})

export default router;