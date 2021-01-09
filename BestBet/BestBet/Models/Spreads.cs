//using System;
//namespace BestBet.Models
//{
//    public class Spreads
//    {
//        public IList<double> odds { get; set; }
//        public IList<string> points { get; set; }
//    }

//    public class Odds
//    {
//        public Spreads spreads { get; set; }
//    }

//    public class Site
//    {
//        public string site_key { get; set; }
//        public string site_nice { get; set; }
//        public int last_update { get; set; }
//        public Odds odds { get; set; }
//    }

//    public class SpreadsMatch
//    {
//        public string sport_key { get; set; }
//        public string sport_nice { get; set; }
//        public IList<string> teams { get; set; }
//        public int commence_time { get; set; }
//        public string home_team { get; set; }
//        public IList<Site> sites { get; set; }
//        public int sites_count { get; set; }

//        private string bestHomeSite { get; set; }
//        private string bestAwaySite { get; set; }

//        public string BestHomeSite
//        {
//            get
//            {
//                return bestHomeSite;
//            }
//            set
//            {
//                try
//                {
//                    if (value != null)
//                    {
//                        bestHomeSite = value;
//                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BestHomeSite"));
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"crash: {ex.Message}");
//                }
//            }
//        }


//        public string BestAwaySite
//        {
//            get
//            {
//                return bestAwaySite;
//            }
//            set
//            {
//                try
//                {
//                    if (value != null)
//                    {
//                        bestAwaySite = value;
//                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BestAwaySite"));
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"crash: {ex.Message}");
//                }
//            }
//        }

//        public string awaySiteImage
//        {
//            get
//            {
//                switch (BestAwaySite)
//                {
//                    case "PointsBet (US)": return "PointsBet.png";
//                    case "William Hill (US)": return "WilliamHill.jpg";
//                    case "LowVig.ag": return "LowVig.png";
//                    case "MyBookie.ag": return "MyBookie.png";
//                    default: return $"{BestAwaySite}.png";
//                }

//            }

//            set
//            {
//                awaySiteImage = value;
//            }

//        }



//        public string homeSiteImage
//        {
//            get
//            {
//                switch (BestHomeSite)
//                {
//                    case "PointsBet (US)": return "PointsBet.png";
//                    case "William Hill (US)": return "WilliamHill.jpg";
//                    case "LowVig.ag": return "LowVig.png";
//                    case "MyBookie.ag": return "MyBookie.png";
//                    default: return $"{BestHomeSite}.png";
//                }
//            }

//            set
//            {
//                awaySiteImage = value;
//            }

//        }
//    }

//    public class AllSpreads
//    {
//        public bool success { get; set; }
//        public IList<Datum> data { get; set; }
//    }


//}
