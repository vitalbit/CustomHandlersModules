var tree = tree || {

    openBranch: function (li_el) {
        var el = li_el.childNodes[1];
        el.style.display = "block";
        li_el.style.listStyleImage = "url(css/minus.gif)";
        li_el.setAttribute("onclick", 'tree.closeBranch(this)');
        event.cancelBubble = true;
    },

    closeBranch: function (li_el) {
        var el = li_el.childNodes[1];
        el.style.display = "none";
        li_el.style.listStyleImage = "url(css/plus.gif)";
        li_el.setAttribute("onclick", 'tree.openBranch(this)');
        event.cancelBubble = true;
    }
}