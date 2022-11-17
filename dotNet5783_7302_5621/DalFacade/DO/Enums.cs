

namespace DO;
/// <summary>
/// The 5 catagories our food store provides
/// </summary>
public struct Enums
{
    public enum Category 
    {
        Starters,
        MainCourses,
        SideDishes,
        Drinks,
        Deserts
    };

    public enum Starters {Salmon, BeefFilleTartar, SoupOfTheDay, crispyChickenWings }
    public enum MainCourses { RibEyeSteak, RoastedChickenBreast, GrilledBeefFillet, DuckBreast }
    public enum SideDishes { Rice,Fries, ChoppedSalad, Antipasto }
    public enum Drinks {Beer,RedWine,Water, Cocktail }
    public enum Deserts { HomemadeIceCream, HotSouffle, CoconutCrèmeBrulee, PistachioMousse }

}
