//窗体移动js	
function loadWinMoveJS() {	
	//浏览器宽度
	var iWidth = document.documentElement.clientWidth; 
	//浏览器高度
	var iHeight = document.documentElement.clientHeight; 
	
	//弹出窗体宽度
	var w = 445;
	//弹出窗体高度
	var h = 313;			
	var app_wraper = document.getElementById("app_wraper");						
	var app_hd = document.getElementById("app_hd");								
	
	var moveX = 0;
	var moveY = 0;
	var moveTop = 0;
	var moveLeft = 0;
	var moveable = false;
	var docMouseMoveEvent = document.onmousemove;
	var docMouseUpEvent = document.onmouseup;				
	//鼠标右键按下事件方法
	app_hd.onmousedown = function() {			  
	  var evt = getEvent();
	  moveable = true; 
	  moveX = evt.clientX;
	  moveY = evt.clientY;			  
	  moveTop = parseInt(app_wraper.style.top);
	  moveLeft = parseInt(app_wraper.style.left);
	  
	  //鼠标拖动事件方法
	  document.onmousemove = function() {
	   if (moveable) {
		var evt = getEvent();
		var x = moveLeft + evt.clientX - moveX;
		var y = moveTop + evt.clientY - moveY;	
		//alert("x+w="+(x+y)+";iWidth="+iWidth+";y+h="+(y+h)+";iHeight="+iHeight);
		if ( x > 0 &&( x + w < iWidth) && y > 0 && (y + h < iHeight) ) {
		 app_wraper.style.left = x + "px";
		 app_wraper.style.top = y + "px";
		}				
		
	   } 
	  };
	  
	  //鼠标按键弹起事件
	  document.onmouseup = function () { 
	   if (moveable) { 
		document.onmousemove = docMouseMoveEvent;
		document.onmouseup = docMouseUpEvent;
		moveable = false; 
		moveX = 0;
		moveY = 0;
		moveTop = 0;
		moveLeft = 0;
	   } 
	  };
	}			

	// 获得Event对象，用于兼容IE和FireFox
	function getEvent() {
	 return window.event || arguments.callee.caller.arguments[0];
	}		
}		
		
//跳转
function addAppbox(appId,tbToken) {
	document.getElementById("ifrm").src = "http://web.wangwang.taobao.com/appbox/add_appbox_ext.htm?appId="+appId+"&tb_token="+tbToken+"&time="+new Date();
	document.getElementById("app_wraper").style.display = "block";			
	loadWinMoveJS();
}
//隐藏窗体
function closeAppbox() {
	document.getElementById("app_wraper").style.display = "none";
}