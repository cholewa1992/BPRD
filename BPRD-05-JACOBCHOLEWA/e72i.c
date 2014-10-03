void main(){
	int arr[4];
	arr[0] = 7;
	arr[1] = 13;
	arr[2] = 9;
	arr[3] = 8;
	int *sum;

	arrsum(4, arr,sum);
	print *sum;
	println;
}

void arrsum(int n, int arr[], int *sump){
	*sump = 0;
	int i;
	i = 0;
	while(i < n){
		*sump = *sump + arr[i];
		i = i+1;
	}
}
