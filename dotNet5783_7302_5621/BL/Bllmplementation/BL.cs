using BlApi;

namespace BLImplementation
{
    /// <summary>
    /// the main implementation class
    /// </summary>
    internal class BL : IBL
    {
        public IOrder Order => new BLOrder();
        public IProduct Product => new BlProduct();
        public ICart cart => new BlCart();
    }
}
