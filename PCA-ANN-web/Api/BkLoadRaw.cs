using System.Reflection.Emit;
using Blazorise.Extensions;

namespace RehseBlazor.Api;

public class BkLoadRaw : AbstractBk
{
    protected override async Task<string> Call()
    {
        try{
            var response = await client.PostAsJsonAsync<OptionProfileController>($"{UriBase()}/loadfile", OptionProfileController.Instance());

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

        Console.WriteLine("Hello from load raw data!");
        return "success";
    }

    public override StateService.STATE StateAfterCompletion() { return StateService.STATE.RawDataLoaded; }

    public override bool IsComplete() { return StateService.Instance().State >= StateService.STATE.RawDataLoaded; }

    public override bool IsCallable() { return StateService.Instance().State >= StateService.STATE.Init; }
}
