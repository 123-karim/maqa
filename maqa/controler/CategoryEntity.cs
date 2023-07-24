using maqa.code;
using maqa.Data.sqlserveref;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maqa.controler
{
    public class CategoryEntity :Idata<Category>
    {
        private DBcontext db;
        private Category _table;

        public CategoryEntity()
        {
            db = new DBcontext();
        }
        public int Add(Category Table)
        {
            if (db.Database.CanConnect())
            {
                db.Category.Add(Table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Delete(int Id)
        {
            if (db.Database.CanConnect())
            {
                _table = find(Id);
                db.Category.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int edit(int Id, Category Table)
        {
            db = new DBcontext();
            if (db.Database.CanConnect())
            {
                db.Category.Update(Table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Category find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.Category.Where(t => t.Id == Id).FirstOrDefault();
                
            }
            else
            {
                return null;
            }
        }

        public List<Category> Getalldata()
        {
            if (db.Database.CanConnect())
            {
                return db.Category.ToList();
                
            }
            else
            {
                return null;
            }
        }

        public List<Category> Getdatabyuser(String UserId)
        {
            throw new NotImplementedException();
        }

        public List<Category> Searsh(string searshItem)
        {
            if (db.Database.CanConnect())
            {
                return db.Category.Where(x => x.Name.Contains(searshItem) || x.Id.ToString().Contains(searshItem)).ToList();

            }
            else
            {
                return null;
            }
        }
    }
}

