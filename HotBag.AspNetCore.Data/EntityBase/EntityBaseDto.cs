namespace HotBag.AspNetCore.Data.EntityBase
{
    public class EntityBaseDto<TPrimaryKey> : IEntityBaseDto<TPrimaryKey>

    {
        #region Primary key of the table 
        public TPrimaryKey Id { get; set; }
        #endregion

        //#region create audit entities 
        //public DateTime CreatedDateTime { get; set; } 
        //public Guid? CreatedByUser { get; set; } 
        //#endregion

        //#region update audit entities 
        //public DateTime? ModifiedDateTime { get; set; } 
        //public Guid? UpdatedByUser { get; set; }  
        //#endregion
    }
}
