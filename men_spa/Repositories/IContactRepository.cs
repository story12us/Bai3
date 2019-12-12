using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using men_spa.Models;

namespace men_spa.Repositories
{
    public interface IContactRepository
    {
        public Task AddNew(ContactModel contact);
        public Task<IEnumerable<ContactModel>> GetAll();
        public Task<List<ContactModel>> GetByEmail(string email);        
    }
}
