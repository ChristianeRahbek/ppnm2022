
erf.pyxplot.png: erf.data.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel '$$ x $$' \n\
	set ylabel '$$ y $$' \n\
	set title 'error function' \n\
	set key left top \n\
	plot [-2: 2] [-1: 1]'$<' index 0 using 1:2 with lines title 'error function',\ \n\
	'erf.tab.txt' with points pointtype 2 title 'Table values' \n\
	"| tee log.gpi | pyxplot

#add points manually to  erf.tab.txt file
#erf.tab.txt: Makefile
#	echo 0 0 1 > $@
#	echo *next values*

erf.data.txt: main.exe
	mono $< > $@

%.exe: %.cs
	mcs $<
