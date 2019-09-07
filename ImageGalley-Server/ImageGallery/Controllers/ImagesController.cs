﻿using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ImageGallery.Controllers
{
    public class ImagesController : ApiController
    {
        // GET: api/Images
        public IEnumerable<Image> Get()
        {
			return Bal.Instance.GetImages();
        }

        // GET: api/Images/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Images
        public Image Post([FromBody]Image image)
        {
			return Bal.Instance.createImage(image); 
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
