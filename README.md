## Introduction
This repo is a code sample to reproduce an issue i faced as mentioned in [here](https://github.com/dotnet/efcore/issues/30127)

## How to run
- clone this repository
- open the folder in vscode as a dev container
- go to ```src/Runner``` 
- run `dotnet dev-certs https --trust`, (optional)
- run `dotnet run`
- make a request to `GET /test` endpoint

## The issue
- The first request always works and data is saved to database, but any subsequent calls to the endpoint fails with the error

    `SqlException: Violation of PRIMARY KEY constraint 'PK_status'. Cannot insert duplicate key in object 'test.status'. The duplicate key value is (1).`




