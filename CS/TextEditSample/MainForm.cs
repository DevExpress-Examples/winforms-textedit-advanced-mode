using System.Drawing;

namespace TextEditSample {
    public partial class MainForm : DevExpress.XtraEditors.XtraForm {
        public MainForm() {
            InitializeComponent();
            EditorHelpers.CreatePersonPrefixImageComboBox(prefixImageComboboxEdit.Properties, null);
            this.employeeBindingSource.Add(EmployeeDataHelper.CreateDefaultEmployee());
        }
        protected override void OnLookAndFeelChangedCore() {
            base.OnLookAndFeelChangedCore();
            ClientSize = dataLayoutControl1.Root.MinSize;
        }
    }
}