// Função para exibir o loader
function showLoading() {
    document.getElementById('loading').style.display = 'flex';
}

// Função para ocultar o loader
function hideLoading() {
    document.getElementById('loading').style.display = 'none';
}

document.addEventListener('DOMContentLoaded', function () {
    // Mostrar o loader ao submeter formulários
    const forms = document.querySelectorAll('form');
    forms.forEach(form => {
        form.addEventListener('submit', function () {
            showLoading();
        });
    });

    // Mostrar o loader ao clicar em links
    const links = document.querySelectorAll('a');
    links.forEach(link => {
        link.addEventListener('click', function (event) {
            // Evitar ativar o loader para âncoras internas ou modais
            const href = link.getAttribute('href');
            if (!href || href.startsWith('#') || link.dataset.bsToggle === 'modal') return;

            // Exibir o loader
            showLoading();
        });
    });
});

// Ocultar o loader em caso de erro (exemplo para AJAX)
window.addEventListener('error', function () {
    hideLoading();
});