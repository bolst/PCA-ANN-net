using RehseBlazor.Data;

public class OptionProfileController
{
    #region singleton
    private static OptionProfileController? instance = null;
    private OptionProfileController(){}
    public static OptionProfileController Instance()
    {
        if (instance == null) instance = new OptionProfileController();
        instance.GetOptions();
        return instance;
    }
    #endregion

    private void GetOptions()
    {
        OptionProfile inst = OptionProfile.Instance();

        components = (int)inst.NumComponents.Value();
        fullSpectrum = (bool)inst.FullSpectrum.Value();
        framework = (string)inst.Framework.Value();
        optimizer = (string)inst.Optimizer.Value();
        activation = (string)inst.Activation.Value();
        loss = (string)inst.Loss.Value();
        epochs = (string)inst.Epochs.Value();
        batchSize = (string)inst.BatchSize.Value();
        patience = (string)inst.Patience.Value();
        hiddenNodes = (string)inst.HiddenNodes.Value();
        runs = (int)inst.Runs.Value();
        classNumber = (int)inst.ClassNumber.Value();
    }

    public string? rawDataFilename {get; set;}
    public string? pcaScoresFilename {get; set;}
    public int? components {get; set;}
    public bool? fullSpectrum {get; set;}
    public string? framework {get; set;}
    public string? optimizer {get; set;}
    public string? activation {get; set;}
    public string? loss {get; set;}
    public string? epochs {get; set;}
    public string? batchSize {get; set;}
    public string? patience {get; set;}
    public string? hiddenNodes {get; set;}
    public int? runs {get; set;}
    public int? classNumber {get; set;}
}