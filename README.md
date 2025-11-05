# :space_invader: Game Design 2025 - Vladimir G :space_invader:

## Table of Contents

- [About the Game](#about-the-game)
- [Story and Objective](#story-and-objective)
- [Playthrough](#playthrough)
- [User Documentation](#user-documentation)
  - [User Controls Guide](#user-controls-guide)
  - [Health Points](#health-points)
  - [Enemies](#enemies)
  - [Collectibles](#collectibles)
- [Developer Documentation](#development-documentation)
- [Acknowledgements](#acknowledgements)
- [Tutorial References](#tutorial-references)

## About the Game

This was a self-directed project creating a 2d game in Unity, over two terms working in class and at home. Facing many problems and overcoming them, I have managed to flesh out a playable state of the game. It is a game focusing on the player reaching a start point to an end point while avoiding obstacles.

### Story and Objective

You play as the masked figure, banished to a dungeon area. Forced to escape and reclaim the power once held over the kingdom. Yet the plot takes a twist in a future-added cutscene, which contrasts with  what the player once thought the masked figure was.

### Playthrough

https://github.com/user-attachments/assets/c48f8516-9734-4080-8fd4-a13b24b807ba

## User Documentation

### User Controls Guide

| Keybind | Actions |
| ------- | ------- |
| A       | :arrow_left: MoveLeft  |
| D  |  :arrow_right: MoveRight|
| S | :arrow_down: Drop through Platforms |
| Space | :arrow_up: Jump |
| Shift | :fast_forward: Dash  |
| Double Space | :arrow_up: :arrow_up: Double Jump |
| Space + A or D|:arrow_up: :arrow_left: :arrow_right: Wall Jump|

### Health Points

Health points are added as another difficulty layer.
The player starts with 5 hearts. When taking damage, hearts are deducted, and when hearts are collected, the health is updated by one. When the player reaches 0 hearts, the player dies.

5 hearts were chosen to provide a balance to the game, a perfect number allowing for mistakes without a great cost.

<img width="200" height="50" alt="image" src="https://github.com/user-attachments/assets/cf1ea260-2efb-4e6e-a8d0-26b596082f94" />

When the health is changed, the UI updates to display the new HP level.

### Enemies 

Enemies have been added to provide an additional objective to the game. Making the end harder to reach. 

To provide variety, two different enemies have been implemented.
The ground enemy patrols between two points. If the player comes within a certain distance, the enemy enters chase mode, increasing speed
The air enemy functions by having a return point. If the player comes within a certain distance, the enemy begins to chase the player; if the player leaves the chase zone, the enemy returns to the return point.

If colliding with enemies using an on-void collision trigger 2D, the player will lose hit points.

To deal damage, the player must jump on the enemy to collide with the enemy's weak hit box. Then, once 3 damage is dealt, the enemy dies.

| Ground | Flying |
| ------- | ------- |
|![enemy gifsssss splease work](https://github.com/user-attachments/assets/7c300d80-d69f-460d-8de0-073c40392fbe) | ![pleaseeee flying enemhy](https://github.com/user-attachments/assets/def6b3e7-d445-4e03-919c-a3ea5fc216b8)

### Collectibles

The collectibles were implemented as another feature to bring more life into the game. The edition of collectibles forces the player to engage with the entire level, significantly changing the gameplay.

Collectibles in the form of gems are scattered around the map. Once the player has collected all the gems, a key will appear. This then allows the player to unlock the door and finish the level.

|Gems|Key|Door|
| ------- | ------- | -------- |
|![gem key](https://github.com/user-attachments/assets/29487519-24df-40c7-a54f-b9addb28b6d3) |  ![key right size](https://github.com/user-attachments/assets/1a5d8e59-0db4-40c6-8224-acfd754dd357) | ![door](https://github.com/user-attachments/assets/9576708b-e6c8-4e9f-b139-a552390dfa52) |



## Development Documentation

To build the project, the software was used Unity and Visual Studio Code.

Used Unity to manage assets, set properties, create state machines, and so on, and it allowed me to build the game.

Used Visual Studio Code to create and edit scripts.

<img width="1440" height="900" alt="image" src="https://github.com/user-attachments/assets/4d6760a9-6596-48cd-8bbd-bf70bb4ef8c5" />
<img width="1440" height="900" alt="image" src="https://github.com/user-attachments/assets/4a04842c-b41f-4a65-9db6-d6585bf53994" />



### Tutorials

To learn how to create most things within my game, I used tutorials online to develop my own game and code.

When the tutorials would not work, I would first look for a different tutorial. If all fails, I ask Copilot how to solve the problem. Making sure I understood the code before implementing.

Tutorials were the biggest reference used when creating the game.

Other codes were created independently of understanding and knowledge of previous codes. An example is the boss code; the only tutorial used was a Brackeys video, but I managed to develop different state functions scripts by myself from the knowledge learned.

### AI Assistance

I used Co-Pilot to help me implement features of the game.

I utilised the AI as an assistant in the following ways
- Asked AI to explain the code to me, including code from the tutorials, to improve my understanding of the language.
- Asked AI to help me debug the code to find issues that were causing problems.
- Get help with designing new features by asking for a high-level code structure, to act as a reference when developing my own game.

I learned to use AI as a new skill
One approach I found useful is to describe the behaviour I wanted to implement into my game, then ask for suggestions and step-by-step guidance so that I understand each change I make to the project.

This allowed me to further reinforce my skills as a developer and what good usage of AI looks like to integrate different work into my project.

### Animations

Animations are one of the key features of the project. 

Animations were by far one of the most challenging features to implement. Taking countless hours from different tutorials to be able to implement within my game. Having to adapt code to fit the animations and learning transitions all came with time, but provided me with new skills after spending so long. In hindsight, the implementation of animations not only improved my game but the my overall understanding of code and game engine builders.

**Player**

This is an example of an animation tree for my player.

<img width="631" height="355" alt="image" src="https://github.com/user-attachments/assets/3cc6a4a1-db69-4697-9aa8-29b378b613c4" />

My player animation contains the following state:
- Movement (Idle / Run)
- Hurt
- Die
- Jump (Fall)
- Wall Jump 
- Double Jump (Fall)

Multiple states were merged to provide more clarity.

<img width="475" height="111" alt="Screenshot 2025-11-05 at 12 15 37 pm" src="https://github.com/user-attachments/assets/034f3eab-5a0e-4eb0-8a98-fce0fab811ba" />
<img width="475" height="111" alt="Screenshot 2025-11-05 at 12 16 10 pm" src="https://github.com/user-attachments/assets/235bd5ec-1c4c-4157-a750-59777d0893c9" />

For the movement, using rb velocities was more efficient than addForce. Direct velocity control provides more responsive movement, enhancing the platformer experience.

**Boss**

The Boss uses a state machine for the Animations. This is different from the player as it allows for code to 'attach' to the animations. Allowing for certain code to trigger and run at certain animations.

<img width="520" height="420" alt="image" src="https://github.com/user-attachments/assets/598680c7-3548-4730-b1bb-3f2e8ccd4756" /> <img width="329" height="420" alt="image" src="https://github.com/user-attachments/assets/f052f062-f87f-4b0f-9bad-79a352c45e06" />

The boss had the following animation states:
- Walk
- Attack
- Spell
- Transition
- Second Phase Walk
- Attack
- Spell
- Death

The Walk states acted as the main block of animations. Both walk states had code which allowed the boss to attack the player and use spells and attack the player. This was done by allowing the boss to choose between an Attack and a Spell, then triggering that animation. During the animation, an event is triggered, the event is a piece of code checking whether the player's hitbox is colliding with the area, then either making the player lose health, or nothing happens.

<img width="1438" height="570" alt="image" src="https://github.com/user-attachments/assets/cd3f2bbb-c231-4072-a014-041ac1fbdf54" />

The following image shows Gizmo Draw Circle 2d, which was used to show the radius of the multiple attacks the boss could do. The animation at the bottom shows the event that will trigger during an animation. 

Choosing a state machine for the boss allowed for more complex scenarios to occur. It allowed for more than one logic state to occur at once, overall improving the boss fight experience, which improved the quality of the game severely.

### Physics


Physics is an important part of the game.
Because it's a platformer game, the player character moves along the ground and jump on the platforms
I have implemented jumps down through the platform the player stands on which required temporarily disabling colliders
Wall jumps are a key feature of the game and player must use them to complete the game
To implement the wall jump I had to control the character's physics, e.g. to implement sliding down the wall as part of wall jump.
Finally, hitting enemies on the head required working with colliders as well. E.g. make the player bounce up after hitting the enemy.
When the player is hit it is immune to futher attacks for a short time, implemented by disabling player's hit box.
>

## Acknowledgements

- Boss: https://assetstore.unity.com/packages/2d/characters/bringer-of-death-free-195719 by Clembod
- Player: https://assetstore.unity.com/packages/2d/characters/pixel-adventure-1-155360 by PixelFrog
- Tilemaps and Enemies: https://assetstore.unity.com/packages/2d/environments/stomper-platform-assets-195244 by Ansimuz

## Tutorial References

| Action | Tutorials |
| ------- | ------- |
| Basic Movement | https://www.youtube.com/watch?v=K1xZ-rycYY8. |
| Dash | https://www.youtube.com/watch?v=2kFGmuPHiA0. |
| DropDown | https://www.youtube.com/watch?v=aWdwQJbg1Ds |
| Double Jump | https://www.youtube.com/watch?v=OT537RfNzCU |
| HeartSystem | https://www.youtube.com/watch?v=yxzg8jswZ8A |
| Learning to implement animations | https://www.youtube.com/watch?v=AdQz2wStdLY |
| Collectable System | https://www.youtube.com/watch?v=5GWRPwuWtsQ |
| UI| https://www.youtube.com/watch?v=DX7HyN7oJjE|
| Level Select| https://www.youtube.com/watch?v=2XQsKNHk1vk|
| Level Lock | https://www.youtube.com/watch?v=2XQsKNHk1vk |
| Pause Menu | https://www.youtube.com/watch?v=MNUYe0PWNNs |
| Scene Managment | https://www.youtube.com/watch?v=E25JWfeCFPA|
| Ground Enemy Attack | https://www.youtube.com/watch?v=KF3EVjOhN4c&list=PLSR2vNOypvs72jRSvOEWv448Tle9nDw1Z&index=1 |
| Ground Enemy Player Attack | https://www.youtube.com/watch?v=ICVkhZ5s970&list=PLSR2vNOypvs72jRSvOEWv448Tle9nDw1Z&index=2|
| Ground Enemy Patrol | https://www.youtube.com/watch?v=l7VyxIzAIAc&list=PLSR2vNOypvs72jRSvOEWv448Tle9nDw1Z&index=3|
| Ground Enemy Chase | https://www.youtube.com/watch?v=ptLg-J67vIU&list=PLSR2vNOypvs72jRSvOEWv448Tle9nDw1Z&index=4 |
| Flying Enemy Logic | https://www.youtube.com/watch?v=TIXY0TR7Z0g | 
| Boss | https://www.youtube.com/watch?v=AD4JIXQDw0s|
| Boss HealthBar | https://www.youtube.com/watch?v=bRcMVkJS3XQ |

