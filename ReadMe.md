# Internet Music Database

This project is meant as a personal project for demonstration and development with skills in RESTful API's, Clean Architecture, and SOLID OOP implementation.
Included is a React UI Client that consumes the API.

## Description

This is a REST API built with that mimics a lightweight version of an Internet Music Database or **IMuDB**. Implemented with [ASP.NET](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-8.0) and [Entity Framework](https://learn.microsoft.com/en-us/ef/) handling the abstraction between code and the SQL Database.

## Getting Started

### Dependencies

- [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Entity Framework](https://learn.microsoft.com/en-us/ef/core/get-started/overview/install)
- [Visual Studio or Visual Studio Code](https://visualstudio.microsoft.com/downloads/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Architecture

### Endpoints

basic URI supported `https://localhost:{port}/api/{controller}`

#### Controllers

**Album**

| Verb     | Route                            | Return Codes |
| -------- | -------------------------------- | ------------ |
| `Get`    | `/album?artistId={optional}`     | 200 / 400    |
| `Get`    | `/album/{albumId}`               | 200 / 400    |
| `Post`   | `/album`                         | 200 / 400    |
| `Put`    | `/album`                         | 204 / 400    |
| `Delete` | `/album/{albumId}`               | 204 / 400    |
| `Get`    | `/album/{albumId}/song/{songId}` | 200 / 400    |
| `Put`    | `/album/{albumId}/song/{songId}` | 204 / 400    |

**Artist**

| Verb     | Route                | Return Codes |
| -------- | -------------------- | ------------ |
| `Get`    | `/artist`            | 200 / 400    |
| `Get`    | `/artist/{artistId}` | 200 / 400    |
| `Post`   | `/artist`            | 200 / 400    |
| `Put`    | `/artist`            | 204 / 400    |
| `Delete` | `/artist/{artistId}` | 204 / 400    |


### Models

#### Album Models

| AlbumCreate                                                                                                                                                                                        | AlbumReturn                                                        | AlbumDetails                                                                                                                                                                                                         | AlbumUpdate                                                        |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------ |
| <pre>{<br>"Name": string,<br>"Year": int,<br>"ArtistId": Guid,<br>"Songs":[{<br> "Name": string,<br> "Length": int,<br> "Track": int,<br> "Genre": string,<br> "Lyrics": string,<br> }]<br>}</pre> | <pre>{<br>"Id": Guid,<br>"Name": string,<br>"Year": int<br>}</pre> | <pre>{<br>"Id": Guid,<br>"Name": string,<br>"Year": int,<br>"ArtistName": string,<br>"Songs": [{<br> "Id": Guid,<br> "Name": string,<br> "Length": int,<br> "Track": int<br>}],<br> "UpdatedAt": DateTime<br>}</pre> | <pre>{<br>"Id": Guid,<br>"Name": string,<br>"Year": int<br>}</pre> |

#### Artist Models

| ArtistCreate                                                | ArtistReturn                                                             | ArtistDetails                                                                                                                                                            | ArtistUpdate                                           |
| ----------------------------------------------------------- | ------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------ |
| <pre>{<br>"Name": string,<br>"Members": string[]<br>}</pre> | <pre>{<br>"Id": Guid<br>"Name": string<br>"Members": string[]<br>}</pre> | <pre>{<br>"Id": Guid<br>"Name": string<br>"Members": string[]<br>"Albums": {<br> "Id": Guid<br> "Name": string<br> "Year": int<br>},<br>"UpdatedAt": DateTime<br>}</pre> | <pre>{<br>"Id": Guid<br>"Members": string[]<br>}</pre> |

#### Song Models

| SongCU                                           | SongDetails                                                                                                                                                                                      | SongReturn                                                                      |
| ---------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------- |
| <pre>{<br>"Id": Guid,<br>"Lyrics": string,<br>}<pre> | <pre>{<br>"Id": Guid,<br>"Name": string,<br>"Length": int,<br>"Track": int,<br>"Genre": string,<br>"Lyrics": string,<br>"Album": {<br>},<br>"Artist: {<br>},<br>"UpdatedAt": DateTime<br>}</pre> | <pre>{<br>"Id": Guid,<br>"Name": string,<br>"Length": int,<br>"Track": int<br>} |


## Front End UI
### React + Vite

This template provides a minimal setup to get React working in Vite with HMR and some ESLint rules.

Currently, two official plugins are available:

- [@vitejs/plugin-react](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react/README.md) uses [Babel](https://babeljs.io/) for Fast Refresh
- [@vitejs/plugin-react-swc](https://github.com/vitejs/vite-plugin-react-swc) uses [SWC](https://swc.rs/) for Fast Refresh
