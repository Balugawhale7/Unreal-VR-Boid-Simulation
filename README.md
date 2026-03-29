# Unreal VR Boid Simulation
This is a 3D VR simulation of Boids made in Unreal Engine. A Boid being an individual agent following simple rules, an example of bird/fish flocking simulation. 
This was part of a University project. This contains just project files, build included in link below.

<img width="1267" height="707" alt="image" src="https://github.com/user-attachments/assets/be62f903-7291-4edd-86dd-3ccf8196aa50" />

**Link to video demo of project:** https://youtu.be/ghWKVlnsO7g

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

### Collision Avoidance

The Collision Avoidance function was originally a simple collider that checks to see if other objects were around the Boid. The function would then return a direction from that object to the Boid. 

This however would have the issue of causing the Boid to avoid the centre of the object rather than the edges. This works to an extent on smaller objects, on larger objects the Boids would tend to ‘clip into’ the object or go in complete opposite directions to the objects it saw, rather than avoid it gradually.

To solve these issues instead of using a collider a ray cast was used to detect objects in front of the Boid. The function initially had to be constructed by calculating points on a disk and then building up the dimensions from there. In 2D the rays can be cast from the Boid’s forward vector at increasing angles for each additional ray cast.

For 3D however, the rays must be cast in a cone in front of the Boid. A cone is a section of the Boid’s vision range, which by itself is a sphere around the Boid. To calculate the ray’s end positions, it was necessary to calculate how to spread out points on a sphere.

### Points on a Disk

This is the function for calculating points on a disk. The function loops through a number of points:


<p align="center">
  <img width="350" height="200" alt="image" src="https://github.com/user-attachments/assets/ebb4aef8-1963-4ccc-88c2-674044cb7463" />
</p>


<p align="center">
  Point Loop
</p>

For each point there is a distance that goes from 0 to 1 in the loop, the number is given a power to spread out the points from the centre:

<p align="center">
  <img width="600" height="200" alt="image" src="https://github.com/user-attachments/assets/2bc6fb84-0abb-44b8-b938-2478ac28b959" />
</p>

<p align="center">
  Distance Calculation
</p>

Then an angle that turns each point by some fraction of a circle:

<p align="center">
  <img width="400" height="200" alt="image" src="https://github.com/user-attachments/assets/e37f3428-27c8-41a6-a4fb-2775f2e65d44" />
</p>

<p align="center">
  Angle Calculation
</p>

The distance and angle can then be used to calculate the X and Y coordinates of the point:

<p align="center">
  <img width="600" height="200" alt="image" src="https://github.com/user-attachments/assets/a4d4fc9c-7f73-4763-8ab9-8f25857114ed" />
</p>



Then plot out the point in space:

<p align="center">
  <img width="300" height="200" alt="image" src="https://github.com/user-attachments/assets/f4f36d7f-7f51-4426-9aa0-3658e01949ea" />
</p>

<p align="center">
  Draw Point
</p>

Where the points are plotted is determined by the turn fraction. If the fraction is easily divisible then the points arrange into a specific number of lines equal to the turn fraction divided by 1.

If the turn fraction is an irrational number, the points tend to spread out evenly. The turn fraction which spreads the points out the most is the golden ratio subtracted by 1 in this case 0.618003:

<p align="center">
 <img width="280" height="269" alt="image" src="https://github.com/user-attachments/assets/08c2f2da-8f36-48b4-a25b-a12b955634af" />
 <img width="298" height="268" alt="image" src="https://github.com/user-attachments/assets/6d7fa1e4-d71e-4528-88fa-972940c7ab50" />
 <img width="286" height="268" alt="image" src="https://github.com/user-attachments/assets/32328c43-a383-44aa-8732-5f63c93fc762" />
</p>

<p align="center">
  Different Turn Fractions
</p>

### Points on a Sphere

The function for calculating points on a sphere modifies the function for the disk. The main difference being the calculation to plot out the points on an additional axis and having the minimum number of points be the negative of the max number, this is so that it creates a sphere and not a half-sphere:

<p align="center">
 <img width="939" height="248" alt="image" src="https://github.com/user-attachments/assets/e9ebf2a4-b800-4d75-8609-facfac957ded" />
</p>

<p align="center">
  X, Y, and Z Coordinate Calculations
