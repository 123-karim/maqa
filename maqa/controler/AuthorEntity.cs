using maqa.code;
using maqa.Data.sqlserveref;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maqa.controler
{
    public class AuthorEntity : Idata<Author>
    {
        private DBcontext db;
        private Author _table;

        public AuthorEntity()
        {
            db = new DBcontext();
        }
        public int Add(Author Table)
        {
            if (db.Database.CanConnect())
            {
                db.Author.Add(Table);
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
                db.Author.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int edit(int Id, Author Table)
        {
            db = new DBcontext();
            if (db.Database.CanConnect())
            {
                db.Author.Update(Table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Author find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.Author.Where(t => t.Id == Id).FirstOrDefault();
                
            }
            else
            {
                return null;
            }
        }

        public List<Author> Getalldata()
        {
            if (db.Database.CanConnect())
            {
                return db.Author.ToList();
                
            }
            else
            {
                return null;
            }
        }

        public List<Author> Getdatabyuser(String UserId)
        {
            throw new NotImplementedException();
        }

        public List<Author> Searsh(string searshItem)
        {
            if (db.Database.CanConnect())
            {
                return db.Author.Where(
                    x => x.FullName.Contains(searshItem) 
                    || x.UserId.ToString().Contains(searshItem)
                    || x.Bio.Contains(searshItem)
                    || x.UserName.Contains(searshItem)
                    || x.Facebook.Contains(searshItem)
                    || x.Instgram.Contains(searshItem)
                    || x.Twitter.Contains(searshItem)
                    || x.Id.ToString().Contains(searshItem)).ToList();

            }
            else
            {
                return null;
            }
        }
    }
}

