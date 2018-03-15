# Follow https://stackoverflow.com/a/43880251/.

ApiKey=$1
Source=$2

mono nuget.exe setApiKey $ApiKey -Source $Source -Verbosity quiet

mono nuget.exe push ./SqlHelper/bin/Release/SqlWrapperLite.*.nupkg -Source $Source
