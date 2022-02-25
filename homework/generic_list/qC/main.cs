using static System.Console;

public class main {
	public static void Main() {
		list<int> a = new list<int>();
		a.push(1);
		a.push(2);
		a.push(3);
		WriteLine($"Printing list of int:");
		for(a.start(); a.current != null; a.next()) {
			WriteLine(a.current.item);
		}
		list<string> s = new list<string>();
		s.push("hello");
		s.push("world");
		s.push("!");
		WriteLine($"Printing list of string:");
		for(s.start(); s.current != null; s.next()) {
			WriteLine(s.current.item);
		}
	}
}

public class node <T> {
	public T item;
	public node<T> next;
	public node (T item) {this.item = item;}
}

public class list<T> {
	public node<T> first = null, current = null;
	public void push(T item) {
		if(first == null) {
			first = new node<T>(item);
			current = first;
		}
		else {
			current.next = new node<T>(item);
			current = current.next;
		}
	}
	public void start() {current = first;}
	public void next() {current = current.next;}	
}
