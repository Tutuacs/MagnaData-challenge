<script setup>
// Modal.vue imported from: https://tailwindcss.com/plus/ui-blocks/application-ui/overlays/modal-dialogs
// Icons from: https://heroicons.com/
import {
  Dialog,
  DialogPanel,
  DialogTitle,
  TransitionChild,
  TransitionRoot,
} from "@headlessui/vue";
import { CheckCircleIcon } from "@heroicons/vue/24/outline";

const props = defineProps({
  open: {
    type: Boolean,
    req: true,
  },
});

const emit = defineEmits(["close", "create"]);

const handleClose = () => {
  emit("close");
};

const handleCreate = () => {
  emit("create");
  emit("close");
};
</script>

<template>
  <div>
    <button
      class="rounded-md bg-white/10 px-2.5 py-1.5 text-sm font-semibold text-white inset-ring inset-ring-white/5 hover:bg-white/20"
      @click="open = true"
    >
      Open dialog
    </button>
    <TransitionRoot as="template" :show="open">
      <Dialog class="relative z-10" @close="handleClose">
        <TransitionChild
          as="template"
          enter="ease-out duration-300"
          enter-from="opacity-0"
          enter-to=""
          leave="ease-in duration-200"
          leave-from=""
          leave-to="opacity-0"
        >
          <div class="fixed inset-0 bg-gray-900/50 transition-opacity"></div>
        </TransitionChild>

        <div class="fixed inset-0 z-10 w-screen overflow-y-auto">
          <div
            class="flex min-h-full items-end justify-center p-4 text-center sm:items-center sm:p-0"
          >
            <TransitionChild
              as="template"
              enter="ease-out duration-300"
              enter-from="opacity-0 translate-y-4 sm:translate-y-0 sm:scale-95"
              enter-to=" translate-y-0 sm:scale-100"
              leave="ease-in duration-200"
              leave-from=" translate-y-0 sm:scale-100"
              leave-to="opacity-0 translate-y-4 sm:translate-y-0 sm:scale-95"
            >
              <DialogPanel
                class="relative transform overflow-hidden rounded-lg bg-gray-800 text-left shadow-xl outline -outline-offset-1 outline-white/10 transition-all sm:my-8 sm:w-full sm:max-w-xl"
              >
                <div class="bg-gray-800 px-4 pt-5 pb-4 sm:p-6 sm:pb-4">
                  <div>
                    <div class="flex items-center">
                      <div
                        class="mx-auto flex size-12 shrink-0 items-center justify-center rounded-full bg-red-500/10 sm:mx-0 sm:size-10"
                      >
                        <CheckCircleIcon
                          class="size-6 text-green-400"
                          aria-hidden="true"
                        />
                      </div>
                      <div
                        class="mt-3 text-center sm:mt-0 sm:ml-4 sm:text-left"
                      >
                        <DialogTitle
                          as="h3"
                          class="text-base font-semibold text-white"
                          >Create Todo</DialogTitle
                        >
                      </div>
                    </div>
                    <div class="flex flex-col items-center">
                      <div class="mt-4 w-9/10">
                        <div class="flex flex-col gap-2">
                          <label for="todo-description" class="text-white"
                            >Description</label
                          >
                        <input
                            type="text"
                            class="bg-white rounded w-full px-2 py-1 focus:outline-none focus:ring-2 focus:ring-green-500"
                            placeholder="Create API endpoint"
                            id="todo-description"
                        />
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                <div
                  class="bg-gray-700/25 px-4 py-3 sm:flex sm:flex-row-reverse sm:px-6"
                >
                  <button
                    type="button"
                    class="inline-flex w-full justify-center rounded-md bg-green-500 px-3 py-2 text-sm font-semibold text-white hover:bg-green-400 sm:ml-3 sm:w-auto"
                    @click="handleCreate"
                  >
                    Create
                  </button>
                  <button
                    type="button"
                    class="mt-3 inline-flex w-full justify-center rounded-md bg-white/10 px-3 py-2 text-sm font-semibold text-white inset-ring inset-ring-white/5 hover:bg-white/20 sm:mt-0 sm:w-auto"
                    @click="handleClose"
                    ref="cancelButtonRef"
                  >
                    Cancel
                  </button>
                </div>
              </DialogPanel>
            </TransitionChild>
          </div>
        </div>
      </Dialog>
    </TransitionRoot>
  </div>
</template>
