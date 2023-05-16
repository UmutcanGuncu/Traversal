using System;

namespace SignalRApi.DAL
{
    public enum ECity
    {
        Tunceli=1,
        Adana=2,
        Bursa=3,
        Kırşehir=4,
        İzmir=5,
        Ankara=6 

    }
    public class Visitor
    {
        public int VisitorId { get;set; }
        public ECity City { get;set; }
        public int CityVisitCount { get;set; }
        public DateTime VisitDate { get;set; }

    }
}
