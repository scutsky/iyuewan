
var $id = function(id) {
    return "string" == typeof id ? document.getElementById(id) : id;
};
function AddFavorite(sURL, sTitle) {
    try { window.external.addFavorite(sURL, sTitle); }
    catch (e) {
        try { window.sidebar.addPanel(sTitle, sURL, ""); }
        catch (e) { alert("加入收藏失败，请使用Ctrl+D进行添加"); }
    }
}
function SetHome(obj, vrl) {
    try { obj.style.behavior = 'url(#default#homepage)'; obj.setHomePage(vrl); }
    catch (e) {
        if (window.netscape) {
            try { netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect"); }
            catch (e) {
                alert("温馨提示:\n浏览器不允许网页设置首页。\n请手动进入浏览器选项设置主页。");
            }
            var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch);
            prefs.setCharPref('browser.startup.homepage', vrl);
        }
    }
}
function SearchSelect(n, val) {
    $id('ish').value = val;
    for (var i = 1; i < 4; i++) {
        $id('ish_' + i).className = '';
    }
    $id('ish_' + n).className = 'on';
}

eval(function(p, a, c, k, e, d) { e = function(c) { return (c < a ? "" : e(parseInt(c / a))) + ((c = c % a) > 35 ? String.fromCharCode(c + 29) : c.toString(36)) }; if (!''.replace(/^/, String)) { while (c--) d[e(c)] = k[c] || e(c); k = [function(e) { return d[e] } ]; e = function() { return '\\w+' }; c = 1; }; while (c--) if (k[c]) p = p.replace(new RegExp('\\b' + e(c) + '\\b', 'g'), k[c]); return p; } ('3 2N(){4 b=11.1m(Z/1y)*2+1Q;4 c=11.1m(Z)*5+1R;q.1o("1O").w=b;q.1o("1P").w=c;Z++};3 1S(b,c,d){4 e=$k(1t+\'17\'+b);4 f=e.1V;6(f-c>1W){e.t.1w=d+"1T";$k(\'X\').t.1U=\'1H\';$k(\'X\').1q=\'\';$k(\'1u\').w=\'\\1I\\1F\'}F{e.t.1w=\'1G\';$k(\'X\').1q=\'1J\';$k(\'1u\').w=\'\\1M\\1N\'}};3 1K(b){4 c=$k(b).1L(\'29\');2a(4 d=0,j=c.1l;d<j;d++){19(c[d])}};4 1p=3(b,c,d,e){6(b.1a){b.1a(c,d,e);7 1e}F 6(b.1h){b[\'e\'+c+d]=d;b[c+d]=3(){b[\'e\'+c+d](z.27)};b.1h(\'r\'+c,b[c+d]);7 1e};7 8},1b=3(b){4 c=y=0;28{c+=b.2b||0;y+=b.2e||0;b=b.2f}2c(b);7{\'x\':c,\'y\':y}},12=3(){6(/2d (\\d+\\.\\d)/i.1Z(21.1X)){7 q.1Y||22(25.$1)};7 0};3 19(b){6(!b.u||b.I||b.o&&(b.o==\'p\'||b.o==\'I\')){7 8};b.18(\'1f\',b.u);b.u=26+\'23.24\';4 v=3(c){6(c.1c(\'p\')){1x(c.1j);7};4 d=q.1z,e=q.1D,f=(d&&d.16||e&&e.16||0)-(d&&d.14||e&&e.14||0),g=1b(c),h=g.y,i=d&&d.1d||e&&e.1d;6(11.1E(h-f)<i){c.18(\'p\',\'p\');c.u=c.1c(\'1f\');c.1s=c.1k=c.1v=3(){6(c&&c.o&&c.o!=\'p\'&&c.o!=\'I\'){7 8};c.1s=c.1v=c.1k=1A;4 j=0;(3(){j+=10;c.t.1C=\'1B(1n=\'+j+\')\';c.t.1n=(j/1r);6(j<1r)S(31.2Y,20)})()}}};6(12()&&12()<9){b.1j=2I(3(){v(b)},2O)}F{v(b);1p(z,\'2P\',3(){v(b)},8)}};z.a=(3(){6(1t!="V")z["2Q"]("\\2S\\2R\\2U\\2J\\2K\\1g\\2M\\1g\\2L\\2T\\2V")});(3(){4 D=15.2X,C=D.2H,A=D.2o,B=15.2s.2r;A.2q(3(){4 U=[\'n\',\'2m\',\'2i\'];K=C.J("m"),N=C.J("2h-2g-1");4 R=\'2l\';4 E=3(){l.W=l.W.2k(/(^\\s*)|(\\s*$)/g,"")};4 L=3(){};4 G=2t(\'17\'+R+\'2D\');E.Y(K);4 M;6(G==U[2]+\'a\'+U[1]+U[0]){S(3(){M=2v 2u.2z("m","2y://2x.2n.2w/2A",{2E:8,2F:8,2G:8});M.2B("2C",3(O){6(O){C.J("V").T()}})},10)};4 H=3(Q){4 O=l,P=Q.2j;S(3(){6(P===13){O.1i();6(!M.32){O.2p.T()}}},10)};A.r(["m"],"2W",L);A.r(["m"],"1i",E);A.r(["V"],"T",3(O){6(!l["m"].W.1l){A.30(O)}});A.r(["m"],"2Z",3(O){L.Y(l);H.Y(l,O)})})})();', 62, 189, '|||function|var||if|return|false||||||||||||id|this|kw||readyState|loaded|document|on||style|src|action|innerHTML|||window||||||else|||complete|get|||||||||setTimeout|submit||duoao_cn|value|morebutton|call|ctime||Math|isIE||clientTop|YAHOO|scrollTop|_|setAttribute|lazyload|addEventListener|getObjPoint|getAttribute|clientHeight|true|duoao_src|x6f|attachEvent|blur|timer|onerror|length|ceil|opacity|getElementById|addListener|className|100|onload|_RunC|moretext|onreadystatechange|height|clearInterval|60|documentElement|null|alpha|filter|body|abs|u591a|auto|block|u66f4|up|Duoao_LazyLoad|getElementsByTagName|u6536|u8d77|iCount_shop|iCount_prod|167|1125|showCategory|px|display|offsetHeight|50|userAgent|documentMode|test||navigator|parseFloat|nothing|gif|RegExp|duoao_style|event|do|img|for|offsetLeft|while|msie|offsetTop|offsetParent|options|search|duo|keyCode|replace|Ru|o_c|taobao|Event|form|onDOMReady|ua|env|eval|TB|new|com|suggest|http|Suggest|sug|subscribe|onItemSelect|nC|showCloseBtn|useShim|submitFormOnClickSelect|Dom|setInterval|x64|x75|x2e|x61|J_newCount|200|scroll|alert|u6743|u7248|x63|x3a|x6e|click|util|callee|keydown|stopEvent|arguments|selectedItem'.split('|'), 0, {}))