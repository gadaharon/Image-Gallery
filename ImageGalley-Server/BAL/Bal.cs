using DAL;
using CLOUDINARY;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
		

		public IEnumerable<ImageUploadResponse> GetImages()
		{
			// Get data from DB
			DataTable images = Dal.Instance.GetImages();
			if(images == null)
			{
				return null;
			}
			IEnumerable<ImageUploadResponse> query = from image in images.AsEnumerable() select new ImageUploadResponse() {
				Id = image.Field<int>("Id"),
				ImageId = image.Field<string>("ImageId"),
				Uri = image.Field<string>("Uri"),
				Height = image.Field<int>("Height"),
				Width = image.Field<int>("Width"),
				Format = image.Field<string>("Format"),
				CreatedAt = image.Field<string>("CreatedAt")
			};

			return query;
		}
		public async Task<ImageUploadResponse> CreateImage(string base64)
		{
			// Upload image to Cloudinary
			ImageUploadResponse imageUploadResponse = await CloudinaryService.Instance.UploadImage(base64);

			if(imageUploadResponse == null)
			{
				return null;
			}

			// Insert image response to DB
			var insertedDataDB = Dal.Instance.InsertImage(
				imageUploadResponse.ImageId,
				imageUploadResponse.Uri,
				imageUploadResponse.Height,
				imageUploadResponse.Width,
				imageUploadResponse.Format,
				imageUploadResponse.CreatedAt
			);

			if(insertedDataDB == null) {
				return null;
			}

			return imageUploadResponse;
		}
	}

	 
}