# NET Core 3 Part 1

## Background

These sessions will focus mainly on how to use NET Core to produce solid code following various well known patterns and practices. 

NET Core 3.x Extensions library has been heavily refactored since versions 2.x and this documents is for all of you that have used the older versions but also if you haven't been in contact with NET Core before. 

The three sessions will focus on coding techniques and how to use Microsoft.Extensions in a proper way to create all kinds of applications in NET Core 3.x

In this first session I will show you the basics of some of the building blocks included in NET Core Extensions to get you up to speed using them.

In session two we will have a deeper look into NET Core. We will look at Entity Framework Core using Code First and also how to write your own extensions in a simple way. 

Session three we will play around a bit with what we have seen and do some kind of rounding up of what you have seen. Finally will have a brief look at NET 5 and what differs from earlier versions.   

## Demos

1. Various Host samples

   These samples are here just to show a variety of different applications you can make by using Microsoft.Extensions just to show their common base.

2. Basics in a simple Console

   **ConsoleSample**

   Console sample of how to make configuration, logging and dependency injection available in it's simplest way

   **ConsolePropertyInjectionSample**

   Console sample of how to handle injection in classes that requires empty constructor for some reason.

   **ConsoleScopesSample**

   Console sample showing the difference between Scoped, Transient and Singleton lifecycles.

3. Basics in HostedService

   **IHostedServiceSample**

   Using the base for all HostedServices, IHostedService and comparing it with BackgroundService base class.

   **HostApplicationLifetimeSample**

   The correct way of detecting the states of the host and how to get signalled when anything changes

4. Configuration samples

   **ConfigurationProviders**

   How the configuration is implemented in NET Core and NET 5

   **StaticConfiguration**

   Injecting configuration values the correct way by using IOptions and IOptionsSnapshot

   **MonitoredConfiguration**

   Injecting configuration values the correct dynamic way by using IOptionsMonitor

5. Logging samples

   **UsingSerilog**

   How to change the base logger to anything that interacts correctly with Microsoft.Extensions, in this case Serilog

