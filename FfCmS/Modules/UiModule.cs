namespace FfCmS.Modules
{
    public class UiModule : Nancy.NancyModule
    {
        public UiModule()
        {
            Get["/"] = _ => "Hello World!";
        }
    }
}