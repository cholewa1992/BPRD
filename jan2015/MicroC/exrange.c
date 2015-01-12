void main() {
	int a[1	.. 2 .. 20]; sumArr(a, |a|);
	int b[-100 .. 1 .. 100]; sumArr(b, |b|);
	int c[50 .. -5 .. 0]; sumArr(c, |c|);
	int d[10 .. -2 .. -10]; sumArr(d, |d|);
	int e[10 .. 1 .. 10]; sumArr(e, |e|);
}

void sumArr(int arr[], int len){
	int i; i = 0;
	int sum; sum = 0;
	while (i < len){
		sum = sum + arr[i];	
		i=i+1;
	}
	print sum;
}
