﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using DalApi;

namespace BlImplementation;

internal class Product :IProduct
{
    private IDal dalProduct = new Dal.DalList();
}
