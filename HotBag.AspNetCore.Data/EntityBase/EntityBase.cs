using System.ComponentModel.DataAnnotations;

namespace HotBag.AspNetCore.Data.EntityBase
{
    public class EntityBase<TPrimaryKey> : IEntityBase<TPrimaryKey>
    {
        #region Primary key of the table
        [Key]
        //[BsonId]
        public TPrimaryKey Id { get; set; }
        #endregion

        //#region create audit entities
        //[IgnoreUpdate]
        //[BsonDateTimeOptions]
        //[IgnoreMap]
        //[AutoFill(AutoFillProperty.CurrentDate)]
        //public DateTime CreatedDateTime { get; set; } 
        //[IgnoreUpdate]
        //[IgnoreMap]
        //[ForeignKey("CreatedByUserEntity")]
        //public Guid? CreatedByUser { get; set; }
        //[IgnoreMap]
        //public virtual HotBagUser CreatedByUserEntity { get; set; }
        //#endregion

        //#region update audit entities
        //[IgnoreInsert]
        //[BsonDateTimeOptions]
        //[IgnoreMap]
        //[AutoFill(AutoFillProperty.CurrentDate)]
        //public DateTime? ModifiedDateTime { get; set; } 

        //[IgnoreInsert] 
        //[ForeignKey("UpdatedByUserEntity")]
        //[IgnoreMap]
        //public Guid? UpdatedByUser { get; set; }
        //[IgnoreMap]
        //public virtual HotBagUser UpdatedByUserEntity { get; set; }
        //#endregion
    }
}
