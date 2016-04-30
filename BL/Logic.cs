﻿using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BL
{
    public class Logic
    {
        public void InsertUser(int id, string userName, string firstName, string lastName, string password)
        {
            using (var context = new DataContext())
            {
                var user = new Model.User
                {
                    Id = id,
                    UserName = userName,
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password,
                    IsOnline = false
                };
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public bool IsExist(string userName, string password)
        {
            bool userExist = false;
            var db = new DataContext();
            foreach (var u in db.Users)
            {
                if (u.UserName == userName && u.Password == password)
                {
                    u.IsOnline = true;
                    userExist = true;
                    break;
                }
            }
            if (userExist)
            {
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            db.Dispose();
            return false;
        }

        public Model.User GetUser(string userName)
        {
            Model.User user;
            using (var context = new DataContext())
            {
                user = context.Users.Where((u) => u.UserName == userName).FirstOrDefault();
                return user;
            }
        }

        public List<Model.User> GetOfflineUsers(List<Model.User> _onlineUsers)
        {
            List<Model.User> offlineUsers = new List<Model.User>();
            using (var db = new DataContext())
            {
                foreach (var user in db.Users)
                {
                    if (!(_onlineUsers.Exists(u => u.Id == user.Id)))
                        offlineUsers.Add(user);
                }
            }
            return offlineUsers;
        }
    }
}
