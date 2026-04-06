using System;

// The MyService class implements the IMyService interface and provides a simple implementation of the LogCreation method.
public class MyService : IMyService
{
    private readonly int _serviceId;

// The constructor generates a random service ID to demonstrate that the same instance is used across the application.
    public MyService()
    {
        _serviceId = new Random().Next(100000, 999999);
    } 
// The LogCreation method logs a message along with the service ID to the console.
    public void LogCreation(string message)
    {
        Console.WriteLine($"Service Id : {_serviceId}: {message}");
    }  
}