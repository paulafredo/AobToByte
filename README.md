# 🔍 AOB/Byte Converter

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Version](https://img.shields.io/badge/version-1.0.2-blue)](https://github.com/paulafredo/AobToByte/releases)
[![Platform](https://img.shields.io/badge/platform-Windows-lightgrey)](https://www.microsoft.com/windows)
[![Size](https://img.shields.io/badge/size-1MB-green)](https://github.com/paulafredo/AobToByte/releases)

Advanced conversion tool for hexadecimal signatures (AOB) and byte arrays, specially designed for reverse engineering and low-level development.

![Application Interface Screenshot](https://github.com/user-attachments/assets/51359dbd-6db2-401d-af18-725ccb1c176a)

## ✨ Features

- **Bidirectional Conversion**: Seamlessly convert between AOB and Byte Array formats
- **Wildcard Support**: Handle unknown bytes with `??` or `?` wildcards
- **Smart Validation**: Automatic detection of invalid hex inputs
- **Pattern Templates**: Quick-access to common signature patterns
- **One-Click Copy**: Instant clipboard copying of converted results
- **Lightweight**: Minimal footprint (~1MB) with no dependencies
- **Portable**: Single executable with no installation required

## 📥 Installation

1. Download the latest release from [Releases](https://github.com/paulafredo/AobToByte/releases)
2. Extract the ZIP archive
3. Run `AobToByte.exe`

---

## 🧪 Local Build (For Developers)

### Requirements
- Visual Studio 2022+
- .NET 6 or 7 SDK

### Steps
```bash
git clone https://github.com/paulafredo/AobToByte.git
cd AobToByte
```

#### Then, either:

✅ **In Visual Studio**  
- Open `AobToByte.sln`
- Right-click the solution → **"Restore NuGet Packages"**
- Build the project (Ctrl+Shift+B)

💬 If you get errors like `CS0246: type or namespace 'Guna' not found`  
Just run:

```bash
dotnet restore
```

This will install all required packages including `Guna.UI2.WinForms`.

---

## 🛠 Usage Examples

### AOB to Byte Array Conversion

```text
Input (AOB):  
47 7B 5A BD AE 57 66 BB 5C 1F 48 BA 1B C0 CF 3B 9C FB 28 3D A2 B1 17 BD E4 99 7F 3F 04 00 80 3F 00 00 80 3F FE FF 7F 3F

Output (Byte Array):
0x47, 0x7B, 0x5A, 0xBD, 0xAE, 0x57, 0x66, 0xBB, 0x5C, 0x1F, 0x48, 0xBA, 0x1B, 0xC0, 0xCF, 0x3B, 0x9C, 0xFB, 0x28, 0x3D, 0xA2, 0xB1, 0x17, 0xBD, 0xE4, 0x99, 0x7F, 0x3F, 0x04, 0x00, 0x80, 0x3F, 0x00, 0x00, 0x80, 0x3F, 0xFE, 0xFF, 0x7F, 0x3F
```

---

## 📄 License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).  
Feel free to use, distribute and modify it.

---

## 👤 Author

[Paul Alfredo](https://github.com/paulafredo)

