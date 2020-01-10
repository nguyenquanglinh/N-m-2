namespace QuanLyPhongNet
{
    public class User
    {
        public User()
        {
            this.Name = "";
            this.Pass = "";
        }

        public User(string username, string pass) : this()
        {
            this.Pass = username;
            this.Pass = pass;
        }

        public string Pass { get; set; }
        public string Name { get; set; }

        public override int GetHashCode()
        {
            return Pass.GetHashCode() ^ Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        public override string ToString()
        {
            return "User:\n" + "Name: " + Name + ", Pass: " + Pass;
        }
    }


    public class Admin : User
    {
        public Admin(string username, string pass) : base(username, pass)
        {
           
        }
        public bool CheckUser()
        {
            //kiểm tra tên đăng nhập addmin có đúng không
            return false;
        }
        public Admin(User user):base(user.Name,user.Pass)
        {

        }
    }
}