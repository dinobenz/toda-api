::variables
set username=%USERNAME%
set current_dir=%CD%
set open_cover_path=c:\Users\%username%\AppData\Local\Apps\OpenCover
set nunit_path=C:\Program Files (x86)\NUnit 2.6.3\bin\nunit-console-x86.exe
set report_generator_path="c:\Users\%username%\AppData\Local\Apps\ReportGenerator"
set output_report_path=%current_dir%\OpenCoverReport
set output_report_file=%current_dir%\OpenCoverReport\coverage.xml
set test_dll=src\toda-api.test\bin\Debug\toda.api.test.dll

::open cover
%open_cover_path%\OpenCover.Console.exe -register:user -target:"%nunit_path%" -targetargs:"%test_dll% /noshadow" -output:"OpenCoverReport\coverage.xml" -filter:"+[*]* -[*]*.BundleConfig -[*]*.FilterConfig -[*]*.IoC -[*]*.RouteConfig -[*]*.WebApiApplication -[*]*.WebApiConfig"


::sleep
sleep 5


::generate report
%report_generator_path%\ReportGenerator.exe -reports:OpenCoverReport\coverage.xml -targetdir:OpenCoverReport


::open report
start OpenCoverReport\index.htm