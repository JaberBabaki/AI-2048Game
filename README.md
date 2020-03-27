# AI-2048Game
>spring 2016
# Table of Contents

<!--ts-->
   * [About this project](#About-this-project)
   * [Some of algoritms](#some-of-algoritm)
   * [Technology Stack](#Techonology-stack)
   * [AI Strategy](#AI-starategy) 
   * [How to play](#How-to-play)
<!--te-->  
# About this project
2048 is a single-player sliding block puzzle game designed by Italian web developer Gabriele Cirulli. The game’s objective is to slide numbered tiles on a grid to combine them to create a tile with the number 2048. However, one can continue to play the game after reaching the goal, creating tiles with larger numbers.

In this project, the user can view the history of their previous games and also see the highest record of all those who have installed the game.

![Repo List](https://github.com/jReskti/AI-2048Game/blob/master/picture/1.jpg) ![Repo List](https://github.com/jReskti/AI-2048Game/blob/master/picture/4.jpg)![Repo List](https://github.com/jReskti/AI-2048Game/blob/master/picture/6.jpg)

# Some of algorithms
Game 2048 is a completely algorithmic game that we implement in this project using C # programming. In general, the game has a lot of algorithms because it is basically a combination of mathematics, intelligence, boredom and luck. And therefore extremely attractive.

# Techonology stack
Project is created with:
* C#
* sqlite
* php
* MySQL
# AI starategy
2048 is an intriguing and addictive puzzle game. The
AI for this game is still in its infancy, and while much
progress has already been made, there is still plenty of room
for improvement. The game has a large element of luck
involved, so a good AI must minimise the risk, but not so
much as to rule out greatness.
The approach taken was to treat the
game as adversarial; the AI does traditional depth-limited
Mini-Max searching, assuming the opponent will place the
worst possible tile. While this approach seams reasonableplan
for the worst-the AI is making decisions based on
events that may be highly unlikely happen, which is clearly
sub-optimal. The author of this AI does, introduce an
evaluation function based largely on monotonicity of the
rows and columns of cells.
# How to play
 Use your arrow keys or drag mouse to move the tiles. When two tiles with the same number touch, they merge into one!
 Every merged tile is added to your score.
