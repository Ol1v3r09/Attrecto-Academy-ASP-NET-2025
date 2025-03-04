﻿using Academy_2025.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Academy_2025.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository()
        {
            _context = new ApplicationDbContext();
        }

        public List<User> GetUsersAbove18()
        {
            return _context.Users.Where(x => x.Age > 18).ToList();
        }

        public List<User> GetAll() 
        {
            return _context.Users.ToList();
        }

        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Create(User data)
        {
            _context.Users.Add(data);
            _context.SaveChanges();
        }

        public User? Update(int id, User data)
        {

            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user.Id == id)
            {
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;

                _context.SaveChanges();

                return user;
            }

            return null;
        }

        public bool Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user.Id == id)
            {
                _context.Users.Remove(user);

                _context.SaveChanges();

                return true;
            }

            return false;
        }
    
    }

}
