using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web;
namespace Spread.Web.UI
{
	public class ImageThumbnailMake
	{
		public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
		{
			Image image = Image.FromFile(HttpContext.Current.Server.MapPath(originalImagePath));
			int num = width;
			int num2 = height;
			int x = 0;
			int y = 0;
			int num3 = image.Width;
			int num4 = image.Height;
			if (mode != null)
			{
				if (!(mode == "HW"))
				{
					if (!(mode == "W"))
					{
						if (!(mode == "H"))
						{
							if (mode == "Cut")
							{
								if ((double)image.Width / (double)image.Height > (double)num / (double)num2)
								{
									num4 = image.Height;
									num3 = image.Height * num / num2;
									y = 0;
									x = (image.Width - num3) / 2;
								}
								else
								{
									num3 = image.Width;
									num4 = image.Width * height / num;
									x = 0;
									y = (image.Height - num4) / 2;
								}
							}
						}
						else
						{
							num = image.Width * height / image.Height;
						}
					}
					else
					{
						num2 = image.Height * width / image.Width;
					}
				}
			}
			Image image2 = new Bitmap(num, num2);
			Graphics graphics = Graphics.FromImage(image2);
			graphics.InterpolationMode = InterpolationMode.High;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.Clear(Color.Transparent);
			graphics.DrawImage(image, new Rectangle(0, 0, num, num2), new Rectangle(x, y, num3, num4), GraphicsUnit.Pixel);
			try
			{
				image2.Save(HttpContext.Current.Server.MapPath(thumbnailPath));
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				image.Dispose();
				image2.Dispose();
				graphics.Dispose();
			}
		}
	}
}
