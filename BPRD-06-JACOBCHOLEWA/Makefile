all: CLex.fs CPar.fs Machine.class

Machine.class: Machine.java
	javac Machine.java

CLex.fs: CLex.fsl
	fslex --unicode CLex.fsl
CPar.fs: CPar.fsy 
	fsyacc --module CPar CPar.fsy
clean:
	rm -rf *class CLex.fs CPar.fs CPar.fsi
