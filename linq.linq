<Query Kind="Statements">
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

//using the statement Language environment, we code complete
//c# statements which include the linq query and a receiving variable.
//The statements will end with the semi-colon (;)
//To see the contents of the receiving variable you will use the 
//LinqPad command .Dump()
//.Dump() is NOT a c# method. It is a LinqPad method


var results = from x in Albums
				where x.Artist.Name == ("U2")
				orderby x.ReleaseYear
				select new
				{
					Title = x.Title,
					Year = x.ReleaseYear
				};
				
results.Dump();




//ternary operator
//condition(s) ? true value : false value 
var results = from x in Albums
				orderby x.ReleaseLabel
				select new
				{
					title = x.Title,
					label = x.ReleaseLabel == null ? "unknown" : 
								x.ReleaseLabel
				};
results.Dump();


//a list of albums show the title and decade of release.

var results3 = from x in Albums
select new
				{
					title = x.Title,
					Decades = x.ReleaseYear >= 1970 && x.ReleaseYear < 1980 ? "70s" : 
					(x.ReleaseYear >= 1980 && x.ReleaseYear < 1990 ? "80s" :
					(x.ReleaseYear >= 1990 && x.ReleaseYear < 2000 ? "90s" :
					"Modern"))
					
					
				};
results3.Dump();


//situation: I need a value from a queryt that will be used in another future query
//create a list of tracks showing the name and whether the track is longer than the track average
//length or shorter of the average.
var resultaverage = (from x in Tracks
					select x.Milliseconds).Average();
var results4 = from x in Tracks
select new
				{
				Song=x.Name,
				Time = x.Milliseconds,
				Length = x.Milliseconds > resultaverage ? "Long" :
				(x.Milliseconds < resultaverage ? "Short" : "Average")
				};
resultaverage.Dump();
results4.Dump();


//Aggregates
//.Sum(),.Count(),Min(),Max(),.Average()
//aggregates must be done against a collection (0, 1 or more rows)

//List all albums with Title, Artist Name, and the number of tracks on that album
var results5 = from x in Albums
select new
				{
				title = x.title,
				artist = x.Artist.Name,
				trackcount = x.Tracks.Count()
				};
results5.Dump();

//Create a list of artists with their album counts
//ordered by descending

var results6 = from x in Artists
				orderby x.Albums.Count()
				select new
				{
					artist = x.Name,
					albumcount = x.Albums.count()
					
				}
results6.Dump();


//find the maximum number of albums for all artist
//what is the most albums
var results7 = (from x in Artists
	select x.Albums.Count()).Max();
//who is that artist 
var results7b = from x in Artists
				where x.Albums.Count() == results7
				select x;
				
var results7c = from x in Artists
				where x.Albums.Count() ==(from y in Artists
	select y.Albums.Count()).Max()
				select x;
	results7c.Dump();


//produce a lits of albums which have tracks showing their 
//title, artist, number of tracks on album, total price 
//of all tracks, longest shortest and average track

var results8 = from x in Albums
	where x.Tracks.Count() > 0
	select new
				{
					title = x.Title,
					artist = x.Artist.Name,
					numberoftracks = (from y in x.Tracks select y).Count()
					,ethodnumberoftracks = x.Tracks.Count(),
					cost=x.Tracks.Sum(y => y.UnitPrice),
					longest = x.Tracks.Max(y => y.Milliseconds),
					shortest = x.Tracks.Min(y => y.Milliseconds),
					min = x.Tracks.Average(y => y.Milliseconds),
				
			};
results8.Dump();

//list all the Playlists which have at least a track.
//Show the playlist name, number of playlist tracsks,
//the cost of the playlist nad the total storage size for the play lisy

var results9 = from x in Playlists
	where x.PlaylistTracks.Count() > 0
	select new 
				{
					name = x.Name,
					trackcount = x.PlaylistTracks.Count(),
					cost = x.PlaylistTracks.Sum(plt => plt.Track.UnitPrice),
					storage = x.PlaylistTracks.Sum(plt => plt.Track.Bytes/1000.0)
				};
results9.Dump();



	
	
	
	
	
