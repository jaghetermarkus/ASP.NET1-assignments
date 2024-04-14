let forms = document.querySelectorAll("form");

forms.forEach((form) => {
  let inputs = form.querySelectorAll("input");
  inputs.forEach((input) => {
    input.addEventListener("keyup", (e) => {
      switch (e.target.type) {
        case "text":
          textValidation(e, e.target.dataset.valMinlengthMin);
          break;
        case "email":
          emailValidation(e);
          break;
        case "password":
          passwordValidation(e);
          break;
      }
    });
  });
});

const handleValidationOutput = (isValid, e, text = "") => {
  let span = document.querySelector(`[data-valmsg-for="${e.target.name}"]`);
  console.log("handleValidation");
  if (isValid) {
    console.log("handleValidation isValid");
    e.target.classList.remove("input-validation-error");
    e.target.classList.add("input-validation-valid");
    span.classList.remove("field-validation-error");
    span.classList.add("field-validation-valid");
    span.innerHTML = "Looks good!";
  } else {
    console.log("handleValidation notValid");
    e.target.classList.add("input-validation-error");
    e.target.classList.remove("input-validation-valid");
    span.classList.add("field-validation-error");
    span.classList.remove("field-validation-valid");
    span.innerHTML = text;
  }
};

const textValidation = (e, minLength = 1) => {
  console.log("textValidation");
  if (e.target.value.length > 0)
    handleValidationOutput(
      e.target.value.length >= minLength,
      e,
      e.target.dataset.valMinlength
    );
  else handleValidationOutput(false, e, e.target.dataset.valRequired);
};

const emailValidation = (e) => {
  const regEx =
    /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*\.[a-zA-Z]{2,}$/;
  console.log("emailValidation");
  if (e.target.value.length > 0)
    handleValidationOutput(
      regEx.test(e.target.value),
      e,
      e.target.dataset.valRegex
    );
  else handleValidationOutput(false, e, e.target.dataset.valRequired);
};

const passwordValidation = (e) => {
  const regEx = /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_])(?!.*\s).{8,}$/;

  if (e.target.dataset.valEqualtoOther && e.target.value.length > 0) {
    let compareFieldName = e.target.dataset.valEqualtoOther.split(".")[1];

    // Needs improvement --->
    if (document.querySelector(`[name='Password.${compareFieldName}']`)) {
      var compareField = document.querySelector(
        `[name='Password.${compareFieldName}']`
      );
    } else {
      var compareField = document.querySelector(`[name='${compareFieldName}']`);
    }
    // <---- Needs improvement

    if (compareField.value == e.target.value)
      handleValidationOutput(true, e, e.target.dataset.valEqualto);
    else handleValidationOutput(false, e, e.target.dataset.valEqualto);
  } else {
    if (e.target.value.length > 0)
      handleValidationOutput(
        regEx.test(e.target.value),
        e,
        e.target.dataset.valRegex
      );
    else handleValidationOutput(false, e, e.target.dataset.valRequired);
  }
};
