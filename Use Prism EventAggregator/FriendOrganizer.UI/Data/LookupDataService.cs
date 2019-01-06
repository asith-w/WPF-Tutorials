﻿using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
  public class LookupDataService : IFriendLookupDataService
  {
    private Func<FriendOrganizerDbContext> _contextCreator;

    public LookupDataService(Func<FriendOrganizerDbContext> contextCreator)
    {
      _contextCreator = contextCreator;
    }

    public async Task<IEnumerable<LookupItem>> GetFriendLookupAsync()
    {
      using (var ctx = _contextCreator())
      {
        return await ctx.Friends.AsNoTracking()
          .Select(f =>
          new LookupItem
          {
            Id = f.Id,
            DisplayMember = f.FirstName + " " + f.LastName
          })
          .ToListAsync();
      }
    }
  }
}
