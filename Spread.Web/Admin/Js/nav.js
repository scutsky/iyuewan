var preClassName = ""; 
function list_sub_detail(Id, item) 
{ 
if(preClassName != "") 
{ 
getObject(preClassName).className = "left_back" 
} 
if(getObject(Id).className == "left_back") 
{ 
getObject(Id).className = "left_back_onclick"; 
outlookbar.getbyitem(item); 
preClassName = Id 
} 
} 
function getObject(objectId) 
{ 
if(document.getElementById && document.getElementById(objectId)) 
{ 
return document.getElementById(objectId) 
} 
else if(document.all && document.all(objectId)) 
{ 
return document.all(objectId) 
} 
else if(document.layers && document.layers[objectId]) 
{ 
return document.layers[objectId] 
} 
else 
{ 
return false 
} 
} 
function outlook() 
{ 
this.titlelist = new Array(); 
this.itemlist = new Array(); 
this.addtitle = addtitle; 
this.additem = additem; 
this.getbytitle = getbytitle; 
this.getbyitem = getbyitem; 
this.getdefaultnav = getdefaultnav 
} 
function theitem(intitle, insort, inkey, inisdefault) 
{ 
this.sortname = insort; 
this.key = inkey; 
this.title = intitle; 
this.isdefault = inisdefault 
} 
function addtitle(intitle, sortname, inisdefault) 
{ 
outlookbar.itemlist[outlookbar.titlelist.length] = new Array(); 
outlookbar.titlelist[outlookbar.titlelist.length] = new theitem(intitle, sortname, 0, inisdefault); 
return(outlookbar.titlelist.length - 1) 
} 
function additem(intitle, parentid, inkey) 
{ 
if(parentid >= 0 && parentid <= outlookbar.titlelist.length) 
{ 
insort = "item_" + parentid; 
outlookbar.itemlist[parentid][outlookbar.itemlist[parentid].length] = new theitem(intitle, insort, inkey, 0); 
return(outlookbar.itemlist[parentid].length - 1) 
} 
else additem = - 1 
} 
function getdefaultnav(sortname) 
{ 
var output = ""; 
for(i = 0; i < outlookbar.titlelist.length; i ++ ) 
{ 
if(outlookbar.titlelist[i].isdefault == 1 && outlookbar.titlelist[i].sortname == sortname) 
{ 
output += "<div class=list_tilte id=sub_sort_" + i + " onclick=\"hideorshow('sub_detail_"+i+"')\">"; 
output += "<span>" + outlookbar.titlelist[i].title + "</span>"; 
output += "</div>"; 
output += "<div class=list_detail id=sub_detail_" + i + "><ul>"; 
for(j = 0; j < outlookbar.itemlist[i].length; j ++ ) 
{ 
output += "<li id=" + outlookbar.itemlist[i][j].sortname + j + " onclick=\"changeframe('"+outlookbar.itemlist[i][j].title+"', '"+outlookbar.titlelist[i].title+"', '"+outlookbar.itemlist[i][j].key+"')\"><a href=#>" + outlookbar.itemlist[i][j].title + "</a></li>" 
} 
output += "</ul></div>" 
} 
} 
getObject('right_main_nav').innerHTML = output 
} 
function getbytitle(sortname) 
{ 
var output = "<ul>"; 
for(i = 0; i < outlookbar.titlelist.length; i ++ ) 
{ 
if(outlookbar.titlelist[i].sortname == sortname) 
{ 
output += "<li id=left_nav_" + i + " onclick=\"list_sub_detail(id, '"+outlookbar.titlelist[i].title+"')\" class=left_back>" + outlookbar.titlelist[i].title + "</li>" 
} 
} 
output += "</ul>"; 
getObject('left_main_nav').innerHTML = output 
} 
function getbyitem(item) 
{ 
var output = ""; 
for(i = 0; i < outlookbar.titlelist.length; i ++ ) 
{ 
if(outlookbar.titlelist[i].title == item) 
{ 
output = "<div class=list_tilte id=sub_sort_" + i + " onclick=\"hideorshow('sub_detail_"+i+"')\">"; 
output += "<span>" + outlookbar.titlelist[i].title + "</span>"; 
output += "</div>"; 
output += "<div class=list_detail id=sub_detail_" + i + " style='display:block;'><ul>"; 
for(j = 0; j < outlookbar.itemlist[i].length; j ++ ) 
{ 
output += "<li id=" + outlookbar.itemlist[i][j].sortname + "_" + j + " onclick=\"changeframe('"+outlookbar.itemlist[i][j].title+"', '"+outlookbar.titlelist[i].title+"', '"+outlookbar.itemlist[i][j].key+"')\"><a href=#>" + outlookbar.itemlist[i][j].title + "</a></li>" 
} 
output += "</ul></div>" 
} 
} 
getObject('right_main_nav').innerHTML = output 
} 
function changeframe(item, sortname, src) 
{ 
if(item != "" && sortname != "") 
{ 
window.top.frames['mainFrame'].getObject('show_text').innerHTML = sortname + "  <img src=images/slide.gif broder=0 />  " + item 
} 
if(src != "") 
{ 
window.top.frames['manFrame'].location = src 
} 
} 
function hideorshow(divid) 
{ 
subsortid = "sub_sort_" + divid.substring(11); 
if(getObject(divid).style.display == "none") 
{ 
getObject(divid).style.display = "block"; 
getObject(subsortid).className = "list_tilte" 
} 
else 
{ 
getObject(divid).style.display = "none"; 
getObject(subsortid).className = "list_tilte_onclick" 
} 
} 
function initinav(sortname) 
{ 
outlookbar.getdefaultnav(sortname); 
outlookbar.getbytitle(sortname); 
//window.top.frames['manFrame'].location = "manFrame.html" 
}

