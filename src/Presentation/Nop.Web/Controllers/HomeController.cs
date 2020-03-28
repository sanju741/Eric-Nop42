using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Seo;
using Nop.Services.Configuration;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Framework.Security;

namespace Nop.Web.Controllers
{
    public partial class HomeController : BasePublicController
    {
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;

        public HomeController(ISettingService settingService, IStoreContext storeContext)
        {
            _settingService = settingService;
            _storeContext = storeContext;
        }
        [HttpsRequirement(SslRequirement.No)]
        public virtual IActionResult Index()
        {
            var storeId = _storeContext.ActiveStoreScopeConfiguration;
            ViewBag.HomePageSchema = _settingService.LoadSetting<SeoSettings>(storeId)?.HomeSchema;
            return View();
        }
    }
}