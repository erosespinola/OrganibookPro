using Organibook.Models;
using Organibook.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
        public Object Get(String id)
        {
            ArrayList barcodes = new ArrayList();
            int scans = 100;
            System.Drawing.Bitmap image = (Bitmap)Bitmap.FromFile(@"C:\Users\Eros Espínola\Documents\Visual Studio 2012\Projects\OrganibookPro\Organibook\isbn1.jpg");
            BarcodeImaging.FullScanPage(ref barcodes, image, scans);
            return WebApi.getBook((String)barcodes[0]);
        }

    }
}
