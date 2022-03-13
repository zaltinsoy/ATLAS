# ATLAS - MMI 541 Physics Game Project

# Introduction
## Summary
Atlas is a 3D First Person Puzzle Game where the players will be in the role of the reincarnation of the Greek titan Atlas. The game will be consist of different test chambers. Player's aim is to reach the exit of  each chamber. These test chambers will consist 3D puzzles and the player will use the different gravity manipulation powers to solve these puzzles and reach the end of the level. Game is developed in Unity platform, and Cyclone Physics Engine[^cyc]  is used for the physics calculations in the game. Atlas developed as a term project in the MMI 541 Physics for Computer Games course. 

* **Genre:** 3D First Person Single Player Puzzle Game
* **Platform:** Windows PC
* **Player's role:** Solve 3D puzzles with the ability of gravity manipulation

## Similar Games & Inspiration Sources
Following games are popular 3D puzzle games,  they are not based on the gravity manipulation but they give inspirational for the creation of 3D puzzles.

* PORTAL (2007)
* Q.U.B.E (2012)
* The Talos Principle (2014)
* The Witness (2016)

Following games are short students projects. These games are directly focused on the gravity manipulation. It is valuable to see how other games use the gravity manipulation as a game mechanic.

* The Flaws of Gravity (2017)
* Gravitas (2019)

# Game Development
## Game Story

In the game setting, gods of the old are real. Mythological gods are secretly living together with humans for ages. They live, they die and they reincarnate. They born as normal humans. During their lifetime when they encounter a stressful /traumatic situation, they remember their past lives and gain their abilities. 

**Luxus** is a global multinational technology company. They are aware of the existence of the gods and they want to use these gods for their own gains.

**Mauri** is (unawarely) the latest reincarnation of the Atlas. **Luxus** abducted and imprisoned him. One day, they left the door open, but the door leads to a test chamber. Only way to get out of the room is using the ability of gravity manipulation. By this way, they force him to remember his old lives and manifest his powers. Their master plan is to use the Atlas's powers for their own agenda.

## Environment
Each game level will be a test chamber. They will have a hospital like, sterile design in the first levels and cyberpunkish designs towards to end. These test chambers will have one entry and one exit door. Player needs to use their different abilities to the reach exit door (complete the level). There won't be any NPC/enemy etc. in the chambers. Other than the puzzle related objects, rooms will be mostly empty. For the scope of the project, only first level of the game is developed.

## Gameplay
Player will have 2 different gravity related power. Each level will be a 3D puzzle and player will use different powers to reach the end of the level.

### Powers:

#### P1: Object Gravity Direction Change
_Not every leaf falls to ground_

Normally, gravity pulls all objects towards the ground. In other words, the gravitational force acts on the global -y direction for all objects. With this ability, player can change the direction of the gravitational force acting on some of the objects. Only rectangular prism shaped objects can be altered with this power. Any of the 6 faces can be chosen as "gravitation direction".

#### P2: Object Zero Gravity
_There is no force_

With this ability player can reduce the gravitational force on an object to zero. Object will remain where it is up until a player or another object touches it or player dismiss the ability. If the object was on the ground or on another surface, it will remain to stay on there, if it is on the air, it will stay on the air.

## Physics Components

Below physics phenomenons will occur during the game:

* Rigid Body Physics
* Velocity and Acceleration
* Gravity: Gravity direction of the objects will constantly change during the gameplay and they will fall to different surfaces.
* Collision: Objects will be collide in the game. Therefore collision detection is one of the crucial parts of the game. Objects will not bounce back (coefficient of restitution is equal to 0) but they will drag others on the direction of the their gravitation. Objects with different gravity directions will affect each other.

### General Game Object Scripts 
C# port of Cyclone Physics Engine is used for the all physical interaction in the game. Following scripts are attached to all objects in the game.

#### Particle Class
This class used for containing main attributes of the game object like position, velocity, acceleration and inverse mass. It also includes the integration method of the objects.

