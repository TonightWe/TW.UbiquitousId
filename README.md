UbiquitousId
==========

**Description**
A library for .Net that makes creating and working with custom identifiers easy! Stop relying on ambiguous Guid's/Integers for your Id's and start using something ubiquitous like IId<YourType>

**Installation:**
The easiest way to install is by using [Nuget](http://nuget.org/packages/TW.UbiquitousId/)

**Introduction To Ids**
The type you will use most frequently while working with the UbiquitousId library is the Id<T> type.

To fully understand the Id<T> type, you really only need to know a few things:  
- Each Id<T> instance consists of a schema and set of id components
- The id components appear in the order defined in the schema
- When an id is serialized, the id components are separated by the separator defined in the schema
- When an id is deserialized, the id components are expected to be separated by the separator defined in the schema
- You can create an id instance from a list of components(type and order must match schema) and a schema 
- You can create an id string by invoking the ToString() method of an id instance
- You can recreate an id instance from an id string

Id components are serialized/deserialized with implementations of IIdComponentConverter. There are several implementations that are already implemented by default, namely: 
- DateTimeIdComponentConverter (converts DateTime components)
- EnumIdComponentConverter (converts Enum components)
- GuidIdComponentConverter (converts Guid components)
- StringIdComponentConverter (converts String components)

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
var dateTime = id.Components.First();
var guid = id.Components.Last();

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
