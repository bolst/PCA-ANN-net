$env_dat = Get-Content .\env.json -Raw | ConvertFrom-Json
$env = $env_dat.env

if ( $env -eq "dev") {
    dotnet watch --project .\PCA-ANN-web\RehseBlazor.csproj
}
else {
    .\run-docker.ps1
}