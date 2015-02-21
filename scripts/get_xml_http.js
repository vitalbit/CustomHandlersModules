var xmlHttp = xmlHttp || {

    getXmlHttp: function () {
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
    },

    login: function () {
        var req = xmlHttp.getXmlHttp();
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
    },

    loadJson: function () {
        var req = xmlHttp.getXmlHttp();
        var tab = document.getElementById('tab');
        var area = document.getElementById('json_area');
        var text = document.getElementById('text_area');
        var json_href = document.getElementById('json_text');
        var json_tree = document.getElementById('tree_area');
        req.onreadystatechange = function () {
            if (req.readyState == 4) {
                tab.style.display = 'block';
                area.style.display = 'block';
                json_href.style.backgroundColor = 'orange';
                var json = JSON.parse(req.responseText);
                json_tree.innerHTML = xmlHttp.toTree(json);
                text.innerHTML = req.responseText;
            }
        }
        req.open('POST', 'contact.axd', true);
        req.send('');
    },

    toTree: function (object) {
        var json = '<ul style="list-style-type: square">';
        for (prop in object) {
            var value = object[prop];
            switch (typeof (value)) {
                case "object":
                    //var token = Math.random().toString(36).substr(2, 16);
                    //json += "<li style='list-style-type:circle;'><a href='#" + token + "' data-toggle='collapse'>" + prop + "</a><div id='" + token + "' class='collapse'>" + to_tree(value) + "</div></li>";
                    json += "<li id='li_branch' style='list-style-image: url(css/plus.gif)' onclick='tree.openBranch(this)'>" + prop + '<div id="hide_branch" style="display: none">' + xmlHttp.toTree(value) + "</div></li>";
                    break;
                default:
                    json += '<li style="list-style-image: none" onclick="event.cancelBubble = true;">' + prop + ":" + value + "</li>";
            }
        }
        return json + "</ul>";
    }
};