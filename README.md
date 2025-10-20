# AutoFocus for Unity URP

A URP Unity script that dynamically adjusts camera **Depth of Field** in real time to keep the **focal point** perfectly in focus. Designed to work seamlessly with the companion script [CameraController](https://github.com/hsuehyt/CameraController).

---

## 🎯 Overview

`AutoFocus.cs` reads the **focal point** assigned in `CameraController.cs` and dynamically adjusts the **Depth of Field (DoF)** parameter in a URP **Global Volume**.
This keeps the selected object or scene point perfectly in focus — ideal for cinematic orbit cameras, XR/VR rigs, and animated camera moves.

---

## ⚙️ Features

* Works with **URP Volume Depth of Field** component
* Automatically detects and syncs with your **CameraController**
* Adjusts focus distance every frame
* Zero dependencies — plug and play
* Compatible with **Unity 2022+ URP**

---

## 🧩 Requirements

* Unity **URP** project
* A **Global Volume** with a **Depth of Field** override enabled
* `CameraController.cs` (download from [here](https://github.com/hsuehyt/CameraController))

---

## 🧠 How It Works

1. The script accesses the `DepthOfField` component from your **Volume Profile**.
2. It gets the current **focalPoint** from the attached `CameraController`.
3. Calculates the distance between the camera and that focal point.
4. Updates `dof.focusDistance` in real-time.

```csharp
float distance = Vector3.Distance(transform.position, focalPoint.transform.position);
dof.focusDistance.value = distance;
```

---

## 🚀 Setup Guide

1. **Assign URP Asset**

   * In *Project Settings → Graphics*, assign your URP pipeline asset.
   * Enable **Post Processing** and **Depth Texture**.

2. **Add a Volume**

   * Create a Global Volume → Add Override → *Post-processing → Depth of Field*.
   * Set Mode to **Bokeh** and tweak focus parameters.

3. **Attach Scripts**

   * Add `CameraController.cs` to your camera (handles orbit, pan, zoom).
   * Add `AutoFocus.cs` to the same GameObject.
   * Drag your **Volume** into the `Volume` field of `AutoFocus`.

4. **Play**

   * Move or animate the `focalPoint` — the camera focus updates automatically.

---

## 🧩 Public Variables

| Variable           | Type               | Description                                              |
| ------------------ | ------------------ | -------------------------------------------------------- |
| `volume`           | `Volume`           | Reference to the Global Volume containing Depth of Field |
| `cameraController` | `CameraController` | Camera control script providing the focal point          |

---

## 💡 Example Scene

A demo scene could include:

* A camera orbiting around a target sphere
* A Global Volume with DoF enabled
* AutoFocus attached to the same camera

---

## 📜 License

MIT License — feel free to use, modify, and share.

---

## 🧷 Related Repository

* 🎮 [CameraController](https://github.com/hsuehyt/CameraController): Scene-view-style orbit, pan, and zoom controller for Unity’s new Input System.
