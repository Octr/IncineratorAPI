using Plukit.Base;
using Staxel.Logic;
using Staxel.Tiles;
using Staxel.TileStates.Docks;

namespace IncineratorAPI
{
    internal sealed class IncineratorTileStateEntityBuilder : DockTileStateEntityBuilder, IEntityPainterBuilder, IEntityLogicBuilder2, IEntityLogicBuilder
    {
        EntityLogic IEntityLogicBuilder.Instance(Entity entity, bool server)
        {
            return (EntityLogic)new IncineratorTileStateEntityLogic(entity);
        }

        public new void Load()
        {
            base.Load();
        }

        EntityPainter IEntityPainterBuilder.Instance()
        {
            return (EntityPainter)new DockTileStateEntityPainter((DockTileStateEntityBuilder)this);
        }

        public new string Kind
        {
            get
            {
                return IncineratorTileStateEntityBuilder.KindCode;
            }
        }

        public new static string KindCode
        {
            get
            {
                return "IncineratorAPI.tileStateEntity.Incinerator";
            }
        }

        public new static Entity Spawn(EntityUniverseFacade facade, Tile tile, Vector3I location)
        {
            Entity entity = new Entity(facade.AllocateNewEntityId(), false, IncineratorTileStateEntityBuilder.KindCode, true);
            Blob blob = BlobAllocator.Blob(true);
            blob.SetString(nameof(tile), tile.Configuration.Code);
            blob.SetLong("variant", (long)tile.Variant());
            blob.FetchBlob(nameof(location)).SetVector3I(location);
            blob.FetchBlob("velocity").SetVector3D(Vector3D.Zero);
            entity.Construct(blob, facade);
            Blob.Deallocate(ref blob);
            facade.AddEntity(entity);
            return entity;
        }
    }
}
