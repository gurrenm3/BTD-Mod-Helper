using System;
using System.Collections;
using System.Collections.Generic;
#if BloonsTD6
using Assets.Scripts.Unity.Tasks;

namespace BTD_Mod_Helper.Api
{
    /// <summary>
    /// Class for a Coroutine style task that runs during the BTD6 loading screen
    /// </summary>
    public abstract class ModLoadTask : NamedModContent
    {
        internal static readonly Dictionary<int, ModLoadTask> Cache = new Dictionary<int, ModLoadTask>();

        /// <inheritdoc />
        public sealed override string DisplayNamePlural => base.DisplayNamePlural;

        /// <inheritdoc />
        public sealed override string Description => base.DisplayNamePlural;

        internal IEnumerator iEnumerator;

        //public abstract void Perform();

        /// <summary>
        /// Coroutine style function
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerator Coroutine();


        /// <inheritdoc />
        public sealed override int RegisterPerFrame => 999;

        /// <inheritdoc />
        public override void Register()
        {
            // nothing here since registering happens after TitleScreen, so ModLoadTasks should already be finished
        }

        internal ITask CreateTask()
        {
            var action = (Il2CppSystem.Action) new Action(() => { });
            Cache[action.GetHashCode()] = this;
            return new Task(DisplayName, action).Cast<ITask>();
        }
    }
}
#endif