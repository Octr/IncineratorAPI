using Plukit.Base;
using Staxel.Core;

namespace IncineratorAPI
{
    public class IncineratorEffectComponentBuilder : IComponentBuilder
    {
        public string Kind()
        {
            return IncineratorEffectComponentBuilder.KindCode();
        }

        public static string KindCode()
        {
            return "incineratoreffect";
        }

        public object Instance(Blob config)
        {
            return (object)new IncineratorEffectComponent(config);
        }
    }
}
