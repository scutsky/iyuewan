(function(global) {
	// 接口的根目录
	var apiBase = window.globalBasePath || '../../ajax/';

	var config = {

		// 接口
		api: {
		
		},

		stateCode: {
			// 返回成功
			success: 2000000
		},

		errorIcon: '<i class="iconfont icon-alert m-r-5"></i>'
	};

	global.YM = global.YM || {};
	global.YM.config = config;
	
})(window);