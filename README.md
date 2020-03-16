# SampleMediatRProject
A simple project that implements the MediatR package as part of implementation of Mediator pattern in an API project. This is used as the sample for one of my talks on Mediator pattern.

It is basically an API that gets the Id of the person and go all the way to repository and retrieve the name of the person and display the name with greeting. What is being demonstrated here is how a MediatR can be used to create a part of simple n-tier API application and how it combines with the best practices.

The other nuget it uses is autofac to register the dependencies in order to implement dependency injection.
