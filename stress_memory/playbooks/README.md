# 🚀 Playbook Ansible – Instalación de Ambiente de Memoria Bajo Estrés (Windows)

Este playbook de Ansible automatiza el despliegue de servicios que simulan consumo intensivo de memoria en servidores Windows. Está diseñado para compilar scripts en C#, generar ejecutables y registrarlos como servicios del sistema.

---

## 📁 Estructura del proyecto

```
stress_memory/
├── playbooks
│   ├── reproducir_ambiente.yml
│   ├── tasks
│   │   ├── compilacion_creacion.yml
│   │   └── validaciones_previas.yml
│   └── vars
│       └── main.yml
└── windows
    ├── meaninglessService.cs
    ├── MemorySimulatorService.cs
    └── README.md
```
---

## ⚙️ Variables principales (`vars/main.yml`)


### Variables y definiciones 

| Variable | Tipo | Description |
|-------|----------|-------------|
| `servicios` | dict | Variable donde se define el nombre del servicio y ruta del script de C# a compilar. |
| `dest_dir` | str | Variable a definir la ruta destino donde se alojaran los scripts a compilar y posterior .exe. |
| `version_compilador` | str | Variable donde se define la version del compilar, por defecto v4, pero ajustar a gusto. |
| `dir_microsoft_net` | str | Variable donde se define la ruta de Microsoft.NET, donde se aloja el compilador csc.exe |

### Ejemplo de uso de las variables

```yaml
servicios:
  - {nombre: CX.Parsing.Servicio, script: ../windows/MemorySimulatorService.cs}
  - {nombre: CX.Storage.Motor, script: ../windows/meaninglessService.cs}
  - {nombre: CX.Trace.Motor, script: ../windows/meaninglessService.cs}
dest_dir: C:\Temp
version_compilador: v4
dir_microsoft_net: C:\Windows\Microsoft.NET
```

---

## 🧠 ¿Qué hace este playbook?

1. **Validaciones previas**
   - Verifica conectividad con el host.
   - Comprueba existencia de directorios (`Microsoft.NET`, `directorio destino especificado`).
   - Copia scripts de servicio al servidor remoto.
   - Verifica si la versión del compilador (`csc.exe`) está disponible.

2. **Compilación y despliegue**
   - Compila los scripts C# usando el compilador .NET Framework (`csc.exe`).
   - Crea servicios Windows a partir de los ejecutables generados.

3. **Control de errores**
   - Si no se encuentra el compilador, se notifica y se listan las versiones disponibles.
   - Si falla alguna validación, se muestra un mensaje explicativo.

---

## ▶️ Ejecución del playbook

```bash
ansible-playbook -i inventario.ini reproducir_ambiente.yml -u vagrant -k 
```

> Requiere acceso `winrm` configurado hacia los hosts de Windows.
> Sugerencia de inventario.ini

```bash
$ cat inventario.ini
[windows]
win_lab   ansible_host=192.168.121.25

[windows:vars]
ansible_connection=winrm
ansible_winrm_transport=basic
ansible_winrm_server_cert_validation=ignore
```

---

## 📌 Requisitos

- Servidores Windows con PowerShell habilitado.
- Acceso por `WinRM` desde el controlador Ansible.
- .NET Framework instalado (en la ruta especificada).

---

## 🛡️ Manejo de errores y depuración

El playbook implementa manejo de errores (`block`, `rescue`) y muestra mensajes claros al operador en caso de fallos como:

- Falla de conexión con el host.
- Falta de rutas de compilador.
- Directorios no encontrados.

---

## 🧪 Ejemplo de servicio simulado

- `MemorySimulatorService.cs`: Script que simula consumo alto de memoria.
- `meaninglessService.cs`: Plantilla de servicio base reutilizable.

---

## 📋 Resultado esperado

- Scripts C# compilados a ejecutables `.exe` en `C:\Temp`.
- Servicios instalados en el sistema con nombres definidos en `vars/main.yml`.

---

## 👨‍💻 Autor

- **John Freidman** - [@Xploit9999](https://github.com/Xploit9999)

---

## ⚠️ Advertencia

> **Este playbook puede afectar el rendimiento del sistema objetivo.** Solo se debe usar en ambientes de prueba o laboratorio.
