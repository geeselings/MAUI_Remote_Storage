using SQLite;
using MauiRemoteStorage.Models;

namespace MauiRemoteStorage.DataAccess
{
    public class PersonData
    {
        SQLiteConnection database;

        public void InitializeDatabase()
        {
            if (database is not null)
            {
                return;
            }
            database = new SQLiteConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);
            database.CreateTable<Person>();
        }

        public List<Person> GetPeople()
        {
            InitializeDatabase();
            return database.Table<Person>().ToList();
        }

        public int SavePerson(Person person)
        {
            InitializeDatabase();
            if (person.ID != 0)
            {
                return database.Update(person);
            }
            else
            {
                return database.Insert(person);
            }
        }
    }
}
