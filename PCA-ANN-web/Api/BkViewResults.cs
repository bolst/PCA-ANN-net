namespace RehseBlazor.Api;

public class BkViewResults : AbstractBk
{
    protected override async Task<string> Call()
    {
        Console.WriteLine("Hello from view results!");
        await Task.Delay(1);
        return "success";
    }

    public override StateService.STATE StateAfterCompletion() { return StateService.Instance().State; }

    public override bool IsComplete() { return StateService.Instance().State >= StateService.STATE.AnnRan; }

    public override bool IsCallable() { return StateService.Instance().State >= StateService.STATE.AnnRan; }


}