```cs
       Vector3d position = new Vector3d();
        velocity = new Vector3d();
        forceAccum = new Vector3d();
        acceleration = new Vector3d();
        inverseMass = new REAL();
        damping = new REAL();
        GameObject particleObject = new GameObject();
        damping = 0.95;

        if (mass == 0) { inverseMass = mass; }
        else { inverseMass = 1 / mass; }
```
```cs
public static Particle integrate(REAL duration, Particle obje)
    {
        Vector3d resultingAcc = new Vector3d();

        //update linear position
        obje.position = Vector3d.addScaledVector(obje.position, obje.velocity,
		duration);
        
        
        resultingAcc = obje.acceleration;
        resultingAcc = Vector3d.addScaledVector(resultingAcc, obje.forceAccum, 
		obje.inverseMass);
        obje.acceleration = resultingAcc;

        //Update linear velocity from the acceleration;
        obje.velocity = Vector3d.addScaledVector(obje.velocity, resultingAcc, 
		duration);
        
        //Impose drag
        obje.velocity.x *= Math.Pow(obje.damping, duration);
        obje.velocity.y *= Math.Pow(obje.damping, duration);
        obje.velocity.z *= Math.Pow(obje.damping, duration);

        obje.forceAccum = new Vector3d(0, 0, 0);
        obje.acceleration = new Vector3d(0, 0, 0);

        return obje;
    }
```
	
#### Cyclone Runner
This script calls Cyclone integration method each frame. Then update the position of the object in the game scene. Mainly it's a interface between Cyclone and Unity.
```cs
  void Update()
    {
        //integrate object over time
        particleObje = Particle.integrate(Time.deltaTime, particleObje);
        //apply new position to gameObject
        transform.position = Vector3d.updatePosition(particleObje.position);
    }
```

### Collision Detection and Resolution
One collision script is developed for the both collision detection and collision resolution. 

#### Collision Detection
Collision detection algorithm check in a loop whether chosen object collide with another object in the game and then continue this process for the next object. All objects in the game environments are rectangular prisms therefore it's easier to detect their collisions.

```cs
      for (int i = 0; i < numMoving; i++) 
        {
            for (int j = 0; j < numMoving; j++) 
            {
                if (i == j){continue;}

                parGravy = gravy[i].GetComponent<Particle>();
                parGravy2 = gravy[j].GetComponent<Particle>();
                difference = Vector3d.disBetween(parGravy.position, 
				parGravy2.position);
                xDif = Math.Abs(parGravy.position.x - parGravy2.position.x);
                yDif = Math.Abs(parGravy.position.y - parGravy2.position.y);
                zDif = Math.Abs(parGravy.position.z - parGravy2.position.z);
                
                xLim = parGravy.transform.localScale.x / 2 + 
				parGravy2.transform.localScale.x / 2;
                yLim = parGravy.transform.localScale.y / 2 + 
				parGravy2.transform.localScale.y / 2;
                zLim = parGravy.transform.localScale.z / 2 + 
				parGravy2.transform.localScale.z / 2;
                
                xPenet = xLim - xDif;
                yPenet = yLim - yDif;
                zPenet = zLim - zDif;
                minPen = Math.Min(xPenet, Math.Min(yPenet, zPenet));

```

In the game when two object collide with each other normally their behavior will be result on rotation of the one object:

