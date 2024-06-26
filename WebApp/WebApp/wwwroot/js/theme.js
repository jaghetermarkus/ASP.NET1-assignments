function toggleTheme() {
  try {
    let mode = this.checked ? "dark" : "light";

    localStorage.setItem("mode", mode);
    sessionStorage.setItem("mode", mode);

    fetch(`/sitesettings/thememode?mode=${mode}`).then((res) => {
      if (res.ok) window.location.reload();
      else console.log("failed to switch theme mode");
    });
  } catch {}
}

function setSavedTheme() {
  try {
    let savedTheme = localStorage.getItem("theme");
    if (savedTheme === "dark") {
      document.body.classList.add("dark-mode");
    }
  } catch {}
}

document.querySelector("#switch-mode").addEventListener("click", toggleTheme);
