<Query Kind="Expression">
  <Connection>
    <ID>981f395a-3efe-4d71-9795-79fefe6cb6bc</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//query syntax
//from x in Albums 
//where x.ReleaseYear >= 2007 && x.ReleaseYear <= 2010
//select x


from x in Customers
where x.Country == ("USA")
orderby x.LastName, x.FirstName 
select x



from x in Customers
where x.Country == ("USA") &&  
	  x.Email.Contains("yahoo")
select new
{
	FullName = x.LastName + ", " + x.FirstName,
	Email = x.Email
}
from x in Albums
orderby x.Title
select new
{
	Title = x.Title,
	Year = x.ReleaseYear,
	ArtistName = x.Artist.Name
}

from x in Albums
where x.Artist.Name == ("U2")
orderby x.ReleaseYear
select new
{
	Title = x.Title,
	Year = x.ReleaseYear
}

