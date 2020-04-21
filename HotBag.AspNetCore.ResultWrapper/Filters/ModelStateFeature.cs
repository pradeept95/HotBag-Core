using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HotBag.AspNetCore.ResultWrapper.Filters
{
    public class ModelStateFeature
    {
        public ModelStateDictionary ModelState { get; set; }

        public ModelStateFeature(ModelStateDictionary state)
        {
            this.ModelState = state;
        }
    }
}
