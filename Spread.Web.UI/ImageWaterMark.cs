using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
namespace Spread.Web.UI
{
	public class ImageWaterMark
	{
		public static void AddImageSignPic(string imgPath, string filename, string watermarkFilename, int watermarkStatus, int quality, int watermarkTransparency)
		{
			byte[] buffer = File.ReadAllBytes(HttpContext.Current.Server.MapPath(imgPath));
			Image image = Image.FromStream(new MemoryStream(buffer));
			filename = HttpContext.Current.Server.MapPath(filename);
			if (!watermarkFilename.StartsWith("/"))
			{
				watermarkFilename = "/" + watermarkFilename;
			}
			watermarkFilename = HttpContext.Current.Server.MapPath(watermarkFilename);
			if (File.Exists(watermarkFilename))
			{
				Graphics graphics = Graphics.FromImage(image);
				Image image2 = new Bitmap(watermarkFilename);
				if (image2.Height < image.Height && image2.Width < image.Width)
				{
					ImageAttributes imageAttributes = new ImageAttributes();
					ColorMap[] map = new ColorMap[]
					{
						new ColorMap
						{
							OldColor = Color.FromArgb(255, 0, 255, 0),
							NewColor = Color.FromArgb(0, 0, 0, 0)
						}
					};
					imageAttributes.SetRemapTable(map, ColorAdjustType.Bitmap);
					float num = 0.5f;
					if (watermarkTransparency >= 1 && watermarkTransparency <= 10)
					{
						num = (float)watermarkTransparency / 10f;
					}
					float[][] array = new float[5][];
					float[][] arg_147_0 = array;
					int arg_147_1 = 0;
					float[] array2 = new float[5];
					array2[0] = 1f;
					arg_147_0[arg_147_1] = array2;
					float[][] arg_15E_0 = array;
					int arg_15E_1 = 1;
					array2 = new float[5];
					array2[1] = 1f;
					arg_15E_0[arg_15E_1] = array2;
					float[][] arg_175_0 = array;
					int arg_175_1 = 2;
					array2 = new float[5];
					array2[2] = 1f;
					arg_175_0[arg_175_1] = array2;
					float[][] arg_189_0 = array;
					int arg_189_1 = 3;
					array2 = new float[5];
					array2[3] = num;
					arg_189_0[arg_189_1] = array2;
					array[4] = new float[]
					{
						0f,
						0f,
						0f,
						0f,
						1f
					};
					float[][] newColorMatrix = array;
					ColorMatrix newColorMatrix2 = new ColorMatrix(newColorMatrix);
					imageAttributes.SetColorMatrix(newColorMatrix2, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
					int x = 0;
					int y = 0;
					switch (watermarkStatus)
					{
					case 1:
						x = (int)((float)image.Width * 0.01f);
						y = (int)((float)image.Height * 0.01f);
						break;
					case 2:
						x = (int)((float)image.Width * 0.5f - (float)(image2.Width / 2));
						y = (int)((float)image.Height * 0.01f);
						break;
					case 3:
						x = (int)((float)image.Width * 0.99f - (float)image2.Width);
						y = (int)((float)image.Height * 0.01f);
						break;
					case 4:
						x = (int)((float)image.Width * 0.01f);
						y = (int)((float)image.Height * 0.5f - (float)(image2.Height / 2));
						break;
					case 5:
						x = (int)((float)image.Width * 0.5f - (float)(image2.Width / 2));
						y = (int)((float)image.Height * 0.5f - (float)(image2.Height / 2));
						break;
					case 6:
						x = (int)((float)image.Width * 0.99f - (float)image2.Width);
						y = (int)((float)image.Height * 0.5f - (float)(image2.Height / 2));
						break;
					case 7:
						x = (int)((float)image.Width * 0.01f);
						y = (int)((float)image.Height * 0.99f - (float)image2.Height);
						break;
					case 8:
						x = (int)((float)image.Width * 0.5f - (float)(image2.Width / 2));
						y = (int)((float)image.Height * 0.99f - (float)image2.Height);
						break;
					case 9:
						x = (int)((float)image.Width * 0.99f - (float)image2.Width);
						y = (int)((float)image.Height * 0.99f - (float)image2.Height);
						break;
					}
					graphics.DrawImage(image2, new Rectangle(x, y, image2.Width, image2.Height), 0, 0, image2.Width, image2.Height, GraphicsUnit.Pixel, imageAttributes);
					ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
					ImageCodecInfo imageCodecInfo = null;
					ImageCodecInfo[] array3 = imageEncoders;
					for (int i = 0; i < array3.Length; i++)
					{
						ImageCodecInfo imageCodecInfo2 = array3[i];
						if (imageCodecInfo2.MimeType.IndexOf("jpeg") > -1)
						{
							imageCodecInfo = imageCodecInfo2;
						}
					}
					EncoderParameters encoderParameters = new EncoderParameters();
					long[] array4 = new long[1];
					if (quality < 0 || quality > 100)
					{
						quality = 80;
					}
					array4[0] = (long)quality;
					EncoderParameter encoderParameter = new EncoderParameter(Encoder.Quality, array4);
					encoderParameters.Param[0] = encoderParameter;
					if (imageCodecInfo != null)
					{
						image.Save(filename, imageCodecInfo, encoderParameters);
					}
					else
					{
						image.Save(filename);
					}
					graphics.Dispose();
					image.Dispose();
					image2.Dispose();
					imageAttributes.Dispose();
				}
			}
		}
		public static void AddImageSignText(string imgPath, string filename, string watermarkText, int watermarkStatus, int quality, string fontname, int fontsize)
		{
			byte[] buffer = File.ReadAllBytes(HttpContext.Current.Server.MapPath(imgPath));
			Image image = Image.FromStream(new MemoryStream(buffer));
			filename = HttpContext.Current.Server.MapPath(filename);
			Graphics graphics = Graphics.FromImage(image);
			Font font = new Font(fontname, (float)fontsize, FontStyle.Regular, GraphicsUnit.Pixel);
			SizeF sizeF = graphics.MeasureString(watermarkText, font);
			float num = 0f;
			float num2 = 0f;
			switch (watermarkStatus)
			{
			case 1:
				num = (float)image.Width * 0.01f;
				num2 = (float)image.Height * 0.01f;
				break;
			case 2:
				num = (float)image.Width * 0.5f - sizeF.Width / 2f;
				num2 = (float)image.Height * 0.01f;
				break;
			case 3:
				num = (float)image.Width * 0.99f - sizeF.Width;
				num2 = (float)image.Height * 0.01f;
				break;
			case 4:
				num = (float)image.Width * 0.01f;
				num2 = (float)image.Height * 0.5f - sizeF.Height / 2f;
				break;
			case 5:
				num = (float)image.Width * 0.5f - sizeF.Width / 2f;
				num2 = (float)image.Height * 0.5f - sizeF.Height / 2f;
				break;
			case 6:
				num = (float)image.Width * 0.99f - sizeF.Width;
				num2 = (float)image.Height * 0.5f - sizeF.Height / 2f;
				break;
			case 7:
				num = (float)image.Width * 0.01f;
				num2 = (float)image.Height * 0.99f - sizeF.Height;
				break;
			case 8:
				num = (float)image.Width * 0.5f - sizeF.Width / 2f;
				num2 = (float)image.Height * 0.99f - sizeF.Height;
				break;
			case 9:
				num = (float)image.Width * 0.99f - sizeF.Width;
				num2 = (float)image.Height * 0.99f - sizeF.Height;
				break;
			}
			graphics.DrawString(watermarkText, font, new SolidBrush(Color.White), num + 1f, num2 + 1f);
			graphics.DrawString(watermarkText, font, new SolidBrush(Color.Black), num, num2);
			ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
			ImageCodecInfo imageCodecInfo = null;
			ImageCodecInfo[] array = imageEncoders;
			for (int i = 0; i < array.Length; i++)
			{
				ImageCodecInfo imageCodecInfo2 = array[i];
				if (imageCodecInfo2.MimeType.IndexOf("jpeg") > -1)
				{
					imageCodecInfo = imageCodecInfo2;
				}
			}
			EncoderParameters encoderParameters = new EncoderParameters();
			long[] array2 = new long[1];
			if (quality < 0 || quality > 100)
			{
				quality = 80;
			}
			array2[0] = (long)quality;
			EncoderParameter encoderParameter = new EncoderParameter(Encoder.Quality, array2);
			encoderParameters.Param[0] = encoderParameter;
			if (imageCodecInfo != null)
			{
				image.Save(filename, imageCodecInfo, encoderParameters);
			}
			else
			{
				image.Save(filename);
			}
			graphics.Dispose();
			image.Dispose();
		}
	}
}
