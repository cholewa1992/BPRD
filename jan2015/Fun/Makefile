all: FunPar.fs FunLex.fs
FunPar.fs: FunPar.fsy
	fsyacc --module FunPar FunPar.fsy
FunLex.fs: FunLex.fsl
	fslex --unicode FunLex.fsl
clean:
	rm -rf FunLex.fs FunPar.fs FunPar.fsi
