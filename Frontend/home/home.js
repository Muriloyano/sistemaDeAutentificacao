function toggleMenu() {
    const menu = document.getElementById("userMenu");
    if (menu.style.display === "block") {
        menu.style.display = "none";
    } else {
        menu.style.display = "block";
    }
}

window.onclick = function(event) {
    if (!event.target.closest('.menu-container')) {
        const menu = document.getElementById("userMenu");
        if (menu) {
            menu.style.display = "none";
        }
    }
}

document.addEventListener('DOMContentLoaded', () => {
    const btnSair = document.getElementById('btnSair');

    if (btnSair) {
        btnSair.addEventListener('click', function(event) {
            event.preventDefault(); 
            
            localStorage.clear();
            sessionStorage.clear();

            window.location.href = 'login.html'; 
        });
    }
});