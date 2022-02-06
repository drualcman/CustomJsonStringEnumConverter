// See https://aka.ms/new-console-template for more information
using EnumsToJson;
using System.Text.Json;

try
{
    Console.WriteLine("*************** serialize object with Serialize ***************");
    string jsonString = JsonSerializer.Serialize(new UserDemo { Name = "Sergi", Department = UserDepartment.Development, Dashboard = UserView.Reports });
    Console.WriteLine(jsonString);
    Console.WriteLine("Check Enum is using the integer values");
    Console.WriteLine("*************** Deserialize without custom serialize ***************");
    UserDemo User1 = JsonSerializer.Deserialize<UserDemo>(jsonString);
    Console.WriteLine(User1.Name);
    Console.WriteLine(User1.Department);
    Console.WriteLine(User1.Dashboard);

    // Create a instance about my customer converter
    JsonSerializerOptions options = new JsonSerializerOptions { Converters = { new CustomJsonStringEnumConverter() } };

    Console.WriteLine("*************** Using custom converter *********************");
    Console.WriteLine("*************** My string *********************");
    jsonString = @"{""Name"":""Sergi"",""Department"":""Development"",""Dashboard"":""Reports""}";
    Console.WriteLine(jsonString);
    Console.WriteLine("Check Enum now is using the string values");
    Console.WriteLine("*************** Deserialize *********************");
    UserDemo User2 = JsonSerializer.Deserialize<UserDemo>(jsonString, options);
    Console.WriteLine(User2.Name);
    Console.WriteLine(User2.Department);
    Console.WriteLine(User2.Dashboard);

    Console.WriteLine("*************** My string combination *********************");
    jsonString = @"{""Name"":""Sergi"",""Department"":""Development"",""Dashboard"":4}";
    Console.WriteLine(jsonString);
    Console.WriteLine("Check Enum now is using the string and integer values");
    Console.WriteLine("*************** Deserialize *********************");
    User2 = JsonSerializer.Deserialize<UserDemo>(jsonString, options);
    Console.WriteLine(User2.Name);
    Console.WriteLine(User2.Department);
    Console.WriteLine(User2.Dashboard);

}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
