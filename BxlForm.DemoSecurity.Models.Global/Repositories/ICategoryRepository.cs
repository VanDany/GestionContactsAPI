﻿using BxlForm.DemoSecurity.Models.Global.Data;
using System.Collections.Generic;

namespace BxlForm.DemoSecurity.Models.Global.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Get();

        Category GetCat(int id);

        void Insert(Category category);

        void Update(int id, Category category);

        void Delete(int id);


    }
}
