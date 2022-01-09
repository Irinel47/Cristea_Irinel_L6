using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cristea_Irinel_L6.Models;

namespace Cristea_Irinel_L6.Data
{
    public class ShoppingListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ShoppingListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Models.ShopList>().Wait();
        }
        public Task<List<Models.ShopList>> GetShopListsAsync()
        {
            return _database.Table<Models.ShopList>().ToListAsync();
        }
        public Task<Models.ShopList> GetShopListAsync(int id)
        {
            return _database.Table<Models.ShopList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveShopListAsync(Models.ShopList slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteShopListAsync(Models.ShopList slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}
