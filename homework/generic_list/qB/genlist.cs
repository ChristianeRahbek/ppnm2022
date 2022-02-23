public class genlist<T> { public T[] data;

	public int size = 0, capacity = 8;

	public genlist() {
		data = new T[capacity];
	}

	public void push(T item) { //add an item to list
		if(size == capacity) {
			T[] newdata = new T[capacity *= 2];
			for(int i = 0; i < size; i++) {
				newdata[i] = data[i];
			}
			data = newdata;
		}
		data[size] = item;
		size++;
	}
	
	public void remove(int i) { //removes element number "i"
		T[] newdata = new T[capacity];
		for(int j = 0; j < size; j++) {
			if(j < i) newdata[j] = data[j];
			if(j > i) newdata[j-1] = data[j];
		}
		data = newdata;
		size--;
	}

}