// 导航栏配置文件
var outlookbar=new outlook();
var t;


t=outlookbar.addtitle('系统设置','中文一系统设置',1)
outlookbar.additem('系统参数设置',t,'Config/Admin_config.aspx')
outlookbar.additem('系统日志管理',t,'Manage/LogList.aspx')

t=outlookbar.addtitle('中文一查询分析器','中文一系统设置',2)
outlookbar.additem('查询分析器',t,'backup/SqlSet.aspx')


t=outlookbar.addtitle('中文一管理员管理','中文一系统设置',3)
outlookbar.additem('管理员管理',t,'Manage/List.aspx')
outlookbar.additem('添加管理员',t,'Manage/Add.aspx')





t=outlookbar.addtitle('中文一新闻管理','栏目管理',1)
outlookbar.additem('添加新闻分类',t,'Article/AddArticle_type.aspx')
outlookbar.additem('新闻分类管理',t,'Article/List_type.aspx')
outlookbar.additem('发布新闻',t,'Article/Add.aspx')

outlookbar.additem('新闻管理',t,'Article/List.aspx')

t=outlookbar.addtitle('中文一广告管理','栏目管理',2)
outlookbar.additem('增加广告位',t,'Advertising/AdvAdd.aspx')
outlookbar.additem('编辑广告位',t,'Advertising/AdvEdit.aspx')
outlookbar.additem('广告位列表',t,'Advertising/AdvList.aspx')
outlookbar.additem('调用广告示例',t,'Advertising/AdvView.aspx')
outlookbar.additem('发布广告',t,'Advertising/BarAdd.aspx')
outlookbar.additem('编辑广告',t,'Advertising/BarEdit.aspx')
outlookbar.additem('广告列表',t,'Advertising/BarList.aspx')



t=outlookbar.addtitle('英文一新闻管理','栏目管理',3)
outlookbar.additem('添加新闻分类',t,'Article/enAddArticle_type.aspx')
outlookbar.additem('新闻分类管理',t,'Article/en_List_type.aspx')
outlookbar.additem('发布新闻',t,'Article/en_Add.aspx')
outlookbar.additem('新闻管理',t,'Article/en_List.aspx')

t=outlookbar.addtitle('英文一广告管理','栏目管理',4)
outlookbar.additem('增加广告位',t,'Advertising/en_AdvAdd.aspx')
outlookbar.additem('编辑广告位',t,'Advertising/en_AdvEdit.aspx')
outlookbar.additem('广告位列表',t,'Advertising/en_AdvList.aspx')
outlookbar.additem('调用广告示例',t,'Advertising/en_AdvView.aspx')
outlookbar.additem('发布广告',t,'Advertising/en_BarAdd.aspx')
outlookbar.additem('编辑广告',t,'Advertising/en_BarEdit.aspx')
outlookbar.additem('广告列表',t,'Advertising/en_BarList.aspx')



t=outlookbar.addtitle('中文一产品管理','中文一内容管理',1)
outlookbar.additem('添加商品',t,'Goods/Add.aspx')
outlookbar.additem('商品管理',t,'Goods/List.aspx')
outlookbar.additem('添加商品分类信息',t,'Menu/Add.aspx')
outlookbar.additem('商品分类信息',t,'Menu/List.aspx')

