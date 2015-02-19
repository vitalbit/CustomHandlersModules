function get_xml_http() {
    var xmlhttp;
    try {
        xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
    } catch (e) {
        try {
            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
        } catch (E) {
            xmlhttp = false;
        }
    }
    if (!xmlhttp && typeof XMLHttpRequest != 'undefined') {
        xmlhttp = new XMLHttpRequest();
    }
    return xmlhttp;
}

function login() {
    var req = get_xml_http();
    var log = document.getElementById('login');
    var pass = document.getElementById('password');
    var wrap = document.getElementById('login_wrap');
    var mes = document.getElementById('login_li');
    var loading = document.getElementById('loading');
    loading.style.display = 'block';
    req.onreadystatechange = function () {
        if (req.readyState == 4) {
            loading.style.display = 'none';
            wrap.style.display = 'none';
            mes.innerHTML = req.responseText;
        }
    }
    req.open('POST', 'auth.axd', true);
    req.withCredentials = true;
    req.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    req.send('login=' + log.value + '&password=' + pass.value);
}