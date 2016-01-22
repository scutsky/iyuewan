//转码网址跳转
function clickurl(urlid, webRoot){
    if(!webRoot)
        webRoot = '';
    var win = window.open(webRoot+"/index.php?r=/t/go&url="+urlid);
    if(win==null){
        location.href=webRoot+"/index.php?r=/t/go&url="+urlid;
    }
}

              