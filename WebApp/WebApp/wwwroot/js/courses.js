document.addEventListener("DOMContentLoaded", function () {
  select();
  search();
  // updateCourseFilter();
  // updateCoursesByFilter();

  // let selectedCategory = "@ViewBag.CurrentCategory";

  // if (selectedCategory) {
  //   let selectedOption = document.querySelector(
  //     `.option[data-value="${selectedCategory}"]`
  //   );
  //   if (selectedOption) {
  //     let select = document.querySelector(".select");
  //     let selected = select.querySelector(".selected");
  //     selected.textContent = selectedCategory;
  //   }
  // }
  // updateCourses();

  // const searchInput = document.getElementById("searchString");
  // searchInput.addEventListener("input", function () {
  //   const selectedCategory = document.querySelector(".selected").textContent;
  //   const searchString = this.value;
  //   updateCourses(selectedCategory, searchString);
  // });
});

function select() {
  try {
    let select = document.querySelector(".select");
    let selected = select.querySelector(".selected");
    let selectOptions = select.querySelector(".select-options");

    selected.addEventListener("click", function () {
      selectOptions.style.display =
        selectOptions.style.display === "block" ? "none" : "block";
    });

    let options = selectOptions.querySelectorAll(".option");
    options.forEach(function (option) {
      option.addEventListener("click", function () {
        selected.innerHTML = this.textContent;
        selectOptions.style.display = "none";
        let category = this.getAttribute("data-value");
        selected.setAttribute("data-value", category);
        // updateCoursesByFilter(category);
        updateCoursesByFilter();

        // console.log(category);
        // const selectedCategory = event.target.getAttribute("data-value");
        // const searchString = document.getElementById("searchString").value;
        // updateCourses(selectedCategory, searchString);
        // updateCoursesByFilter(category);
      });
    });

    // selectOptions.addEventListener("click", function (event) {
    //   if (event.target.classList.contains("option")) {
    //     let selectedCategory = event.target.getAttribute("data-value");
    //     selectedCategoryInput.value = selectedCategory;
    //     console.log(selectedCategory);
    //     document.getElementById("courseFilterForm").submit();
    //   }
    // });
    // selectOptions.addEventListener("click", function (event) {
    //   if (event.target.classList.contains("option")) {
    //     const selectedCategory = event.target.getAttribute("data-value");
    //     const searchString = document.getElementById("searchString").value;
    //     updateCourses(selectedCategory, searchString);
    //   }
    // });
  } catch {}
}

function search() {
  try {
    document
      .querySelector("#searchString")
      .addEventListener("keyup", function () {
        updateCoursesByFilter();
        // const searchValue = this.value;
        // const category =
        //   document
        //     .querySelector(".select .selected")
        //     .getAttribute("data-value") || "all";
        // console.log(category);
        // const url = `/course/courses?category=${encodeURIComponent(
        //   category
        // )}&searchString=${encodeURIComponent(searchValue)}`;

        // fetch(url)
        //   .then((res) => res.text())
        //   .then((data) => {
        //     const parser = new DOMParser();
        //     const dom = parser.parseFromString(data, "text/html");
        //     document.querySelector(".courses-wrapper").innerHTML =
        //       dom.querySelector(".courses-wrapper").innerHTML;

        //     const pagination = dom.querySelector(".pagination")
        //       ? dom.querySelector(".pagination").innerHTML
        //       : "";
        //     document.querySelector(".pagination").innerHTML = pagination;
        //   });
      });
  } catch {}
}

function updateCoursesByFilter() {
  const category =
    document.querySelector(".select .selected").getAttribute("data-value") ||
    "all";
  const searchValue = document.getElementById("searchString").value;
  const url = `/course/courses?category=${encodeURIComponent(
    category
  )}&searchString=${encodeURIComponent(searchValue)}`;

  fetch(url)
    .then((res) => res.text())
    .then((data) => {
      const parser = new DOMParser();
      const dom = parser.parseFromString(data, "text/html");
      document.querySelector(".courses-wrapper").innerHTML =
        dom.querySelector(".courses-wrapper").innerHTML;

      const pagination = dom.querySelector(".pagination")
        ? dom.querySelector(".pagination").innerHTML
        : "";
      document.querySelector(".pagination").innerHTML = pagination;
    });
}

// function updateCourses(category, searchValue) {
//   const url = `/course/courses?category=${encodeURIComponent(
//     category
//   )}&searchQuery=${encodeURIComponent(searchValue)}`;

//   fetch(url)
//     .then((res) => res.text())
//     .then((data) => {
//       const parser = new DOMParser();
//       const dom = parser.parseFromString(data, "text/html");

//       // Uppdatera kurslistan
//       const itemsContainer = document.querySelector(".items");
//       itemsContainer.innerHTML = dom.querySelector(".items").innerHTML;

//       // Uppdatera pagineringen om den finns
//       const paginationContainer = document.querySelector(".pagination");
//       if (dom.querySelector(".pagination")) {
//         paginationContainer.innerHTML =
//           dom.querySelector(".pagination").innerHTML;
//       } else {
//         paginationContainer.innerHTML = ""; // Ta bort pagineringen om den inte finns
//       }
//     })
//     .catch((error) => {
//       console.error("Fetch error:", error);
//     });
// }

// function updateCoursesByFilter(category) {
//   // Skapa en POST-förfrågan till kontrollermetoden med den valda kategorin
//   fetch("/Course/Courses", {
//     method: "POST",
//     headers: {
//       "Content-Type": "application/json",
//     },
//     body: JSON.stringify({ category: category }),
//   })
//     .then((response) => response.text())
//     .then((data) => {
//       // Uppdatera DOM med det nya innehållet från kontrollern
//       document.querySelector(".courses-wrapper").innerHTML = data;
//     })
//     .catch((error) => {
//       console.error("Error:", error);
//     });
// }
