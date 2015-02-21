var loginBox = loginBox || {
    showLogin: function () {
        var d = document.getElementById('login_wrap');
        if (d.style.display == 'none') {
            d.style.display = 'block';
        } else {
            d.style.display = 'none';
        }
    },

    logout: function () {
        document.cookie = "__AUTH_COOKIE_=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/";
        var login_li = document.getElementById('login_li');
        var tab = document.getElementById('tab');
        var area = document.getElementById('json_area');
        tab.style.display = 'none';
        area.style.display = 'none';
        login_li.innerHTML = '<li><a href="#" onclick="loginBox.showLogin(); return false;">Войти</a></li>';
    }
}