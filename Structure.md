# Klassische HTML Seite

## Bei jedem Webserver, egal ob IIS, Apache, etc.

/wwwroot
/wwwroot/index.html -- W�rde vom Browser automatisch aufgerufen werden bei 
	>> http://example.com

/wwwroot/home.html -- Wenn index auf Home ein Link hat, dann w�re die Url 
	>> http://example.com/home

/wwwroot/content/foo.html -- Wenn man diese aufrufen m�chte, dann w�re die Url 
	>> http://example.com/content/foo

/wwwroot/content/index.html -- 
	>> http://example.com/content/index

Wenn Webserver so konfiguriert ist, dass er die index.html in einer Seite automatisch sucht, dann kann man es weglassen.
	>> http://example.com/content -- Geht auf die /wwwroot/content/index.html

## ASP.Net Struktur

/Views -- Zentraler Ordner, welcher wwwroot bei regul�ren Web-Servern entspricht
/Views/_ViewStart.html -- Einstiegspunkt, welcher (per Default) auf die _Layout.html zeigt

-- ASP.Net sucht automatisch nach .cshtml Dateien im Stammverzeichnis (Views) und Views/Shared

/Views/`Home`/index.cshtml -- �ber den `Home`Controller wird zu dieser View hier navigiert
/Views/`Movies`/index.cshtml -- Hier �ber `Movies`Controller

