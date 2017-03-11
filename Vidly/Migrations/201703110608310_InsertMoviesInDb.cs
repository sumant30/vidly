namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertMoviesInDb : DbMigration
    {
        public override void Up()
        {
            Sql ( "Insert Into Movies(Name,Genre,ReleaseDate,DateAdded,InStock) Values('Hangover',1,'2014-01-09',GetDate(),5)" );
            Sql ( "Insert Into Movies(Name,Genre,ReleaseDate,DateAdded,InStock) Values('Die Hard',6,'2012-03-12',GetDate(),10)" );
            Sql ( "Insert Into Movies(Name,Genre,ReleaseDate,DateAdded,InStock) Values('The Terminator',6,'2010-04-12',GetDate(),3)" );
            Sql ( "Insert Into Movies(Name,Genre,ReleaseDate,DateAdded,InStock) Values('Toy Story',4,'1998-03-09',GetDate(),2)" );
        }
        
        public override void Down()
        {
        }
    }
}
