let searchForm = document.querySelector('.search-form');
document.querySelector('#search-btn').onclick = () => {
    searchForm.classList.toggle('active');
    shopcart.classList.remove('active');
    loginForm.classList.remove('active');
}

let shopcart = document.querySelector('.shopping-cart');
document.querySelector('#cart-btn').onclick = () => {
    shopcart.classList.toggle('active');
    searchForm.classList.remove('active');
    loginForm.classList.remove('active');
}

let loginForm = document.querySelector('.login-form');
document.querySelector('#login-btn').onclick = () => {
    loginForm.classList.toggle('active');
    shopcart.classList.remove('active');
    searchForm.classList.remove('active');
}
window.onscroll = () => {
    searchForm.classList.remove('active');
    shopcart.classList.remove('active');
    loginForm.classList.remove('active');
}