﻿using Shop.DataBase;
using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Shop.Services
{
    public class ConfigurationService
    {
        public Config GetConfig(string Key)
        {
            using (var context = new SHContext())
            {
                return context.Configurations.Find(Key);
            }
        }
    }
}
