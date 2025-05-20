# Proyecto Vagrant - Laboratorio con Windows y Linux

Este proyecto utiliza **Vagrant** y **Libvirt** para levantar un laboratorio de máquinas virtuales con sistemas operativos Windows y Linux. El objetivo principal es facilitar la creación de entornos de prueba automatizados y reproducibles.

## Estructura del Proyecto

```
.
├── Vagrantfile
├── vars
│   └── vars.yml
└── scripts
    └── connection.ps1
```

### 1. `Vagrantfile`

Contiene la definición de las máquinas virtuales. Utiliza el archivo `vars/vars.yml` para obtener los parámetros de configuración de cada VM, incluyendo:

- Tipo de sistema operativo (`tipo`): Windows o Linux
- Nombre del host (`host`)
- Cantidad de memoria (`memory`)
- Número de CPUs (`cpus`)
- Imagen base de Vagrant (`so`)
- Proveedor (`provider`): Actualmente configurado para `libvirt`.

Para VMs Windows, se ejecuta el script `scripts/connection.ps1` para habilitar PowerShell Remoting y abrir el puerto necesario (TCP 5985).

### 2. `vars/vars.yml`

Archivo en formato YAML que define las características de cada máquina virtual a levantar. Ejemplo de contenido:

```yaml
vms:
  - tipo: "windows"
    host: "lab1-windows"
    memory: "2048"
    cpus: "1"
    so: "jborean93/WindowsServer2016"
    provider: "libvirt"

  - tipo: "Linux"
    host: "lab1-rhel"
    memory: "1024"
    cpus: "1"
    so: "almalinux/9"
    provider: "libvirt"
```

> Todo se puede ajustar basado en su necesidad, la variable `so` con tiene el box que vagrant va a descargar y usar para el montaje de la VM. Puedes visitar [VagrantBoxes](https://portal.cloud.hashicorp.com/vagrant/discover) para ver el gran catalogo de boxes disponibles. 

### 3. `scripts/connection.ps1`

Este script es ejecutado en las máquinas Windows y se encarga de:

- Habilitar PowerShell Remoting (`Enable-PSRemoting`)
- Configurar una regla de firewall para permitir conexiones remotas vía WinRM (puerto TCP 5985)
- Ajustar el registro para permitir autenticación con cuentas locales

## Requisitos Previos

- [Vagrant](https://www.vagrantup.com/)
- Plugin de `vagrant-libvirt`
- Virtualización habilitada en el sistema
- Libvirt (QEMU/KVM) instalado y configurado

## Uso

1. Clona este repositorio.
2. Asegúrate de tener instalado Vagrant y Libvirt.
3. Ejecuta el siguiente comando para levantar las máquinas:

```bash
$ vagrant up
```

## Apagar las máquinas

```bash
$ vagrant halt
```

## Eliminar las máquinas

```bash
$ vagrant destroy -f
```

> Para mas información sobre la gestión por CLI, visita la documentación oficial de Vagrant [Vagrant CLI](https://developer.hashicorp.com/vagrant/docs/cli)

---

## 👨‍💻 Autor

- **John Freidman** - [@Xploit9999](https://github.com/Xploit9999)
