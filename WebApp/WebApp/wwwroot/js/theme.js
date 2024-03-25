function toggleTheme() {
  const body = document.body;
  body.classList.toggle("dark-mode");

  let theme = body.classList.contains("dark-mode") ? "dark" : "light";
  localStorage.setItem("theme", theme);
}

function setSavedTheme() {
  let savedTheme = localStorage.getItem("theme");
  if (savedTheme === "dark") {
    document.body.classList.add("dark-mode");
  }
}

document.getElementById("switch-mode").addEventListener("click", toggleTheme);
document.addEventListener("DOMContentLoaded", setSavedTheme);
