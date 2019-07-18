using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

public class RestApi
{
    private readonly IList<User> _users;

    public RestApi(string database)
    {
        _users = JsonConvert.DeserializeObject<IList<User>>(database);
    }

    public string Get(string url, string payload = null)
    {
        if (string.IsNullOrEmpty(payload))
            return JsonConvert.SerializeObject(_users);
        
        var request = JsonConvert.DeserializeObject<Dictionary<string, IEnumerable<string>>>(payload);
        var users = request["users"];

        return JsonConvert.SerializeObject(_users.Where(x => users.Contains(x.Name)));
    }

    public string Post(string url, string payload)
    {
        if (url == "/add") 
        {
            var request = JsonConvert.DeserializeObject<Dictionary<string, string>>(payload);
            var user = new User(request["user"]);
            _users.Add(user);

            return JsonConvert.SerializeObject(user);
        }
        else if (url == "/iou")
        {
            var request = JsonConvert.DeserializeObject<Dictionary<string, object>>(payload);
            var lender = _users.FirstOrDefault(x => x.Name.Equals(request["lender"]));
            var borrower = _users.FirstOrDefault(x => x.Name.Equals(request["borrower"]));
            var amount = (double) request["amount"];

            lender.Lend(borrower, amount);
            borrower.Borrow(lender, amount);

            return JsonConvert.SerializeObject(new[] {lender, borrower}.OrderBy(x => x.Name));
        }

        return string.Empty;
    }
}

public class User
{
    [JsonProperty("name")]
    public string Name { get; }

    [JsonProperty("owes")]
    public Dictionary<string, double> Owes { get; private set; } = new Dictionary<string, double>();

    [JsonProperty("owed_by")]
    public Dictionary<string, double> OwedBy { get; private set; } = new Dictionary<string, double>();

    [JsonProperty("balance")]
    public double Balance => OwedBy.Sum(x => x.Value) - Owes.Sum(x => x.Value);

    public User(string name)
    {
        Name = name;
    }

    public void Lend(User borrower, double amount)
    {
        if (Owes.ContainsKey(borrower.Name))
        {
            amount = Owes[borrower.Name] - amount;
            if (amount > 0)
            {
                Owes[borrower.Name] = amount;
                return;
            }

            Owes.Remove(borrower.Name);
            amount *= -1;
        }

        if (amount > 0)
        {
            if (OwedBy.ContainsKey(borrower.Name))
            {
                OwedBy[borrower.Name] += amount;
            }
            else 
            {
                OwedBy.Add(borrower.Name, amount);
                OwedBy = OwedBy.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            }
        }
    }

    public void Borrow(User lender, double amount) 
    {
        if (OwedBy.ContainsKey(lender.Name))
        {
            amount = OwedBy[lender.Name] - amount;
            if (amount > 0)
            {
                OwedBy[lender.Name] = amount;
                return;
            }

            OwedBy.Remove(lender.Name);
            amount *= -1;
        }

        if (amount > 0)
        {
            if (Owes.ContainsKey(lender.Name))
            {
                Owes[lender.Name] += amount;
            }
            else 
            {
                Owes.Add(lender.Name, amount);
                Owes = Owes.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            }
        }
    }
}