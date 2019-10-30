<template>
    <div>{{ msg }}</div>
</template>

<script lang="ts">
    import { Vue, Component, Prop } from 'vue-property-decorator'

    @Component
    export default class HeaderComponent extends Vue {

        @Prop() msg: string = "";

        constructor() {
            super();

            this.msg = "123";
        }

    }

</script>
