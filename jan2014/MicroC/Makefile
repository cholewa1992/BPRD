all: CLex.fs CPar.fs Machine.class
CLex.fs: CLex.fsl
	fslex --unicode CLex.fsl
CPar.fs: CPar.fsy 
	fsyacc --module CPar CPar.fsy
Machine.class: Machine.java
	javac Machine.java
clean:
	rm -rf Machine.class CLex.fs CPar.fs CPar.fsi *.out