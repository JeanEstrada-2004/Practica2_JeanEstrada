document.addEventListener("DOMContentLoaded", () => {
    const form = document.querySelector("form");
    form.addEventListener("submit", (e) => {
        const age = document.querySelector("input[name='Age']");
        if (parseInt(age.value) < 0) {
            alert("La edad debe ser un número positivo.");
            e.preventDefault();
        }
    });
});
