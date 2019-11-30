﻿using System;
using System.Collections.Generic;

namespace Recitopia_LastChance.Models
{
    public partial class View_All_Ingredient_Nutrients
    {
        public long? NID { get; set; }
        public int Id { get; set; }
        public int Customer_Id { get; set; }
        public int Ingred_Id { get; set; }
        public int Nutrition_Item_Id { get; set; }
        public decimal Nut_per_100_grams { get; set; }
        public string Ingred_name { get; set; }
        public string Nutrition_Item { get; set; }
    }
}
