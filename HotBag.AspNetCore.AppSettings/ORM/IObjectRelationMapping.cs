namespace HotBag.AspNetCore.AppSettings.ORM
{
    public interface IObjectRelationMapping
    {
        DatabaseORM CurrentSelectedORM { get; set; }
        void SetNewORM(DatabaseORM databaseORM, Dialect dialect = Dialect.SQLServer);
    }
}
