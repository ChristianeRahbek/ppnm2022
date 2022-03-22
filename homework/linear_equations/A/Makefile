Out.txt: main.exe QRGS.cs
	mono $<

main.exe: main.cs QRGS.dll  math.dll
	mcs $< -target:exe -reference:QRGS.dll,math.dll

QRGS.dll: QRGS.cs math.dll
	mcs $< -target:library -reference:math.dll

math.dll: matrix.cs vector.cs
	mcs $< -target:library

.PHONY:
clean:
	rm *.exe *.txt
