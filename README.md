# DickinsonBros.DateTime
<a href="https://dev.azure.com/marksamdickinson/dickinsonbros/_build/latest?definitionId=13&amp;branchName=master"> <img alt="Azure DevOps builds (branch)" src="https://img.shields.io/azure-devops/build/marksamdickinson/DickinsonBros/13/master"> </a> <a href="https://dev.azure.com/marksamdickinson/dickinsonbros/_build/latest?definitionId=13&amp;branchName=master"> <img alt="Azure DevOps coverage (branch)" src="https://img.shields.io/azure-devops/coverage/marksamdickinson/dickinsonbros/13/master"> </a><a href="https://dev.azure.com/marksamdickinson/DickinsonBros/_release?_a=releases&view=mine&definitionId=6"> <img alt="Azure DevOps releases" src="https://img.shields.io/azure-devops/release/marksamdickinson/b5a46403-83bb-4d18-987f-81b0483ef43e/6/7"> </a><a href="https://www.nuget.org/packages/DickinsonBros.DateTime/"><img src="https://img.shields.io/nuget/v/DickinsonBros.DateTime"></a>

A wrapper library for DateTime

Features
* Adds extensibility via abstraction
* Allows for unit testing

<h2>Example Usage</h2>

```C#

var date = dateTimeService.GetDateTimeUTC();
Console.WriteLine(date);

```

    5/26/2020 8:58:20 PM

Example Runner Included in folder "DickinsonBros.DateTime.Runner"

<h2>Setup</h2>

<h3>Add Nuget References</h3>

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
