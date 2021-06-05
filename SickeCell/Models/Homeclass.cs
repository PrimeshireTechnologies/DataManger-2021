using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SickeCell.Interfaces;

namespace SickeCell.Models
{
    public class Confirmation :IConfirmation
    {
        public string Email { get; set; }
        public string Confirmed { get; set; }
        public string Message { get; set; }

        public ActionResult Validation(IConfirmation confirmvalue)
        {
            throw new NotImplementedException();
        }
    }
                 
    public class SickeCellclass :ISickeCellclass
    {
        public string Clientseacrh { get; set; }
        public string Clientidx { get; set; }
        public string ClientID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Middle_Initial { get; set; }
        public string UniqueID { get; set; }
        public string DOB { get; set; }
        public string Age { get; set; }
        public string AgeGroup { get; set; }
        public string Ageat { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string Ethnicity { get; set; }
        public string Eligibility { get; set; }
        public string SSN { get; set; }
        public string CountyCode { get; set; }
        public string CountyCodeDescription { get; set; }
        public string SickleCellDiagnosis { get; set; }
        public string FullStreetAddress { get; set; }
        public string FullStreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string PMPProviderName { get; set; }
        public string Specialist { get; set; }
        public string CCUCase { get; set; }
        public string Email_Address { get; set; }
        public string ClientresideinruralID { get; set; }
        public string Nameofmother { get; set; }
        public string Address_Of_Mother { get; set; }
        public string Telephone_Of_Mother { get; set; }
        public string Nameoffather { get; set; }
        public string Address_Of_Father { get; set; }
        public string Telephone_Of_Father { get; set; }
        public string Nameofguardian { get; set; }
        public string Address_Of_Guardian { get; set; }
        public string Guardian_Telephone { get; set; }
        public string Emergency_Contact1 { get; set; }
        public string Emergency_Contact1_HomePhone { get; set; }
        public string Emergency_Contact1_CellPhone { get; set; }
        public string Emergency_Contact2 { get; set; }
        public string Emergency_Contact2_HomePhone { get; set; }
        public string Emergency_Contact2_CellPhone { get; set; }
        public string SicklecelltypeID { get; set; }
        public string Medication { get; set; }
        public string Medication2 { get; set; }
        public string Medication3 { get; set; }
        public string Medication4 { get; set; }
        public string HydroxyureaheardID { get; set; }
        public string HydroxyureatakenID { get; set; }
        public string HydroxyureacurrentlyID { get; set; }
        public string HydroxyureapasttakenID { get; set; }
        public string Hydroxyureadosage { get; set; }
        public string Hydroxyureadosageunknown { get; set; }
        public string Hydroxyureacapsulescolor { get; set; }
        public string Hydroxyureadatelasttaken { get; set; }
        public string Hydroxyureadatepickedup { get; set; }
        public string Pharma1heardID { get; set; }
        public string Pharma1takenID { get; set; }
        public string Pharma1currentlyID { get; set; }
        public string Pharma1pasttakenID { get; set; }
        public string Pharma1dosage { get; set; }
        public string Pharma1dosageunknown { get; set; }
        public string Pharma1capsulescolor { get; set; }
        public string Pharma1datelasttaken { get; set; }
        public string Pharma1datepickedup { get; set; }
        public string Pharma2heardID { get; set; }
        public string Pharma2takenID { get; set; }
        public string Pharma2currentlyID { get; set; }
        public string Pharma2pasttakenID { get; set; }
        public string Pharma2dosage { get; set; }
        public string Pharma2dosageunknown { get; set; }
        public string Pharma2capsulescolor { get; set; }
        public string Pharma2datelasttaken { get; set; }
        public string Pharma2datepickedup { get; set; }
        public string Pharma3heardID { get; set; }
        public string Pharma3takenID { get; set; }
        public string Pharma3currentlyID { get; set; }
        public string Pharma3pasttakenID { get; set; }
        public string Pharma3dosage { get; set; }
        public string Pharma3dosageunknown { get; set; }
        public string Pharma3capsulescolor { get; set; }
        public string Pharma3datelasttaken { get; set; }
        public string Pharma3datepickedup { get; set; }
        public string Globalid { get; set; }
        public string FullName { get; set; }
        public string SelectedSearch { get; set; }
        public string Comments { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string TimeStamp { get; set; }
        public DateTime Datenotescreated { get; set; }
        public int NotesID { get; set; }
        public string PhoneNumber { get; set; }
        public Decimal ZipCode2 { get; set; }
        public Decimal CountryCode2 { get; set; }
        public Decimal PhoneNumber2 { get; set; }
        public string Deceased { get; set; }

        public ActionResult Select(ISickeCellclass selected)
        {
            throw new NotImplementedException();
        }
    }

    public class SickleCelloverviewclass : ISickleCelloverviewclass
    {
        public string Clientidx { get; set; }
        public string Clientseacrh { get; set; }
        public string ClientID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Middle_Initial { get; set; }
        public string UniqueID { get; set; }
        public string DOB { get; set; }
        public string Age { get; set; }
        public string AgeGroup { get; set; }
        public string Ageat { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string Ethnicity { get; set; }
        public string Eligibility { get; set; }
        public string SSN { get; set; }
        public string CountyCode { get; set; }
        public string CountyCodeDescription { get; set; }
        public string SickleCellDiagnosis { get; set; }
        public string FullStreetAddress { get; set; }
        public string FullStreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string PMPProviderName { get; set; }
        public string Specialist { get; set; }
        public string CCUCase { get; set; }
        public string Email_Address { get; set; }
        public string ClientresideinruralID { get; set; }
        public string Nameofmother { get; set; }
        public string Address_Of_Mother { get; set; }
        public string Telephone_Of_Mother { get; set; }
        public string Nameoffather { get; set; }
        public string Address_Of_Father { get; set; }
        public string Telephone_Of_Father { get; set; }
        public string Nameofguardian { get; set; }
        public string Address_Of_Guardian { get; set; }
        public string Guardian_Telephone { get; set; }
        public string Emergency_Contact1 { get; set; }
        public string Emergency_Contact1_HomePhone { get; set; }
        public string Emergency_Contact1_CellPhone { get; set; }
        public string Emergency_Contact2 { get; set; }
        public string Emergency_Contact2_HomePhone { get; set; }
        public string Emergency_Contact2_CellPhone { get; set; }
        public string SicklecelltypeID { get; set; }
        public string Medication { get; set; }
        public string HydroxyureaheardID { get; set; }
        public string HydroxyureatakenID { get; set; }
        public string HydroxyureacurrentlyID { get; set; }
        public string HydroxyureapasttakenID { get; set; }
        public string Hydroxyureadosage { get; set; }
        public string Hydroxyureadosageunknown { get; set; }
        public string Hydroxyureacapsulescolor { get; set; }
        public string Hydroxyureadatelasttaken { get; set; }
        public string Hydroxyureadatepickedup { get; set; }
        public string Pharma1heardID { get; set; }
        public string Pharma1takenID { get; set; }
        public string Pharma1currentlyID { get; set; }
        public string Pharma1pasttakenID { get; set; }
        public string Pharma1dosage { get; set; }
        public string Pharma1dosageunknown { get; set; }
        public string Pharma1capsulescolor { get; set; }
        public string Pharma1datelasttaken { get; set; }
        public string Pharma1datepickedup { get; set; }
        public string Pharma2heardID { get; set; }
        public string Pharma2takenID { get; set; }
        public string Pharma2currentlyID { get; set; }
        public string Pharma2pasttakenID { get; set; }
        public string Pharma2dosage { get; set; }
        public string Pharma2dosageunknown { get; set; }
        public string Pharma2capsulescolor { get; set; }
        public string Pharma2datelasttaken { get; set; }
        public string Pharma2datepickedup { get; set; }
        public string Pharma3takenID { get; set; }
        public string Pharma3currentlyID { get; set; }
        public string Pharma3pasttakenID { get; set; }
        public string Pharma3dosage { get; set; }
        public string Pharma3dosageunknown { get; set; }
        public string Pharma3capsulescolor { get; set; }
        public string Pharma3datelasttaken { get; set; }
        public string Pharma3datepickedup { get; set; }
        public string Globalid { get; set; }
        public string FullName { get; set; }
        public string SelectedSearch { get; set; }
        public string Comments { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string TimeStamp { get; set; }
        public DateTime Datenotescreated { get; set; }
        public int NotesID { get; set; }
        public string PhoneNumber { get; set; }
        public string Deceased { get; set; }
    }

    public class Conversion : IConversion
    {
        public string Path { get; set; }
        public object Jresult { get; set; }
    }

    public class Savelogged : ISavelogged
    {
        public int HistologinId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public DateTime CurrentDate { get; set; }
        public string CurrentDatehis { get; set; }
        public string Logged_In { get; set; }
        public string Logged_Out { get; set; }
        public TimeZone CurrentTimeZone { get; }
        TimeZone ISavelogged.CurrentTimeZone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //public static TimeZone CurrentTimeZone { get; }
    }
}