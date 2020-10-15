Imports System
Imports System.ComponentModel.DataAnnotations
Imports System.Drawing
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Repository

Namespace TextEditSample
    #Region "Data"

    Public NotInheritable Class EmployeeDataHelper

        Private Sub New()
        End Sub

        Public Shared Function CreateDefaultEmployee() As Employee
            Dim r As New Random()
            Dim employee As New Employee()
            employee.FirstName = "Leah"
            employee.LastName = "Simpson"
            employee.BirthDate = New Date(1983, 4, 19)
            employee.Title = "Test Coordinator"
            employee.Prefix = PersonPrefix.Mrs
            employee.Address = New Address()
            employee.Address.Line = "6755 Newlin Ave"
            employee.Address.City = "Whittier"
            employee.Address.State = StateEnum.AK
            employee.Address.ZipCode = "90601"
            employee.HomePhone = "(562) 555-7372"
            employee.MobilePhone = "(562) 559-5830"
            employee.Email = ""
            employee.Skype = "leahs_DX_skype"
            employee.Department = EmployeeDepartment.Engineering
            employee.Status = EmployeeStatus.Salaried
            employee.HireDate = New Date(2009, 2, 14)

            Return employee
        End Function
    End Class

    Public Class Employee
        Public Property Address() As Address
        <Display(Name := "Birth Date")>
        Public Property BirthDate() As Date?
        Public Property Department() As EmployeeDepartment
        Public Property Email() As String
        <Display(Name := "First Name")>
        Public Property FirstName() As String
        <Display(Name := "Full Name")>
        Public ReadOnly Property FullNameBindable As String
            Get
                Return FirstName & " " & LastName
            End Get
        End Property
        <Display(Name := "Hire Date")>
        Public Property HireDate() As Date?
        <Display(Name := "Home Phone")>
        Public Property HomePhone() As String
        <Display(Name := "Last Name")>
        Public Property LastName() As String
        <Display(Name := "Mobile Phone")>
        Public Property MobilePhone() As String
        Public Property PersonalProfile() As String
        Public Property Photo() As Image
        Public Property Prefix() As PersonPrefix
        Public Overridable Property ProbationReason() As String
        Public Property Skype() As String
        Public Property Status() As EmployeeStatus
        Public Property Title() As String
    End Class

    Public Enum PersonPrefix
        Dr = 0
        Mr = 1
        Ms = 2
        Miss = 3
        Mrs = 4
    End Enum

    Public Enum EmployeeStatus
        Salaried = 0
        Commission = 1
        Terminated = 2
        OnLeave = 3
    End Enum

    Public Enum EmployeeDepartment
        Sales = 1
        Support = 2
        Shipping = 3
        Engineering = 4
        HumanResources = 5
        Management = 6
        IT = 7
    End Enum

    Public Class Address
        Public Property City() As String
        Public Property Latitude() As Double
        <Display(Name := "Address")>
        Public Property Line() As String
        Public Property Longitude() As Double
        Public Property State() As StateEnum
        <Display(Name := "Zip code")>
        Public Property ZipCode() As String
    End Class

    Public Enum StateEnum
        CA = 0
        AR = 1
        AL = 2
        AK = 3
        AZ = 4
        CO = 5
        CT = 6
        DE = 7
        DC = 8
        FL = 9
        GA = 10
        HI = 11
        ID = 12
        IL = 13
        [IN] = 14
        IA = 15
        KS = 16
        KY = 17
        LA = 18
        [ME] = 19
        MD = 20
        MA = 21
        MI = 22
        MN = 23
        MS = 24
        MO = 25
        MT = 26
        NE = 27
        NV = 28
        NH = 29
        NJ = 30
        NM = 31
        NY = 32
        NC = 33
        OH = 34
        OK = 35
        [OR] = 36
        PA = 37
        RI = 38
        SC = 39
        SD = 40
        TN = 41
        TX = 42
        UT = 43
        VT = 44
        VA = 45
        WA = 46
        WV = 47
        WI = 48
        WY = 49
        ND = 50
    End Enum

    Friend NotInheritable Class EditorHelpers

        Private Sub New()
        End Sub

        Private Shared Function CreatePersonPrefixImageCollection() As SvgImageCollection
            Dim ret As New SvgImageCollection()
            ret.ImageSize = New Size(16, 16)
            ret.Add(My.Resources.Doctor)
            ret.Add(My.Resources.Mr)
            ret.Add(My.Resources.Ms)
            ret.Add(My.Resources.Miss)
            ret.Add(My.Resources.Mrs)
            Return ret
        End Function
        Public Shared Function CreatePersonPrefixImageComboBox(Optional ByVal edit As RepositoryItemImageComboBox = Nothing, Optional ByVal collection As RepositoryItemCollection = Nothing) As RepositoryItemImageComboBox
            Dim ret As RepositoryItemImageComboBox = CreateEnumImageComboBox(Of PersonPrefix)(edit, collection)
            ret.SmallImages = CreatePersonPrefixImageCollection()
            If edit Is Nothing Then
                ret.GlyphAlignment = HorzAlignment.Center
            End If
            Return ret
        End Function
        Public Shared Function CreateEnumImageComboBox(Of TEnum)(Optional ByVal edit As RepositoryItemImageComboBox = Nothing, Optional ByVal collection As RepositoryItemCollection = Nothing, Optional ByVal displayTextConverter As Converter(Of TEnum, String) = Nothing) As RepositoryItemImageComboBox
            Return CreateEdit(Of RepositoryItemImageComboBox)(edit, collection, Function(e) AddEnum(displayTextConverter, e))
        End Function
        Public Shared Function CreateEdit(Of TEdit As {RepositoryItem, New})(Optional ByVal edit As TEdit = Nothing, Optional ByVal collection As RepositoryItemCollection = Nothing, Optional ByVal initialize As Func(Of TEdit, Boolean) = Nothing) As TEdit
            edit = If(edit, New TEdit())
            If collection IsNot Nothing Then
                collection.Add(edit)
            End If
            If initialize IsNot Nothing Then
                initialize(edit)
            End If
            Return edit
        End Function
        Private Shared Function AddEnum(Of TEnum)(ByVal displayTextConverter As Converter(Of TEnum, String), ByVal e As RepositoryItemImageComboBox) As Boolean
            e.Items.AddEnum(Of TEnum)(displayTextConverter)
            Return True
        End Function
    End Class
    #End Region
End Namespace
