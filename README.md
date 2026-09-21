# LuxStay - Sistema de Gestión Hotelera

Sistema de escritorio desarrollado en **C# (.NET)** con interfaz en **Windows Forms** y base de datos relacional en **Microsoft SQL Server**. Permite la administración integral de hoteles, tipos de habitaciones, check-in, check-out, asignación de amenidades, facturación y reportes estadísticos de ocupación.

---

## Demostración en Video
https://www.youtube.com/watch?v=UC4XEWAWvew

---

## Requisitos Previos

Antes de ejecutar el proyecto, asegúrate de contar con lo siguiente instalado en tu equipo:
* **Visual Studio 2022** (con la carga de trabajo *Desarrollo de escritorio de .NET* instalada).
* **Microsoft SQL Server** (2016 o superior / Express / Developer).
* **SQL Server Management Studio (SSMS)**.

---

## Configurar Credenciales en App.config

En el Explorador de soluciones, haz doble clic en el archivo App.config para abrirlo.

Busca la sección <connectionStrings> y edita la línea con el nombre SQLCONEXION. Debes asegurarte de apuntar a la base de datos LuxStay y colocar tu usuario y tu contraseña de SQL Server:
