using Plukit.Base;
using Staxel.Core;
using Staxel.Docks;
using Staxel.Effects;
using Staxel.Logic;
using Staxel.TileStates.Docks;


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
            // return "controlHint.verb.Incinerate";
            return
            this.Component.InteractVerb;
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

        public void TrashContents(Entity entity, EntityUniverseFacade facade)
        {
            bool flag = false;
            foreach (DockSite dockSite in this._dockSites)
            {
                if (dockSite.DockedItem.Stack.Count > 0)
                    flag = true;
                dockSite.EmptyWithoutExploding(facade);
            }
            if (!flag)
                return;
            this.Component = this._configuration.Components.Get<IncineratorEffectComponent>();
            this._dockSites.First<DockSite>().EffectQueue.Trigger(new EffectTrigger(this.Component.BurnEffect));
        }

    }

}
