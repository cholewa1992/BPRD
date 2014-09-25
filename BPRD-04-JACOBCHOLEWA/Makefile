all: trees.pdf FunPar.fs FunLex.fs

FunPar.fs: FunPar.fsy
	fsyacc --module FunPar FunPar.fsy
FunLex.fs: FunLex.fsl
	fslex --unicode FunLex.fsl


trees.pdf: trees.tex
	pdflatex trees.tex
clean:
	rm -rf trees.pdf trees.aux trees.log FunLex.fs FunPar.fs FunPar.fsi
