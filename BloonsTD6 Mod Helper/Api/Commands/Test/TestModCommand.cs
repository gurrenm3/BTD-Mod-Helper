using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Internal;

namespace BTD_Mod_Helper.Api.Commands.Test;

internal class TestModCommand : ModCommand<TestCommand>
{
    internal static readonly Dictionary<BloonsMod, Cmd> TestModCommands = [];

    public override string Command => "mod";

    public override string Help => "Runs all ModTests added by a mod";

    public override IEnumerable<ModContent> Load()
    {
        yield return this;
        foreach (var m in ModHelper.Mods)
        {
            if (m is MelonMain) continue;
            yield return new Cmd
            {
                mod = m
            };
        }
    }

    public override bool Execute(ref string resultText) => ExplainSubcommands(out resultText);

    internal class Cmd : ModCommand<TestModCommand>
    {
        public override string Name => "Test" + Command + "Command";

        public override string Command => mod is MelonMain ? ModHelper.DllName.Replace(".dll", "") : mod.GetModName();

        public override string Help => $"Runs all ModTests added by {mod.GetModName()}";

        public override void Register()
        {
            base.Register();
            TestModCommands[mod] = this;
        }

        public override IEnumerator Execute(Output output)
        {
            if (mod.loadErrors.Any())
            {
                output.success = false;
                output.resultText = $"Tests not run, mod has {mod.loadErrors.Count} load errors already";
                yield break;
            }

            var modTests = mod.Content.OfType<ModTest>().ToArray();

            ModHelper.Msg($"Running {modTests.Length} test(s)");

            var success = 0;
            var fail = 0;

            foreach (var modTest in modTests)
            {
                yield return modTest.RunTest();

                if (modTest.Failed)
                {
                    fail++;
                    output.success = false;
                }
                else
                {
                    success++;
                }

                output.resultText = $"Ran {modTests.Length} test(s), {success} succeeded, {fail} failed";
                output.exception ??= modTest.Exception;

                if (ConsoleHandler.FailFast)
                {
                    break;
                }
            }
        }

    }
}