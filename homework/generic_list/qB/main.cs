using System;
using static System.Console;

class main {
	public static void Main() {
		genlist<int> list = new genlist<int>();
		list.push(0);
		list.push(1);
		list.push(2);
		list.push(3);
		Write(list);
		list.remove(1);
		Write(list);
	}

	static void Write(genlist<int> list) {
		WriteLine($"List contains:");
		for(int i = 0; i < list.size; i++) {
			WriteLine($"item number {i} is {list.data[i]}");
			//this seems like a problem, as it will list the last numbers "empty" spaces in the list as 0 instead of not being there.
		}
		WriteLine($"");
	}
}
