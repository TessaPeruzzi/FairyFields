# FairyFields
Fairy Fields is a 2D, RPG game where players find themselves in a mystical fairy land. In order to leave, they must help the fairy queen find all of her cats! This game was created as a final project for my CSI 4380 Game Programming class.
Play the game in your browser here! https://tessaperuzzi.itch.io/fairy-fields

![Screenshot 2022-07-24 162348](https://user-images.githubusercontent.com/54461147/180665033-98826dca-93c2-4f5b-b45a-c172efeb49fb.png)
The game starts with a dialogue scene with the player's character and the Fairy Queen, Flora. Players learn that in order to leave the fairy realm, they must help Flora find all of her missing cats.

![Screenshot 2022-07-24 162407](https://user-images.githubusercontent.com/54461147/180665061-adc6e89b-e49e-4bab-8f61-86cae322c93a.png)
Players are then taken to a 2D, pixel art world. Here, they play as a cat and get to explore the various quests throughout the game map.

![Screenshot 2022-07-24 162427](https://user-images.githubusercontent.com/54461147/180665081-ae7ce388-af1f-4ff1-9990-c71c5f6c204b.png)
One quest involves helping a villager find wood for her house.

![Screenshot 2022-07-24 162607](https://user-images.githubusercontent.com/54461147/180665098-82782e8f-8b00-4678-8af8-ef4d7fc6895f.png)
Another quest involves growing crops that need to be fed to the cows in exchange for milk.

![Screenshot 2022-07-24 162705](https://user-images.githubusercontent.com/54461147/180665109-fbbfac8e-da65-4d21-8dac-bbc2a27fe1dd.png)
Once the milk is gathered, a cat will appear.

![Screenshot 2022-07-24 162637](https://user-images.githubusercontent.com/54461147/180665116-6d52c89d-8fed-4aca-a822-419e38c86e13.png)
In another quest, users fish in order to find one of the cats.

![Screenshot 2022-07-24 162725](https://user-images.githubusercontent.com/54461147/180665135-ea274d13-2f32-45a1-892b-c314107ca8f4.png)
There is also one quest that involves fighting a bear.

**Assets Used**  
The following assets were used in this game:

Background/Main Cat Sprite Art/Cow Sprites/Garden Sprites
https://cupnooble.itch.io/sprout-lands-asset-pack

Houses/Animated Flower Art
https://assetstore.unity.com/packages/2d/characters/top-down-2d-rpg-assets-pack-...

Bear Art
https://grafxkid.itch.io/sprite-pack-5

Villager Art
https://grafxkid.itch.io/sprite-pack-1

Cat Art
https://pop-shop-packs.itch.io/cats-pixel-asset-pack

Fish Icons
https://shubibubi.itch.io/cozy-fishing (Free version)

Flora Art
https://red-baby.itch.io/sprite-pack-fantasy-female-mage

Main Character Human Art
https://red-baby.itch.io/sprite-pack-female-dark-hair

Mountain Background
https://photo-library.itch.io/wonderful-mountains

Main Menu/Dialogue Soundtrack/Game Over Sound
https://joshuuu.itch.io/short-loopable-background-music

Main Game Soundtrack
https://zakiro101.itch.io/free-casual-game-music-pack-vol-1

Sound Effects
https://kronbits.itch.io/freesfx

Fonts
Bitmgothic-https://www.1001fonts.com/bitmgothic-font.html
Manaspc-from in-class 2D platformer

Dialogue Script
https://www.youtube.com/watch?v=8oTYabhj248
I referenced this script to create a dialogue system, but still highly edited it to suit my game's needs.

**What I Created**  
This game was created in Unity and used C# scripts.  

*Animations* - None of my assets were premade prefabs in Unity. Instead, they were solely the sprite sheets. Therefore, I had to splice all sheets in Unity and make multiple animations/animators for each character.  

*Various Scripts* - In order to add functionality to the game, I created various scripts. The scripts involved things like health, controlling the player and bear enemy, updating the UI and sound effects, and controlling each of the quests. Since we did not create a 2D RPG game in class, there were no scripts from in class that I directly used. However, I created my scripts using the concepts we were taught in class.  

*TileMap* - I created rule tiles using the grass, room, dirt, fence, and hills tile art. I also created animated tiles for the flowers and water. Then, I added these tiles onto a tile grid. I created multiple tile layers and used collider layers so that players could not walk into fences, hills, or the water.  

*User Interfaces* - I created various user interfaces for when the game starts, pauses, and when the player loses or wins. The menus allow players to move to the next screen or exit the game if the game is played in an executable file.  

*Input System* - I updated my game to the new input system. On the player, I created an input system that used the WASD keys for movement, the Control key for selection/interaction, and the Escape key for pausing.
