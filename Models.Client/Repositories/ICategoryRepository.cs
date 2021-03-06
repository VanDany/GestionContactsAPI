using Models.Client.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Client.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Get();
        void Insert(Category category);

        void Update(int id, Category category);

        void Delete(int id);

        Category GetCat(int id);
    }
}
