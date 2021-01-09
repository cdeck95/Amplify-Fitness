using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using BestBet.Services;
using BestBet.Models;
using System.Windows.Input;
using System.Threading.Tasks;

namespace BestBet.ViewModels
{
    public class SportsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        OddsAPIInterface _rest = DependencyService.Get<OddsAPIInterface>();

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsRefreshing"));
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;

                    await getUpcomingMatches();

                    IsRefreshing = false;
                });
            }
        }

        private ObservableCollection<Sport> allSports;

        public ObservableCollection<Sport> AllSports
        {
            get
            {
                return allSports;
            }
            set
            {
                try
                {
                    allSports = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AllSports"));
                } catch (Exception ex)
                {
                    Console.WriteLine($"crash: {ex.Message}");
                }
            }
        }

        private List<Match> allMatches;

        public List<Match> AllMatches
        {
            get
            {
                return allMatches;
            }
            set
            {
                try
                {
                    allMatches = value;
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AllMatches"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"crash: {ex.Message}");
                }
            }
        }

        public SportsViewModel() 
        {
            getSports();
            getUpcomingMatches();
        }

        public SportsViewModel(bool refreshUpcomingMatches)
        {
           
        }

        public async void getSports()
        {
            try
            {
                //Console.WriteLine("about to invoke");
                var result = await _rest.getSports();

                allSports = result;
                
                //Console.WriteLine("invoked api");
             
            } catch (Exception ex)
            {
                Console.WriteLine($"crash: {ex.Message}");
            }
        }

        public async Task<bool> getUpcomingMatches()
        {
            try
            {
                Console.WriteLine("about to invoke upcoming matches");
                var result = await _rest.getUpcomingMatches(App.sport, App.region);

                List<Match> tempMatches = new List<Match>();
                foreach (var match in result)
                {
                    tempMatches.Add(match);
                }

                foreach (var match in tempMatches)
                {
                    List<Book> currentBooks = await App.Database.GetSelectedBooksAsync();
                    List<string> bookNames = new List<string>();

                    foreach (var book in currentBooks)
                    {
                        bookNames.Add(book.name);
                    }

                    match.sites.RemoveAll(site => !(bookNames.Contains(site.site_nice)));

                }
                //Console.WriteLine($"{tempMatches.Count}");
                allMatches = tempMatches;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AllMatches"));

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"crash: {ex.Message}");
                return false;
            }
        }
    }
}
