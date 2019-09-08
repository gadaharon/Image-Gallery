using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLOUDINARY
{
	public class ImageUploadResponse
	{
		public int Id { get; set; }
		public string ImageId { get; set; }
		public string Uri { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }
		public string Format { get; set; }
		public string CreatedAt { get; set; }
	}
}