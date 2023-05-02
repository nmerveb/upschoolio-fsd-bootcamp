namespace Domain.Common
{
    //Db'ye gidecek objeleri burasi uzerinden implement ederiz.
    public interface IEntityBase<TKey>
    {
       TKey Id { get; set; }
    }
}
