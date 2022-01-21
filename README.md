# To-the-Gates
To The Gates! is a game in tower defense style with some extra mechanics on top. Core of the game is based on one of the projects which i did when I've started learning Unity.
After that i decided to expand it somehow bigger, redesign and add more things. Only free assets were used in this game, with some extra modifications with polybrush.

# Core mechanics

Resources - required to place towers or fences.

Morale - determines whether you win or lose certain level; Increases range of your turrets; Is used as indicator to spawn extra resources nodes

Nodes - after reaching certain Morale threshold, a message appears on screen informing player about extra resource nodes around the map.
They can be distinguished by different mouseOver material. After clicking they award extra resources to player. One time use only.

HP ramp up - with every death enemies have ramping up hit points.

Turrets - core mechanic for every tower defense game.

Fence - these can be placed on path of enemies to suspend enemy movement for certain amount of time. 
They have own hit points which are gradually lost the more enemies are attacking the fence.
Base cost is almost the same as for turret and after huge amount of testing they might be useful in certain situations.

# Level progression

Design idea for level progression is that u either advance (winning) or retreat (losing) which allows you to somehow bounce between levels.
At this moment 3 levels are implemented with more to come.

Base level concept is:

1-[2]-3

with second level as starting one. To win the game you have to advance to level 1 and win there aswell to "pushback" enemy.

# How to play

https://play.unity.com/mg/other/to-the-gates

WebGL version so you don't have to download it. Unfortunately polybrush texture blend doesn't work well with WebGL so lighting/textures are different from what can be seen on screenshots as they're from PC build.

Controls: WSAD for camera
TAB - Infoboard
Left mouse button - interaction with world (turrets/fences/nodes)
Esc - Quit

PC Build is available in releases. You have to download and extract files then use .exe file.

# Screenshots

![Alt text](https://github.com/Fzhut0/To-the-Gates/blob/master/Assets/External%20assets/ttg1.png?raw=true "Start Menu")
![Alt text](https://github.com/Fzhut0/To-the-Gates/blob/master/Assets/External%20assets/ttg2.png?raw=true "Start Menu")

