SDKDIR=$(HOME)/.dotnet/sdk/6.0.102# or whatever your sdk is
CSCPATH=$(SDKDIR)/Roslyn/bincore/csc.dll
NETSTANDARD=$(SDKDIR)/ref/netstandard.dll
CONFIG=$(SDKDIR)/vstest.console.runtimeconfig.json
DOTNET=DOTNET_CLI_TELEMETRY_OPTOUT=1; dotnet
CSC=$(DOTNET) $(CSCPATH) -reference:$(NETSTANDARD)
RUN=$(DOTNET) exec --runtimeconfig $(CONFIG)
CSC = mcs
RUN = mono

all: Out.txt Fig.erf.png

Fig.erf.png: fig.erf.gpi erf.data.txt
	pyxplot $<

Out.txt	erf.data.txt: main.exe 
	$(RUN) $< 1> Out.txt 2> erf.data.txt

main.exe: main.cs integrate.dll

LIBDIR = ../../matlib #path to directory of integrate.cs
#integrate.dll: $(LIBDIR)/integrate/integrate.cs 
integrate.dll: integrate.cs
	$(CSC) -target:library -out:integrate.dll integrate.cs


%.exe: %.cs
	$(CSC) -t:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

%.dll: %.cs
	$(CSC) -t:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	$(RM) *.dll *.exe *.png *.txt log*
