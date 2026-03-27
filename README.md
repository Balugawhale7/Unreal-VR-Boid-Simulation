# Unreal VR Boid Simulation
This is a 3D VR simulation of Boids made in Unreal Engine. A Boid being an individual agent following simple rules, an example of bird/fish flocking simulation. 
This was part of a University project. This contains just project files, build included in link below.

<img width="1267" height="707" alt="image" src="https://github.com/user-attachments/assets/be62f903-7291-4edd-86dd-3ccf8196aa50" />

**Link to video demo of project:** https://youtu.be/1WhtZJly2eY

**Link to build:** https://drive.google.com/file/d/1HsAsdzJjo_mluqdX0pGhpiM9RUD2z1mg/view?usp=drive_link

## Development:

**Tech used:** Unreal Engine

### Unreal VR Prototype

In Unreal the Boids were programmed using Unreal’s Blueprint Visual Scripting system, which uses C++ as the language.

### Spawn Area

A spawn area in the shape of a cube was created to spawn Boids. This cube determined the space which the Boids were allowed to occupy. The Boids are given a random position that is within the extent of the cube and a random direction that they head towards.

<p align="center">
  <img width="300" height="250" alt="image" src="https://github.com/user-attachments/assets/d305091f-a5f7-4782-a112-b12242bfafa2" />
</p>

<p align="center">
  Spawn Area
</p>

### Boid Detection

Boids need to be able to see each other to determine their own behaviour. A function was used which creates a sphere and detects actors within it. It has a filter that is solely used to exclude detection of other actors, in this case the current Boid.

It then checks to see if there are other objects of type ‘world dynamic’ (An object with dynamic movement) within the sphere, which should only be other Boid objects. An array is created which puts all the Boids that are within the sphere inside the array. This is constantly updated every tick to make sure that it is accurate.

<p align="center">
  <img width="438" height="291" alt="image" src="https://github.com/user-attachments/assets/ec6722d0-edd0-4033-96ce-6b0891eb4308" />
</p>

<p align="center">
  Boid Detection and Array
</p>

### Boid Behaviour Functions
After this information is collected, the next step is to implement the rules of Boids. Each rule had to have a separate function to make it easier to work on each of the components individually. Each function returns a vector direction.

<p align="center">
  <img width="700" height="300" alt="image" src="https://github.com/user-attachments/assets/446575e8-d817-4ef3-b9fd-d03de992b4e5" />
</p>

<p align="center">
  Separation
</p>

<p align="center">
  <img width="700" height="300" alt="image" src="https://github.com/user-attachments/assets/39283220-01a9-4bef-9eda-fc6a0e153f96" />
</p>

<p align="center">
  Alignment
</p>

<p align="center">
  <img width="700" height="300" alt="image" src="https://github.com/user-attachments/assets/d30b2989-4fc2-4298-9cc5-a9badaba7f4c" />
</p>

<p align="center">
  Cohesion
</p>

After returning all the vectors from each of the behaviour functions, they are aggregated and normalized to produce a vector that the Boid should head in. After the vector has been multiplied by a speed, the Boid’s position and rotation is then set in ‘world location’ which moves the Boid.

<p align="center">
  <img width="600" height="250" alt="image" src="https://github.com/user-attachments/assets/54cbfa43-fd64-431e-99d4-a57f1afe72c1" />
</p>

<p align="center">
  Aggregated Weights
</p>
