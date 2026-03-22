using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json;
using System.Reflection.Metadata;

class Program
{
    static int BinarySearch(List<User> sortedUsers, string target)
    //Creating a binary search method (Ex.4)
    {
        int left = 0;
        int right = sortedUsers.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            // Compare the username at mid with the target username
            int comparison = sortedUsers[mid].Username.CompareTo(target); 

            if (comparison == 0)
                return mid; // Target found at index mid
            if (comparison < 0)
                left = mid + 1; // Search in the right half
            else
                right = mid - 1; // Search in the left half
        }
        return -1; // Target not found
    }
    static async Task Main()
    {
        List<User> users = await FetchUsersFromApi(); // Fetch users from API 

        Console.WriteLine("Fetched Users:");
        // Loop through the list of users and print their usernames 
        foreach (var user in users)
        {
            Console.WriteLine(user.Username);
        }
        // Sort username in Acc (Ex:3)

        users.Sort((u1, u2) => u1.Username.CompareTo(u2.Username));
        Console.WriteLine("\nSorted Users:");
        foreach (var user in users)
        {
            Console.WriteLine(user.Username);
        }

        //Adding a target username to search for 
        Console.WriteLine("\nEnter a username to search:");
        string targetUsername = Console.ReadLine();

        //Performing binary search for the target username
        int result = BinarySearch(users, targetUsername);
        if (result != -1)
        {
            //If Found
            Console.WriteLine($"\nUser found at index {result}, Name: {users[result].Name}"); 
        }
        else //If Not Found
        {
            Console.WriteLine("\nUsername not found.");
        }
    }

    static async Task<List<User>> FetchUsersFromApi()
    //Method to fetch users from API and convert the response to a list of User objects
    {
        using HttpClient client = new HttpClient(); //Creating Http CLient
        string url = "https://randomuser.me/api/?results=10";
        var response = await client.GetFromJsonAsync<ApiResponse>(url);
        List<User> users = new List<User>();
        
        //loop through the results and create User objects from the API response, then add them to the list of users
        foreach (var result in response.Results)
        {
            users.Add(new User
            {
                Username = result.Login.Username,
                Name = $"{result.Name.First} {result.Name.Last}"
            });
        }
        return users;
    }

} 

class ApiResponse // Class to represent the structure of the API response
{
    public List<ApiResult> Results { get; set; }
}

class ApiResult // Class to represent each result in the API response
{
    public Name Name { get; set; }
    public Login Login { get; set; }
}

class Name  // Class to represent the name Object : First name + Last name
{
    public string First { get; set; }
    public string Last { get; set; }
}

class Login // Class to represent the login object which contains the username
{
    public string Username { get; set; }
}

class User  // Class to represent the User object with properties for Username and Name
{
    public string Username { get; set; }
    public string Name { get; set; }
}

