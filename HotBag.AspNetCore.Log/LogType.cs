namespace HotBag.AspNetCore.Log
{
    /// <summary>
    /// The log level.
    /// </summary>
    public enum LogType
    {
        Trace,
        Debug,
        Info,
        Warn,
        Error,
        Fatal,

        Exception = 1, 
        Warnign = 3, 
        Success = 5
    }
}
