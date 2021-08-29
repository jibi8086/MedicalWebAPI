<template>
  <base-section
    id="affiliates"
    space="36"
  >
    <v-container>
      <base-section-heading title="Medicine Brands" />

      <v-slide-group>
        <template v-for="n in 5">
          <v-slide-item
            :key="n"
            class="align-self-center"
          >
            <base-img
              v-if="n==1"
              :src="require(`@/assets/mandkind.jpg`)"
              color="grey"
              contain
              height="60"
              width="170"
            />
            <base-img
              v-else-if="n==2"
              :src="require(`@/assets/cipla.png`)"
              color="grey"
              contain
              height="60"
              width="170"
            />
            <base-img
              v-else-if="n==3"
              :src="require(`@/assets/mandkind.jpg`)"
              color="grey"
              contain
              height="60"
              width="170"
            />
            <base-img
              v-else-if="n==4"
              :src="require(`@/assets/cipla.png`)"
              color="grey"
              contain
              height="60"
              width="170"
            />
            <base-img
              v-else
              :src="require(`@/assets/mandkind.jpg`)"
              color="grey"
              contain
              height="60"
              width="170"
            />
          </v-slide-item>

          <v-responsive
            v-if="n < 6"
            :key="`divider-${n}`"
            class="text-center"
            height="56"
            width="48"
          >
            <v-divider vertical />
          </v-responsive>
        </template>
      </v-slide-group>
    </v-container>
  </base-section>
</template>

<script>
  export default {
    name: 'SectionAffiliates',
    data: () => ({
      items: [],
    }),
  }
</script>
