using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServer.Reference.Commerce.Site.Features.Product.Models;
using EPiServer.Reference.Commerce.Site.Features.Shared.Services;
using Mediachase.Commerce.Pricing;
using Mediachase.Commerce;
using EPiServer.Reference.Commerce.Site.Features.Market.Services;
using EPiServer.Commerce.Catalog.Linking;
using EPiServer.Reference.Commerce.Site.Infrastructure.Facades;
using EPiServer.Web.Routing;
using EPiServer.Filters;
using System.Globalization;
using EPiServer.Reference.Commerce.Site.Features.Shared.Extensions;
using Mediachase.Commerce.Catalog;

namespace EPiServer.Reference.Commerce.Site.Features.Product.Controllers
{
    public class TicketController : ContentController<TicketVariant>
    {
        private readonly IPromotionService _promotionService;
        private readonly IContentLoader _contentLoader;
        private readonly IPriceService _priceService;
        private readonly ICurrentMarket _currentMarket;
        private readonly ICurrencyService _currencyservice;
        //private readonly IRelationRepository _relationRepository;
        private readonly AppContextFacade _appContext;
        private readonly UrlResolver _urlResolver;
        //private readonly FilterPublished _filterPublished;
        //private readonly CultureInfo _preferredCulture;
        private readonly bool _isInEditMode;

        public TicketController(
            IPromotionService promotionService,
            IContentLoader contentLoader,
            IPriceService priceService,
            ICurrentMarket currentMarket,
            CurrencyService currencyservice,
            //IRelationRepository relationRepository,
            AppContextFacade appContext,
            UrlResolver urlResolver,
            //FilterPublished filterPublished,
            //Func<CultureInfo> preferredCulture,
            Func<bool> isInEditMode)
        {
            _promotionService = promotionService;
            _contentLoader = contentLoader;
            _priceService = priceService;
            _currentMarket = currentMarket;
            _currencyservice = currencyservice;
            //_relationRepository = relationRepository;
            _appContext = appContext;
            _urlResolver = urlResolver;
            //_preferredCulture = preferredCulture();
            _isInEditMode = isInEditMode();
            //_filterPublished = filterPublished;
        }

        public ActionResult Index(TicketVariant currentContent)
        {
            var market = _currentMarket.GetCurrentMarket();
            var currency = _currencyservice.GetCurrentCurrency();

            var defaultPrice = GetDefaultPrice(currentContent, market, currency);
            var discountPrice = GetDiscountPrice(defaultPrice, market, currency);

            var model = new TicketVariantViewModel()
            {
                Price = discountPrice,
                OriginalPrice = discountPrice,
                Ticket = currentContent,
                Images = currentContent.GetAssets<IContentImage>(_contentLoader, _urlResolver)
            };

            return View(model);
        }

        private IPriceValue GetDefaultPrice(TicketVariant variation, IMarket market, Currency currency)
        {
            return _priceService.GetDefaultPrice(
                market.MarketId,
                DateTime.Now,
                new CatalogKey(_appContext.ApplicationId, variation.Code),
                currency);
        }

        private Money GetDiscountPrice(IPriceValue defaultPrice, IMarket market, Currency currency)
        {
            if (defaultPrice == null)
            {
                return new Money(0, currency);
            }

            return _promotionService.GetDiscountPrice(defaultPrice.CatalogKey, market.MarketId, currency).UnitPrice;
        }
    }
}
