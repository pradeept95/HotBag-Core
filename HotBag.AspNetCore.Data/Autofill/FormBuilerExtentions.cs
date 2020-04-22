﻿using HotBag.AspNetCore.Authorization.Identity;
using System;
using System.Linq;
using System.Reflection;

namespace HotBag.AspNetCore.Data.Autofill
{
    public static class FormBuilerExtentions
    {
        public static void AutoFill(this object obj)
        {
            var AppSession = NullAppSession.Instance;
            if (!obj.GetType().GetTypeInfo().IsClass)
                return;
            var type = obj.GetType();
            var props = type.GetProperties().Where(x => x.GetCustomAttribute<AutoFillAttribute>() != null);
            foreach (var prop in props)
            {
                var customAtt = prop.GetCustomAttribute<AutoFillAttribute>();
                if (customAtt != null)
                {
                    if (customAtt.HasFixedValue)
                    {

                        var typedDefValue = Convert.ChangeType(customAtt.DefaultValue, prop.PropertyType);
                        if (null != prop && prop.CanWrite)
                        {
                            prop.SetValue(obj, typedDefValue, null);
                        }
                    }
                    else
                    {
                        switch (customAtt.fillBy)
                        {
                            case AutoFillProperty.PrimaryKey:
                                customAtt.DefaultValue = prop.PropertyType == typeof(Guid) ?
                                    Guid.NewGuid() : Guid.Empty;

                                var t = prop.PropertyType;

                                break;

                            case AutoFillProperty.CurrentCulture:

                                //var rqf = ContextResolver.Context.Features.Get<IRequestCultureFeature>();
                                //// Culture contains the information of the requested culture
                                //var culture = rqf.RequestCulture.Culture.ToString();
                                //customAtt.DefaultValue = culture;

                                break;
                            case AutoFillProperty.CurrentUser:

                                //var claim=
                                //    ContextResolver.Context.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Name);
                                customAtt.DefaultValue = AppSession.UserId;

                                break;
                            case AutoFillProperty.CurrentDate:
                                customAtt.DefaultValue = DateTime.Now;
                                break;

                        }
                        var typedDefValue = Convert.ChangeType(customAtt.DefaultValue, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                        if (null != prop && prop.CanWrite)
                        {
                            prop.SetValue(obj, typedDefValue, null);
                        }
                    }
                }
            }
        }
    }
}
