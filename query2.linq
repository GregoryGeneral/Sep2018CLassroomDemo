<Query Kind="Program">
  <Connection>
    <ID>981f395a-3efe-4d71-9795-79fefe6cb6bc</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

void Main()
{
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
	
}

// Define other methods and classes here
public class PlaylistSummarry
{
	public string name{get;set;}
	public int trackcount{get;set;}
	public decimal cost {get;set;}
	public double? storage{get;set;}
	
}


//Create a list of albums showing its title and artist.
//Show albums with 15 or more tracks only.
//For each album shpw the songs on the album and their length

void Main()
{
	var results = from x in Albums
	where x.Tracks.Count > 24
	select new
	{
		artist = x.Artist.Name,
		title = x.Title,
		songs = from y in x.Tracks
		select new
		{
			songname = y.Name,
			length = y.Milliseconds/60000 + ";" +
			(y.Milliseconds%60000)/1000
		}
	};
results.Dump();
}
public class Song
{
public string songname{get;set;}
public double length{get;set;}

}