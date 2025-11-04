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

This was a self directed project creating a 2d game in Unity, over two terms working in class and outside of school. Facing many problems and overcoming them I have managed to create a fleshed out a playable state of the game. It is a game focusing on the player reaching a start point to end point while avoiding obstacles.

### Story and Objective

You play as the masked figure, banished into a dungeon area. Forced to escape and reclaim the power once had over the kingdom. Yet the plot takes a twist in a future added cutscene which contrasts what the player once thought the masked figure was.

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
The player starts with 5 hearts, when taking damage, hearts are deducted and when hearts are collected, the health is updated by one. When the player reaches 0 hearts the player is dies.

5 hearts were chosen to provide a balance to the game, a perfect number allowing for mistakes without a great cost.

<img width="200" height="50" alt="image" src="https://github.com/user-attachments/assets/cf1ea260-2efb-4e6e-a8d0-26b596082f94" />

When the health is changed the UI is updating to display the new HP level.

### Enemies 

Enemies have been added to provide an additional objective to the game. Making the end harder to reach. 

To provide variety two different enemies have been implemented having.
The ground enemy patrols between two points, if the player comes in a certain distance, the enemy becomes in chase mode, increasing speed
The air enemy, functions by having a return point. If the player comes into a certain distance the enemy begins to chase the player, if the player leaves the chase zone the enemy returns to return point.

If colliding with enemies using an on void collision trigger 2D, the player will lose hit points.

To deal damage the player must jump on the enemy to collide with the enemy weak hit box. Then once 3 damage is dealt the enemy dies.

| Ground | Flying |
| ------- | ------- |
|![enemy gifsssss splease work](https://github.com/user-attachments/assets/7c300d80-d69f-460d-8de0-073c40392fbe) | ![pleaseeee flying enemhy](https://github.com/user-attachments/assets/def6b3e7-d445-4e03-919c-a3ea5fc216b8)

### Collectibles

The collectibles were implemented as another feature to bring more life into the game. The edition of collectibles forces the player to engage with the entire level significantly changing the gameplay.

Collectibles in the form of gems are scattered around the map. Once the player has collected all the gems a key will appear. This then allows the player to unlock the door and finish the level.

|Gems|Key|Door|
| ------- | ------- | -------- |
|![gem key](https://github.com/user-attachments/assets/29487519-24df-40c7-a54f-b9addb28b6d3) |  ![key right size](https://github.com/user-attachments/assets/1a5d8e59-0db4-40c6-8224-acfd754dd357) | ![door](https://github.com/user-attachments/assets/9576708b-e6c8-4e9f-b139-a552390dfa52) |



## Development Documentation

To build the project, the software used was Unity and Visual Studio Code.
I used Unity to manage assets, set properties, create state machines and so on.
I used Visual Studio Code to edit scripts.

<unity and vs code screenshots>

### Tutorials

<
I actiely looked up tutotirals online and followed the steps from the tutorials

when I had toroubl I asked co-pilot to explain the code, find issues and suggest the changes
(Some code samples were developed with assistance from peers and copilot usage. )

For examp.e, I used Bendux tutotrials to implement, jumps, left and right movement, learnt how to apply basic force using 3d vectors.
Similarly, I folloed Bendux tutorial to implemnt Dash feature, e.g. i learned to disable gravity for the duration of the dash.


Other codes were created independently from understanding and knowledge of previous codes. An example is the boss code, the only tutorial used was a Brackeys, but I managed to develop a different state functions sctipts by myself from knowledge learned.
(my understanding of the technology improved after implementing few features following tutorials
i was able to write more code afterwards using knowledge from previous tasks
)
>

### AI Assistance

<I used co-pilot to help me implement features of the game.
I utilised the AI as an assistant in the following ways
- Ask AI to explain the code to me, including code from the tutorials
- Ask AI to help me debug the code to find issues
- Get help with designing new features by asking for high level code structure

I learned using AI as a new skill
One approach I found useful is to describe the behavior I wanted to implement and ask for suggestions and step by step guidance so that I understood each change I make to the project
(This furthermore reinforced my skills as a developer and understanding of programming. )
>


### Animations

<
Animations is one of the key features of the project.
I particurarly enjoyed building animation state machines and creating smooth transitions between animation states
here's an example of animation state machine for player movement
<screenshot of animation state machine here>

The animations for Boss.....
<boss animation state macin screenshot>

### Physics

<
Physics is an important part of the game.
Because it's a platformer game the player character moves along the ground and jump on the platforms
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

