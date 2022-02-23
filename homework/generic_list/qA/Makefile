
SDKDIR=$(HOME)/-dotnet/sdk/6.0.102 #the location is my sdk should be here. this is just c/p from Dimitri.
CSCPATH=$(SDKDIR)/Roslyn/bincore/csc.dll
NETSTANDARD=$(SDKDIR)/ref/netstandard.dll
CONFIG=$(SDKDIR)/vstest.console.runtimeconfig.json
DOTNET=DOTNET_CLI_TELEMETRY_OUTPUT=1 && dotnet
CSC=$(DOTNET) $(CSCPATH) -reference:$(NETSTANDARD)
RUN=$(DOTNET) exec --runtimeconfig $(CONFIG)
CSC = mcs
RUN = mono

Out.txt: main.exe
	$(RUN) $< < input.txt 1> $@

main.exe: main.cs genlist.dll
	$(CSC) -target:exe -out:$@ -reference:genlist.dll main.cs

genlist.dll: genlist.cs
	$(CSC) -target:library -out:genlist.dll genlist.cs
