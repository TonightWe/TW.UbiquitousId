UbiquitousId 
========== 

**Continuous Integration Nuget Feed:**
A [TonightWe continuous integration Nuget feed](https://www.myget.org/feed/Packages/tonightwe) is available
The current build status is: ![Unknown](https://www.myget.org/BuildSource/Badge/tonightwe?identifier=8e64120a-794f-4eb1-9462-be460c7901af)

**Description:**
A library for .Net that makes creating and working with custom identifiers easy. Stop relying on ambiguous Guid's/Integers for your Id's and start using something ubiquitous!

**Installation:**
The easiest way to install is by using [Nuget](http://nuget.org/packages/TW.UbiquitousId/)

**Documentation**
see the [wiki](https://github.com/TonightWe/UbiquitousId/wiki) for available documentation

**Quickstart:**
```C#
// Quickstart Setup
// ----------------

// create an interface for your custom id type so your code doesn't have a hard dependency on UbiquitousId
// Note: not necessary but good design
public interface IUserId
{
  DateTime DateTimeIdComponent {get;}
  Guid GuidIdComponent {get;}
}

// implement IUserId and let UbiquitousId handle the heavy lifting!
public class UserId : IUserId
{
  #region Constructors
  
  ///<summary>
  /// Constructs a new <see cref="UserId" />
  ///</summary>
  public UserId()
  {
    // generate the components of a new Id however you want...
    // the order in which you pass them must match that defined in the schema
    _id = new Id(new List<Object>{DateTime.UtcNow,Guid.NewGuid()},IdSchema);
  }
  
  ///<summary>
  /// Reconstructs an existing <see cref="UserId" />
  ///</summary>
  public UserId(userIdString)
  {
    _id = new Id(userIdString,IdSchema);
  }
  
  #endregion
  
  #region Fields
  
  // this schema specifies the first id component is a DateTime and the 
  // second id component is a Guid
  private static readonly IIdSchema IdSchema = new IdSchema(new []{typeof(DateTime),typeof(Guid)});
  private readonly IId _id;
  
  #endregion
  
  #region Properties
  
  public DateTime DateTimeIdComponent { get { return _id.First(); } }
  public Guid GuidIdComponent { get { return _id.Last(); } }

  #endregion
  
  #region Methods
  
  public override String ToString()
  {
    return _id.ToString();
  }
  
  #endregion
}


// QuickStart Part 1: Creating an Id instance
// -------------------------------------------

// create your id
var userId = new UserId();

// access components
DateTime dateTimeIdComponent = userId.DateTimeIdComponent;
Guid guidIdComponent = userId.GuidIdComponent;

// convert to string
var userIdString = userId.ToString(); 
// userIdString would equal:
// 2009-06-15 20:45:30Z|fe67da762a214fa2b356d9e5da80edfc



// Quickstart Part 2: Reconstructing an existing Id instance
// ------------------------------------------------------------

userId = new UserId(userIdString);

userIdString = userId.ToString();
// again, idString would equal: 
// 2009-06-15 20:45:30Z|fe67da762a214fa2b356d9e5da80edfc

```
