using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace cryptocoin.webapi.Controllers
{
    public class BaseApiController : ApiController, IDisposable
    {
        protected BaseApiController() { }
    }
}
