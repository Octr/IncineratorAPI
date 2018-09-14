using Plukit.Base;
using Staxel.Core;
using Staxel.Docks;
using Staxel.Effects;
using Staxel.Logic;
using Staxel.TileStates.Docks;
using System.Threading.Tasks;

namespace IncineratorAPI
{
    public sealed class IncineratorTileStateEntityLogic : DockTileStateEntityLogic
    {

        internal IncineratorEffectComponent Component { get; private set; }
        public IncineratorTileStateEntityLogic(Entity entity)

          : base(entity)
        {
        }

        protected override void AddSite(DockSiteConfiguration site)
        {
            this._dockSites.Add(new DockSite(this.Entity, new DockSiteId(this.Entity.Id, this._dockSites.Count), site));
        }

        public override string AltInteractVerb()
        {
            return "IncineratorAPI.controlHint.verb.Incinerate";
        }

        public override bool SuppressInteractVerb()
        {
            return !this.HasAnyDockedItems();
        }

        public override Vector3F InteractCursorColour()
        {
            if (this.HasAnyDockedItems())
                return base.InteractCursorColour();
            return Constants.CursorColor;
        }

        public async void TrashContents(Entity entity, EntityUniverseFacade facade)
        {
           
            foreach (DockSite dockSite in this._dockSites)
            {
                if (dockSite.DockedItem.Stack.Count > 0)
  
                this.Component = this._configuration.Components.Get<IncineratorEffectComponent>();
                this._dockSites.First<DockSite>().EffectQueue.Trigger(new EffectTrigger(this.Component.BurnEffect));
                await Task.Delay(1000);
                dockSite.EmptyWithoutExploding(facade);
            }
  
        }

    }

}
