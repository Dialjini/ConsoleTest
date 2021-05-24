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
        public string name { get; set; }
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
        public double maxPrice { get; set; }
        public DateTime publicationDate { get; set; }
        public DateTime endDate { get; set; }
        public string address { get; set; }
        public List<Lot> lot { get; set; }
        public List<PartThree> docs { get; set; }

        public OutputData(int id, string name, string status, string provider,
            double maxPrice, DateTime publicationDate, DateTime endDate, string address,
            List<Lot> lot, List<PartThree> docs)
        {
            this.id = id;
            this.name = name;
            this.status = status;
            this.provider = provider;
            this.maxPrice = maxPrice;
            this.publicationDate = publicationDate;
            this.endDate = endDate;
            this.address = address;
            this.lot = lot;
            this.docs = docs;
        }

        public void PrintResult(OutputData data)
        {
            data.publicationDate += new TimeSpan(4, 0, 0); // � json �� ������� UTC
            data.endDate += new TimeSpan(4, 0, 0); // ����������� ��� ��� ��� � ��������� ������� � ���

            string docs = "", lots = "";
            int i = 0;
            foreach(var doc in data.docs) // ��������� ���������
            {
                i++;
                docs += String.Format("{0}. {1}\n    URL: {2}\n ", i, doc.FileName, doc.Url);
            }

            i = 0;
            foreach(var lot in data.lot) // ��������� ����
            {
                i++;
                lots += String.Format("{0}. ������������: {1}\n    ������� ���������: {2}\n    ����������:{3}\n    ���� �� �������:{4}\n ",
                                        i, lot.name, lot.unit, lot.count, lot.price);
            }

            // ������ ��� ��������� ����� ������ �� �����
            string stringData = String.Format((" ����� �������: {0}\n\n" +
                                               " ������������ �������: {1}\n\n" +
                                               " ������� ������: {2}\n\n" +
                                               " ������������ ���������: {3}\n\n" +
                                               " ���(��������� ������������ ����): {4}\n\n" +
                                               " ���� ����������(���): {5}\n\n" +
                                               " ���� ��������� ������ ������(���): {6}\n\n" +
                                               " ����� ��������: {7}\n\n" +
                                               " ������ ������� ����:\n {8}\n" +
                                               " ������ ����������:\n {9}\n"), 
                                               data.id, data.name, data.status, data.provider, data.maxPrice, data.publicationDate, data.endDate,
                                               data.address, lots, docs);
            Console.WriteLine(stringData);
        }

    }
}