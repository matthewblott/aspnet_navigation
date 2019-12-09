using System.Collections.Generic;
using System.IO;
using System.Linq;
using aspnet_navigation.models;
using Newtonsoft.Json;

namespace aspnet_navigation.services
{
  public class UserService : IUserService
  {
    private const string Filename = "data/users.json";
    private readonly IList<User> _users = new List<User>();

    public UserService()
    {
      if (!File.Exists(Filename)) return;

      var json = File.ReadAllText(Filename);

      _users = JsonConvert.DeserializeObject<IList<User>>(json);
    }

    public IEnumerable<User> GetAll() => _users;

    public User GetById(int id)
    {
      var q = from x in _users where x.Id == id select x;
      var user = q.FirstOrDefault();

      return user;
    }

    public User GetByUsername(string username)
    {
      var q = from x in _users where x.Username == username select x;
      var user = q.FirstOrDefault();

      return user;
    }

    public IEnumerable<Group> GetGroupsByUser(int userId)
    {
      var q = from x in _users where x.Id == userId select x.Groups;
      var groups = q.FirstOrDefault();

      return groups;

    }
    
    public void Add(User user)
    {
      user.Id = _users.Count + 1;

      _users.Add(user);

      SaveChanges();
    }

    public void Update(User user)
    {
      _users.Remove(GetByUsername(user.Username));
      _users.Add(user);
      SaveChanges();
    }

    private void SaveChanges()
    {
      var json = JsonConvert.SerializeObject(_users, Formatting.Indented);

      File.WriteAllText(Filename, json);
    }
    
  }
  
}