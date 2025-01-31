// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Loader
function showLoading() {
    document.getElementById('loading').style.display = 'flex';
}

function hideLoading() {
    document.getElementById('loading').style.display = 'none';
}

document.addEventListener('DOMContentLoaded', function () {
    const forms = document.querySelectorAll('form');
    forms.forEach(form => {
        form.addEventListener('submit', function () {
            showLoading();
        });
    });

    const links = document.querySelectorAll('a');

    links.forEach(link => {

        link.addEventListener('click', function (event) {

            const href = link.getAttribute('href');

            if (!href || href.startsWith('#') ||
                href.startsWith('javascript:void(0)') ||
                link.dataset.bsToggle === 'modal' ||
                link.hasAttribute('download'))
                return;

            showLoading();
        });
    });
});

window.addEventListener('error', function () {
    hideLoading();
});