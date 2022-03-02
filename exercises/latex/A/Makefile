SDKDIR=$(HOME)/.dotnet/sdk/6.0.102# or whatever your sdk is
CSCPATH=$(SDKDIR)/Roslyn/bincore/csc.dll
NETSTANDARD=$(SDKDIR)/ref/netstandard.dll
CONFIG=$(SDKDIR)/vstest.console.runtimeconfig.json
DOTNET=DOTNET_CLI_TELEMETRY_OPTOUT=1; dotnet
CSC=$(DOTNET) $(CSCPATH) -reference:$(NETSTANDARD)
RUN=$(DOTNET) exec --runtimeconfig $(CONFIG)
CSC = mcs
RUN = mono

all:ms.pdf exp_pyx.pdf

ms.pdf:ms.tex exp_pyx.pdf 
	pdflatex $<
	pdflatex $<
#	bibtex $<
#	pdflatex $<

exp_pyx.pdf:fig.pyxplot.gpi out.exp.txt exp_data.txt
	pyxplot $<

out.exp.txt:main.exe
	$(RUN) $< > $@

exp_data.txt:exp_data.exe
	$(RUN) $< > $@

main.exe: main.cs sfuns.dll

sfuns.dll:sfuns.cs
	$(CSC) -t:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

%.exe: %.cs
	$(CSC) -t:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

%.dll: %.cs
	$(CSC) -t:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)
