namespace HotBag.AspNetCore.Data.EntityBase
{
    public interface IEntityBaseDto<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
