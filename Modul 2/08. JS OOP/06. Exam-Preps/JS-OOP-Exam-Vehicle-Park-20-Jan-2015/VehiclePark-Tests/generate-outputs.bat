FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    node VehiclePark-Skeleton.js < "%%f" > "!file:.in.txt=.out.txt!"
)
