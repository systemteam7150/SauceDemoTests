Clone repository project

With Visual Studio open project , select SauceDemoTests.csproj

Click on the root, with right-mouse key select "Restore Nuget Packages"

In the Visual Studio, click on the View -> Test Explorer

When Test Explorer panel is opened select any test from the tree and with the right-mouse key select Run (make sure you have FireFox installed)


With Command line commands:
1. Prerequisite: Install .NET 8 Runtime https://dotnet.microsoft.com/en-us/download/dotnet/8.0
1. git clone https://github.com/systemteam7150/SauceDemoTests.git
2. cd SauceDemoTests
3. dotnet restore
4. dotnet test --filter "Name=Test1_VerifyLogin" OR
5. dotnet test --filter "Name=Test2_AddAndBuyItems" OR
6. dotnet test --filter "Name=Test3_PurchaseWithinRange"

