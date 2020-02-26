using Domain;

namespace Infrastructure
{
    public class Repository : IRepository
    {
        public User GetUserById(int id)
        {
            return new User()
            {
                Name = "Kristian Petkov",
                Age = 28,
                Height = 180
            };
        }
    }
}
