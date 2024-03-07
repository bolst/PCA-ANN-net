namespace RehseBlazor.Api;

public class BkRunAnn : AbstractBk
{
    protected override async Task<string> Call()
    {
        try
        {
            var response = await client.PostAsJsonAsync<OptionProfileController>($"{UriBase()}/runann", OptionProfileController.Instance());

            if (response.IsSuccessStatusCode)
            {
                string response_value = await response.Content.ReadAsStringAsync();
                return response_value;
            }
        }
        catch(Exception exc)
        {
            Console.WriteLine(exc.ToString());
            return exc.ToString();
        }

        Console.WriteLine("Hello from run ann!");
        return "success";
    }

    public override StateService.STATE StateAfterCompletion() { return StateService.STATE.AnnRan; }

    public override bool IsComplete() { return StateService.Instance().State >= StateService.STATE.AnnRan; }

    public override bool IsCallable() { return StateService.Instance().State >= StateService.STATE.PcaScoresLoaded; }

}