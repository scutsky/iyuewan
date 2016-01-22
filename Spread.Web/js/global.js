

//扩展jq.fn
$.extend($.fn, {
	//ipt焦点
	inputTxt : function(opts){
		var def = {
			   val : "",
			fColor : "#333",
		    BColor : "#929292"
		};
		var setting = $.extend(def,opts);
		
		$(this).attr("value",setting.val).css("color",setting.BColor);
		$(this).bind({
			"focus" : function(){ if ( $(this).val() == setting.val ){ $(this).attr("value","").css("color",setting.fColor)}},
			"blur" : function(){ if ( $(this).val() == "" ){ $(this).attr("value",setting.val).css("color",setting.BColor)}}
		})
	}
  	
});

$(function(){
	  var aSlidePage = $('.Focus .slide-nav-box a');
	  var aSlideCon = $('.Focus .slide-box li');
	  var iSize = aSlideCon.size();
	  var iNow = 0;
	  var timer = null;
	  aSlidePage.each(function(index){
		  $(this).mouseover(function(){
			  iNow = index;
			  slideRun()
		  });
	  })
	  function slideRun(){
		  aSlidePage.removeClass('cur');
		  aSlidePage.eq(iNow).addClass('cur');
		  aSlideCon.stop();
		  aSlideCon.eq(iNow).siblings().css("z-index","0").animate({
			  opacity:0
		  },600);
		  aSlideCon.eq(iNow).css("z-index","9").animate({
			  opacity:1
		  },600);
	  }
	  autoRun();
	  function autoRun(){
		  timer = setInterval(function(){
			  iNow++;
			  if(iNow>iSize-1) iNow=0;
			  slideRun();
		  },4000)
	  };
	  $('.Focus').hover(function(){
		  clearInterval(timer);
	  },function(){
		  autoRun();
	  });
});

$(function () {
    $(".wrap-nav ul li").focus(function () {
        alert("focus");
        $(".wrap-nav ul li ul").css('display', 'block');
    });
    $(".wrap-nav ul li").blur(function () {
        alert("blur");
        $(".wrap-nav ul li ul").css('display', 'none');
    });
});