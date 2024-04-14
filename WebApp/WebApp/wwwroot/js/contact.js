document.addEventListener("DOMContentLoaded", function () {
  selectService();
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
      });
    });
  } catch {}
}
