# SimpleSQLite
sqlite-net extensions


## Getting Started

```
using (var conn = new SQLiteConnection(dbPath))
{
    if (IsTableExists<T>(connection))
    {
        var names = conn.Table<Names>();
    }
    // OR
    var names = SimpleSQLite.Common.Get<Names>(conn);
}
```

## API

```
var names = SimpleSQLite.Common.Get<Names>(conn);
SimpleSQLite.Common.SaveTable<Names>(conn);
```

### Prerequisities

.NET Framework 4


### Installing

https://www.nuget.org/packages/SimpleSQLite/


## Built With

visual studio 2013


## License

https://github.com/herbertagosto/SimpleSQLite/blob/master/LICENSE_3RD_PARTY
https://github.com/herbertagosto/SimpleSQLite/blob/master/LICENSE

