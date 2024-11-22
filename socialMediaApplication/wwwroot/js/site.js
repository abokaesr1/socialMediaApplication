var swiper = new Swiper(".multiple-slide-carousel", {
            loop: true,
        slidesPerView: 6,
        spaceBetween: 20,
        autoplay: true,
        navigation: {
            nextEl: ".multiple-slide-carousel .swiper-button-next",
        prevEl: ".multiple-slide-carousel .swiper-button-prev",
   },
        breakpoints: {
            1920: {
            slidesPerView: 9,
        spaceBetween: 20
    },
        1028: {
            slidesPerView: 7,
        spaceBetween: 20
    },
        990: {
            slidesPerView: 3,
        spaceBetween: 20
    }
  }
 });
