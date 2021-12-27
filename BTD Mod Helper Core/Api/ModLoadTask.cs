using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Unity.Tasks;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace BTD_Mod_Helper.Api
{
    /// <summary>
    /// Class for a Coroutine style task that runs during the BTD6 loading screen
    /// </summary>
    public abstract class ModLoadTask : NamedModContent
    {
        internal static Dictionary<int, ModLoadTask> Cache = new Dictionary<int, ModLoadTask>();

        public sealed override string DisplayNamePlural { get; }
        public sealed override string Description { get; }

        internal IEnumerator iEnumerator;

        //public abstract void Perform();

        /// <summary>
        /// Coroutine style function
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerator Coroutine();

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