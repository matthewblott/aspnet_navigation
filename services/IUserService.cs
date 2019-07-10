using System.Collections.Generic;
using aspnet_template.models;

namespace aspnet_template.services
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