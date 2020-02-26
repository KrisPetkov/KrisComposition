using Domain;

namespace Application
{
    public class UserService : IUserService
    {
        private readonly IRepository _userRepository;

        public UserService(IRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetMyUser()
        {
            return _userRepository.GetUserById(1);
        }
    }
}
