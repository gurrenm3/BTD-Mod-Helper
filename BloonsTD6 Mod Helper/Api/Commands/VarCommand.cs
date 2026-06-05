#if DEBUG
using System;
using System.Collections.Generic;
using System.Globalization;
using CommandLine;

namespace BTD_Mod_Helper.Api.Commands;

internal class VarCommand : ModCommand
{
    public override string Command => "var";

    public override string Help => "Modifies a Mod Helper variable to be a specific new value";

    [Value(0, Required = true, HelpText = "Variable name")]
    public string Variable { get; set; }

    [Value(1, HelpText = "Variable new value")]
    public string Value { get; set; }

    public override bool Execute(ref string resultText)
    {
        if (ModHelper.Variables.TryGetValue(Variable, out var value) && value != null)
        {
            if (string.IsNullOrEmpty(Value))
            {
                resultText = value.ToString();
                return true;
            }

            ModHelper.Variables[Variable] = Convert.ChangeType(Value, value.GetType(), CultureInfo.InvariantCulture);
            return true;
        }

        if (string.IsNullOrEmpty(Value))
        {
            return false;
        }

        if (float.TryParse(Value, out var f))
        {
            ModHelper.Variables[Variable] = f;
        }
        else if (bool.TryParse(Value, out var b))
        {
            ModHelper.Variables[Variable] = b;
        }
        else
        {
            ModHelper.Variables[Variable] = Value;
        }

        return true;
    }

    public override IEnumerable<string> SuggestionsForValue(int index) => index switch
    {
        0 => ModHelper.Variables.Keys,
        _ => base.SuggestionsForValue(index)
    };

}
#endif