# My Gym Bro

A gym log with progression. This repository holds the Flutter app and the ASP.NET Core API.

## Prerequisites

- .NET 10 SDK
- Flutter stable (this app was created with 3.41.6)
- Docker, for local PostgreSQL

The local database user and database name are `mygymbro`. The password is not in source. Copy `.env.example` to `.env` and set `POSTGRES_PASSWORD`. Use that same value in `ConnectionStrings__Database`.

## Layout

```text
my_gym_bro/                 Flutter app
api/MyGymBro/               API solution (MyGymBro.slnx)
  MyGymBro.Api/             HTTP host
  MyGymBro.Infrastructure/  PostgreSQL via EF Core
  MyGymBro.Api.Tests/       API integration tests
api/Directory.Build.props
api/Directory.Packages.props
```

## Run PostgreSQL

```bash
docker compose up -d
```

Docker Compose reads `POSTGRES_PASSWORD` from `.env`. PostgreSQL listens on `localhost:5432`.

## Run the API

The API reads `ConnectionStrings__Database` from the environment. Load `.env` in the same shell, then start the host:

```bash
set -a
source .env
set +a
dotnet run --project api/MyGymBro/MyGymBro.Api --launch-profile https
```

The development HTTPS endpoint is `https://localhost:7137`. OpenAPI is mapped only in Development, at `/openapi/v1.json`. `GET /health` checks that PostgreSQL accepts a connection.

```bash
dotnet test api/MyGymBro/MyGymBro.slnx
```

## Run the app

```bash
cd my_gym_bro
flutter pub get
flutter run
```
