using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SkillTreeHW1.Models
{
    public class AccountRepository
    {
        public List<AccountBook> GetAccountBooks()
        {
            var  db = new SkillTreeHomeworkEntities();
            return db.AccountBook.ToList();
        }
}
}