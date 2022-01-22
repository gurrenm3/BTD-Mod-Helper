using Assets.Scripts.Data.MapSets;
using Assets.Scripts.Models.Map;
using MelonLoader;

namespace BTD_Mod_Helper.Api
{
    /// <summary>
    /// Class for creating custom Maps easier. 
    /// </summary>
    public abstract class ModMap : NamedModContent
    {
        /// <summary>
        /// The name of this map.
        /// </summary>
        public abstract new string Name { get; }

        /// <summary>
        /// The difficulty of this map.
        /// </summary>
        public abstract MapDifficulty Difficulty { get; }

        /// <summary>
        /// The <see cref="MapModel"/> associated with this modded map.
        /// </summary>
        public MapModel Map { get => (map == null) ? map = GetMapModel() : map; }
        private MapModel map;


        /// <summary>
        /// Creates an instance of this <see cref="ModMap"/>.
        /// </summary>
        public ModMap()
        {
            // Line below is for reference to see what parameters are needed for a MapModel
            //var mapModel = new MapModel("", null, null, null, null, null, null, 3, null, null, 4); 
        }

        /// <summary>
        /// Used this to create the actual MapModel for this map. It will automatically
        /// be called the first time <see cref="Map"/> is accessed and the result will be
        /// cached.
        /// </summary>
        /// <returns></returns>
        protected abstract MapModel CreateMapModel();

        private MapModel GetMapModel()
        {
            if (map != null)
                return map;

            var model = CreateMapModel();
            bool isCreated = model != null && RegisterInGame(model);
            return isCreated ? model : null;
        }

        /// <summary>
        /// Registers the map into BTD6
        /// </summary>
        /// <returns>True if successful, otherwise false.</returns>
        private bool RegisterInGame(MapModel model)
        {
            return false;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public sealed override void Register()
        {
            MelonLogger.Msg($"Registered ModMap {Name}");
        }
    }
}