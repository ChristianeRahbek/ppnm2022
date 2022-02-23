all: Out.txt
	cat Out.txt

Out.txt: main.exe
	mono main.exe > Out.txt

main.exe: main.cs genlist.dll
	mcs -target:exe -reference:genlist.dll -out:$@ $<

genlist.dll: genlist.cs
	mcs -target:library -out:genlist.dll genlist.cs
