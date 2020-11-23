CarESP is a emotion computation system. It is integrated by 4 components:

1) Cognitive emotion component, based on the Orthony, Clore and Collins and Em model.
2) Primary emotion, called stress factor. Inspired on the behaoir of stress on humans. This component is based on safety of the user, and has 4 components: vehicle's health, vehicle's capabiity for autonomous driving, operational states and environmental conditions. 
3) Vehicle's personality, based on the driving style of the user. 
4) Emotion mapping framework, based on the emotional experience component of affective computing. 

The system simulator was developed in a 3D enviroment empower by Unity-Game engine, which is contained in the folder 3D simulation. The emotion computation were developedn in Symulink/Matlab environment, where Simulink contains the architecture of the system and the connection, and Matlab functions defined the complex computations.  

Finally, the system is capable to test the generation of emotions in 6 scenarios:
    1) Pedestrian test: this test consists on the scenario of avoiding or hitting a Pedestrian.
    2) Driving in straigt line: this test consists on the scenario of stay below an allowed speed.
    3) Lane change: the test consists on the scenario of properly or improperly do the lane chnage.
    4) Curve handle: the test consists on the scenario of properly or improperly take a curve. 
    5) Vehicle following: the test consists on the scenario where a car following a leading car has an appropiate or unappropiate distance. 
    6) Overtaking: The test consists on a combination of scenarios such as car following, lane change, curve handle and the avoidance of hitting an obstacle (another vehicle).

The system was designed in Unity version 2019.1.0f2 and Matlab/Simulink 2019b. 
To start the application, clone all the files. To run, make sure all the Matlab files are in the same root directory where the run simulation is being executed or make sure the root directory of the Matlab files is added to the Matlab run environment. 