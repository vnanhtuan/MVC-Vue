const HomeCarousel = {
    /* 👇 nhận prop images từ Razor */
    props: {
        images: { type: Array, required: true }
    },
    template: `
    <v-container>
      <v-carousel height="300">
        <v-carousel-item
          v-for="(img, i) in images"
          :key="i"
          :src="img.src"
          cover
        />
      </v-carousel>
    </v-container>
  `
};

// gắn lên window để layout dùng
window.HomeCarousel = HomeCarousel;