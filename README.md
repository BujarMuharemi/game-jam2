# game-jam2
A puzzle physics platformer game made in a week for the [Brackeys Game Jam 2022.1](https://itch.io/jam/brackeys-7). The goal is to have a semi finished prototype which include the following: 
* game design which fits the theme
* better graphics, music and sfx then last time
* more polish then last time

## Dev Screenshots
![first screenshot](./firstScreenshot.PNG)

## To Do List
### General
* find a name for the game
* get your game play tested by 5 people or more

### Most important for today *(23.2)*
* test the game design of the xray view -> works good
    * test change xray time to just work when player holds button down, and he has like 3 seconds to use ~~after its depleted it take 3 seconds to recharge, but only when fully recharged its usable (grey while recharging)~~
        * -> added 5 sec viewable timer to platforms, they slowly fade out
        * -> xray can just be refiled with pickups
* create a moving platform script with a lot of public settings, which can be used for everything (platforms, spikes, saws) -> use debug line to show their travel range etc
* draw "ball player"
* ~~and just 1 health, because it makes everything worse~~ → instant death makes it better
* add parallax effect to game so it has depth
* "level done" pickup w/ icon and  next lvl canvas(without function)
* shader w/ radius for x ray
* add some pickup for points/ u have to pick up all to pass a level...

### Art 
- import all art without cutting the corners to hard
    - import new art
    - reimport old assets 
- different backgrounds (tree layer, mountains/hills etc)
 - ~~draw hearts for UI~~
- draw icon/bar for xray view 

    #### *later*
    * particle effects for everything (getting hit, landing somewhere)
    * post processing ?
    * light at pickups ?

### Level Design 
Levels design and creation of the 3 levels should be done after all the art and game mechanics are almost final. 

* tutorial level
* checkpoints
* first easy level
* second/end level
* 5 min playtime for the whole game ?
* level loading mechanism

### UI 
* show xray view somehow
* next level/level completed canvas
* death counter ?
* starting menu etc
### SFX 
should also be done before starting level creation. I very simple in unity.
* player "rolling/walking", jumping, landing, getting hit, dying
* canon shooting, bullet hitting
* chainsaw working
* pushing boxes
* using xray effect

### Music
* some music which matches the style and pace of the game
* 2 songs minimum, which loop



