# CPU Stress Script

This Bash script simulates CPU stress by spawning multiple background processes that calculate digits of π using `bc`. It is useful for simple load testing or benchmarking purposes.

## 🛠️ Requirements

- `bash`
- `bc` (basic calculator utility)

You can install `bc` using your package manager:

```bash
# Debian/Ubuntu
sudo apt install bc

# RedHat/Fedora
sudo dnf install bc

# Arch
sudo pacman -S bc
```

## Usage

```bash
./cpu_stress.sh -c <cores> -t <seconds>
```

## 📌 Flags

| Flags | Required | Description |
|-------|----------|-------------|
| `-c` | yes | Number of cores to stress. |
| `-t` | yes | Duration of stress test (in seconds). |
| `-h` | no | Show the help panel. |

## 📖 Example

```bash
# This will stress 2 CPU cores for 300 seconds.

./cpu_stress.sh -c 2 -t 300

```
## ⚙️ How it Works

- The script launches one bc process per core requested, each calculating π to a high precision in an infinite loop.
- After the specified time (-t), all background bc processes are killed.

## ❗ Notes

- This script is for educational or light testing purposes only.
- Do not use it on production systems or systems without proper cooling, as it may cause thermal stress.

## Author

- **John Freidman** - [@Xploit9999](https://github.com/Xploit9999)
