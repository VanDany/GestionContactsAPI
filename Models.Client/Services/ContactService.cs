using Models.Client.Data;
using Models.Client.Mappers;
using Models.Client.Repositories;
using GR = Models.Global.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Models.Client.Services
{
    public class ContactService : IContactRepository
    {
        private readonly GR.IContactRepository _globalRepository;

        public ContactService(GR.IContactRepository globalRepository)
        {
            _globalRepository = globalRepository;
        }        

        public IEnumerable<Contact> Get(int userId)
        {
            return _globalRepository.Get(userId).Select(c => c.ToClient());
        }

        public Contact Get(int userId, int id)
        {
            return _globalRepository.Get(userId, id)?.ToClient();
        }

        public void Insert(Contact contact)
        {
            _globalRepository.Insert(contact.ToGlobal());
        }

        public void Update(int id, Contact contact)
        {
            _globalRepository.Update(id, contact.ToGlobal());
        }

        public void Delete(int userId, int id)
        {
            _globalRepository.Delete(userId, id);
        }
        public IEnumerable<Contact> GetByCategory(int categoryId, int userId)
        {
            return _globalRepository.GetByCategory(categoryId, userId).Select(c => c.ToClient());
        }
    }
}
