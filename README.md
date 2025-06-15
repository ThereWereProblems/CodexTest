# MyPrivateDrive

Simple private file storage application with Angular frontend, ASP.NET Core backend and PostgreSQL database. The whole stack runs with Docker Compose.

## Requirements
- Docker
- Docker Compose

## Running
Clone the repository and run:

```bash
docker-compose up --build
```

The frontend will be available at `http://localhost:4200` and the backend API at `http://localhost:5000`.

## Environment variables
Edit `.env` to change default credentials and JWT key.

## Architecture
- **Frontend**: Angular 17 application served by Nginx.
- **Backend**: ASP.NET Core Web API with JWT authentication.
- **Database**: PostgreSQL storing user and file metadata.

Uploaded files are stored in the Docker volume `uploads`.

This project is a minimal example and can be extended with user registration and password reset functionality.
