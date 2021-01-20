using System.Collections.Generic;
using Tam.webapp.Models;

namespace Tam.webapp.Services.PlayLists
{
    interface IPlayListsService
    {
        PlayList GetPlayList(long id);
    }
}
