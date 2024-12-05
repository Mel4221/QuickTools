
#WINDOWS_RUNTIME="win-x64"
#LINUX_RUNTIME="linux-x64"
dotnet publish -c Release -r win-x64 --self-contained false -o bin/win
dotnet publish -c Release -r linux-x64 --self-contained false -o bin/linux
