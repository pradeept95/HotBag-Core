using System;

namespace HotBag.AspNetCore.Data.Autofill
{
    /// <summary>
    /// Optional IgnoreUpdate attribute.
    /// Custom for Dapper.SimpleCRUD to exclude a property from Update methods
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreUpdateAttribute : System.Attribute
    {
    }
}
