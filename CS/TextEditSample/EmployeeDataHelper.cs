using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;

namespace TextEditSample {
    #region Data

    public static class EmployeeDataHelper {
        public static Employee CreateDefaultEmployee() {
            Random r = new Random();
            Employee employee = new Employee();
            employee.FirstName = "Leah";
            employee.LastName = "Simpson";
            employee.BirthDate = new DateTime(1983, 4, 19);
            employee.Title = "Test Coordinator";
            employee.Prefix = PersonPrefix.Mrs;
            employee.Address = new Address();
            employee.Address.Line = "6755 Newlin Ave";
            employee.Address.City = "Whittier";
            employee.Address.State = StateEnum.AK;
            employee.Address.ZipCode = "90601";
            employee.HomePhone = "(562) 555-7372";
            employee.MobilePhone = "(562) 559-5830";
            employee.Email = string.Empty;
            employee.Skype = "leahs_DX_skype";
            employee.Department = EmployeeDepartment.Engineering;
            employee.Status = EmployeeStatus.Salaried;
            employee.HireDate = new DateTime(2009, 2, 14);

            return employee;
        }
    }

    public class Employee {
        public Address Address { get; set; }
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }
        public EmployeeDepartment Department { get; set; }
        public string Email { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Full Name")]
        public string FullNameBindable => string.Format("{0} {1}", FirstName, LastName);
        [Display(Name = "Hire Date")]
        public DateTime? HireDate { get; set; }
        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Mobile Phone")]
        public string MobilePhone { get; set; }
        public string PersonalProfile { get; set; }
        public Image Photo { get; set; }
        public PersonPrefix Prefix { get; set; }
        public virtual string ProbationReason { get; set; }
        public string Skype { get; set; }
        public EmployeeStatus Status { get; set; }
        public string Title { get; set; }
    }

    public enum PersonPrefix {
        Dr = 0,
        Mr = 1,
        Ms = 2,
        Miss = 3,
        Mrs = 4
    }

    public enum EmployeeStatus {
        Salaried = 0,
        Commission = 1,
        Terminated = 2,
        OnLeave = 3
    }

    public enum EmployeeDepartment {
        Sales = 1,
        Support = 2,
        Shipping = 3,
        Engineering = 4,
        HumanResources = 5,
        Management = 6,
        IT = 7
    }

    public class Address {
        public string City { get; set; }
        public double Latitude { get; set; }
        [Display(Name = "Address")]
        public string Line { get; set; }
        public double Longitude { get; set; }
        public StateEnum State { get; set; }
        [Display(Name = "Zip code")]
        public string ZipCode { get; set; }
    }

    public enum StateEnum {
        CA = 0,
        AR = 1,
        AL = 2,
        AK = 3,
        AZ = 4,
        CO = 5,
        CT = 6,
        DE = 7,
        DC = 8,
        FL = 9,
        GA = 10,
        HI = 11,
        ID = 12,
        IL = 13,
        IN = 14,
        IA = 15,
        KS = 16,
        KY = 17,
        LA = 18,
        ME = 19,
        MD = 20,
        MA = 21,
        MI = 22,
        MN = 23,
        MS = 24,
        MO = 25,
        MT = 26,
        NE = 27,
        NV = 28,
        NH = 29,
        NJ = 30,
        NM = 31,
        NY = 32,
        NC = 33,
        OH = 34,
        OK = 35,
        OR = 36,
        PA = 37,
        RI = 38,
        SC = 39,
        SD = 40,
        TN = 41,
        TX = 42,
        UT = 43,
        VT = 44,
        VA = 45,
        WA = 46,
        WV = 47,
        WI = 48,
        WY = 49,
        ND = 50
    }

    static class EditorHelpers {
        static SvgImageCollection CreatePersonPrefixImageCollection() {
            SvgImageCollection ret = new SvgImageCollection();
            ret.ImageSize = new Size(16, 16);
            ret.Add(Properties.Resources.Doctor);
            ret.Add(Properties.Resources.Mr);
            ret.Add(Properties.Resources.Ms);
            ret.Add(Properties.Resources.Miss);
            ret.Add(Properties.Resources.Mrs);
            return ret;
        }
        public static RepositoryItemImageComboBox CreatePersonPrefixImageComboBox(RepositoryItemImageComboBox edit = null, RepositoryItemCollection collection = null) {
            RepositoryItemImageComboBox ret = CreateEnumImageComboBox<PersonPrefix>(edit, collection);
            ret.SmallImages = CreatePersonPrefixImageCollection();
            if(edit == null)
                ret.GlyphAlignment = HorzAlignment.Center;
            return ret;
        }
        public static RepositoryItemImageComboBox CreateEnumImageComboBox<TEnum>(RepositoryItemImageComboBox edit = null, RepositoryItemCollection collection = null, Converter<TEnum, string> displayTextConverter = null) {
            return CreateEdit<RepositoryItemImageComboBox>(edit, collection, (e) => AddEnum(displayTextConverter, e));
        }
        public static TEdit CreateEdit<TEdit>(TEdit edit = null, RepositoryItemCollection collection = null, Func<TEdit, bool> initialize = null) where TEdit : RepositoryItem, new() {
            edit = edit ?? new TEdit();
            if(collection != null) collection.Add(edit);
            if(initialize != null)
                initialize(edit);
            return edit;
        }
        static bool AddEnum<TEnum>(Converter<TEnum, string> displayTextConverter, RepositoryItemImageComboBox e) {
            e.Items.AddEnum<TEnum>(displayTextConverter);
            return true;
        }
    }
    #endregion
}
