using System.Text;
using System.Security.Claims;
using System;

namespace HotBag.AspNetCore.Data.Autofill
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]

    public class JoinAttribute : System.Attribute
    {
        public Type TableName { get; set; }
        public string At { get; set; }
        public JoinType JoinType { get; set; }
    }

    public enum JoinType
    {
        InnerJoin, CrossJoin, LeftJoin, RightJoin, LeftOuterJoin, RightOuterJoin
    }
    public class GetFromAttribute : System.Attribute
    {
        public Type TableName { get; set; }
    }
}
