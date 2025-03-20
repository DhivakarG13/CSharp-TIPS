## Assignment_14_

1. Dependencies in the projects are added in the order such that it builds in order D,C,B,A.
![image](https://github.com/user-attachments/assets/2a8caab7-0878-492d-8734-1cadbcd03734)
2. Functionalities of B was asked to used in C, which is impossible because Circular dependency is not allowed.
![image](https://github.com/user-attachments/assets/a8b27e26-6464-4520-9183-8c1748f78a94)
3. Dependencies are modified to a order by which it executes properly.
![image](https://github.com/user-attachments/assets/98c9f938-5427-4d77-85fe-70599ed09a50)

###  Importance of proper project organization, solution management, and build order in C# development:
- Inside a solution we will be having projects and class libraries.
- when we run the app the the control flow should be like greeting , then getting user input, evaluating and displaying the result.
- The class libraries must be build in the order such that the the class library on which most of the other projects are dependent should be build first.
- In visual studio we can only edit the build order by editing the dependencies of the project.
- And if visual studio detects that we're adding dependencies to a project which may end up in circular dependency while building , it'll not allow us to add that dependency to that project.
- So if dependency order is like A <- B <- C <- D <- E.
- The build order will be like E, D, C, B, A.
- Designing the app in such a way that there will be no circular dependency is important.
