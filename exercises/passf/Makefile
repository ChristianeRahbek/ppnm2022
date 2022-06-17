Out.txt: main.exe
	mono main.exe > Out.txt

main.exe: main.cs table.dll
	mcs $< -target:exe -reference:table.dll

table.dll: table.cs
	mcs $< -target:library
