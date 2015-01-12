void main() {
	int a[1 .. 2 .. 20];
	int i; i = 0;
	print |a|;
	while (i < 10) {
		print a[i];
		i=i+1; 
	}
}
