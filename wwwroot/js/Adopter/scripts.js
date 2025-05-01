document.addEventListener("DOMContentLoaded", () => {
    const form = document.querySelector("form");
    form.addEventListener("submit", (e) => {
        const fullName = document.querySelector("input[name='FullName']");
        if (fullName.value.trim() === "") {
            alert("El nombre completo es obligatorio.");
            e.preventDefault();
        }
    });
});
