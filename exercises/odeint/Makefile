SDKDIR=$(HOME)/.dotnet/sdk/6.0.102# or whatever your sdk is
CSCPATH=$(SDKDIR)/Roslyn/bincore/csc.dll
NETSTANDARD=$(SDKDIR)/ref/netstandard.dll
CONFIG=$(SDKDIR)/vstest.console.runtimeconfig.json
DOTNET=DOTNET_CLI_TELEMETRY_OPTOUT=1; dotnet
CSC=$(DOTNET) $(CSCPATH) -reference:$(NETSTANDARD)
RUN=$(DOTNET) exec --runtimeconfig $(CONFIG)
CSC = mcs
RUN = mono

all: Fig.osc.png

Fig.osc.png: fig.oscillator.gpi osc.data.txt
	pyxplot $<

osc.data.txt: main.exe 
	$(RUN) $< 1> $@ 2> log

main.exe: main.cs matlib.dll

matlib.dll: ode.cs vector.cs
	$(CSC) -target:library -out:./$@ $^

#vector.dll: vector.cs
#	$(CSC) -target:library -out:vector.dll vector.cs

%.exe: %.cs
	$(CSC) -t:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

%.dll: %.cs
	$(CSC) -t:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	$(RM) *.dll *.exe *.png *.txt log*
