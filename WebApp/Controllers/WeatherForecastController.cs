using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotBag.AspNetCore.Authorization;
using HotBag.AspNetCore.ResultWrapper.ResponseModel;
using HotBag.AspNetCore.Web.BaseController;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Host.Publisher;
using Web.Host.Subscriber;

namespace WebApp.Controllers
{ 
    public class WeatherForecastController : BaseApiController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IPublishEvent publisher;
        private readonly ISubscriberEvent subscriberBase;

        public WeatherForecastController(ILogger<WeatherForecastController> logger
            , IPublishEvent publisher,
            ISubscriberEvent subscriberBase)
        {
            _logger = logger;
            this.publisher = publisher;
            this.subscriberBase = subscriberBase;
        }

        [HttpGet]
        //[HotBagAuthorize(HotBagClaimTypes.Permission, "WeatherForecast.Read")]
        public ListResultDto<WeatherForecast> Get()
        {
            var rng = new Random();
            var result =  Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToList();

            publisher.Publish();
             

            return new ListResultDto<WeatherForecast>(result, "all forecast data");
        }


    }
}
