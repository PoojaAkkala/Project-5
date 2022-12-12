using Calculator.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Calculator.Data
{
    public class OrderDataBase
    {
        SQLiteAsyncConnection Database;
        
        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<Order>();
        }

        public async Task<List<Order>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<Order>().ToListAsync();
        }

       

        public async Task<Order> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<Order>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(Order item)
        {
            await Init();
             
           
            return await Database.InsertAsync(item);
            

        }

        public async Task<int> DeleteItemAsync(Order item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
        public async Task<int> DeleteAllAsync()
        {
            await Init();
            return await Database.DeleteAllAsync<Order>();
        }
    }
}
