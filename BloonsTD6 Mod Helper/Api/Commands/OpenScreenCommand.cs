namespace BTD_Mod_Helper.Api.Commands;

/// <summary>
/// Parent command for opening UI screens
/// </summary>
public class OpenScreenCommand : ModCommand<OpenCommand>
{
    /// <inheritdoc />
    public override string Command => "screen";

    /// <inheritdoc />
    public override string Help => "Opens UI screens";

    /// <inheritdoc />
    public override bool Execute(ref string resultText) => ExplainSubcommands(out resultText);
}