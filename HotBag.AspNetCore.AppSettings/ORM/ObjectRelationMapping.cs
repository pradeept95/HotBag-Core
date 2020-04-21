namespace HotBag.AspNetCore.AppSettings.ORM
{
    public class ObjectRelationMapping : IObjectRelationMapping
    {
        public DatabaseORM CurrentSelectedORM { get; set; }

        public ObjectRelationMapping()
        {
            CurrentSelectedORM = DatabaseORM.EntityFrameworkCore; // this is an default orm selected to communicate with database
        }

        /// <summary>
        /// dialet is optional and it it only applicable to the dapper
        /// if you have a database orm option to Dapper, set the database also
        /// if you don't send the dialect it default set to slqserver
        /// </summary>
        /// <param name="databaseORM"></param>
        /// <param name="dialect"></param>
        public void SetNewORM(DatabaseORM databaseORM, Dialect dialect = Dialect.SQLServer)
        {
            CurrentSelectedORM = databaseORM;
            if (this.CurrentSelectedORM == DatabaseORM.Dapper)
            {
                //TODO : //set to database provider
            }
        }
    }
}
