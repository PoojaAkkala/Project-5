using Calculator.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Data
{
    public class BillDataBase
    {
        SQLiteAsyncConnection Database;

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(BillConstants.DatabasePath, BillConstants.Flags);
            var result = await Database.CreateTableAsync<BillModel>();
        }

        public async Task<List<BillModel>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<BillModel>().ToListAsync();
        }



        

        public async Task<int> SaveItemAsync(BillModel item)
        {
            await Init();


            return await Database.InsertAsync(item);


        }

        public async Task<int> DeleteItemAsync(BillModel item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
        public async Task<int> DeleteAllAsync()
        {
            await Init();
            return await Database.DeleteAllAsync<BillModel>();
        }
    
}
}
