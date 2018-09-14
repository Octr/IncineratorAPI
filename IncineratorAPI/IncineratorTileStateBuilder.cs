using Plukit.Base;
using Staxel.Logic;
using Staxel.Tiles;
using Staxel.TileStates;
using System;

namespace IncineratorAPI
{
    public sealed class IncineratorTileStateBuilder : ITileStateBuilder, IDisposable
    {
        public void Dispose()
        {
        }

        public void Load()
        {
        }

        public string Kind()
        {
            return IncineratorTileStateBuilder.KindCode();
        }

        public Entity Instance(Vector3I location, Tile tile, Universe universe)
        {
            return IncineratorTileStateEntityBuilder.Spawn((EntityUniverseFacade)universe, tile, location);
        }

        public static string KindCode()
        {
            return "IncineratorAPI.tileState.Incinerator";
        }
    }
}
