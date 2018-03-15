# Follow https://stackoverflow.com/a/43880251/.

ApiKey=$1
Source=$2

nuget push ./SqlHelper/bin/Debug/SqlWrapperLite.*.nupkg -Verbosity detailed -ApiKey $ApiKey -Source $Source
