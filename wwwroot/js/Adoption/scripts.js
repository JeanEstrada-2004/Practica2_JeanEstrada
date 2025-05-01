document.addEventListener("DOMContentLoaded", () => {
    const form = document.querySelector("form");

    if (form) {
        form.addEventListener("submit", (e) => {
            const petSelect = document.querySelector("select[name='petId']");
            const adopterSelect = document.querySelector("select[name='adopterId']");

            if (!petSelect.value || !adopterSelect.value) {
                alert("Debes seleccionar una mascota y un adoptante.");
                e.preventDefault();
            }
        });
    }
});