![Pasted image 20210702002447](https://user-images.githubusercontent.com/81522783/158060464-4ae880a9-8a62-4ba6-82ae-b1077811c72b.png)

However, we want them to move together without rotation like the following image. To provide this behavior, contact normal equation is changed. New contact normal is equal to normal direction of the contact surface (it is not related to the centers of the colliding objects).

![Pasted image 20210702002414](https://user-images.githubusercontent.com/81522783/158060451-038d9ede-c68c-470c-b38a-21d92fad7559.png)

```cs
  if (xDif < xLim && yDif < yLim && zDif < zLim)
                {
                    if (parGravy.inverseMass == 0 && parGravy2.inverseMass == 0) 
					{ continue; }
                    //get contact normal
                    Vector3d conNormal = Vector3d.normalize(parGravy.position
					- parGravy2.position);
                    //get relative velocity of the objects


                        if (minPen == xPenet)
                        {
                           
                            if (parGravy.velocity.x < 0) { conNormal = 
							new Vector3d(1, 0, 0); }
                            else if (parGravy.velocity.x > 0) { conNormal =
							new Vector3d(-1, 0, 0); }
                            else if (parGravy.velocity.x == 0) { conNormal =
							new Vector3d(0, 0, 0); }

                        }
                        if (minPen == yPenet)
                        {
                            if (parGravy.velocity.y < 0) { conNormal =
							new Vector3d(0, 1, 0); }
                            else if (parGravy.velocity.y > 0) { conNormal =
							new Vector3d(0, -1, 0); }
                            else if (parGravy.velocity.y == 0) { conNormal =
							new Vector3d(0, 0, 0); }
                        }

                        if (minPen == zPenet)
                        {
                          
                            if (parGravy.velocity.z < 0) { conNormal = 
							new Vector3d(0, 0, 1); }
                            else if (parGravy.velocity.z > 0) { conNormal = 
							new Vector3d(0, 0, -1); }
                            else if (parGravy.velocity.z == 0) { conNormal = 
							new Vector3d(0, 0, 0); }
                        }
```
#### Contact Resolution
Classical contact resolution described in the Cyclone Engine [^cyc] is used for the contact resolution.

### Gravitational Effects
Main aim of the game is using different gravitational directions to do that three scripts are developed. Only some of the game objects in the scene have these effects.

#### Apply Gravity
Attached objects will be subjected to normal -y direction gravity.

#### Gravity Direction
Attached objects will have gravity force acted on predefined direction. Player cannot change it during the game. 

#### Change Gravity
Attached objects' gravity forces are subjected to change by player. Player can chose any of the 6 surface for the gravity direction.

# Literature Survey
   Following papers are not directly related to game development. They are  investigating relationship between cognitive skills and 3D puzzle games. Therefore they were not helpful for the design of the game but they gave insight about the different applications of the games. 
   
* Shute, V. J., Ventura, M., & Ke, F. (2015). The power of play: The effects of Portal 2 and Lumosity on cognitive and noncognitive skills. Computers and Education, 80, 58–67. https://doi.org/10.1016/j.compedu.2014.08.013
* Oei, A. C., & Patterson, M. D. (2014). Playing a puzzle video game with changing requirements improves executive functions. Computers in Human Behavior, 37, 216–228. https://doi.org/10.1016/j.chb.2014.04.046
* VanMeerten, N., Varma, K., Gravelle, M., Miller, N., Kraikul, E., & Fatemi, F. (2019). Evidence of a Relationship Between Mental Rotation Skills and Performance in a 3D Puzzle Game. Frontiers in Education, 4(August), 1–6. https://doi.org/10.3389/feduc.2019.00082
* Adams, D. M., Pilegard, C., & Mayer, R. E. (2016). Evaluating the Cognitive Consequences of Playing Portal for a Short Duration. Journal of Educational Computing Research, 54(2), 173–195. https://doi.org/10.1177/0735633115620431


# Limitations
Originally I also planned to implement friction effects in the game and a third power where player can control all of the objects in the scene, however they are not part of the final build of the game due to time restrictions.

The second issue is controlling the avatar. Avatar **position** directly updated based on the input from the keyboard. However, when we update the position directly, it is not subjected to the physics rules and collision detection. To solve that I have tried to assign velocity and acceleration and use these external effects in the **integration** to move the avatar using physics engine. However, I could not manage to use this approach, avatar moves more than expected.

```cs
     if (Input.GetAxis("Vertical") != 0)
        {
            ver = Input.GetAxis("Vertical");
            playerObje = Particle.MovePlayer(Time.deltaTime * ver * 20 * rot,
			playerObje);
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            hor = Input.GetAxis("Horizontal");
            playerObje = Particle.MovePlayer(Time.deltaTime * hor * 20 * 
			rot2, playerObje);
        }
```

# Contribution
The main contribution of this project is developing a game with changing gravitation effects. This changing gravity direction mechanics can lead to different game mechanics and potential 3D puzzles.

[^cyc]: Millingtan, I. (2010). Game physics engine development : how to build a robust commercial-grade physics engine for your game (2nd ed.). https://www.sciencedirect.com/book/9780123819765/game-physics-engine-development
