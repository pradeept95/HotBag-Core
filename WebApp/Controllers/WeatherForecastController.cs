using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotBag.AspNetCore.Authorization;
using HotBag.AspNetCore.AutoMapper;
using HotBag.AspNetCore.ResultWrapper.ResponseModel;
using HotBag.AspNetCore.Web.BaseController;
using HotBag.Web.Host.MicroservicePublisher;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Web.Host.Publisher;
using Web.Host.Subscriber;
using WebApp.Models;

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
        private readonly IHotBagObjectMapper _objectMapper;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger
            , IPublishEvent publisher
            , ISubscriberEvent subscriberBase
            , IHotBagObjectMapper objectMapper)
        {
            _logger = logger;
            this.publisher = publisher;
            this.subscriberBase = subscriberBase;
            this._objectMapper = objectMapper;
        }

        [HttpGet]
        //[HotBagAuthorize(HotBagClaimTypes.Permission, "WeatherForecast.Read")]
        public ListResultDto<WeatherForecast> Get()
        {
            var rng = new Random();
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToList();


            //event bus publish test
            publisher.Publish();

            
            //email microservice test
            EmailPublisher.PublishMessage(JsonConvert.SerializeObject(result));



            //automapper test
            var testEntity = new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Pradeep",
                MiddleName = "Raj",
                LastName = "Thapaliya",
                Address = "8904 Jody Ln",
                DOB = DateTime.Now
            };


            var testEntityDto = _objectMapper.Map<PersonDto>(testEntity);
            var te = _objectMapper.Map<Person>(testEntityDto);


            return new ListResultDto<WeatherForecast>(result, "all forecast data");
        }


    }
}
