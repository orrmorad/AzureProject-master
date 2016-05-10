using DAL;
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
        #region OLD CODE
        //private static Logic _logic;

        //private Logic()
        //{
        //    OnlineUserNames = new ObservableCollection<string>();
        //}

        //public ObservableCollection<string> OnlineUserNames { get; set; }

        //public static Logic LogicInstance
        //{
        //    get
        //    {
        //        if (_logic == null)
        //            _logic = new Logic();
        //        return _logic;
        //    }
        //}

        //public void UpdateOnlineList(string _userName)
        //{
        //    OnlineUserNames.Add(_userName);
        //}
        #endregion


        /************NEW CODE************/
        private static Logic instance;
        private static object syncRoot = new Object();
        public ObservableCollection<string> Collection { get; set; }
        public ObservableCollection<string> OfflineCollection { get; set; }

        public ObservableCollection<string> ChatCollection { get; set; }


        private Logic()
        {
            Collection = new ObservableCollection<string>();
            OfflineCollection = new ObservableCollection<string>();
            ChatCollection = new ObservableCollection<string>();
        }

        public static Logic Instance
        {
            get
            {
                if (instance == null)
                    instance = new Logic();
                return instance;
            }
        }

        public void UpdateOnlineList(string _userName)
        {
            Collection.Add(_userName);
            OfflineCollection.Remove(_userName);
        }

        public void UpdateOfflineList(string _userName)
        {
            OfflineCollection.Add(_userName);
            Collection.Remove(_userName);
        }

        public void ChatUserList(string _user1, string _user2)
        {
            ChatCollection.Add(_user1);
            ChatCollection.Add(_user2);
        }


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
