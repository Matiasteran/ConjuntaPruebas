document.addEventListener("DOMContentLoaded", function () {
    var sidebar = document.getElementById("sidebar");
    var content = document.getElementById("content");
    var menuToggle = document.querySelector(".menu-toggle");
    var closeSidebar = document.getElementById("closeSidebar");

    // Función para abrir el menú
    menuToggle.addEventListener("click", function () {
        sidebar.classList.add("active");
        content.classList.add("active");
    });

    // Función para cerrar el menú
    closeSidebar.addEventListener("click", function () {
        sidebar.classList.remove("active");
        content.classList.remove("active");
    });
});