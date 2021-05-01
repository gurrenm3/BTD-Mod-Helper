using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Unity.Bridge;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTD_Mod_Helper.Api
{
    internal class BloonTracker
    {
        public Dictionary<int, Bloon> currentBloons = new Dictionary<int, Bloon>();
        public Dictionary<int, BloonToSimulation> currentBloonToSims = new Dictionary<int, BloonToSimulation>();

        public void TrackBloon(Bloon bloon)
        {
            if (currentBloons.ContainsKey(bloon.Id))
            {
                currentBloons[bloon.Id] = bloon;
                return;
            }

            currentBloons.Add(bloon.Id, bloon);
        }

        public void StopTrackingBloon(Bloon bloon) => StopTrackingBloon(bloon.Id);

        public void StopTrackingBloon(int id)
        {
            currentBloons.Remove(id);
        }

        public Bloon GetBloon(int id)
        {
            currentBloons.TryGetValue(id, out Bloon bloon);
            return bloon;
        }


        public void TrackBloonToSim(BloonToSimulation bloon)
        {
            if (currentBloonToSims.ContainsKey(bloon.id))
            {
                currentBloonToSims[bloon.id] = bloon;
                return;
            }

            currentBloonToSims.Add(bloon.id, bloon);
        }


        public void StopTrackingBloonToSim(BloonToSimulation bloon) => StopTrackingBloonToSim(bloon.id);

        public void StopTrackingBloonToSim(int id)
        {
            currentBloonToSims.Remove(id);
        }


        public BloonToSimulation GetBloonToSim(int id)
        {
            currentBloonToSims.TryGetValue(id, out BloonToSimulation bloonToSim);
            return bloonToSim;
        }
    }
}
