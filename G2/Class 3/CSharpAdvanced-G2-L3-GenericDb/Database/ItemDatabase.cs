using CSharpAdvanced_G2_L3_GenericDb.Entities;

namespace CSharpAdvanced_G2_L3_GenericDb.Database
{
    public class ItemDatabase : Database<Item>
    {
        public List<Item> GetItemsWithQuantity(int quantity)
        {
            return GetAll().Where(x => x.Quantity == quantity).ToList();
        }
    }
}
