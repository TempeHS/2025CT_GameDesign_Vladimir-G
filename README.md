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
- [Developer Documentation](#developer-documentation)
- [Acknowledgements](#acknowledgements)

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

<what ar those for>

## Development Documentation

To complete the project, the devolping software used was Unity and Visual Studio Code.

**Problems faced during development**
- Double jump only working from the ground
- Wall jump feel more natural
- Platform drop colliders functioning correctly

## Acknowledgments

<add artist here>

<add tutorials used>

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

Note:
Some code samples were developed with assistance from peers and copilot usage. I provided the behaviour and logic I wanted the code to do, and integrated it through suggestions and code examples. This furthermore reinforced my skills as a developer and understanding of programming. 

Other codes were created independently from understanding and knowledge of previous codes. An example is the boss code, the only tutorial used Brackeys, but I managed to develop a different state functions sctipts by myself from knowledge learned.

Inspiration, code snippets, etc.
* [Github md syntax](https://docs.github.com/en/get-started/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax)
* [TempeHS Unity template](https://github.com/TempeHS/TempeHS_Unity_DevContainer)
