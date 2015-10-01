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
    public class AgendaPageController : PageController<AgendaPage>
    {
        public ActionResult Index(AgendaPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            return View(currentPage);
        }
    }
}