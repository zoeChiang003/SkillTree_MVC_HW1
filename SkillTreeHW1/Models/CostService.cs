using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGrease.Css.Extensions;

namespace SkillTreeHW1.Models
{
    public class CostService
    {

        private Random _random;
        public CostService()
        {
            _random = new Random();
        }
        public List<AccountModel> GenCost(int count)
        {
            var typeList = new List<string>{ "支出","收入"};
            
            var accountListModel = new List<AccountModel>();

            for (int i = 0; i < count; i++)
            {
                accountListModel.Add(new AccountModel()
                {
                    CostType = typeList[_random.Next(0, typeList.Count)],
                    Cost = _random.Next(0, 10000).ToString("N0"),
                    CostTime = RandomDay()
                });
            }
            accountListModel.Sort((x, y) => DateTime.Compare(x.CostTime, y.CostTime));
            return accountListModel;
        }

        private DateTime RandomDay()
        {
            DateTime start = new DateTime(2018, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(_random.Next(range));
        }

        public List<AccountModel> GetCostFromDb()
        {
            var accountListModel = new List<AccountModel>();
            var accountRepository = new AccountRepository();
            var accountBooks = accountRepository.GetAccountBooks();

            foreach (var accountBook in accountBooks)
            {
                accountListModel.Add(new AccountModel()
                {
                    CostType = accountBook.Categoryyy.ToString(),
                    Cost = accountBook.Amounttt.ToString(),
                    CostTime = accountBook.Dateee
                });
            }
            return accountListModel;
        }
    }
}