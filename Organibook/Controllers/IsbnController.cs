using Organibook.Models;
using Organibook.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace Organibook.Controllers
{
    public class IsbnController : ApiController
    {
        private BookFetcher WebApi = new BookFetcher
        {
            Key = "VEYO0O89"
        };

        // GET api/isbn/5
        [BasicAuthentication]
        public Book Get(string id)
        {
            return WebApi.getBook(id);
        }

        // POST api/isbn/
        [BasicAuthentication]
        public Book Post([FromBody]string s)
        {
            //Converting a base 64 string to image
            byte[] imageBytes = Convert.FromBase64String(s.Substring(s.IndexOf(',') + 1));
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Bitmap image = (Bitmap)Bitmap.FromStream(ms, true);

            // Getting the ISBN
            ArrayList barcodes = new ArrayList();
            int scans = 100;
            BarcodeImaging.FullScanPage(ref barcodes, image, scans);

            if (barcodes.Count == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return WebApi.getBook((String)barcodes[0]);
            }
        }

    }
}
