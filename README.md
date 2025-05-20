# simular-ambiente-estresado

Repositorio dedicado a la generación de entornos simulados con estrés en recursos del sistema (memoria, CPU, disco, etc.), tanto en sistemas **Linux**, **UNIX** como **Windows**. Este repositorio está diseñado para ser utilizado con fines de **automatización de pruebas, validación de monitoreo** y **remediación de incidentes** mediante herramientas como **Ansible**.

## Objetivo

El propósito de este proyecto es permitir la creación de condiciones controladas en servidores que representen escenarios de uso extremo o fallos comunes en recursos. Estos escenarios pueden incluir:

- Consumo elevado de memoria
- Uso intensivo de CPU
- Saturación de disco
- Simulación de procesos colgados o zombis
- Problemas comunes en servicios del sistema

Una vez generadas estas condiciones, se pueden implementar y validar playbooks de Ansible para detectar, monitorear y remediar automáticamente los problemas.

## Estructura Actual de proyecto

```bash
├── Generar_VMs
│   ├── README.md
│   ├── scripts
│   │   └── connection.ps1
│   ├── Vagrantfile
│   └── vars
│       └── vars.yml
├── README.md
├── stress_cpu
│   └── Linux
│       ├── README.md
│       └── stress_cpu.sh
└── stress_memory
    ├── playbooks
    │   ├── README.md
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

## Advertencia ⚠️

> Estos scripts están diseñados para **afectar intencionalmente el rendimiento del sistema**. No se recomienda ejecutarlos en entornos de producción. Úsalos únicamente en entornos de pruebas controlados.
