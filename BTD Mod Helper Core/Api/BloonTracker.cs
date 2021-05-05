using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Unity.Bridge;
using System;
using System.Collections.Generic;
using System.Text;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.Api
{
    internal class BloonTracker
    {
        public Dictionary<int, Bloon> currentBloons = new Dictionary<int, Bloon>();
        public Dictionary<int, BloonToSimulation> currentBloonToSims = new Dictionary<int, BloonToSimulation>();

        public void TrackBloon(Bloon bloon)
        {
            if (currentBloons.ContainsKey(bloon.GetId()))
            {
                currentBloons[bloon.GetId()] = bloon;
                return;
            }

            currentBloons.Add(bloon.GetId(), bloon);
        }

        public void StopTrackingBloon(Bloon bloon) => StopTrackingBloon(bloon.GetId());

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
            if (currentBloonToSims.ContainsKey(bloon.GetId()))
            {
                currentBloonToSims[bloon.GetId()] = bloon;
                return;
            }

            currentBloonToSims.Add(bloon.GetId(), bloon);
        }


        public void StopTrackingBloonToSim(BloonToSimulation bloon) => StopTrackingBloonToSim(bloon.GetId());

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
