using MoneyBook.DAL;
using MoneyBook.Entities;
using MoneyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.BLL
{
    public class TypeBLL
    {
        private TypeDAL dal = new TypeDAL();
        public void Check(IEnumerable<TypeModel> typeModels)
        {
            var add = new List<TypeEntity>();
            var del = new List<string>();
            var modify = new List<TypeEntity>();
            foreach (var model in typeModels)
            {
                if (model.IsDelete)
                {
                    del.Add(model.ID);
                    continue;
                }
                if (model.IsModify)
                {
                    modify.Add(new TypeEntity()
                    {
                        ID = Convert.ToInt32(model.ID),
                        IOFlag = model.IOFlag,
                        Name = model.Name
                    });
                    continue;
                }
                if (string.IsNullOrWhiteSpace(model.ID))
                {
                    add.Add(new TypeEntity()
                    {
                        IOFlag = model.IOFlag,
                        Name = model.Name
                    });
                    continue;
                }
            }
            dal.Delete(del);
            dal.Update(modify);
            dal.Insert(add);
        }

        public List<TypeModel> QueryAll()
        {
            return dal.QueryAll().Select(p => new TypeModel()
            {
                IOFlag = p.IOFlag,
                IsDelete = false,
                IsModify = false,
                ID = p.ID.ToString(),
                Name = p.Name
            }).ToList();
        }
    }
}
