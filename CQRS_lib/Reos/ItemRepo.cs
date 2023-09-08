using CQRS_lib.Data;
using CQRS_lib.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_lib.Reos
{
    public class ItemRepo : IItemsRepo
    {
        private AppDbContext _db;

        public ItemRepo(AppDbContext appDb)
        {
            _db = appDb;
        }

        public Items GetItem(int id)
        {
            var item = _db.Items.Where(x => x.Id == id).FirstOrDefault();
            return item ?? new();
        }

        public List<Items> GetItems()
        {
            return _db.Items.ToList();
        }

        public int InsertItem(Items item)
        {
            _db.Items.Add(item);
            return _db.SaveChanges();
        }

        public int UpdateItem(Items item)
        {
            try
            {
                _db.Items.Attach(item);
                _db.Entry(item).State = EntityState.Modified;
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteItem(int id)
        {
            var item = _db.Items.Where(x => x.Id == id).FirstOrDefault();
            if (item != null) _db.Items.Remove(item);
            return _db.SaveChanges();
        }
    }
}