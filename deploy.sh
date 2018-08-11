# Follow:
#  - https://stackoverflow.com/a/43880251/
#  - https://github.com/travis-ci/travis-ci/issues/5932

ApiKey=$1
Source=$2

# Download latest version of nuget.exe.
curl -O https://dist.nuget.org/win-x86-commandline/latest/nuget.exe

# Output NuGet's version number.
mono ./nuget.exe

# Deploy package to nuget.org.
mono ./nuget.exe push ./SqlWrapperLite/bin/Release/SqlWrapperLite.*.nupkg -Verbosity detailed -ApiKey $ApiKey -Source $Source
