using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace CLOUDINARY
{
	public class CloudinaryService : CloudinaryConfig
	{
		private readonly Account account = new Account(NAME, API_KEY, SECRET);
		private Cloudinary cloudinary;
		private static readonly object Padlock = new Object();
		private static CloudinaryService instance = null;
		public static CloudinaryService Instance
		{
			get
			{
				lock (Padlock)
				{
					if(instance == null)
					{
						instance = new CloudinaryService();
					}
					return instance;
				}
			}
		}
		public CloudinaryService()
		{
			cloudinary = new Cloudinary(account);
		}

		public async Task<ImageUploadResponse> UploadImage(string base64)
		{
			try
			{
				var uploadParams = new ImageUploadParams()
				{
					File = new FileDescription(base64)
				};

				var uploadResponse = await cloudinary.UploadAsync(uploadParams);

				return new ImageUploadResponse()
				{
					ImageId = uploadResponse.PublicId,
					Uri = uploadResponse.SecureUri.AbsoluteUri,
					Height = uploadResponse.Height,
					Width = uploadResponse.Width,
					Format = uploadResponse.Format,
					CreatedAt = uploadResponse.CreatedAt.ToString()
				};
			}
			catch (Exception)
			{

				return null;
			}
			
		}
			
	}
}