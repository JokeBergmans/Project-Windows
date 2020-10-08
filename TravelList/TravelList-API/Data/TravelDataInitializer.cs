﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelList_API.Data
{
    public class TravelDataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public TravelDataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
            }
        }
    }
}