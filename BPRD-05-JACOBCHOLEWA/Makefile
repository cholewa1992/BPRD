all: CLex.fs CPar.fs 

CLex.fs: CLex.fsl
	fslex --unicode CLex.fsl
CPar.fs: CPar.fsy 
	fsyacc --module CPar CPar.fsy
clean:
	rm -rf CLex.fs CPar.fs CPar.fsi
