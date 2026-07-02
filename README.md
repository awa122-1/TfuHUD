# Milthm Mod

> **English**
>
> This project is an unofficial fan-made modification for Milthm.
> It is **not affiliated with, associated with, authorized, endorsed by, or in any way officially connected with Morizero or Milthm**.
>
> **中文**
>
> 本项目为 Milthm 的非官方玩家制作模组，与 **Morizero** 或 **Milthm** **没有任何关联、合作、授权或官方认可关系**。

---

# Requirements / 运行需求

- Milthm
- BepInEx 5.x
- Windows

---

# Installation / 安装教程

## 1. Install BepInEx / 安装 BepInEx

Download the latest BepInEx 5.x release from GitHub.

请从 GitHub 下载最新版本的 BepInEx 5.x。

https://github.com/BepInEx/BepInEx/releases

Extract all files into your Milthm game folder.

将压缩包中的所有文件解压到 Milthm 游戏目录。

Example / 示例：

```
Milthm/
├── BepInEx/
├── winhttp.dll
├── doorstop_config.ini
└── Milthm.exe
```

Launch the game once.

首次启动游戏一次。

BepInEx will automatically create the `plugins` folder.

BepInEx 会自动创建 `plugins` 文件夹。

```
BepInEx/
└── plugins/
```

---

## 2. Install the Mod / 安装模组

Copy the mod DLL into:

将模组 DLL 文件复制到：

```
BepInEx/plugins/
```

Example / 示例：

```
BepInEx/
└── plugins/
    └── MilthmMod.dll
```

Launch the game again.

再次启动游戏即可。

---

# Uninstall / 卸载

Delete the mod DLL from:

删除以下文件：

```
BepInEx/plugins/
```

To completely remove BepInEx, delete:

如需彻底卸载 BepInEx，请删除：

- `BepInEx`
- `winhttp.dll`
- `doorstop_config.ini`

---

# Disclaimer / 免责声明

**English**

This project is an unofficial fan-made modification.

It is **not affiliated with, associated with, authorized, endorsed by, or in any way officially connected with Morizero or Milthm**.

Milthm and all related names, trademarks, assets, and copyrights belong to their respective owners.

This project is provided "as is" without any warranty.

**中文**

本项目为非官方玩家制作模组。

本项目与 **Morizero** 或 **Milthm** 没有任何关联、合作、授权或官方认可关系。

Milthm 及其相关名称、商标、资源和版权均归其各自权利人所有。

本项目按「现状」提供，不提供任何形式的保证。

---

# License / 许可证

This project is licensed under the MIT License.

本项目采用 MIT License 开源许可证。
