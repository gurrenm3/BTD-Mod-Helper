using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace UpdaterPlugin;

public static class TaskHelpers
{
    public static async Task<bool> WhenAllFailFast(IEnumerable<Func<CancellationToken, Task>> taskFactories)
    {
        using var cts = new CancellationTokenSource();

        var tasks = taskFactories
            .Select(factory => factory(cts.Token))
            .ToList();

        var allTasks = Task.WhenAll(tasks);

        try
        {
            // Await completion of all tasks
            await allTasks;
            return true;
        }
        catch (Exception e)
        {
            // One task failed → cancel the rest
            cts.Cancel();

            // Attach continuation to swallow/log remaining errors,
            // but don't *await* (so you don’t block).
            _ = Task.WhenAll(tasks).ContinueWith(t =>
            {
                var ignored = t.Exception; // observe & ignore
            }, TaskContinuationOptions.OnlyOnFaulted);

            Melon<UpdaterPlugin>.Logger.Warning(e);

            return false;
        }
    }
}