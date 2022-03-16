FMT = png
OPT = font "Arial,20" size 1024,600
PLOT = Cspline
PLOTFILE=$(PLOT).$(FMT)
DATA = out.txt
ECHO=/bin/echo

$(PLOTFILE): $(PLOT).gpi $(DATA)
	pyxplot $<

$(DATA): main.exe
	mono $< >$@

main.exe: main.cs matlib.dll
	mcs $< -reference:$(lastword $^)

matlib.dll: cspline.cs
	mcs $< -target:library -out:$@

$(PLOT).gpi: Makefile
	cat /dev/null >$@
	$(ECHO) 'set terminal $(FMT)' >>$@
	$(ECHO) 'set output "$(PLOTFILE)"' >>$@
	$(ECHO) 'set multiplot' >>$@
	$(ECHO) 'set key below' >>$@
	$(ECHO) 'set grid' >>$@
	$(ECHO) 'set title "Interpolation"' >>$@
	$(ECHO) 'set origin -5,4' >>$@
	$(ECHO) 'plot [][]\' >>$@
	$(ECHO) ' "$(DATA)" index 0 using 1:2 with points pointtype 7 title "points"\' >>$@
	$(ECHO) ',"$(DATA)" index 1 using 1:2 with lines title "exact"\' >>$@
	$(ECHO) ',"$(DATA)" index 1 using 1:3 with lines title "cspline"' >>$@
	$(ECHO) 'set title "Derivative"' >>$@
	$(ECHO) 'set origin 5,4' >>$@
	$(ECHO) 'plot [][]\' >>$@
	$(ECHO) ' "$(DATA)" index 2 using 1:2 with lines title "exact derivative"\' >>$@
	$(ECHO) ',"$(DATA)" index 2 using 1:3 with lines title "spline derivative"' >>$@
	$(ECHO) 'set title "Integral"' >>$@
	$(ECHO) 'set origin -5,-4' >>$@
	$(ECHO) 'plot [][]\' >>$@
	$(ECHO) ' "$(DATA)" index 3 using 1:2 with lines title "exact integral"\' >>$@
	$(ECHO) ',"$(DATA)" index 3 using 1:3 with lines title "spline integral"' >>$@

clean:
	rm -f *.exe *.dll $(PLOTFILE) $(DATA) *.gpi *.svg out*
