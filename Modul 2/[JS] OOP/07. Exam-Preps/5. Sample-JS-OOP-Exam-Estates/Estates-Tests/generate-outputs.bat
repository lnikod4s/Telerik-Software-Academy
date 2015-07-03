FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    node ../Estates-Solution/Estates-Classical-Inheritance.js < "%%f" > "!file:.in.txt=.out.txt!"
)
PAUSE
