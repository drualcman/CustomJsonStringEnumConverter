# CustomJsonStringEnumConverter
Can convert Enum from value or from name using a JsonSerialize

## Example data
```
public enum UserDepartment
{
    All,
    CST,
    Couriers,
    Suppliers,
    Packing,
    Marketing,
    Web,
    Development,
    Accountant
}

public enum UserView
{
    Dashboard,
    Customers,
    Couriers,
    Suppliers,
    Reports,
    Accountant,
    Web
}

public class Usuario
{
    public string Name { get; set; }
    public UserDepartment Department { get; set; }
    public UserView Dashboard { get; set; }
}
```

# How to use
```
string jsonString = jsonString = @"{""Name"":""Sergi"",""Department"":""Development"",""Dashboard"":""Reports""}";
JsonSerializerOptions options = new JsonSerializerOptions { Converters = { new CustomJsonStringEnumConverter() } };
UserDemo User = JsonSerializer.Deserialize<UserDemo>(jsonString, options);

// other setup of the enum mixing value and string value
jsonString = @"{""Name"":""Sergi"",""Department"":""Development"",""Dashboard"":4}";
User = JsonSerializer.Deserialize<UserDemo>(jsonString, options);
```