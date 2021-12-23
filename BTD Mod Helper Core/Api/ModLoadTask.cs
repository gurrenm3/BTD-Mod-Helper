using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Unity.Tasks;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace BTD_Mod_Helper.Api
{
    public abstract class ModLoadTask : NamedModContent
    {
        internal static Dictionary<int, ModLoadTask> Cache =
            new Dictionary<int, ModLoadTask>();

        public sealed override string DisplayNamePlural { get; }
        public sealed override string Description { get; }

        internal IEnumerator iEnumerator;

        //public abstract void Perform();

        public abstract IEnumerator Coroutine();

        /// <inheritdoc />
        protected sealed override void Register()
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