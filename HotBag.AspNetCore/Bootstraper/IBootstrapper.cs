namespace HotBag.AspNetCore.Bootstraper
{
    internal interface IBootstrapper
    {
        void Init();
        bool Build();
    }
}
