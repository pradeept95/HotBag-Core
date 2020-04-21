namespace HotBag.AspNetCore.Data.EntityBase
{
    public interface IEntityBase<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
