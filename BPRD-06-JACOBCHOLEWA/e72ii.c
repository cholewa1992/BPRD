void main(){
	int arr[5];
	square(5, arr);

	int sum;
	arrsum(5, arr,&sum);
	print sum;
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

void square(int n, int arr[]){
	int i;
	i = 0;
	while(i < n){
		arr[i] = i*i;
		i = i+1;
	}
}
