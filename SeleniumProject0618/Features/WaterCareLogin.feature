@WaterCare
Feature: watercare 

#dotnet test --test-adapter-path:. --filter "Category=WaterCare" --logger:"xunit;LogFilePath=TestResults/SetupTests_$(date +%Y%m%d%H%M%S).xml"
#livingdoc test-assembly SeleniumProject0618/bin/Debug/net8.0/SeleniumProject0618.dll -t SeleniumProject0618/bin/Debug/net8.0/TestExecution.json --output ./SeleniumProject0618/TestResults/TestResultsCore_$(date +%Y%m%d%H%M%S).html 


Scenario: WaterCare Login
	Given watercare login
