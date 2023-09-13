const IconosHeader = document.querySelector("#ActionLinks");
const MenuBtn = document.getElementById("MenuBtn");
const NavLateral = document.getElementById("NavLateral");
const btnCloseNav = document.getElementById("btnCloseNav");

let AnchoVentana = 0;

function RevisarAncho() {
    AnchoVentana = window.innerWidth;

    if (AnchoVentana > 699) {
        IconosHeader.style.display = "none";
        MenuBtn.style.display = "block";
    }
    else if (AnchoVentana <= 699) {
        IconosHeader.style.display = "flex";
        MenuBtn.style.display = "none";
        DesaparecerNav();
    }
}

const AparecerNav = () => {
    NavLateral.style.display = "flex";
    NavLateral.style.animation = "ancho 0.2s ease-in forwards";
}

const DesaparecerNav = () => {
    NavLateral.style.animation = "anchoReversa 0.2s ease-in forwards";
    setTimeout(() => {
        NavLateral.style.display = "none";
    }, 1000);
}

RevisarAncho();

window.onresize = () => RevisarAncho();

MenuBtn.onclick = () => AparecerNav();

btnCloseNav.onclick = () => DesaparecerNav();