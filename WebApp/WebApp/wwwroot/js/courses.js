document.addEventListener("DOMContentLoaded", function () {
  select();
  search();
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
        updateCoursesByFilter();
      });
    });
  } catch {}
}

function search() {
  try {
    document
      .querySelector("#searchString")
      .addEventListener("keyup", function () {
        updateCoursesByFilter();
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

      const coursesWrapper = dom.querySelector(".courses-wrapper");
      if (coursesWrapper) {
        document.querySelector(".courses-wrapper").innerHTML =
          coursesWrapper.innerHTML;
      }

      const pagination = dom.querySelector(".pagination")
        ? dom.querySelector(".pagination").innerHTML
        : "";
      document.querySelector(".pagination").innerHTML = pagination;
    });
}
