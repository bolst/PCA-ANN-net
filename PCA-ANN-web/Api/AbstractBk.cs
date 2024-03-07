namespace RehseBlazor.Api;

public abstract class AbstractBk
{

    protected string ErrorMessage {get; set;} = "";

    protected HttpClient client = new HttpClient();

    protected abstract Task<string> Call();

    public abstract bool IsCallable();

    public abstract bool IsComplete();

    public abstract StateService.STATE StateAfterCompletion();

    public async Task<bool> Perform()
    {
        // to ensure the http request doesn't time out while waiting for pca/ann to run
        client.Timeout = TimeSpan.FromMinutes(10);

        if (IsCallable())
        {
            Task<string> statusCall = Call();

            string retval = await statusCall;

            if (retval == "success")
            {
                StateService.Instance().State = StateAfterCompletion();
                return true;
            }
            else
            {
                ErrorMessage = retval;
                return false;
            }
        }
        else
        {
            Console.WriteLine("Not there yet");
        }

        return false;
    }

    protected string UriBase() { return @"http://127.0.0.1:8000/"; }//@"http://host.docker.internal:8000/"; }

    public string GetError() { return ErrorMessage; }


}