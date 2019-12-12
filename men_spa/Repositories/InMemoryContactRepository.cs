using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using men_spa.Models;
namespace men_spa.Repositories
{
    public class InMemoryContactRepository : IContactRepository
    {
        private List<ContactModel> _contacts;
        public InMemoryContactRepository()
        {
            _contacts = new List<ContactModel>();           
        }

        async Task IContactRepository.AddNew(ContactModel contact)
        {
            //_contacts chỉ là một List bình thường không có hàm async, tuy nhiên prototype yêu cầu
            //asyc await nên tạo Task bọc lấy lệnh synchronous
            await Task.Run(() => _contacts.Add(contact));
        }

    

        Task<IEnumerable<ContactModel>> IContactRepository.GetAll()
        {
            return Task<IEnumerable<ContactModel>>.Factory.StartNew(() =>
            {
                return _contacts;
            });
        }
       /* IEnumerable<ContactModel> IContactRepository.GetAll()
        {
           return _contacts;
        }*/

Task<List<ContactModel>> IContactRepository.GetByEmail(string email)
        {
            List<ContactModel> foundContacts = new List<ContactModel>();
            foreach (var contact in _contacts)
            {
                if (contact.email.ToLower() == email)
                {
                    foundContacts.Add(contact);
                }
            }
            return Task<List<ContactModel>>.Factory.StartNew(() =>
            {
                return foundContacts;
            });
        }
    }
}
