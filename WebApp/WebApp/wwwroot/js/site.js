﻿document.addEventListener("DOMContentLoaded", () => {
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

    header.classList.remove("active");
  });

  handleProfileImageUpload();
  setActiveMenuItem();
});

function setActiveMenuItem() {
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
}

if (document.body.querySelector(".dark-mode")) {
  document.querySelector(".input-switch").classList.add("dark");
}

function handleProfileImageUpload() {
  try {
    let fileUploader = document.querySelector("#fileUploader");
    if (fileUploader != undefined) {
      fileUploader.addEventListener("change", function () {
        console.log(this.files);
        if (this.files.length > 0) {
          this.form.submit();
        }
      });
    }
  } catch (error) {}
}
