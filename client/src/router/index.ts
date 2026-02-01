import { createRouter, createWebHistory } from "vue-router";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      redirect: "/todo",
    },
    {
      path: "/todo",
      name: "todo",
      component: () => import("../pages/Todo/index.vue"),
    },
  ],
});

export default router;
