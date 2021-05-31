<div stlye="margin: 0 auto;">
  <img src="https://raw.githubusercontent.com/LatifY/GameArchitecture/main/Assets/GameArchitecture/Sprites/Icons/garc_icon.png", width=120>
</div>

# GameArchitecture
**GameArchitecture** is a package made by **[Latif Yılmaz](https://latifyilmaz.com)**. It will make it easier for you to make games in Unity. It has many software and technical tools for developers.

This small document will simply introduce you to the **features**. So **let's start!**

### Introductions

<details>
<summary>Game Manager</summary>
<br>
  
It is the game control center in general. Adjustments such as language, recording, features that should be present in each scene are made. Tag name is "GameManager".
  
### GameManager

- Keeps properties such as what state the game is in (Menu, In Game, Battle, Market, Paused etc.) 
- It has optional [Don't Destroy](https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html) feature. 
- It is also used for scene transitions.
  
### GameEditor

- Allows you to manage some adjustments of the game. Such as adding, deleting, changing a new language or adding, deleting, checking [PlayerPrefs](https://docs.unity3d.com/ScriptReference/PlayerPrefs.html). 
- It does not require you to write additional code as it shows them by providing an easy interface.

</details>

* Localization System
* PlayerPrefs System
* Collider/Collision System With GUI
* Easy Environment Implementations
* Audio Manager
* Music Manager
* Save/Load System for file
* Child Editor System
* Dialogue System
* Writer Effects [Wobbly Text, Shake Text, Jelly Text, Sprite Support] with TextMeshPro
* Cool Transition Effects
* UI Manager
