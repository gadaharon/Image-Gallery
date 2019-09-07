using DAL;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAL
{
	public class Bal
	{
		private static readonly object padlock = new object();
		private static Bal _instance = null;

		public static Bal Instance
		{
			get
			{
				lock (padlock)
				{
					if (_instance == null)
					{
						_instance = new Bal();
					}
					return _instance;
				}
			}
		}
		private Bal()
		{
		}

		public IEnumerable<Image> GetImages()
		{
			DataTable images = Dal.Instance.GetImages();

			IEnumerable<Image> query = from image in images.AsEnumerable() select new Image() {
				Uri = image.Field<string>("Uri"),
				Height = image.Field<int>("Height"),
				Width = image.Field<int>("Width")
			};

			return query;
		}
		public Image createImage(Image image)
		{
			DataSet data = Dal.Instance.CreateImage(image.Uri, image.Height, image.Width);

			if(data.Tables[0].Rows.Count == 0)
			{
				return null;
			}

			DataRow T_image = data.Tables[0].Rows[0];

			Image newImage = new Image()
			{
				Id = int.Parse(T_image["Id"].ToString()),
				Uri = T_image["Uri"].ToString(),
				Height = int.Parse(T_image["Height"].ToString()),
				Width = int.Parse(T_image["Width"].ToString())
			};

			return newImage;
		}
	}

	 
}