using Plukit.Base;
using System;

namespace IncineratorAPI
{
    public class IncineratorEffectComponent
    {
        public string BurnEffect { get; }
        public string InteractVerb { get; }
        public IncineratorEffectComponent(Blob config)
        {
            this.BurnEffect = config.GetString("effect");
            if (string.IsNullOrEmpty(this.BurnEffect))
                Logger.LogException(new Exception("Missing effect code from incineratoreffect component"));
            this.InteractVerb = config.GetString("verb");
            if (string.IsNullOrEmpty(this.InteractVerb))
                Logger.LogException(new Exception("Missing verb code from incineratoreffect component"));
        }
    }
}
