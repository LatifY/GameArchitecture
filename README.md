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

<details>
  <summary>UI Manager</summary>
  <br>
  
  Adjustments of UI Elements are made with this script. For example, opening a menu or updating the character's score in a text etc. It is located in the [Canvas panel](https://docs.unity3d.com/2020.1/Documentation/Manual/UICanvas.html).
  
- Tag name is "UIManager".

</details>

<details>
  <summary>Audio Manager</summary>
  
  Sounds are kept under this object with the [AudioSource](https://docs.unity3d.com/2020.1/Documentation/Manual/class-AudioSource.html) component. To play these sounds, it is sufficient to call the given key or index to the method. 
  
- Tag name is "AudioManager". 
- It has optional [Don't Destroy](https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html) feature. 
  
</details>

<details>
  <summary>Music Manager</summary>
  
  Musics are set under this script. Again sounds are added as well. [Don't Destroy](https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html) is also available so it doesn't get lost on scene change.
  
</details>

<details>
  <summary>PlayerPrefs System</summary>
  
  You can edit PlayerPrefs keys and values from GameManager (Object) > Game Editor (Script). It allows you to get easy saves in 3 data types. It has not relevant to GameArchitecture Save system.
  
</details>

<details>
  <summary>Localization System</summary>
  
  GameArchitecture allows you to support your game in the language you want. For this, you can create or delete the languages you want via GameManager (Object) > GameEditor (Script). You can also set the language instantly if you are going to change it for the editor. It is enough to write the texts you will write for languages in the .txt file in Resources folder. You can write your texts by specifying a key and get texts specific to whichever language you are using with MultiLang.GetTranslation("key").
  
</details>

* Collider/Collision System With GUI
* Easy Environment Implementations
* Save/Load System for file
* Child Editor System
* Dialogue System
* Writer Effects [Wobbly Text, Shake Text, Jelly Text, Sprite Support] with TextMeshPro
* Cool Transition Effects
