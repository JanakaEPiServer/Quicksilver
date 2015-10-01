using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EPiServer.Reference.Commerce.Site.Features.Agenda.Pages;

namespace EPiServer.Reference.Commerce.Site.Features.Agenda.Controllers
{
    public class AgendaController : PageController<AgendaPage>
    {
        public ActionResult Index(AgendaPage currentPage)
        {
            return View(currentPage);
        }
    }
}