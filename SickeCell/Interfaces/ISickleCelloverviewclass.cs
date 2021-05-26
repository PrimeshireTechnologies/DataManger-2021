using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SickeCell.Interfaces
{
    public interface ISickleCelloverviewclass
    {
        string Clientidx { get; set; }
        string Clientseacrh { get; set; }
        string ClientID { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        string Middle_Initial { get; set; }
        string UniqueID { get; set; }
        string DOB { get; set; }
        string Age { get; set; }
        string AgeGroup { get; set; }
        string Ageat { get; set; }
        string Gender { get; set; }
        string Race { get; set; }
        string Ethnicity { get; set; }
        string Eligibility { get; set; }
        string SSN { get; set; }
        string CountyCode { get; set; }
        string CountyCodeDescription { get; set; }
        string SickleCellDiagnosis { get; set; }
        string FullStreetAddress { get; set; }
        string FullStreetAddress2 { get; set; }
        string City { get; set; }
        string State { get; set; }
        string ZipCode { get; set; }
        string HomePhone { get; set; }
        string WorkPhone { get; set; }
        string PMPProviderName { get; set; }
        string Specialist { get; set; }
        string CCUCase { get; set; }
        string Email_Address { get; set; }
        string ClientresideinruralID { get; set; }
        string Nameofmother { get; set; }
        string Address_Of_Mother { get; set; }
        string Telephone_Of_Mother { get; set; }
        string Nameoffather { get; set; }
        string Address_Of_Father { get; set; }
        string Telephone_Of_Father { get; set; }
        string Nameofguardian { get; set; }
        string Address_Of_Guardian { get; set; }
        string Guardian_Telephone { get; set; }
        string Emergency_Contact1 { get; set; }
        string Emergency_Contact1_HomePhone { get; set; }
        string Emergency_Contact1_CellPhone { get; set; }
        string Emergency_Contact2 { get; set; }
        string Emergency_Contact2_HomePhone { get; set; }
        string Emergency_Contact2_CellPhone { get; set; }
        string SicklecelltypeID { get; set; }
        string Medication { get; set; }
        string HydroxyureaheardID { get; set; }
        string HydroxyureatakenID { get; set; }
        string HydroxyureacurrentlyID { get; set; }
        string HydroxyureapasttakenID { get; set; }
        string Hydroxyureadosage { get; set; }
        string Hydroxyureadosageunknown { get; set; }
        string Hydroxyureacapsulescolor { get; set; }
        string Hydroxyureadatelasttaken { get; set; }
        string Hydroxyureadatepickedup { get; set; }
        string Pharma1heardID { get; set; }
        string Pharma1takenID { get; set; }
        string Pharma1currentlyID { get; set; }
        string Pharma1pasttakenID { get; set; }
        string Pharma1dosage { get; set; }
        string Pharma1dosageunknown { get; set; }
        string Pharma1capsulescolor { get; set; }
        string Pharma1datelasttaken { get; set; }
        string Pharma1datepickedup { get; set; }
        string Pharma2heardID { get; set; }
        string Pharma2takenID { get; set; }
        string Pharma2currentlyID { get; set; }
        string Pharma2pasttakenID { get; set; }
        string Pharma2dosage { get; set; }
        string Pharma2dosageunknown { get; set; }
        string Pharma2capsulescolor { get; set; }
        string Pharma2datelasttaken { get; set; }
        string Pharma2datepickedup { get; set; }
        string Pharma3takenID { get; set; }
        string Pharma3currentlyID { get; set; }
        string Pharma3pasttakenID { get; set; }
        string Pharma3dosage { get; set; }
        string Pharma3dosageunknown { get; set; }
        string Pharma3capsulescolor { get; set; }
        string Pharma3datelasttaken { get; set; }
        string Pharma3datepickedup { get; set; }
        string Globalid { get; set; }
        string FullName { get; set; }
        string SelectedSearch { get; set; }
        string Comments { get; set; }
        string UserFirstName { get; set; }
        string UserLastName { get; set; }
        string TimeStamp { get; set; }
        DateTime Datenotescreated { get; set; }
        int NotesID { get; set; }
        string PhoneNumber { get; set; }
        string Deceased { get; set; }
    }
}
