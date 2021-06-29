﻿using Models.Client.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Client.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<Contact> Get(int userId);
        Contact Get(int userId, int id);
        void Insert(Contact contact);
        void Update(int id, Contact contact);
        void Delete(int userId, int id);
        IEnumerable<Contact> GetByCategory(int categoryId, int userId);
    }
}
