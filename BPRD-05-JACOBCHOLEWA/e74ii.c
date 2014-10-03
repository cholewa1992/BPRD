void main(){
	int arr[5];
	square(5, arr);

	int *sum;

	arrsum(5, arr,sum);
	print *sum;
	println;
}

void arrsum(int n, int arr[], int *sump){
	*sump = 0;
	int i;
	for(i = 0; i < n; ++i){
		*sump = *sump + arr[i];
	}
}

void square(int n, int arr[]){
	int i;
	for(i = 0; i < n; ++i){
		arr[i] = i*i;
	}
}
