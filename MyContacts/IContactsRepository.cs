using System.Data;
namespace MyContacts
{
    internal interface IContactsRepository
    {
        DataTable SelectAll();
        DataTable SelectRow(int contactID);
        DataTable search(string parameter);
        bool Insert(string name, string family, string mobile, string email, int age, string address);
        bool Update(int contactId, string name, string family, string mobile, string email, int age, string address);
        bool Delete(int contactId);
        
    
    }
}
