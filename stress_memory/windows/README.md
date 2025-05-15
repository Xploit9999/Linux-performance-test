# MemorySimulatorService

`MemorySimulatorService` es un servicio de Windows escrito en C# que simula carga de memoria en un sistema Windows. Su propósito principal es probar el comportamiento del sistema o de aplicaciones bajo condiciones de presión de memoria.

---

## 🧠 ¿Qué hace este servicio?

El servicio monitorea el uso de memoria RAM en el sistema. Si la memoria utilizada es inferior al 90%, comienza a consumir más memoria reservando bloques de datos grandes en intervalos regulares, hasta alcanzar ese límite.

---

## ⚙️ Funcionamiento

- Se ejecuta como un **servicio de Windows**.
- Usa `PerformanceCounter` para medir la memoria disponible.
- Crea cadenas de texto grandes para simular consumo de RAM.
- Agrega nuevos bloques cada 10 segundos, si el uso de memoria sigue por debajo del 90%.
- Libera la memoria al detener el servicio.

---

## 📁 Estructura principal

- `OnStart`: Inicia un hilo que ejecuta el método `WorkerMethod`.
- `WorkerMethod`: Evalúa periódicamente el porcentaje de uso de memoria y reserva más si es necesario.
- `OnStop`: Libera los recursos consumidos.
- `Main`: Punto de entrada del servicio.

---

## 📦 Requisitos

- Visual C# Compiler version +4.0
- Windows con permisos para instalar y ejecutar servicios

---

## 🛠️ Instalación del servicio

1. Compila el proyecto como un ejecutable (`.exe`).

```bash
PS> cd C:\Windows\Microsoft.NET\Framework\v4.0.30319
PS> csc.exe /t:exe /out:C:\Temp\MemorySimulatorService.exe C:\Temp\MemorySimulatorService.cs /reference:System.ServiceProcess.dll /reference:Microsoft.VisualBasic.dll
```

2. Usa `sc.exe` para instalar el servicio:

```bash
PS> sc.exe create MemorySimulatorService binPath= "C:\Temp\MemorySimulatorService.exe" start= auto
```

3. Inicia el servicio:

```bash
PS> sc.exe start MemorySimulatorService
```

---

## 🧪 Uso y pruebas

Este servicio puede ser útil para:

- Probar el comportamiento del sistema bajo presión de memoria.
- Validar monitoreo, alertas y recolección de métricas de infraestructura.
- Simular ambientes con poca RAM disponible.

---

## ⚠️ Advertencia

Este servicio **consume memoria progresivamente**. Úsalo solo en entornos controlados. No lo ejecutes en producción ni en máquinas críticas sin supervisión.

---

## 📜 Licencia

Este script es de uso libre para fines educativos, de prueba o desarrollo.

---
