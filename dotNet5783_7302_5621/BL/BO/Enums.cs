using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BO;
/// <summary>
/// the all BO enums
/// </summary>
public class Enums
{
    public enum category { Starters, MainCourses, SideDishes, Drinks, Deserts }
    public enum starters { Salmon, BeefFilleTartar, SoupOfTheDay, crispyChickenWings }
    public enum mainCourses { RibEyeSteak, RoastedChickenBreast, GrilledBeefFillet, DuckBreast }
    public enum sideDishes { Rice, Fries, ChoppedSalad, Antipasto }
    public enum drinks { Beer, RedWine, Water, Cocktail }
    public enum deserts { HomemadeIceCream, HotSouffle, CoconutCrèmeBrulee, PistachioMousse }
    public enum customerName { Miriam, Pazit, Yehudit, Shira, Yael, Tehila, Tamar, Michal, Yosef, Beni }
    public enum customerAdress { Jerusalem, TelAviv, Ashdod, Netania, BeerSheva, Eilat }
    public enum orderStatus {Confirmed, Shipped, Supplied}
}
