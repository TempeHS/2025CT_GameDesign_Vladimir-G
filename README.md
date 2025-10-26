# :space_invader: Game Design 2025 - Vladimir G :space_invader:

This was a self directed project creating a 2d game in Unity, over two terms working in class and outside of school. Facing many problems and overcoming them I have managed to create a fleshed out a playable state of the game. It is a game focusing on the player reaching a start point to end point while avoiding obstacles.

## All features within my game    :video_game:

The following sections below will explain all features I have implemented withing the guidance of tutorials online and people I collabed with.

#### Sections
| Section | Content |
| ------- | ------- |
|[Player](#player)|Movement| 
||HP|
||Collectables|
|||
|Game|GameManager|
|||
|Menus|UI|
|||
|Level|UI|
||Objects|
||Tilemaps|
||Spikes|
||Camera|
||Light|
|||
|AI|EnemyGround|
||EnemyAir|
|||
|Boss|DeathBringer|

<br>

## Player

### Movement    :runner:

| Keybind | Actions |
| ------- | ------- |
| A       | :arrow_left: MoveLeft  |
| D  |  :arrow_right: MoveRight|
| S | :arrow_down: Drop through Platforms |
| Space | :arrow_up: Jump |
| Shift | :fast_forward: Dash  |
| Double Space | :arrow_up: :arrow_up: Double Jump |
| Space + A or D|:arrow_up: :arrow_left: :arrow_right: Wall Jump|

https://github.com/user-attachments/assets/22cc96df-b7b2-4962-b9dc-ce8599f5ee0a


#### Implementing mechanics into the game:

To complete my basic movement which include jump, and moving left and right. To do this I followed a simple tutorial made by Bendux. Where it focues on applying basic force using vector 2s. 

For the dash I followed a Bendux tutorial again. It provided a simple and easy way to implement a dash mechanic, by appyling force and diabeling gravity allowing the player to dash straight. 

To add a drop down which had by far the most errors when attemtpiting to implementing. As when switching from using gameobjects in the hierachy to tilemap colliders the orignal code from GameCodeLibrary would not work. To solve this problem I collabed with Copilot, and learnt I had to use a different type of disableing collider for my player where it would just disable Physics 2D instead of Player collider fixing any issues with colliders after and dropping through the floor.

<img width="699" height="538" alt="image" src="https://github.com/user-attachments/assets/af4b8f01-a47a-459f-97f5-de0125abf851" /> </br>

To make the double jump I used a tutorial by game code library. It is a simple code where it would count how many jumps and limiting any more jumps after two. 

#### Tutorials used:

| Action | Tutorials :pencil: |
| ------- | ------- |
| Basic Movement | https://www.youtube.com/watch?v=K1xZ-rycYY8. |
| Dash | https://www.youtube.com/watch?v=2kFGmuPHiA0. |
| DropDown | https://www.youtube.com/watch?v=aWdwQJbg1Ds |
| Double Jump | https://www.youtube.com/watch?v=OT537RfNzCU |

</br>
</br>
</br>

### HP :heart:

For the player, there is a healthbar system implemented. This was by far one of the most challenging mechanics to implement, I went through at least 7 tutorial attempting to add this mechanic into my game. Then I stumbled on this tutorial which after a small debug I was able to implement a working heart system. 

The way the Hp worked is, it would set a player HP, current = total at the start. And using maths to be able to subtract or increase the Heart amount. Then it would update the HealthBar System, which is what the player sees. Allowing for my hearts to be able to update and function. It was a very simple way to display and write the code yet it outclassed many other tutorials.


But there was still one more addition which just seemed necessary to implement. A heart collecting system. However I did not want a boring simple way to pick up the hearts, I wanted to be able to do it straight from the tilemaps. So I began to figure a solution out. Well I created a update function which would allow for the Hp to update.

</br>

<img width="580" height="88" alt="image" src="https://github.com/user-attachments/assets/fb400f41-6a8c-42b8-a291-e4da033942bc" />

</br>

But the problem is I didn't know how to write the intial tilemap code. So I resorted to asking Copilot how to do it after seacrhing the internet and not finding a way to implement the mechanic the exact way I wanted it to work. The solution it told me is to take the current PlayerPosition and check if it has collided with a HeartTilemap. Basically resulting in any hearts which a player might stumble on to be collected.

https://github.com/user-attachments/assets/c7b7848a-dec7-4591-81cb-b45417c1b248


#### Tutorials used:

| Action | Tutorials :pencil: |
| ------- | ------- |
| HeartSystem | https://www.youtube.com/watch?v=yxzg8jswZ8A |

## Authors

Contributors names and contact info

ex. Mr Jones
ex. [@benpaddlejones](https://github.com/benpaddlejones)

## Version History

* 0.2
    * Various bug fixes and optimizations
    * See [commit change]() or See [release history]() or see [branch]()
* 0.1
    * Initial Release

## License

This project is licensed under the [NAME HERE] License - see the LICENSE.md file for details

## Acknowledgments

Inspiration, code snippets, etc.
* [Github md syntax](https://docs.github.com/en/get-started/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax)
* [TempeHS Unity template](https://github.com/TempeHS/TempeHS_Unity_DevContainer)
