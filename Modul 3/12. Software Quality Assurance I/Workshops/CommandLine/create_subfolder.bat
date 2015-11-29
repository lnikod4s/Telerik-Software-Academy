@echo off
IF EXIST %1 (
	RD %1
) ELSE (
	MD %1
)