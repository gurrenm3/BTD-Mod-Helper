- Added setting to toggle Mod Browser Populating on Startup
    - From my personal testing, this leads to ~1s faster startup on average, in exchange for waiting 5s - 10s when you
      first open the browser
- Added `Instances` and `Lists` classes for modders that have getters for commonly used BTD6 singleton classes and game objects
  - eg `InGame.instance.coopGame.Cast<Btd6CoopGameNetworked>().Connection.Connection.NKGI` can instead be `Instances.NKGI`
  - Also gets added as a component to a Game Object at the root of a global scene, so you can easily access fields with Unity Explorer