t=outlookbar.addtitle('中文一关键字管理','中文一内容管理',2)
outlookbar.additem('增加关键字',t,'Keyword/Add.aspx')
outlookbar.additem('关键字列表',t,'Keyword/List.aspx')
outlookbar.additem('关键字类别列表',t,'Keyword/TagCateList.aspx')

t=outlookbar.addtitle('中文一友情链接','中文一内容管理',3)
outlookbar.additem('添加链接',t,'Links/Add.aspx')
outlookbar.additem('编辑链接',t,'Links/Edit.aspx')
outlookbar.additem('链接列表',t,'Links/List.aspx')





t=outlookbar.addtitle('英文一系统设置','英文一系统设置',1)
outlookbar.additem('系统参数设置',t,'Config/en_Admin_config.aspx')
outlookbar.additem('系统日志管理',t,'Manage/en_LogList.aspx')

t=outlookbar.addtitle('英文一查询分析器','英文一系统设置',2)
outlookbar.additem('查询分析器',t,'backup/en_SqlSet.aspx')



t=outlookbar.addtitle('英文一管理员管理','英文一系统设置',3)
outlookbar.additem('管理员管理',t,'Manage/en_List.aspx')
outlookbar.additem('添加管理员',t,'Manage/en_Add.aspx')




t=outlookbar.addtitle('英文一商品管理','英文一内容管理',1)
outlookbar.additem('添加商品',t,'Goods/en_Add.aspx')
outlookbar.additem('商品管理',t,'Goods/en_List.aspx')
outlookbar.additem('添加商品分类信息',t,'Menu/en_Add.aspx')
outlookbar.additem('商品分类信息',t,'Menu/en_List.aspx')

t=outlookbar.addtitle('英文一关键字管理','英文一内容管理',2)
outlookbar.additem('增加关键字',t,'Keyword/en_Add.aspx')
outlookbar.additem('关键字列表',t,'Keyword/en_List.aspx')
outlookbar.additem('关键字类别列表',t,'Keyword/en_TagCateList.aspx')


t=outlookbar.addtitle('英文一友情链接','英文一内容管理',3)
outlookbar.additem('添加链接',t,'Links/en_Add.aspx')
outlookbar.additem('编辑链接',t,'Links/en_Edit.aspx')
outlookbar.additem('链接列表',t,'Links/en_List.aspx')

t=outlookbar.addtitle('中文一企业信息','中文一关于我们',1)
//outlookbar.additem('添加企业信息',t,'about/contantadd.aspx')
outlookbar.additem('企业信息管理',t,'about/contant.aspx')

t=outlookbar.addtitle('中文一联系我们','中文一关于我们',2)
//outlookbar.additem('添加信息',t,'about/theme_add.aspx')

outlookbar.additem('信息管理',t,'about/themesetting.aspx')

t=outlookbar.addtitle('中文一留言管理','中文一关于我们',3)
outlookbar.additem('留言列表',t,'about/liuyan.aspx')

t=outlookbar.addtitle('企业信息','英文一关于我们',1)
//outlookbar.additem('添加企业信息',t,'about/en_contantadd.aspx')
outlookbar.additem('企业信息管理',t,'about/encontant.aspx')

t=outlookbar.addtitle('联系我们','英文一关于我们',2)
//outlookbar.additem('添加信息',t,'about/en_theme_add.aspx')
outlookbar.additem('信息管理',t,'about/en_themesetting.aspx')

t=outlookbar.addtitle('英文一留言管理','英文一关于我们',3)
outlookbar.additem('留言列表',t,'en_message_list.aspx')

t=outlookbar.addtitle('生成中文','静态管理',1)
outlookbar.additem('生成中文首页',t,'html/html_index.aspx')
outlookbar.additem('生成中文栏目',t,'html_items.asp')
outlookbar.additem('生成中文内容',t,'html_article.asp')
outlookbar.additem('生成中文所有',t,'html_all.asp')
t=outlookbar.addtitle('生成英文','静态管理',2)
outlookbar.additem('生成英文首页',t,'en_html_index.asp')
outlookbar.additem('生成英文栏目',t,'en_html_items.asp')
outlookbar.additem('生成英文内容',t,'en_html_article.asp')
outlookbar.additem('生成英文所有',t,'en_html_all.asp')









