# 🧰 denk-unity-utils

A lightweight **utility library for Unity 6**, providing commonly used helpers for UI, RectTransform, Enum attributes, logging, and date/time conversions.  
All methods are static and ready to use out-of-the-box.

---

## 📦 Table of Contents
| Section | Description |
|----------|-------------|
| [Installation](#installation) | How to install and use in Unity |
| [DLogger](#dlogger) | Colored log system with tag & custom color |
| [DateUtils](#dateutils) | Date/time parsing and UTC conversion utilities |
| [EnumExtensions](#enumextensions) | Add string value attributes to enums |
| [RectTransformExtensions](#recttransformextensions) | Quick utilities for UI anchoring and layout |
| [UIMath](#uimath) | Math and geometry helpers for UI and general calculations |
| [UISetExtensions](#uisetextensions) | Set UI values (Toggle, Slider, Dropdown) without triggering callbacks |
| [Credits](#credits--contribution) | Credits and contribution info |

---

## 🧩 Installation

1. Download **`denk-unity-utils.unitypackage`** from the **[Releases](../../releases)** page of this repository.  
2. Double-click the file to automatically import it into your Unity project.  
   Unity will add all scripts and files under the `Assets/Plugins/Utilities/` folder.  
3. Alternatively, you can manually install it using Unity Package Manager (UPM):  
   Follow the official Unity guide:  
   👉 [https://docs.unity3d.com/2020.1/Documentation/Manual/upm-ui-local.html](https://docs.unity3d.com/2020.1/Documentation/Manual/upm-ui-local.html)
4. Once imported, you can start using:
   ```csharp
   using Utilities;
   ```

> ⚠️ **Note:**  
> This library is only **tested and guaranteed to work on Unity 6**.  
> Other Unity versions have not been verified yet.

---

## 🧱 DLogger

Lightweight logging utility with colorized tags.  
Ideal for debugging complex systems while keeping your console clean and readable.

### 🔧 Example Usage
```csharp
DLogger.Log("Hello World");
DLogger.LogWarning("Potential issue!");
DLogger.LogError("Critical failure!", "MySystem", "#FF0000");
```

### 💬 Console Output (Unity Example)
| Example Output | Type |
|----------------|------|
| ![info]`[DLogger] Hello World` | Info |
| ![warn]`[DLogger] Potential issue!` | Warning |
| ![error]`[MySystem] Critical failure!` | Error |

*(Sample above matches the real Unity console appearance.)*

---

### 📜 Methods
| Method | Description |
|---------|-------------|
| `Log(string message, string tag = "DLogger", string color = "#FFFFFF")` | Logs a normal message with optional colored tag. |
| `LogWarning(string message, string tag = "DLogger", string color = "#FFFFFF")` | Logs a yellow warning message. |
| `LogError(string message, string tag = "DLogger", string color = "#FFFFFF")` | Logs a red error message. |

> 💡 Works only when `#if !RELEASE` is active — automatically disabled in release builds.  
> You can combine this with Unity's **Define Symbols** to control build-time logs.

---

### 🎨 LogColors Reference

Use the `LogColors` static class for consistent color tags in your logs.

```csharp
DLogger.Log("Download Complete", "Network", LogColors.Aqua);
DLogger.LogWarning("Low FPS detected", "Performance", LogColors.Gold);
DLogger.LogError("Missing reference!", "GameManager", LogColors.OrangeRed);
```

<table>
<thead>
<tr>
<th>Color Name</th>
<th>Hex Code</th>
<th>Preview</th>
</tr>
</thead>
<tbody>
<tr><td><code>White</code></td><td>#FFFFFF</td><td><div style="width:60px;height:18px;background:#FFFFFF;border:1px solid #777;border-radius:4px;">&nbsp;</div></td></tr>
<tr><td><code>Aqua</code></td><td>#00FFFF</td><td><div style="width:60px;height:18px;background:#00FFFF;border:1px solid #777;border-radius:4px;">&nbsp;</div></td></tr>
<tr><td><code>Aquamarine</code></td><td>#7FFFD4</td><td><div style="width:60px;height:18px;background:#7FFFD4;border:1px solid #777;border-radius:4px;">&nbsp;</div></td></tr>
<tr><td><code>Turquoise</code></td><td>#40E0D0</td><td><div style="width:60px;height:18px;background:#40E0D0;border:1px solid #777;border-radius:4px;">&nbsp;</div></td></tr>
<tr><td><code>PaleGreen</code></td><td>#98FB98</td><td><div style="width:60px;height:18px;background:#98FB98;border:1px solid #777;border-radius:4px;">&nbsp;</div></td></tr>
<tr><td><code>YellowGreen</code></td><td>#9ACD32</td><td><div style="width:60px;height:18px;background:#9ACD32;border:1px solid #777;border-radius:4px;">&nbsp;</div></td></tr>
<tr><td><code>Lime</code></td><td>#00FF00</td><td><div style="width:60px;height:18px;background:#00FF00;border:1px solid #777;border-radius:4px;">&nbsp;</div></td></tr>
<tr><td><code>Chartreuse</code></td><td>#7FFF00</td><td><div style="width:60px;height:18px;background:#7FFF00;border:1px solid #777;border-radius:4px;">&nbsp;</div></td></tr>
<tr><td><code>GreenYellow</code></td><td>#ADFF2F</td><td><div style="width:60px;height:18px;background:#ADFF2F;border:1px solid #777;border-radius:4px;">&nbsp;</div></td></tr>
<tr><td><code>Gold</code></td><td>#FFD700</td><td><div style="width:60px;height:18px;background:#FFD700;border:1px solid #777;border-radius:4px;">&nbsp;</div></td></tr>
<tr><td><code>Orange</code></td><td>#FFA500</td><td><div style="width:60px;height:18px;background:#FFA500;border:1px solid #777;border-radius:4px;">&nbsp;</div></td></tr>
<tr><td><code>OrangeRed</code></td><td>#FF4500</td><td><div style="width:60px;height:18px;background:#FF4500;border:1px solid #777;border-radius:4px;">&nbsp;</div></td></tr>
<tr><td><code>Magenta</code></td><td>#FF00FF</td><td><div style="width:60px;height:18px;background:#FF00FF;border:1px solid #777;border-radius:4px;">&nbsp;</div></td></tr>
<tr><td><code>Violet</code></td><td>#EE82EE</td><td><div style="width:60px;height:18px;background:#EE82EE;border:1px solid #777;border-radius:4px;">&nbsp;</div></td></tr>
<tr><td><code>BlueViolet</code></td><td>#8A2BE2</td><td><div style="width:60px;height:18px;background:#8A2BE2;border:1px solid #777;border-radius:4px;">&nbsp;</div></td></tr>
<tr><td><code>Orchid</code></td><td>#DA70D6</td><td><div style="width:60px;height:18px;background:#DA70D6;border:1px solid #777;border-radius:4px;">&nbsp;</div></td></tr>
<tr><td><code>MediumOrchid</code></td><td>#BA55D3</td><td><div style="width:60px;height:18px;background:#BA55D3;border:1px solid #777;border-radius:4px;">&nbsp;</div></td></tr>
</tbody>
</table>

> All colors are defined as static readonly hex strings in `LogColors`.  
> Example:
> ```csharp
> public static readonly string OrangeRed = "#FF4500";
> ```


## ⏰ DateUtils

Utilities for parsing, converting, and formatting date/time in UTC.

### Highlights
- Parse strings to `DateTime`
- Convert milliseconds / seconds / days to UTC
- Get current UTC timestamps
- Format timespans and readable date strings

### Methods
| Method | Description |
|---------|-------------|
| `ParseStringToDate(string str, string format)` | Parses a string into a `DateTime` object. |
| `MilisecondToUtcDate(long milliSec)` | Converts milliseconds since epoch to UTC DateTime. |
| `SecondToUtcDate(long second)` | Converts seconds since epoch to UTC DateTime. |
| `DayToUtcDate(int day)` | Converts day count to UTC DateTime. |
| `HourToUtcDate(int hours)` | Converts hour count to UTC DateTime. |
| `UtcDayNow()` | Gets current UTC day number since epoch. |
| `UtcSecondNow()` / `UtcMilisecondNow()` | Gets current UTC timestamp. |
| `DateToUtcSecond(DateTime date)` | Converts a DateTime to epoch seconds. |
| `ParseTimeSpanToHHMMSS(TimeSpan span)` | Formats TimeSpan as `HH:mm:ss`. |
| `ToIso8601Weeknumber(DateTime date)` | Gets ISO week number. |
| `DateToString(DateTime date)` | Returns compact string (shows only time if same day). |
| `StartOfWeek()` | Returns UTC start of the current week. |

---

## 🧩 EnumExtensions

Attach readable strings to enums and retrieve them easily.

```csharp
public enum Fruit
{
    [EnumStringValue("Sweet Apple")]
    Apple,
    [EnumStringValue("Juicy Orange")]
    Orange
}

Fruit f = Fruit.Apple;
string s = f.GetStringValue(); // => "Sweet Apple"
```

### Members
| Item | Description |
|-------|-------------|
| `EnumStringValueAttribute` | Attribute to store string labels for enum values. |
| `GetStringValue<TEnum>(this TEnum enumValue)` | Extension method to fetch the string label or name. |

---

## 📐 RectTransformExtensions

A collection of helper methods to manipulate UI layout easily.

### Example
```csharp
RectTransform rect = GetComponent<RectTransform>();
rect.FullScreen(true);
rect.SetWidth(300);
rect.SetLeftTopPosition(new Vector2(20, -50));
```

### Common Methods
| Method | Purpose |
|--------|----------|
| `SetDefaultScale()` | Sets localScale = Vector3.zero. |
| `SetPivotAndAnchors(Vector2 vec)` | Sets pivot and both anchors. |
| `GetSize()` / `GetWidth()` / `GetHeight()` | Returns rect size info. |
| `SetLeftTopPosition(Vector2 pos)` / `SetRightBottomPosition(Vector2 pos)` | Sets rect anchored position by corners. |
| `SetSize(Vector2 newSize)` / `SetWidth(float)` / `SetHeight(float)` | Resize RectTransform. |
| `Copy(RectTransform from)` | Copy layout and anchor properties. |
| `FullScreen(bool resetScaleToOne)` | Expand to match parent. |
| `Center(bool resetScaleToOne)` | Centers the rect. |
| `ResetAnchoredPosition3D()` / `ResetLocalPosition()` | Reset transforms. |
| `AnchorMinToZero()` / `AnchorMaxToOne()` / `CenterPivot()` | Quick anchor alignment helpers. |

---

## 🧮 UIMath

A massive collection of static math helpers — derived from legacy NGUI utilities — useful for UI, color conversion, and positioning.

### Features
- Safe `Lerp`, `ClampIndex`, `RepeatIndex`
- Color <-> Hex/Int conversion
- Angle wrapping and clamping
- Rectangle and coordinate conversions
- DPI adjustments and pixel-perfect helpers
- Framerate-independent spring damping and interpolation

### Sample Usage
```csharp
float v = UIMath.WrapAngle(370f); // -> 10
Color c = UIMath.IntToColor(0xFF00FFFF); // -> pink
Rect uv = UIMath.ConvertToTexCoords(new Rect(0,0,64,64), 256, 256);
```

> Perfect for UI element math, color serialization, and coordinate conversion.

---

## 🎛️ UISetExtensions

Set values on UI elements **without triggering OnValueChanged** events.

### Example
```csharp
Toggle t = myToggle;
t.Set(true, false); // set without callback

Slider s = mySlider;
s.Set(0.5f, false);

Dropdown d = myDropdown;
d.Set(2); // change selection silently
```

### Supported Components
| Component | Method |
|------------|---------|
| `Toggle` | `Set(bool value, bool sendCallback = false)` |
| `Slider` | `Set(float value, bool sendCallback = false)` |
| `Scrollbar` | `Set(float value, bool sendCallback = false)` |
| `Dropdown` | `Set(int value)` *(refreshes UI automatically)* |

> 💡 Internally uses reflection to call Unity’s private `Set(value, sendCallback)` methods.

---

## 🧾 Credits & Contribution

Developed and maintained by **Denk Studio**.  
Tested and verified on **Unity 6 (6000.0.28f1)**.

🧠 **Contributions Welcome!**  
If you want to add more utilities, extensions, or optimizations — feel free to fork and submit a pull request!

---

**© 2025 Denk Studio — MIT License**  
“Small, clean, and efficient utilities for modern Unity.”