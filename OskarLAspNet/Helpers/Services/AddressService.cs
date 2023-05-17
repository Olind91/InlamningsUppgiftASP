using OskarLAspNet.Helpers.Repos;
using OskarLAspNet.Models.Entities;
using OskarLAspNet.Models.Identity;

namespace OskarLAspNet.Helpers.Services
{
    public class AddressService
    {
        private readonly AddressRepository _addressRepo;
        private readonly UserAddressRepository _userAddressRepository;

        public AddressService(AddressRepository addressRepo, UserAddressRepository userAddressRepository)
        {
            _addressRepo = addressRepo;
            _userAddressRepository = userAddressRepository;
        }

        public async Task<AddressEntity> GetOrCreateAsync(AddressEntity addressEntity)
        {
            var entity = await _addressRepo.GetAsync(x =>
            x.StreetName == addressEntity.StreetName &&
            x.City == addressEntity.City &&
            x.PostalCode == addressEntity.PostalCode);


            entity ??= await _addressRepo.AddAsync(addressEntity);
            return entity!;

        }

        public async Task AddAddressAsync(AppUser user, AddressEntity addressEntity)
        {
            await _userAddressRepository.AddAsync(new UserAddressEntity
            {
                UserId = user.Id,
                AddressId = addressEntity.Id,
            });
        }
    }
}
