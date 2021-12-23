using System;
using System.Collections;
using Assets.Scripts.Unity.Tasks;
using MelonLoader;

namespace BTD_Mod_Helper.Api
{
    public abstract class ModLoadTask : NamedModContent
    {
        public sealed override string DisplayNamePlural { get; }
        public sealed override string Description { get; }

        public virtual bool RequiresMainThread => false;

        internal void PerformLoadTask()
        {
            if (RequiresMainThread)
            {
                
            }
            
            Perform();
        }
        
        public abstract void Perform();
        
        /// <inheritdoc />
        protected sealed override void Register()
        {
            // nothing here since registering happens after TitleScreen, so ModLoadTasks should already be finished
        }

        public IEnumerator test()
        {
            MelonLogger.Msg("wtf");
            yield return null;
        }

        internal ITask CreateTask()
        {
            return new Task(DisplayName, new Action(PerformLoadTask)).Cast<ITask>();
        }
    }
}