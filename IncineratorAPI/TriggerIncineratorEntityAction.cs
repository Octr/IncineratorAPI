using Staxel.EntityActions;
using Staxel.Logic;

namespace IncineratorAPI
{
    internal sealed class TriggerIncineratorEntityAction : EntityActionDriver
    {
        public static string KindCode()
        {
            return "IncineratorAPI.entityAction.TriggerIncinerator";
        }

        public override string Kind()
        {
            return TriggerIncineratorEntityAction.KindCode();
        }

        public override void Start(Entity entity, EntityUniverseFacade facade)
        {
            (entity.Logic as IncineratorTileStateEntityLogic)?.TrashContents(entity, facade);
            entity.Logic.ActionFacade.NoNextAction();
        }
    }
}
