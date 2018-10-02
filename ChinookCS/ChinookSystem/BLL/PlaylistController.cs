﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region additional namespaces
using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel;
using Chinook.Data.POCOs;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class PlaylistController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<PlayListSummary> Playlist_GetPlaylistSummary()
        {

            using (var context = new ChinookContext())
            {
                //enter the linq query
                var results9 = from x in context.Playlists
                               where x.PlaylistTracks.Count() > 0
                               select new PlaylistSummary
                               {
                                   name = x.Name,
                                   trackcount = x.PlaylistTracks.Count(),
                                   cost = x.PlaylistTracks.Sum(plt => plt.Track.UnitPrice),
                                   storage = x.PlaylistTracks.Sum(plt => plt.Track.Bytes / 1000.0)
                               };
                //results9.Dump();

                return results9.ToList();
            }

        }


    }
}
