# ASP.NET Core Grundkurs

Kurs Repository zum Kurs ASP.NET Core Grundkurs der ppedv AG.

## M001 | ASP.NET Überblick

-   [x] Historie
-   [x] Projekte und Projektmappen
-   [x] ASP.Net Core Empty: Hello, World

## M002 | Konfiguration

-   [x] IOC mittels Dependency Injection
-   [x] Aufbau appsettings.json
-   [x] Logging konfigurieren (Files/OTLP)
-   [x] Lab: Dependency Injection OperationService

## M003 | Controller

-   [x] Overview
-   [x] Recipe Model erstellen
-   [x] Recipe Controller erstellen
-   [x] Api testen mit [httpFiles](https://learn.microsoft.com/en-us/aspnet/core/test/http-files)

## M004 | Model View Controller (MVC)

-   [x] Overview
-   [x] Links setzen
-   [x] Index und Details
-   [x] Layout: [Bootstrap Examples](https://getbootstrap.com/docs/4.0/examples/)
-   [x] Lab: MovieService und MVC App mit Index und Details

## M005 | Forms und Validierung

-   [x] ViewModel Mapping
-   [x] Form Post & Validierung
-   [x] ModelState
-   [x] Lab: Create Page für Movies erstellt

## M006 | FileServer erstellen

-   [ ] Static Files und Directory Browser
-   [ ] File Provider und Dateizugriff
-   [ ] [Hoppscotch](https://hoppscotch.io/) (Postman Alternative)
-   [ ] API mit [httpFile testen](https://learn.microsoft.com/de-de/aspnet/core/test/http-files)
-   [ ] Api-Key mittels Middleware abfragen
-   [ ] Lab: Request Culture Middleware

## M007 | HttpClient verwenden

-   [ ] Konfiguration auslesen
-   [ ] HttpClient verwenden
-   [ ] MultipartFormDataContent
-   [ ] HttpContext, Request, Response

## M008 | EFCore: Code First & Testing

-   [x] O/R Mapping Framework EFCore
-   [x] Code First Ansatz (Entites + DbContext)
-   [x] LocalDB verwenden (Kommandozeile: `sqllocaldb create|start|stop|info <instanceName>`)
-   [x] [Testing Strategien gegen Datenbank](https://learn.microsoft.com/de-de/ef/core/testing/)
-   [x] Seed erstellen und Abhängigkeiten modellieren
-   [x] DB Migration 

```bash
// Package Manager Console aufrufen
// Default project: Shared/BusinessLogic

Add-Migration InitDeliveryData -Context DeliveryDbContext

Update-Database

```

-   [x] Unit Tests mit EntityFramework
-   [ ] OrderService anhand von Tests entwickeln
-   [ ] Dashboard fuer aktuelle Orders anzeigen

## M009 | Razor Pages & EF Core: DB First

-   [x] Overview
-   [x] [Northwind DB](https://github.com/microsoft/sql-server-samples/blob/master/samples/databases/northwind-pubs/instnwnd.sql)
-   [x] DB First Ansatz
-   [x] VS Extension [EF Core Power Tools](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerTools)
-   [x] Controller mit Scaffolding erstellen (Microsoft.EntityFrameworkCore.Design)

## M010 | Benutzerverwaltung

-   [x] AspNetCore.Identity.EFCore
-   [x] CodeFirst & Migration
-   [x] UserManager & SignInManager
-   [x] Form Post & Validierung
-   [ ] MS Identity Platform gegen EntraId und GraphAPI

## M011 | Weitere Themen

-   [ ] Paging
-   [ ] Lokalisierung
-   [ ] WebAPI
-   [ ] Cookie Handling
-   [ ] Server Caching
-   [ ] Deployment 
