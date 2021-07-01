<div stlye="margin: 0 auto;">
  <img src="https://raw.githubusercontent.com/LatifY/GameArchitecture/main/Assets/GameArchitecture/Sprites/Icons/garc_icon.png", width=120>
</div>

# GameArchitecture
<details open>
  <summary>English</summary>
  <br>
  
  > **GameArchitecture** is a package made by **[Latif Yılmaz](https://latifyilmaz.com)**. It will make it easier for you to make games in Unity. It has many software and technical tools for developers.

This small document will simply introduce you to the **features**. So **let's start!**

### Introductions

<details>
<summary>Game Manager</summary>
<br>
  
> It is the game control center in general. Adjustments such as language, recording, features that should be present in each scene are made. Tag name is "GameManager".
  
### GameManager

> Keeps properties such as what state the game is in (Menu, In Game, Battle, Market, Paused etc.) 
> It has optional [Don't Destroy](https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html) feature. 
> It is also used for scene transitions.
  
### GameEditor

> Allows you to manage some adjustments of the game. Such as adding, deleting, changing a new language or adding, deleting, checking [PlayerPrefs](https://docs.unity3d.com/ScriptReference/PlayerPrefs.html). 
  
> It does not require you to write additional code as it shows them by providing an easy interface.

</details>
  
<details>
  <summary>Camera Manager</summary>
</details>

<details>
  <summary>UI Manager</summary>
  <br>
  
  > Adjustments of UI Elements are made with this script. For example, opening a menu or updating the character's score in a text etc. It is located in the [Canvas panel](https://docs.unity3d.com/2020.1/Documentation/Manual/UICanvas.html).
  
> Tag name is "UIManager".

</details>

<details>
  <summary>Audio Manager</summary>
  <br>
  
  > Sounds are kept under this object with the [AudioSource](https://docs.unity3d.com/2020.1/Documentation/Manual/class-AudioSource.html) component. To play these sounds, it is sufficient to call the given key or index to the method. 
  
> Tag name is "AudioManager". 
> It has optional [Don't Destroy](https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html) feature. 
  
</details>

<details>
  <summary>Music Manager</summary>
  <br>
  
  > Musics are set under this script. Again sounds are added as well. [Don't Destroy](https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html) is also available so it doesn't get lost on scene change.
  
</details>

<details>
  <summary>PlayerPrefs System</summary>
  <br>
  
  > You can edit PlayerPrefs keys and values from ```GameManager (Object) > Game Editor (Script)``` It allows you to get easy saves in 3 data types. It has not relevant to GameArchitecture Save system.
  
</details>

<details>
  <summary>Localization System</summary>
  <br>
  
  > GameArchitecture allows you to support your game in the language you want. For this, you can create or delete the languages you want via ```GameManager (Object) > GameEditor (Script)```
  
  > You can also set the language instantly if you are going to change it for the editor. It is enough to write the texts you will write for languages in the .txt file in ```Resources``` folder. 
  
  > You can write your texts by specifying a key and get texts specific to whichever language you are using with ```MultiLang.GetTranslation("key")```
  
</details>

<details>
  <summary>Collider System With GUI</summary>
  <br>
  
  > Adding the Collider and Collision system with GameArchitecture is simple. You can create more dynamic structure by controlling events with Collider for Trigger or Collision.
  
**Collider Type**
  > Trigger: Trigger doesn't impede physical movement and it is generally used to perform events according to the movements of a player or any object for the specified area. It appears red on the [GUI](https://docs.unity3d.com/ScriptReference/GUI.html). For example, by putting this where the character needs to win the game, you can use Trigger to show the events that will happen when it gets there.
  
  > Collision: It inhibits physical movement. It appears blue on the [GUI](https://docs.unity3d.com/ScriptReference/GUI.html). It is usually used as an obstacle but can be used to summon events such as Trigger. For example, if the character has started to push the box, it can be used to bring animation.

**Tags** 
  > If you want your collider to be effective for specific tags, you can add it to the enter tags section in the component. If left blank, it applies to all tags.
  
**Collider Events**
  > Enter: It is generally used for **Trigger** type. Calls the specified function if an object is entered into it.
  
  > Exit: The logic is the same with **Enter**. It only calls the specified function when an object exits from the area.
  
  > Stay: Stay is called once per physics update for every Collider other that is touching the trigger.
  
**Destroy Collider** 
  > It is recommended to use for trigger type. If any of the specified event types run, the collider object is deleted from the game scene. For example, when the player collects coins, it disappears.
    
  
</details>

<details>
  <summary>Save/Load System for file</summary>
  <br>
  
> It is used to perform saving operations on the file. It is used with the SaveManager object.
  
> Set Variables you want to save into Data Script. And simply save or load with Save Handler.
  
> It saves the data under Assets/Saves. To change save settings, simply change the **SAVE_FOLDER** variable in **SaveSystem** script.
  
> Tag name is "SaveManager"
  
  
</details>
<details>
  <summary>Child Editor</summary>
  <br>
  
  > You can use this component to make mass changes to the sub-objects of any object in the game scene.

- You can change the visibility of child objects in the game scene.
- You can open and close the components of child objects by typing component name as text.
  
</details>
  
<details>
  <summary>Dialogue System</summary>
  <br>
  
  > GameArchitecture has a ready-made dialog system. Include features such as sound by letter or word, special texts, waiting, passing, language support (etc.) Designs are also readily available. You can change it if you want.
  
  > You can edit the "Writer" script by creating boxes in the Dialogue object (prefab). You have to type the sentence directly in the sentence inputs or the key in the language .txt files (Resources folder). If the key is found, it will show according to the file. After event checks whether it will continue other dialogue box or not. You can also call up various events during the dialogue by adding different events.
  
</details>

<details>
  <summary>Writer Special Text Effects</summary>
  <br>
  
  > You can provide customizations for the texts by providing specific tags into Language file. For example; ```<shake>Hello</shake>``` makes the text shake.
  
  ### Wobbly
  
  > It makes the text wave like a flag. For example; ```<wobbly>Hello Player!</wobbly>```
  
  ### Shake
  
  > It makes the text feel like an earthquake is happening. For example; ```<shake>Wooww, What's happening!</shake>```
  
  ### Jelly
  
  > It gives a gel-like animation to the text. For example; ```<jelly>Eww, that's disgusting!</jelly>```
  
  ### Sprites
  
  > It allows the use of various emojis. You can find the emoji code list [here](https://learn.unity.com/tutorial/textmesh-pro-sprite-assets). For example; ```<sprite=6>``` (😂)
  
  ### Colors
  
  > You can also easily change the colors of the texts. It also works with other tags. For example; ```<shake>It looks <color=red>DANGEROUS!</color><shake>```

</details>

<details>
  <summary>Transition Effects</summary>
  <br>
  
  > There are many transition effect animations in GamerArchitecture. These can be used for scene transitions. When the "LoadScene" function in GameManager is used, it automatically uses the transition effect in the scene before and after. In order for these effects to stand on top of other UI elements, it is necessary to put the UI (Canvas) object at the bottom. Tag name is "Transition"
  
 </details>

</details>

<br>
<br>

<details>
   <summary>Türkçe</summary>
   <br>
  
   > **GameArchitecture**, **[Latif Yılmaz](https://latifyilmaz.com)** tarafından hazırlanmış bir pakettir.  Unity'de oyun yapmanızı kolaylaştıracaktır.  Geliştiriciler için birçok yazılım ve teknik araca sahiptir.

 Bu küçük doküman size GameArchitecture paketinin **özelliklerini ve araçlarını** tanıtacaktır.  **Haydi başlayalım!**

 ### Tanıtım

 <details>
 <summary>Game Manager</summary>
 <br>
  
 > Genel olarak oyun kontrol merkezidir.  Her sahnede olması gereken dil, kayıt, özellikler gibi ayarlamalar yapılır.  Etiket adı "GameManager".
  
 ### Game Manager

 > Oyunun hangi durumda olduğu gibi özellikleri tutar (Menü, Oyun İçi, Savaş, Pazar, Duraklatıldı vb.)
 > Opsiyonel [Don't Destroy](https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html) özelliğine sahiptir.
 > Sahne geçişleri için de kullanılır.
  
 ### Game Editor

 > Oyunun bazı ayarlarını yönetmenizi sağlar.  Dil desteği ekleme, silme, değiştirme veya [PlayerPrefs](https://docs.unity3d.com/ScriptReference/PlayerPrefs.html) kontrol etme gibi...
  
 > Kolay bir arayüz sağlar. Ek olarak kod yazmanızı gerektirmez.

 </details>

 <details>
   <summary>UI Manager</summary>
   <br>
  
   > UI Elemanlarının ayarlamaları bu script ile yapılır.  Örneğin, bir menü açmak veya bir metindeki karakterin puanını güncellemek vb. [UI Canvas panelinde](https://docs.unity3d.com/2020.1/Documentation/Manual/UICanvas.html) bulunur.
  
 > Etiket adı "UIManager"dır.

 </details>

 <details>
   <summary>Audio Manager</summary>
   <br>
  
   > Sesler [AudioSource](https://docs.unity3d.com/2020.1/Documentation/Manual/class-AudioSource.html) bileşeni ile bu nesnenin altında tutulur.  Bu sesleri çalmak için verilen anahtar veya indeksi metoda çağırmak yeterlidir. Örneğin; ```AudioManager.Instance.PlayClip("JumpSFX")```
  
 > Etiket adı "AudioManager".

 > Opsiyonel [Don't Destroy](https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html) özelliğine sahiptir.
  
 </details>

 <details>
   <summary>Music Manager</summary>
   <br>
  
   > Müzikler bu komut dosyası altında ayarlanır. Yine sesler de eklenir. [Don't Destroy](https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html) de mevcuttur, böylece sahne değişiminde kaybolmaz.
  
 </details>

 <details>
   <summary>PlayerPrefs Sistemi</summary>
   <br>
  
   > PlayerPrefs anahtarlarını ve değerlerini ```GameManager (Nesne) > Game Editor (Script)``` içinden düzenleyebilirsiniz. 3 veri tipinde kolay kaydetme yapmanızı sağlar.  GameArchitecture Dosya için Kayıt sistemi ile ilgili değildir.
  
 </details>

 <details>
   <summary>Localization(Yerelleştirme) Sistemi</summary>
   <br>
  
   > GameArchitecture, oyununuzu istediğiniz dilde desteklemenizi sağlar.  Bunun için ```GameManager (Object) > GameEditor (Script)``` üzerinden istediğiniz dilleri oluşturabilir veya silebilirsiniz.
  
   > ```GameManager (Object) > GameEditor (Script)``` üzerinden dil ekledikten sonra düzenlemek çok kolay. Diller için yazacağınız anahtar ve metinleri ```Resources``` klasöründeki .txt dosyasına yazmanız yeterlidir.
  
   > ```MultiLang.GetTranslation("key")``` ile bir anahtar belirleyerek metinlerinizi yazabilir ve kullandığınız dile özel metinler alabilirsiniz.
  
 </details>

 <details>
   <summary>GUI ile Collider Sistemi</summary>
   <br>
  
   > Trigger ve Collision sistemini GameArchitecture ile kontrol etmek basittir. Collider objesini Trigger veya Collision olarak ayarlayarak hem arayüz tarafında kolaylık elde edersiniz hem de bazı olayları kontrol ederek daha dinamik bir yapı oluşturabilirsiniz.
  
 **Collider Type**
   > Trigger: Trigger, fiziksel hareketi engellemez ve genellikle belirtilen alan için bir oyuncunun veya herhangi bir nesnenin hareketlerine göre olayları gerçekleştirmek için kullanılır. [GUI](https://docs.unity3d.com/ScriptReference/GUI.html) üzerinde kırmızı görünür. Örneğin, bunu karakterin oyunu kazanması gereken yere koyarak, oraya ulaştığında olacak olayları göstermek için kullanabilirsiniz.
  
   > Collision: Fiziksel hareketi engeller. [GUI](https://docs.unity3d.com/ScriptReference/GUI.html) üzerinde mavi görünür. Genellikle bir engel olarak kullanılır ancak tetikleyici olayları çağırmak için kullanılabilir. Örneğin karakter kutuyu itmeye başladıysa animasyon getirmek için kullanılabilir.

 **Tags**
   > Collider objesinin belirli etiketler için etkili olmasını istiyorsanız, onu bileşendeki etiketleri gir bölümüne ekleyebilirsiniz.  Boş bırakılırsa tüm etiketler için geçerlidir.
  
 **Collider Events**
   > Enter: Genellikle **Trigger** tipi için kullanılır. İçine bir nesne girilmişse belirtilen metodu çağırır.
  
   > Exit: Mantığı **Enter** ile aynıdır. Yalnızca bir nesne alandan çıktığında belirtilen metodu çağırır.
  
   > Stay: Stay, collider'a dokunan diğer her collider için fizik güncellemesi başına bir kez çağrılır.
  
 **Destroy Collider**
   > Trigger tipi için kullanılması tavsiye edilir.  Belirtilen olay türlerinden herhangi biri çalışırsa, collider nesnesi oyun sahnesinden silinir. Örneğin, oyuncu paraları topladığı zaman kaybolur.
    
  
 </details>

 <details>
   <summary>Dosya için Kaydetme/Yükleme Sistemi</summary>
   <br>
  
 > Dosya üzerinde kaydetme işlemleri yapmak için kullanılır. SaveManager nesnesiyle birlikte kullanılır.
  
 > Data Dosyasına kaydetmek istediğiniz değişkenleri Ayarlayın. Ve sadece Save Handler ile kaydedin veya yükleyin.
  
 > Assets/Saves altında verileri kaydeder. Kaydetme ayarlarını değiştirmek için, **SaveSystem** komut dosyasındaki **SAVE_FOLDER** değişkenini değiştirmeniz yeterlidir.
  
 > Etiket adı "SaveManager"
  
  
 </details>
 <details>
   <summary>Child Editor</summary>
   <br>
  
   > Oyun sahnesindeki herhangi bir nesnenin alt nesnelerinde toplu değişiklikler yapmak için bu bileşeni kullanabilirsiniz.

 - Oyun sahnesindeki alt nesnelerin görünürlüğünü değiştirebilirsiniz.
 - Alt nesnelerin bileşenlerini(component) metin olarak bileşen adını yazarak açıp kapatabilirsiniz.
  
 </details>
  
 <details>
   <summary>Diyalog Sistemi</summary>
   <br>
  
   > GameArchitecture hazır bir diyalog sistemine sahiptir. Harf veya kelime başına özel ses, özel metinler, bekleme, geçme, dil desteği (vb.) gibi özellikler içerir. Tasarımlar da hazır olarak mevcuttur. Dilerseniz değiştirebilirsiniz.
  
   > Dialogue nesnesinde (prefab) kutular oluşturarak "Writer" komut dosyasını düzenleyebilirsiniz. Cümleyi doğrudan cümle girişlerine veya anahtarı dil .txt dosyalarında (Resources klasörü) yazmanız gerekir. Anahtar bulunursa dosyaya göre gösterilecektir. Olaydan sonra diğer diyalog kutusuna devam edip etmeyeceğini kontrol eder. Farklı olaylar ekleyerek diyalog sırasında çeşitli olayları da çağırabilirsiniz.
  
 </details>

 <details>
   <summary>Özel Metin Efektleri</summary>
   <br>
  
   > Dil dosyasına belirli etiketler sağlayarak metinler için özelleştirmeler sağlayabilirsiniz. Örneğin;  ```<shake>Merhaba</shake>``` metne deprem etkisi verir.
  
   ### Wave
  
   > Metni bir bayrak gibi dalgalandırır. Örneğin;  ```<wobbly>Merhaba Oyuncu!</wobbly>```
  
   ### Shake
  
   > Metne deprem etkisi verir. Örneğin;  ```<shake>Vay canına, Neler oluyor!</shake>```
  
   ### Jelly
  
   > Metne jel benzeri bir animasyon verir. Örneğin;  ```<jelly>Iyy, bu iğrenç!</jelly>```
  
   ### Sprites(Emoji / Resim)
  
   > Çeşitli emojilerin kullanımına izin verir. Emoji kod listesini [burada](https://learn.unity.com/tutorial/textmesh-pro-sprite-assets) bulabilirsiniz. Örneğin;  ```<sprite=6>``` (😂)
  
   ### Renkler
  
   > Metinlerin renklerini de kolayca değiştirebilirsiniz. Diğer etiketlerle de çalışır.  Örneğin;  ```<shake><color=red>TEHLİKELİ</color> görünüyor!<shake>```

 </details>

 <details>
   <summary>Geçiş Efektleri</summary>
   <br>
  
   > GamerArchitecture'da birçok geçiş efekti animasyonu bulunmaktadır.  Bunlar sahne geçişleri için kullanılabilir.  GameManager'daki ```LoadScene``` işlevi kullanıldığında, sahne öncesi ve sonrası geçiş efektini otomatik olarak kullanır.  Bu efektlerin diğer UI öğelerinin üzerinde durabilmesi için en altta UI (Canvas) nesnesini koymak gerekir.  Etiket adı "Transition"
  
  </details>

 </details>
