var tabControl = tabControl || {
    toTextHref: function () {
        var json_text_href = document.getElementById('json_text');
        var json_tree_href = document.getElementById('json_tree');
        var text_area = document.getElementById('text_area');
        var tree_area = document.getElementById('tree_area');
        json_text_href.style.backgroundColor = "orange";
        json_tree_href.style.backgroundColor = "";
        text_area.style.display = "block";
        tree_area.style.display = "none";
    },

    toTreeHref: function () {
        var json_text_href = document.getElementById('json_text');
        var json_tree_href = document.getElementById('json_tree');
        var text_area = document.getElementById('text_area');
        var tree_area = document.getElementById('tree_area');
        json_text_href.style.backgroundColor = "";
        json_tree_href.style.backgroundColor = "orange";
        text_area.style.display = "none";
        tree_area.style.display = "block";
    }
}