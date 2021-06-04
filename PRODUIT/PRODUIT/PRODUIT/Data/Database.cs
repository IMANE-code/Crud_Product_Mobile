using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PRODUIT.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Produit>().Wait();
        }

        public Task<List<Produit>> GetProductAsync()
        {
            return _database.Table<Produit>().ToListAsync();
        }

        public Task<int> SavePersonAsync(Produit produit)
        {
            if (produit.Id !=0)
            {
                return _database.UpdateAsync(produit);
            }
            else
            {
                return _database.InsertAsync(produit);
            }
        }

        public Task<int> DeleteItemAsync(Produit produit)
        {
            return _database.DeleteAsync(produit);
        }

        public Task<Produit> GetItemAsync(int Id)
        {
            return _database.Table<Produit>().Where(i => i.Id == Id).FirstOrDefaultAsync();
        }

    }
}
