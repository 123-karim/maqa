using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maqa.code
{
   public interface Idata<Table>
    {
        List<Table> Getalldata();
        List<Table> Getdatabyuser(String UserId);
        List<Table> Searsh(string searshItem);
        Table find(int Id);
        int Add(Table Table);
        int edit(int Id ,Table Table);
        int Delete(int Id);

    }
}
