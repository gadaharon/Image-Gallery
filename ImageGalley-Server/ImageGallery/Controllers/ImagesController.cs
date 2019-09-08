using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ImageGallery.Controllers
{
    public class ImagesController : ApiController
    {
        // GET: api/Images
        public IHttpActionResult Get()
        {
			var response = Bal.Instance.GetImages();
			if (response == null)
			{
				return Content(HttpStatusCode.BadRequest,
					new { Message = "Something went wrong" });
			}
			return Content(HttpStatusCode.OK, response);
		}

        // POST: api/Images
        public async Task<IHttpActionResult> Post([FromBody]ImageUploadRequestParams _params)
        {
			var response = await Bal.Instance.CreateImage(_params.Base64);
			if(response == null)
			{
				return Content(HttpStatusCode.BadRequest, 
					new { Message = "Something went wrong" });
			}
			return Content(HttpStatusCode.OK, response);
        }

        // PUT: api/Images/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Images/5
        public void Delete(int id)
        {
        }
    }
}
