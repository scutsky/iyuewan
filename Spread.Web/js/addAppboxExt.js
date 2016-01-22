//�����ƶ�js	
function loadWinMoveJS() {	
	//��������
	var iWidth = document.documentElement.clientWidth; 
	//������߶�
	var iHeight = document.documentElement.clientHeight; 
	
	//����������
	var w = 445;
	//��������߶�
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
	//����Ҽ������¼�����
	app_hd.onmousedown = function() {			  
	  var evt = getEvent();
	  moveable = true; 
	  moveX = evt.clientX;
	  moveY = evt.clientY;			  
	  moveTop = parseInt(app_wraper.style.top);
	  moveLeft = parseInt(app_wraper.style.left);
	  
	  //����϶��¼�����
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
	  
	  //��갴�������¼�
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

	// ���Event�������ڼ���IE��FireFox
	function getEvent() {
	 return window.event || arguments.callee.caller.arguments[0];
	}		
}		
		
//��ת
function addAppbox(appId,tbToken) {
	document.getElementById("ifrm").src = "http://web.wangwang.taobao.com/appbox/add_appbox_ext.htm?appId="+appId+"&tb_token="+tbToken+"&time="+new Date();
	document.getElementById("app_wraper").style.display = "block";			
	loadWinMoveJS();
}
//���ش���
function closeAppbox() {
	document.getElementById("app_wraper").style.display = "none";
}