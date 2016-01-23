using Spread.BLL;
using Spread.Model;
using System;
using System.Configuration;
using System.IO;
using System.Web;
namespace Spread.Web.UI
{
	public class UpLoad
	{
		private Spread.Model.WebSet webset;
		private string filePath;
		private readonly string fileType;
		private readonly int fileSize;
		private readonly int isWatermark;
		private readonly int waterStatus;
		private readonly int waterQuality;
		private readonly string imgWaterPath;
		private readonly int waterTransparency;
		private readonly string textWater;
		private readonly string textWaterFont;
		private readonly int textFontSize;
		public UpLoad()
		{
			this.webset = new Spread.BLL.WebSet().loadConfig(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["WebSetpath"].ToString()));
			this.filePath = this.webset.WebFilePath;
			this.fileType = this.webset.WebFileType;
			this.fileSize = this.webset.WebFileSize;
			this.isWatermark = this.webset.IsWatermark;
			this.waterStatus = this.webset.WatermarkStatus;
			this.waterQuality = this.webset.ImgQuality;
			this.imgWaterPath = this.webset.ImgWaterPath;
			this.waterTransparency = this.webset.ImgWaterTransparency;
			this.textWater = this.webset.WaterText;
			this.textWaterFont = this.webset.WaterFont;
			this.textFontSize = this.webset.FontSize;
		}
		public string fileSaveAs(HttpPostedFile _postedFile, int _isWater)
		{
			string result;
			try
			{
				string text = _postedFile.FileName.Substring(_postedFile.FileName.LastIndexOf(".") + 1);
				if (!this.CheckFileExt(this.fileType, text))
				{
					result = "{msg: 0, msbox: \"不允许上传" + text + "类型的文件！\"}";
				}
				else
				{
					if (this.fileSize > 0 && _postedFile.ContentLength > this.fileSize * 1024)
					{
						result = "{msg: 0, msbox: \"文件超过限制的大小啦！\"}";
					}
					else
					{
						string str = DateTime.Now.ToString("yyyyMMddHHmmssff") + "." + text;
						if (!this.filePath.StartsWith("/"))
						{
							this.filePath = "/" + this.filePath;
						}
						if (!this.filePath.EndsWith("/"))
						{
							this.filePath += "/";
						}
						string str2 = DateTime.Now.ToString("yyyyMMdd") + "/";
						this.filePath += str2;
						string text2 = this.filePath + str;
						string text3 = HttpContext.Current.Server.MapPath(this.filePath);
						if (!Directory.Exists(text3))
						{
							Directory.CreateDirectory(text3);
						}
						string filename = text3 + str;
						_postedFile.SaveAs(filename);
						if (this.isWatermark > 0 && _isWater == 1 && this.CheckFileExt("BMP|JPEG|JPG|GIF|PNG|TIFF", text))
						{
							switch (this.isWatermark)
							{
							case 1:
								ImageWaterMark.AddImageSignText(text2, this.filePath + str, this.textWater, this.waterStatus, this.waterQuality, this.textWaterFont, this.textFontSize);
								break;
							case 2:
								ImageWaterMark.AddImageSignPic(text2, this.filePath + str, this.imgWaterPath, this.waterStatus, this.waterQuality, this.waterTransparency);
								break;
							}
						}
						result = "{msg: 1, msbox: \"" + text2 + "\"}";
					}
				}
			}
			catch
			{
				result = "{msg: 0, msbox: \"上传过程中发生意外错误！\"}";
			}
			return result;
		}
		public string MorefileSaveAs(HttpPostedFile _postedFile, int _isWater)
		{
			string result;
			try
			{
				string text = _postedFile.FileName.Substring(_postedFile.FileName.LastIndexOf(".") + 1);
				if (!this.CheckFileExt(this.fileType, text))
				{
					result = "Ftype";
				}
				else
				{
					if (this.fileSize > 0 && _postedFile.ContentLength > this.fileSize * 1024)
					{
						result = "Fsize";
					}
					else
					{
						string str = DateTime.Now.ToString("yyyyMMddHHmmssff") + "." + text;
						if (!this.filePath.StartsWith("/"))
						{
							this.filePath = "/" + this.filePath;
						}
						if (!this.filePath.EndsWith("/"))
						{
							this.filePath += "/";
						}
						string str2 = DateTime.Now.ToString("yyyyMMdd") + "/";
						this.filePath += str2;
						string text2 = this.filePath + str;
						string text3 = HttpContext.Current.Server.MapPath(this.filePath);
						if (!Directory.Exists(text3))
						{
							Directory.CreateDirectory(text3);
						}
						string filename = text3 + str;
						_postedFile.SaveAs(filename);
						if (this.isWatermark > 0 && _isWater == 1 && this.CheckFileExt("BMP|JPEG|JPG|GIF|PNG|TIFF", text))
						{
							switch (this.isWatermark)
							{
							case 1:
								ImageWaterMark.AddImageSignText(text2, this.filePath + str, this.textWater, this.waterStatus, this.waterQuality, this.textWaterFont, this.textFontSize);
								break;
							case 2:
								ImageWaterMark.AddImageSignPic(text2, this.filePath + str, this.imgWaterPath, this.waterStatus, this.waterQuality, this.waterTransparency);
								break;
							}
						}
						result = text2;
					}
				}
			}
			catch
			{
				result = null;
			}
			return result;
		}
		private bool CheckFileExt(string _fileType, string _fileExt)
		{
			string[] array = _fileType.Split(new char[]
			{
				'|'
			});
			bool result;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].ToLower() == _fileExt.ToLower())
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}
	}
}
