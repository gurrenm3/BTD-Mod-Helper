- Initial fixes for BTD6 v43.0

### Notes for Modders

- For any place where you previously used `InGame.instance.UnityToSimulation`, just switch it now to either `InGame.instance.bridge` or `InGame.Bridge` or `InGame.instance.GetUnityToSimulation()`