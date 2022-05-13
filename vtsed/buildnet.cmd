@echo off

cd ..
set path=%cd%

if exist "C:\Program Files\Microsoft Visual Studio\2022\Community\Msbuild\Current\Bin" (
    cd "C:\Program Files\Microsoft Visual Studio\2022\Community\Msbuild\Current\Bin"
    msbuild %path%\libs.sln -nologo -v:q -p:warninglevel=0 -p:configuration=Debug -p:platform=x64
    msbuild %path%\libs.sln -nologo -v:q -p:warninglevel=0 -p:configuration=Release -p:platform=x64
    msbuild %path%\libs.sln -nologo -v:q -p:warninglevel=0 -p:configuration=Debug -p:platform=x86
    msbuild %path%\libs.sln -nologo -v:q -p:warninglevel=0 -p:configuration=Release -p:platform=x86
)

exit
