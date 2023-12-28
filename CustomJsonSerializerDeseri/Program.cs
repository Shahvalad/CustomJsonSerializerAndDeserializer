
using CustomJsonSerializerDeseri;
using CustomJsonSerializerDeseri.Models;

using (HttpClient client = new HttpClient())
{
    string url = "https://pastebin.com/raw/t4BYwGKv";
    var result = await client.GetAsync(url);

    string json = await result.Content.ReadAsStringAsync();
    var root = json.FromJson<Root>();
    foreach(var prop in root.GetType().GetProperties())
    {
        Console.WriteLine($"{prop.Name} : {prop.GetValue(root)}");
    }

}



// employee obyektini json-a seriyalizasiya edib daha sonra json-u oxuyub deserializasiya edirik
Employee employee = new Employee()
{
    Name = "John",
    Lastname = "Doe",
    Position = "Developer",
    Salary = 1000
};

string jsonEmployee = employee.ToJson();
var newEmp = jsonEmployee.FromJson<Employee>();
foreach (var property in newEmp.GetType().GetProperties())
{
    Console.WriteLine($"{property.Name} : {property.GetValue(newEmp)}");
}

