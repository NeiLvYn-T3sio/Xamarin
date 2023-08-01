using NeilvynSampleBlueprint.Mobile.Domain;
using NeilvynSampleBlueprint.Mobile.Domain.Persistance;
using NeilvynSampleBlueprint.Mobile.Models;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Web;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Services.Web
{
    public class UserService : IUserService
    {
        private readonly IUserWebService _userWebService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceMapper _mapper;

        private bool _isFirstRun;

        public UserService(
            IUserWebService userWebService, 
            IUnitOfWork unitOfWork,
            IServiceMapper mapper)
        {
            _userWebService = userWebService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            _isFirstRun = true;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            if (_isFirstRun)
            {
                _isFirstRun = !_isFirstRun;
                var userDtos = await _userWebService.GetUsers();
                var users = _mapper.Map<IEnumerable<User>>(userDtos);

                _unitOfWork.Users.RemoveAll();
                await _unitOfWork.Users.InsertAsync(users);
                await _unitOfWork.Complete();

                return users;
            }
            else
            {
                return await GetUsersFromDb();
            }
        }

        public async Task<IEnumerable<User>> GetUsersFromDb()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return users;
        }
    }
}
