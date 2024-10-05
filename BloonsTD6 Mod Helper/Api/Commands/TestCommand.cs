namespace BTD_Mod_Helper.Api.Commands;

/// <summary>
/// Root command where test related actions are
/// </summary>
public class TestCommand : ModCommand
{
    /// <inheritdoc />
    public override string Command => "test";

    /// <inheritdoc />
    public override string Help => "Run tests";

    /// <inheritdoc />
    public override bool Execute(ref string resultText) => ExplainSubcommands(out resultText);
}