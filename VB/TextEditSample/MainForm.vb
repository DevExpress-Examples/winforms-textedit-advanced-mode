Imports System.Drawing

Namespace TextEditSample
    Partial Public Class MainForm
        Inherits DevExpress.XtraEditors.XtraForm

        Public Sub New()
            InitializeComponent()
            EditorHelpers.CreatePersonPrefixImageComboBox(prefixImageComboboxEdit.Properties, Nothing)
            Me.employeeBindingSource.Add(EmployeeDataHelper.CreateDefaultEmployee())
        End Sub
        Protected Overrides Sub OnLookAndFeelChangedCore()
            MyBase.OnLookAndFeelChangedCore()
            ClientSize = dataLayoutControl1.Root.MinSize
        End Sub
    End Class
End Namespace