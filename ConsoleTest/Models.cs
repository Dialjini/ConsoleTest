using System;
using System.Collections.Generic;

namespace ConsoleTest
{
    public class Invdata
    {
        public int TradeState { get; set; }
        public string TradeStateName { get; set; }
        public string CustomerFullName { get; set; }
        public string TradeName { get; set; }
        public int Id { get; set; }
        public double InitialPrice { get; set; }
        public bool IsInitialPriceDefined { get; set; }
        public DateTime FillingApplicationEndDate { get; set; }
        public DateTime PublicationDate { get; set; }
        public int ApplicationsCount { get; set; }
        public bool IsImmediate { get; set; }
        public bool ParticipantHasApplicationsOnTrade { get; set; }
        public bool HasDealSignedOutsideEShop { get; set; }
        public DateTime LastModificationDate { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int TypeOfCategory { get; set; }
        public int OrganizationId { get; set; }
        public int SourcePlatform { get; set; }
        public string SourcePlatformName { get; set; }
    }

    public class PartOne
    {
        public int totalpages { get; set; }
        public int currpage { get; set; }
        public int totalrecords { get; set; }
        public List<Invdata> invdata { get; set; }
    }

    public class PartThree
    {
        public string Id { get; set; }
        public DateTime UploadDate { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
        public string UserFileNameFromOuterSystem { get; set; }
        public string Type { get; set; }
    }

    public class Lot
    {
        public double price { get; set; }
        public string unit { get; set; }
        public double count { get; set; }
        public string name { get; set; }
    }

    public class PartTwo
    {
        public string address { get; set; }
        public List<Lot> lot { get; set; }
        public PartTwo()
        {
            this.lot = new List<Lot>();
        }
    }


    public class OutputData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string provider { get; set; }
        public float maxPrice { get; set; }
        public DateTime publicationDate { get; set; }
        public DateTime endDate { get; set; }
        public string address { get; set; }
        public List<Lot> lot { get; set; }
        public List<Invdata> docs { get; set; }

        public OutputData(int id, string name, string status, string provider,
            float maxPrice, DateTime publicationDate, DateTime endDate, string address)
        {
            this.id = id;
            this.name = name;
            this.status = status;
            this.provider = provider;
            this.maxPrice = maxPrice;
            this.publicationDate = publicationDate;
            this.endDate = endDate;
            this.address = address;
            this.lot = new List<Lot>();
            this.docs = new List<Invdata>();
        }


    }
}