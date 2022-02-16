using System;
using System.IO;
using static System.Console;
using static System.Math;

public class qA{
	static public void Main(){
		char[] delimiters = {' ','\t','\n'};
		var options = StringSplitOptions.RemoveEmptyEntries;
		
		for( string line = ReadLine(); line != null; line = ReadLine() ){
			var words = line.Split(delimiters,options);
			foreach(var word in words){
				double x = double.Parse(word);
				WriteLine($"{x} {Sin(x)} {Cos(x)}");
			}
		}
	}
}
