# How to test
These instructions assume that you already have installed .Net 8 SDK.
They also assume you have knowledge of cloning from a git-repository.

## Code coverage
1. Clone the project
2. Open a terminal or command prompt.
3. Navigate to the solution directory.
4. Run the following command to test the project:

```bash
dotnet test /p:CollectCoverage=true /p:Threshold=90 /p:ThresholdType=line /p:ThresholdStat=total /p:CoverletOutput=../cobertura.json
```

This command will execute the tests and collect code coverage information, ensuring that at least 90% of line coverage is enforced.

## Code coverage report
If you want a complete code coverage report you can execute the following commands in the solution directory:

```bash
dotnet tool restore

dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=../cobertura.xml

dotnet tool run reportgenerator -reports:./cobertura.xml -targetdir:coveragereport -reporttypes:Html
```

After these commands you should be able to open `./coveragereport/index.htm(l)` to view complete code coverage information.
