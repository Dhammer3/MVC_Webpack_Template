using React;
using JavaScriptEngineSwitcher.Core;
using JavaScriptEngineSwitcher.V8;
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebApplication1.ReactConfig), "Configure")]

namespace WebApplication1
{
    public static class ReactConfig
    {
        public static void Configure()
        {
            JsEngineSwitcher.Current.DefaultEngineName = V8JsEngine.EngineName;
            JsEngineSwitcher.Current.EngineFactories.AddV8();
        }
    }
}