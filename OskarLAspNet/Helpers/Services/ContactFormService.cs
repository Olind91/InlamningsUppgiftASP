using OskarLAspNet.Helpers.Repos;
using OskarLAspNet.Models.Dtos;
using OskarLAspNet.Models.Entities;
using OskarLAspNet.Models.ViewModels;

namespace OskarLAspNet.Helpers.Services
{
    public class ContactFormService
    {
        private readonly ContactFormRepo _contactFormRepo;

        public ContactFormService(ContactFormRepo contactFormRepo)
        {
            _contactFormRepo = contactFormRepo;
        }

        #region Save form to DB
        public async Task<ContactFormEntry> AddAsync(ContactFormVM viewModel)
        {
            var entity = new ContactFormEntryEntity
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                Company = viewModel.Company,
                Comment = viewModel.Comment,
                RememberMe = viewModel.SaveMyData,
                DateTime = DateTime.UtcNow
            };

            var savedEntity = await _contactFormRepo.AddAsync(entity);

            var contactFormEntry = new ContactFormEntry
            {
                Id = savedEntity.Id,
                Name = savedEntity.Name,
                Email = savedEntity.Email,
                PhoneNumber = savedEntity.PhoneNumber,
                Company = savedEntity.Company,
                Comment = savedEntity.Comment,
                RememberMe = savedEntity.RememberMe,
                DateTime = savedEntity.DateTime
            };

            return contactFormEntry;
        }
        #endregion

        #region Get all comments for admin

        public async Task<IEnumerable<ContactFormEntryEntity>> GetAllAsync()
        {
            return await _contactFormRepo.GetAllAsync();
        }

        #endregion
    }
}
