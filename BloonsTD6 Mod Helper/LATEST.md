**Added a new "Filter by Topics" option at the top right of the Mod Browser**
- Filter to only show mods that have the given github topic
- Default visible options are
    - new-towers: Adding new custom towers to the game
    - new-heroes: Adding new custom heroes to the game
    - new-bloons: Adding new custom bloons to the game
    - utility: Quality of life changes for how you interact with the game
    - tweaks: Smaller changes / additions to base game play
    - expansion: Extensive changes / additions to base game play
    - bosses: Content adding or affecting bosses
    - modes: Adding new game modes / round sets / other ways to play
    - maps: Content adding or affecting maps
    - memes: Silly changes not meant to be taken seriously
- If you have "Show Unverified Mod Browser Content" enabled, then any other assigned topics people use will also be shown
- If another topic garners enough usage it'll be added to the default list
- Add topics to your mod through github (like the btd6-mod topic, or through `ExtraTopics` in ModHelperData)

Other changes

- Can close the Round Set Changer by clicking elsewhere on the background
- Fixed custom game mode RemoveMutators extension
- Added direct `ModGameMode.ModifyGameModel` and `ModRoundSet.ModifyGameModel` overrides
- Fixed ModSettingBool buttons not text switching
- Fixed default position of ModSetting sliders with step sizes