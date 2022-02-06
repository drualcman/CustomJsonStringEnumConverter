// See https://aka.ms/new-console-template for more information
using EnumsToJson;
using System.Text.Json;

try
{
    Console.WriteLine("*************** serialize object with Serialize ***************");
    string jsonString = JsonSerializer.Serialize(new Usuario { Name = "Sergi", Department = UserDepartment.Development, Dashboard = UserView.Reports });
    Console.WriteLine(jsonString);
    Console.WriteLine("Check Enum is using the integer values");
    Console.WriteLine("*************** Deserialize without custom serialize ***************");
    Usuario other1 = JsonSerializer.Deserialize<Usuario>(jsonString);
    Console.WriteLine(other1.Name);
    Console.WriteLine(other1.Department);
    Console.WriteLine(other1.Dashboard);

    // Create a instance about my customer converter
    JsonSerializerOptions options = new JsonSerializerOptions { Converters = { new CustomJsonStringEnumConverter() } };

    Console.WriteLine("*************** Using custom converter *********************");
    Console.WriteLine("*************** My string *********************");
    jsonString = @"{""Name"":""Sergi"",""Department"":""Development"",""Dashboard"":""Reports""}";
    Console.WriteLine(jsonString);
    Console.WriteLine("Check Enum now is using the string values");
    Console.WriteLine("*************** Deserialize *********************");
    Usuario other = JsonSerializer.Deserialize<Usuario>(jsonString, options);
    Console.WriteLine(other.Name);
    Console.WriteLine(other.Department);
    Console.WriteLine(other.Dashboard);

    Console.WriteLine("*************** My string combination *********************");
    jsonString = @"{""Name"":""Sergi"",""Department"":""Development"",""Dashboard"":4}";
    Console.WriteLine(jsonString);
    Console.WriteLine("Check Enum now is using the string and integer values");
    Console.WriteLine("*************** Deserialize *********************");
    other = JsonSerializer.Deserialize<Usuario>(jsonString, options);
    Console.WriteLine(other.Name);
    Console.WriteLine(other.Department);
    Console.WriteLine(other.Dashboard);

}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
