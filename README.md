UbiquitousId
==========

**Description**
A library for .Net that makes creating and working with custom identifiers easy! Stop relying on ambiguous Guid's/Integers for your Id's and start using something ubiquitous like IId<YourType>

**Installation:**
The easiest way to install is by using [Nuget](http://nuget.org/packages/TW.UbiquitousId/)

**Documentation**
see the [wiki](https://github.com/TonightWe/UbiquitousId/wiki) for available documentation

**Quickstart:**
```C#
// Quickstart Setup
// ----------------

// some custom type that needs an id
public interface IUser{}

// define a schema for your id
var schema = new IdSchema(new List<Type>{typeof(DateTime),typeof(Guid)});

// QuickStart Part 1: Creating an Id<T> instance
// ---------------------------------------------

// define components for your id instance. 
// Note: The type and order must match that defined by your schema
var components = new List<Object>
{
  DateTime.Parse("2009-06-15 20:45:30Z"),
  Guid.Parse("fe67da762a214fa2b356d9e5da80edfc")
};

// create your id
var id = new Id<IUser>(components,schema);

// access components
DateTime dateTime = id.Components.First();
Guid guid = id.Components.Last();

// convert to string
var idString = id.ToString(); 
// idString would equal:
// 2009-06-15 20:45:30Z|fe67da762a214fa2b356d9e5da80edfc

// Quickstart Part 2: Reconstructing an existing Id<T> instance
// ------------------------------------------------------------

id = new Id<IUser>(idString,schema);

idString = id.ToString();
// again, idString would equal: 
// 2009-06-15 20:45:30Z|fe67da762a214fa2b356d9e5da80edfc

```
