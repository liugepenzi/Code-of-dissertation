# Winforms application

This project is used to solve the  Korteweg-De Vries equation(KDV) equation.

The user can customize the initial conditions of the equation. These conditions are manually input by the user, and the program will create an object called "Simulation Parameters" to record these fields. Including the number of points of the grid, the maximum time of calculation, the time step, the coefficients of the KdV equation, the initial value condition of the function u, and the scaling ratio of the drawing.

Note:
The third-party library ILNumerics is used in the project. The library is not a free resource, but it provides multiple free trials. If you just want to use it for simple academic purposes, such as running this project, then you only need to go to the official website Fill in your email address to get a free activation code.
Using ILNumerics only requires a few simple steps:
1. Download ILNumerics from NuGet.
2. Find ILNumerics in [Tools]>[Options] on the menu bar.
3. In the [License] option of ILNumerics, fill in the activation code and click active.
If you need more detailed instructions, you can find them on the official website("https://ilnumerics.net/get-started-with-ilnumerics.html")

For filling in the initial conditions of the application, for the sech function, the program cannot recognize this character, so if you want to use sech(x), you can enter 1/cosh(x). In addition, we recommend setting the time step small enough ( For example, 0.001, 0.0001), this not only ensures more accurate estimation results, but also solves the problem that if the time step is too large, the values ​​will grow exponentially or even explode during Runge-Kutta's iterative operation.
