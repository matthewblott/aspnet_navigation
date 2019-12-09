using System.Collections.Generic;
using aspnet_navigation.models;

namespace aspnet_navigation.services
{
  public interface IUserService
  {
    User GetByUsername(string username);
    User GetById(int id);
    IEnumerable<User> GetAll();
    IEnumerable<Group> GetGroupsByUser(int userId);
    void Add(User user);
    void Update(User user);
    
  }
  
}