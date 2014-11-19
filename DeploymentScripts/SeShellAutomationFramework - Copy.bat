del /s C:\FinalTestResult\*.xml 
cd ..
cd SeShellTest
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\msbuild.exe SeShell.Test.csproj /p:configuration=debug
cd bin\debug
"C:\Users\ruzaika\Downloads\Libraries\NUnit-2.6.3\bin\nunit-console.exe" /fixture:SeShell.Test.TestCases.TestSuite SeShell.Test.dll
cd ..
cd ..
cd ..
cd SeShell.Test.XMLTestResult\bin\Debug\
SeShell.Test.XMLTestResult.exe
del /s C:\SeShellResult\*.xml 
cd ..\..\..\DeploymentScripts