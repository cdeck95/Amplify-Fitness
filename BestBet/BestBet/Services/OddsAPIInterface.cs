using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using BestBet.Models;

namespace BestBet.Services
{
    public interface OddsAPIInterface
    {
        Task<ObservableCollection<Sport>> getSports();

        Task<ObservableCollection<Match>> getUpcomingMatches(string title, string region);

        //Task<ObservableCollection<Sport>> getSpreads(string title, string region);

        Task<ObservableCollection<Match>> getOdds(string title, string region);
    }
}
