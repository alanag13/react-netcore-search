using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftwareSearch.Data;

namespace SoftwareSearch.Controllers
{
    [Route("api/[controller]")]
    public class SoftwareController : Controller
    {
        [HttpGet("[action]/greaterThan/{versionNumber}")]
        public IEnumerable<Software> ByVersion(string versionNumber)
        {
            return new List<Software>(SoftwareManager.GetAllSoftwareWithHigherVersion(versionNumber));
        }
    }
}
