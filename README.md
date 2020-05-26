# DickinsonBros.DateTime
<a href="https://www.nuget.org/packages/DickinsonBros.DateTime/">
    <img src="https://img.shields.io/nuget/v/DickinsonBros.DateTime">
</a>

A wrapper library for DateTime

Features
* Adds extensibility via abstraction
* Allows for unit testing

<a href="https://dev.azure.com/marksamdickinson/DickinsonBros/_build?definitionScope=%5CDickinsonBros.DateTime">Builds</a>

<h2>Example Usage</h2>

```C#

var date = dateTimeService.GetDateTimeUTC();
Console.WriteLine(date);

```

    5/26/2020 8:58:20 PM

Example Runner Included in folder "DickinsonBros.DateTime.Runner"

<h2>Setup</h2>

<i>Add Nuget References</i>

    https://www.nuget.org/packages/DickinsonBros.DateTime/
    https://www.nuget.org/packages/DickinsonBros.DateTime.Abstractions

<h3>Create Instance</h3>

```C#    
using DickinsonBros.DateTime;

...

var dateTimeService = new DateTimeService()
```

<h3>Create Instance (With Dependency Injection)</h3>

```C#        
using DickinsonBros.DateTime.Abstractions;
using DickinsonBros.DateTime.Extensions;

...  

var services = new ServiceCollection();   

//Add Service
serviceCollection.AddDateTimeService();

//Build Service Provider 
using (var provider = services.BuildServiceProvider())
{
   var dateTimeService = provider.GetRequiredService<IDateTimeService>();
}
```    
