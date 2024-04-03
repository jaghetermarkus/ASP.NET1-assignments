document.addEventListener("DOMContentLoaded", function () {
  select();
  // updateCourseFilter();
  // updateCoursesByFilter();
});

function select() {
  try {
    let selectedCategoryInput = document.getElementById("selectedCategory");
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
        // updateCourseFilter();
        console.log(category);
        // updateCoursesByFilter(category);
      });
    });

    selectOptions.addEventListener("click", function (event) {
      if (event.target.classList.contains("option")) {
        let selectedCategory = event.target.getAttribute("data-value");
        selectedCategoryInput.value = selectedCategory;
        console.log(selectedCategory);
        document.getElementById("courseFilterForm").submit();
      }
    });
  } catch {}
}

// function updateCourseFilter() {
//   try {
//     if (category != "all") {
//       category.addEventListener("change", function () {
//         console.log(category);
//       });
//     }
//   } catch {}
// }

// function handleProfileImageUpload() {
//   try {
//     let fileUploader = document.querySelector("#fileUploader");
//     if (fileUploader != undefined) {
//       fileUploader.addEventListener("change", function () {
//         console.log(this.files);
//         if (this.files.length > 0) {
//           this.form.submit();
//         }
//       });
//     }
//   } catch (error) {}
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
