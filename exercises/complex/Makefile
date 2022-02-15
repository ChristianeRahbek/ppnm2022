Out.txt: main.exe
	mono main.exe > Out.txt

main.exe: main.cs cmath.dll
	mcs -reference:cmath.dll main.cs

CMATHDIR = ~/repos/ppnm2022/exercises/complex
cmath.dll : $(CMATHDIR)/cmath.cs $(CMATHDIR)/complex.cs
	mcs -target:library -out:./cmath.dll $^ # note "./" in front of cmath.dll
