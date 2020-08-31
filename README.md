# Madbox Test - Job Application Sergi Olives
This repository contains the test for the job application for MadBox as gameplay programmer by Sergi Olives.

### Time to perform the exercise
5 hours working on the project. I used some extra time to write my ideas in the readme and I previously prepared the empty project a day before just to test the used version, downloading Probuilder and making it work in Unity remote.

### Parts that were difficult for you and why
* Camera control was difficult for me since I've never modified a camera in-game with user input (I've created cinematics with camera movement but the player did not control anything) so at first I had to take some time to work on that but when I find out how to do it, it was easy to implement to the rest of the level.
* I had some problems with the animations of the player since it was art that I took from official courses of Unity and I lost some time finding out how the animator was designed for that model so I could use it in my game as expected.

### The parts you think you could do better and how
I did not have much more time left for both AI and GUI so I decided to work more on GUI since it was more straightforward.
* AI: I needed some time to think about a good AI and how to make it look as a real player and I got stuck on thinking about a solution so that's why I decided to work first on the GUI and if I got some time left, I would put the work on this aspect. I did not have enough time to implement and test the AI but in the PlayerController.cs there is a pseudocode approach for the AI that I think it could work better than just the "always moving AI" that it is implemented right now. I think that with 30 extra minutes I would have enough time to implement, test and polish it.
* GUI: I've implemented a first approach with the idea of showing some instructions at the beggining of the level and an indication if you have finished first or not. Then, I got some more time to implement kind of a map where the player can see where the rivals like in FunRace3D. My implementation shows the last checkpoint or at which obstacle the players are and with some more time I think I could have done a better job with the map showing the position of the players in real-time.
* Art and animation: if I got more time, maybe I would have worked more on the artistic side of the project altough I don't think it would improve that much since my skills producing art are not the best. Altough, I could have polished the animations a bit more to fit the project or find better assets. For example, there is an obstacle in the project where the player must climb stairs but because of the lack of art and animations, it is not clear that the player is climbing stairs.

### What you would do if you could go a step further on this game
Having in mind the idea of easy controls or just on-touch controls, I think about "reinventing" the game into a rythm game where the important is the timing of the touches. One thing that I always destroys my experience in some mobile games is the fact that my finger is in front of something important on the screen so I think that a game where the touching is minimal versus the FunRace3D game where without touching the screen the player does not advance, it is more benefitial for the player. I think there are some good minigames that could be played as rythm games like selecting a path, jumping over a bar or implement a swipping mechanic (that I think it wouldn't increase the control difficulty that much) if the player has to avoid animals coming at him and try the mechanic could be something like a race or something like *last man standing*. A rythm game with great music can work really good.


### What did you think
I think that was a good test and a good quantity of time to make a full hypercasual game prototype that I think it shows the core mechanics. One thing that during the beggining of the test was in my mind was how to approach some problems like for example the movement of the obstacles. I prefered to use scripts rather than animations mainly because the test was about programming skills, so that was some dilemma I got into my mind at the very beggining. Also, I tried to make the code as friendly for the designer as possible to let other people modify values for scripts without the need of changing code, at least for the main mechanics I implemented. It was a good challenge to just make good code in 5 hours, this has not been like a gamejam because I needed to focus on code and not just make it work at the short term. 

### Any comment you may have
This has been my first experience applying for a job in the games industry and probably the first time someone looks at my code in a unity project since my previous projects were personal or the code was not evaluated for any of my college projects so I would love to hear some feedback about it just to keep improving. Thank you for the opportunity!

*The project was not tested in a build but worked as expected both for PC and using Unity Remote on my phone.*
