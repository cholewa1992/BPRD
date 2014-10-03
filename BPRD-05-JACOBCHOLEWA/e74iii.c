void main(){
	int arr[5]; //if this array is smaller that the max given then the histogram function will override un-allocated memory, namly the arr pointer and ns[0], ns[1] and so on...
	int ns[7];
	ns[0] = 1;
	ns[1] = 2;
	ns[2] = 1;
	ns[3] = 1;
	ns[4] = 1;
	ns[5] = 2;
	ns[6] = 0;

	histogram(7,ns, 3, arr);

	int i;

	for(i = 0; i < 5; ++i){
		print arr[i];
		println;
	}
}

void histogram(int n, int ns[], int max, int freq[]){
	int c; int i;

	for(i = 0; i < max; ++i){
		freq[i] = 0;
	}

	for(i = 0; i < n; ++i){
		c = ns[i];
		freq[c] = freq[c] + 1;
	}
}
