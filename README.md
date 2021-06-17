<div stlye="margin: 0 auto;">
  <img src="https://raw.githubusercontent.com/LatifY/GameArchitecture/main/Assets/GameArchitecture/Sprites/Icons/garc_icon.png", width=120>
</div>

# GameArchitecture
<details open>
  <summary>English</summary>
  <br>
  
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
  <br>
  
  Sounds are kept under this object with the [AudioSource](https://docs.unity3d.com/2020.1/Documentation/Manual/class-AudioSource.html) component. To play these sounds, it is sufficient to call the given key or index to the method. 
  
- Tag name is "AudioManager". 
- It has optional [Don't Destroy](https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html) feature. 
  
</details>

<details>
  <summary>Music Manager</summary>
  <br>
  
  Musics are set under this script. Again sounds are added as well. [Don't Destroy](https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html) is also available so it doesn't get lost on scene change.
  
</details>

<details>
  <summary>PlayerPrefs System</summary>
  <br>
  
  You can edit PlayerPrefs keys and values from GameManager (Object) > Game Editor (Script). It allows you to get easy saves in 3 data types. It has not relevant to GameArchitecture Save system.
  
</details>

<details>
  <summary>Localization System</summary>
  <br>
  
  GameArchitecture allows you to support your game in the language you want. For this, you can create or delete the languages you want via GameManager (Object) > GameEditor (Script). 
  
  You can also set the language instantly if you are going to change it for the editor. It is enough to write the texts you will write for languages in the .txt file in Resources folder. 
  
  You can write your texts by specifying a key and get texts specific to whichever language you are using with MultiLang.GetTranslation("key").
  
</details>

<details>
  <summary>Collider System With GUI</summary>
  <br>
  
  Adding the Collider and Collision system with GameArchitecture is simple. You can create more dynamic structure by controlling events with Collider for Trigger or Collision.
  
- **Collider Type**
  - Trigger: Trigger doesn't impede physical movement and it is generally used to perform events according to the movements of a player or any object for the specified area. It appears red on the [GUI](https://docs.unity3d.com/ScriptReference/GUI.html). For example, by putting this where the character needs to win the game, you can use Trigger to show the events that will happen when it gets there.
  - Collision: It inhibits physical movement. It appears blue on the [GUI](https://docs.unity3d.com/ScriptReference/GUI.html). It is usually used as an obstacle but can be used to summon events such as Trigger. For example, if the character has started to push the box, it can be used to bring animation.
- **Tags:** If you want your collider to be effective for specific tags, you can add it to the enter tags section in the component. If left blank, it applies to all tags.
- **Collider Events**
  - Enter: It is generally used for **Trigger** type. Calls the specified function if an object is entered into it.
  - Exit: The logic is the same with **Enter**. It only calls the specified function when an object exits from the area.
  - Stay: Stay is called once per physics update for every Collider other that is touching the trigger.
- **Destroy Collider:** It is recommended to use for trigger type. If any of the specified event types run, the collider object is deleted from the game scene. For example, when the player collects coins, it disappears.
    
  
</details>

<details>
  <summary>Save/Load System for file</summary>
  <br>
  
- It is used to perform saving operations on the file. It is used with the SaveManager object.
- Set Variables you want to save into Data Script. And simply save or load with Save Handler.
- It saves the data under Assets/Saves. To change save settings, simply change the **SAVE_FOLDER** variable in **SaveSystem** script.
- Tag name is "SaveManager"
  
  
</details>
<details>
  <summary>Child Editor</summary>
  <br>
  
  You can use this component to make mass changes to the sub-objects of any object in the game scene.

- You can change the visibility of child objects in the game scene.
- You can open and close the components of child objects by writing component name as text.
  
</details>
* Dialogue System
* Writer Effects [Wobbly Text, Shake Text, Jelly Text, Sprite Support] with TextMeshPro
* Cool Transition Effects

  
  
<details>
