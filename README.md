# :space_invader: Game Design 2025 - Vladimir G :space_invader:

This was a self directed project creating a 2d game in Unity, over two terms working in class and outside of school. Facing many problems and overcoming them I have managed to create a fleshed out a playable state of the game. It is a game focusing on the player reaching a start point to end point while avoiding obstacles.

## All features within my game    :video_game:

The following sections below will explain all features I have implemented withing the guidance of tutorials online and people I collabed with.

### Movement    :runner:

| Keybind | Actions |
| ------- | ------- |
| A       | :arrow_left: MoveLeft  |
| D  |  :arrow_right: MoveRight|
| S | :arrow_down: Drop through Platforms |
| Space | :arrow_up: Jump |
| Shift | :fast_forward: Dash  |
| Double Space | :arrow_up: :arrow_up: Double Jump |

//Add a video of movement in//

#### Implementing mechanics into the game:

To complete my basic movement which include jump, and moving left and right. To do this I followed a simple tutorial made by Bendux. Where it focues on applying basic force using vector 2s. 

For the dash I followed a Bendux tutorial again. It provided a simple and easy way to implement a dash mechanic, by appyling force and diabeling gravity allowing the player to dash straight. 

To add a drop down which had by far the most errors when attemtpiting to implementing. As when switching from using gameobjects in the hierachy to tilemap colliders the orignal code from GameCodeLibrary would not work. To solve this problem I collabed with Copilot, and learnt I had to use a different type of disableing collider for my player where it would just disable Physics 2D instead of Player collider fixing any issues with colliders after and dropping through the floor.

To import the double jump I used a tutorial by game code library. It is a simple code where it would count how many jumps and limiting any more jumps after two. 

#### Tutorials used:

| Action | Tutorials :pencil: |
| ------- | ------- |
| Basic Movement | https://www.youtube.com/watch?v=K1xZ-rycYY8. |
| Dash | https://www.youtube.com/watch?v=2kFGmuPHiA0. |
| DropDown | https://www.youtube.com/watch?v=aWdwQJbg1Ds |
| Double Jump | https://www.youtube.com/watch?v=OT537RfNzCU |

### idkdkdkdkdkdk

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
