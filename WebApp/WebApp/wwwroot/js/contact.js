document.addEventListener("DOMContentLoaded", function () {
  selectService();
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

function selectService() {
  try {
    let select = document.querySelector(".select-service");
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

        let selectedService = this.getAttribute("data-value");
        let hiddenInput = document.getElementById("selectedService");
        hiddenInput.value = selectedService;
        console.log(hiddenInput.value);
        // selected.setAttribute("data-value", service);
        // document
        //   .querySelector("#selectedService")
        //   .setAttribute("value", service);
        // console.log(
        //   document.querySelector("#selectedService").getAttribute("value")
        // );

        //   .setAttribute("data-value", service);

        // console.log(category);
        // const selectedCategory = event.target.getAttribute("data-value");
        // const searchString = document.getElementById("searchString").value;
        // updateCourses(selectedCategory, searchString);
        // updateCoursesByFilter(category);
      });
    });
  } catch {}
}
