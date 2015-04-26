using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HousingHack.Handler.Entity;

namespace HousingHack.Handler.Handlers
{
    public class UserHandler
    {
        private HousingHackDb _db;

        public UserHandler()
        {
            _db = new HousingHackDb();
        }
        public int AddUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            var query = from r in _db.Users
                        orderby r.Id descending
                        select r;
            if (query.Any())
            {
                return query.First().Id;
            }
            return 0;
        }

        public void UpdateUser(User user)
        {
            _db.Users.AddOrUpdate(user);
            _db.SaveChanges();
        }

        public bool CheckIfEmailExists(string email)
        {
            var query = from r in _db.Users
                        where r.Email == email
                        select r;
            if (query.Any())
            {
                return true;
            }
            return false;
        }

        public User RetrieveUser(int id)
        {
            var query = from r in _db.Users
                        where r.Id == id
                        select r;
            if (query.Any())
            {
                var currentUser = query.FirstOrDefault();
                if (currentUser != null)
                {
                    return currentUser;
                }
            }
            return null;
        }

        public User CheckUser(string email, string password)
        {
            var query = from r in _db.Users
                        where r.Email == email && r.Password == password
                        select r;
            if (query.Any())
            {
                var currentUser = query.FirstOrDefault();
                if (currentUser != null)
                {
                    return currentUser;
                }
            }
            return null;
        }

        /*public int AddContact(Contact contact)
        {
            _db.Contacts.Add(contact);
            _db.SaveChanges();
            var query = from r in _db.Contacts
                        orderby r.Id descending 
                        select r;
            if (query.Any())
            {
                return query.First().Id;
            }
            return 0;
        }

        public List<Contact> RetrieveContacts(string contactsString)
        {
            if (!String.IsNullOrEmpty(contactsString))
            {
                var contactIdsString = contactsString.Split(',');
                var contactIds = contactIdsString.Select(int.Parse).ToList();
                return contactIds.Select(RetrieveContact).ToList();
            }
            return new List<Contact>();
        }

        public List<Contact> RetrieveAllContacts(int id=1)
        {
            var query = from r in _db.Contacts
                        select r;
            if (query.Any())
            {
                List<Contact> elements = query.ToList();
                return elements;
            }
            return null;
        }
        public List<Report> RetrieveReports(int id)
        {
            var query = from r in _db.Reports
                        where r.ContactId == id
                        select r;
            if (query.Any())
            {
                List<Report> elements = query.ToList();
                return elements;
            }
            return null;
        }

        public Contact RetrieveContact(int id)
        {
            var query = from r in _db.Contacts
                        where r.Id == id
                        select r;
            if (query.Any())
            {
                var currentContact = query.FirstOrDefault();
                if (currentContact != null)
                {
                    return currentContact;
                }
            }
            return null;
        }

        public void AddToContact(int id, int newContactId)
        {
            var requestingContact = RetrieveContact(id);
            if (String.IsNullOrEmpty(requestingContact.Contacts))
            {
                requestingContact.Contacts += newContactId;
            }
            else
            {
                requestingContact.Contacts += "," + newContactId;
            }
            _db.Contacts.AddOrUpdate(requestingContact);
            _db.SaveChanges();
        }

        public void DeleteFromContact(int id, int deleteId)
        {
            var contact = RetrieveContact(id);
            var contactIdsString = contact.Contacts.Split(',');
            var newContactIds = contactIdsString.Where(contactId => deleteId.ToString(CultureInfo.InvariantCulture) != contactId).ToList();
            var sb = new StringBuilder("");
            var first = true;
            foreach (var newContactId in newContactIds)
            {
                if (!first)
                {
                    sb.Append(",");
                }
                else
                {
                    first = false;
                }
                sb.Append(newContactId);
            }
            contact.Contacts = sb.ToString();
            _db.Contacts.AddOrUpdate(contact);
            _db.SaveChanges();
        }

        public List<ContactDropDown> RetrieveDropDownContacts()
        {
            var allContacts = RetrieveAllContacts();
            return allContacts.Select(contact => new ContactDropDown
            {
                Id = contact.Id, Name = contact.Name
            }).ToList();
        }

        public List<int> RetrieveContactIdsForFilter(int id)
        {
            var contact = RetrieveContact(id);
            if (!String.IsNullOrEmpty(contact.Contacts))
            {
                var contactIdsString = contact.Contacts.Split(',');
                return contactIdsString.Select(int.Parse).ToList();
            }
            return new List<int>();
        }

        public void PullContacts(int id)
        {
            var contact = RetrieveContact(id);
            contact.Contacts = "";
            _db.Contacts.AddOrUpdate(contact);
            _db.SaveChanges();
        }*/
    }
}
