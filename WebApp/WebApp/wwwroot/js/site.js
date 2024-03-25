document.addEventListener("DOMContentLoaded", () => {
  let mobileMenu = document.querySelector(".burger-menu");
  let nav = document.querySelector("nav");
  let header = document.querySelector("header");

  mobileMenu.addEventListener("click", () => {
    mobileMenu.classList.toggle("active");
    mobileMenu.classList.toggle("fixed");

    nav.classList.toggle("active");
    header.classList.toggle("active");
  });

  window.addEventListener("resize", () => {
    mobileMenu.classList.remove("active");
    mobileMenu.classList.remove("fixed");

    // nav.classList.remove("active");
    header.classList.remove("active");
  });
});

var currentUrl = window.location.href;

if (currentUrl.includes("details")) {
  document.querySelector(".account").classList.add("active");
} else if (currentUrl.includes("security")) {
  document.querySelector(".security").classList.add("active");
} else if (currentUrl.includes("SavedCourses")) {
  document.querySelector(".courses").classList.add("active");
} else if (currentUrl.includes("courses")) {
  document.querySelector(".courses").classList.add("active");
} else if (currentUrl.includes("contact")) {
  document.querySelector(".contact").classList.add("active");
}

if (document.body.querySelector(".dark-mode")) {
  document.querySelector(".input-switch").classList.add("dark");
}
