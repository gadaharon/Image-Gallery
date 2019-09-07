using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL
{
	public class DalConfig
	{
		protected static readonly string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\image-gallery\ImageGalley-Server\ImageGallery\App_Data\images.mdf;Integrated Security=True";
	}
}