</p>

Once the locations of all the points have been calculated, a ray can be cast from the centre of the sphere to a point. To figure out whether a ray is going in the same direction as the Boid, the function uses the dot product to compare the Boid’s direction with the ray’s direction:

<p align="center">
  <img width="939" height="302" alt="image" src="https://github.com/user-attachments/assets/20e1defd-1125-41bc-b910-fcbe3f95a82f" />
</p>

<p align="center">
  Dot Product
</p>

The dot product returns a value from -1 to 1, the closer this value is to 1 the closer the direction is to the Boid’s direction. A variable called Field of View (FOV) was created to narrow the Boid’s detection range to a cone. In this case, the rays that are red are lower than the specified FOV:

<p align="center">
  <img width="286" height="278" alt="image" src="https://github.com/user-attachments/assets/8315eb76-dea3-44ac-948f-e76adde9c0a8" />
  <img width="306" height="278" alt="image" src="https://github.com/user-attachments/assets/7f45d7f0-fd84-4911-b0ea-0641376d0c66" />
  <img width="313" height="277" alt="image" src="https://github.com/user-attachments/assets/325106b2-b917-480f-b29a-aeb78f3575f2" />
</p>

<p align="center">
  FOV display
</p>

### Calculating Rays

This function is then called at the beginning of the Boid’s function at the start of the simulation. It only needs to be run once for each Boid. Afterwards the Boid can use the array of points to cast rays to determine if they are about to collide with an object.

<p align="center">
  <img width="939" height="217" alt="image" src="https://github.com/user-attachments/assets/2e9f41c0-bea4-4bf3-aaaa-f50de3523a8e" />
</p>

<p align="center">
  Begin Play
</p>

Using the dot product of both directions to see if they are within the FOV threshold. The rays that meet the criteria are drawn:

<p align="center">
  <img width="939" height="341" alt="image" src="https://github.com/user-attachments/assets/dd4815ac-8106-4de6-96dd-8c5ddeaef899" />
</p>

<p align="center">
  Dot Product Comparison and Line Trace
</p>

If the ray hits an object, then it returns a direction that is from the ray to the Boid multiplied by the distance between them subtracted by 1, like the separation function. The closer the object is, the stronger the force that is applied. This is then added to the total direction and then returned, once done looping through all points:

<p align="center">
  <img width="939" height="259" alt="image" src="https://github.com/user-attachments/assets/f1a31ded-3c6f-42a0-8e07-14dcd0e75f8f" />
</p>

<p align="center">
  Add all Directions from Rays
</p>

Here is what the outcome of the function looks like on a single Boid, with the rays drawn for visibility:

<p align="center">
  <img width="420" height="362" alt="image" src="https://github.com/user-attachments/assets/efb8b11a-a8fd-498e-ace4-83a6498e322e" />
</p>

<p align="center">
  Boid with Rays Drawn
</p>

### Stick Attraction

The last function that was created was for interacting with the Boids. The function works by having Boid’s be attracted to a stick that the user can use to move the Boids. 

This is a force that is added onto the other forces but given a greater weight so that Boids prioritize it. It works the same as the cohesion function apart from using the end position of the stick as the direction to follow:

<p align="center">
 <img width="939" height="152" alt="image" src="https://github.com/user-attachments/assets/16462862-dc0b-4936-a695-7ed643512d4b" />
</p>

<p align="center">
  Stick Attraction
</p>

### Variable Menu

Afterwards a menu was created for changing the variables of the Boids on runtime:

<p align="center">
  <img width="393" height="377" alt="image" src="https://github.com/user-attachments/assets/fe113437-22a9-4cc0-b790-ebdeadb013c2" />

</p>

<p align="center">
  Variable Menu
</p>

<p align="center">
  <img width="401" height="439" alt="image" src="https://github.com/user-attachments/assets/99d11050-473c-4fa7-98a5-3b66a7aafe0c" />
</p>

<p align="center">
  Menu Functions
</p>

This is the full Boid behaviour function:

<p align="center">
  <img width="940" height="259" alt="image" src="https://github.com/user-attachments/assets/c61e39e6-84d3-434d-a64d-0e29605ba46d" />

</p>

<p align="center">
  Full Boid Behavior Function
</p>
