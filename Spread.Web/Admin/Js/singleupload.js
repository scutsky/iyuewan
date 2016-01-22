$(function() {
    $("#FileUpload").bind("change", function() {
        //开始提交
        $("#form1").ajaxSubmit({
            beforeSubmit: function(formData, jqForm, options) {
                //隐藏上传按钮
                $(".files").hide();
                //显示LOADING图片
                $(".uploading").show();
            },
            success: function(data, textStatus) {
                if (data.msg == 1) {
                    $("#txtImgUrl").val(data.msbox);
                } else {
                    alert(data.msbox);
                }
                $(".files").show();
                $(".uploading").hide();
            },
            error: function(data, status, e) {
                alert("上传失败，错误信息：" + e);
                $(".files").show();
                $(".uploading").hide();
            },
            url: "/Tools/SingleUpload.ashx",
            type: "post",
            dataType: "json",
            timeout: 600000
        });
    });

    $("#FileUpload2").bind("change", function() {
        //开始提交
        $("#form1").ajaxSubmit({
            beforeSubmit: function(formData, jqForm, options) {
                //隐藏上传按钮
                $(".files2").hide();
                //显示LOADING图片
                $(".uploading2").show();
            },
            success: function(data, textStatus) {
                if (data.msg == 1) {
                    $("#txtImgUrl2").val(data.msbox);
                } else {
                    alert(data.msbox);
                }
                $(".files2").show();
                $(".uploading2").hide();
            },
            error: function(data, status, e) {
                alert("上传失败，错误信息：" + e);
                $(".files2").show();
                $(".uploading2").hide();
            },
            url: "/Tools/SingleUpload.ashx",
            type: "post",
            dataType: "json",
            timeout: 600000
        });
    });
});