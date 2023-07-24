using maqa.code;
using maqa.Data.sqlserveref;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maqa.controler
{
    public class AuthorPostEntity : Idata<AuthorPost>
    {
        private DBcontext db;
        private AuthorPost _table;

        public AuthorPostEntity()
        {
            db = new DBcontext();
        }
        public int Add(AuthorPost Table)
        {
            if (db.Database.CanConnect())
            {
                db.AuthorPost.Add(Table);
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
                db.AuthorPost.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int edit(int Id, AuthorPost Table)
        {
            db = new DBcontext();
            if (db.Database.CanConnect())
            {
                db.AuthorPost.Update(Table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public AuthorPost find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.AuthorPost.Where(t => t.Id == Id).FirstOrDefault();
                
            }
            else
            {
                return null;
            }
        }

        public List<AuthorPost> Getalldata()
        {
            if (db.Database.CanConnect())
            {
                return db.AuthorPost.ToList();
                
            }
            else
            {
                return null;
            }
        }

        public List<AuthorPost> Getdatabyuser(string UserId)
        {
            if (db.Database.CanConnect())
            {
                return db.AuthorPost.Where(x=>x.UserId==UserId).ToList();

            }
            else
            {
                return null;
            }
        }

        public List<AuthorPost> Searsh(string searshItem)
        {
            if (db.Database.CanConnect())
            {
                return db.AuthorPost.Where(
                    x => x.FullName.Contains(searshItem) 
                    //|| x.UserId.ToString().Contains(searshItem)
                    || x.UserName.Contains(searshItem)
                    || x.PostCategory.Contains(searshItem)
                    || x.Posttitle.Contains(searshItem)
                    || x.PostDiscription.Contains(searshItem)
                    || x.PostImgUrl.Contains(searshItem)
                    || x.AuthorId.ToString().Contains(searshItem)
                    || x.CategoryId.ToString().Contains(searshItem)
                    || x.PostCategory.Contains(searshItem)
                    || x.AddeddDate.ToString().Contains(searshItem)

                    || x.Id.ToString().Contains(searshItem)).ToList();

            }
            else
            {
                return null;
            }
        }
    }
}

