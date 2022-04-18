namespace BTD_Mod_Helper.Api.Helpers
{
    internal class VanillaTypeGenerator
    {
        /* Save for now, useful for when they add new upgrades
             Game.instance.model.upgrades.ForEach(upgrade =>
            {
                var textInfo = new CultureInfo("en-US", false).TextInfo;
                var p = textInfo.ToTitleCase(upgrade.name.Replace(".", " ")).Replace(" ", "").Replace("+", "I")
                    .Replace("Buccaneer-", "").Replace("-", "").Replace("'", "").Replace(":", "");
                ModHelper.Msg($"public const string {p} = \"{upgrade.name}\";");
            });
            */
    }
}