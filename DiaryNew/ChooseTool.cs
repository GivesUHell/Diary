using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diary.Basic_Classes;

namespace Diary
{
    public partial class ChooseTool : Form
    {
        DataSet toolsTable;
        MasterForm mdiparent;

        public ChooseTool()
        {
            mdiparent = this.MdiParent as MasterForm;

            InitializeComponent();
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void ChooseTool_Load(object sender, EventArgs e)
        {
            toolsTable = TechTools.getToolsFromDB();
            
            ddlChooseTool.DisplayMember = "toolName";
            ddlChooseTool.ValueMember = "toolSerial";

            DataTable dt = new DataTable();
            dt.Columns.Add("toolSerial", typeof(int));
            dt.Columns.Add("toolName");

            foreach (DataRow dtRowAdd in toolsTable.Tables["tblTools"].Rows)
            {
                if (dtRowAdd["toolStatus"].ToString() == "זמין")
                {
                    DataRow row = dt.NewRow();
                    row[1] = dtRowAdd["toolName"];
                    row[0] = dtRowAdd["toolSerial"];
                    dt.Rows.Add(row);
                }
            }

            dt.AcceptChanges();

            ddlChooseTool.DataSource = dt;

            // Get combobox selection (in handler)
            //string value = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Value;

            ComboboxItem item = new ComboboxItem();
            item.Text = "השאלה זמנית";
            item.Value = 1;
            ddlChooseAction.Items.Insert(0, item);

            ComboboxItem item2 = new ComboboxItem();
            item2.Text = "השאלה קבועה";
            item2.Value = 2;
            ddlChooseAction.Items.Insert(1, item2);

            ddlChooseAction.SelectedIndex = 0;

            //MessageBox.Show((ddlChooseAction.SelectedItem as ComboboxItem).Value.ToString());
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ddlChooseTool.DisplayMember = "toolName";
            ddlChooseTool.ValueMember = "toolSerial";

            DataTable dt = new DataTable();
            dt.Columns.Add("toolSerial", typeof(int));
            dt.Columns.Add("toolName");

            int Serial;

            if (int.TryParse(txtSearch.Text, out Serial))
            {
                foreach (DataRow dtRowAdd in toolsTable.Tables["tblTools"].Rows)
                {
                    if (dtRowAdd["toolSerial"].ToString().Contains(txtSearch.Text))
                    {
                        DataRow row = dt.NewRow();
                        row[1] = dtRowAdd["toolName"];
                        row[0] = dtRowAdd["toolSerial"];
                        dt.Rows.Add(row);
                    }
                }
            }
            else
            {
                foreach (DataRow dtRowAdd in toolsTable.Tables["tblTools"].Rows)
                {
                    if (dtRowAdd["toolName"].ToString().Contains(txtSearch.Text))
                    {
                        DataRow row = dt.NewRow();
                        row[1] = dtRowAdd["toolName"];
                        row[0] = dtRowAdd["toolSerial"];
                        dt.Rows.Add(row);
                    }
                }
            }

            dt.AcceptChanges();

            ddlChooseTool.DataSource = dt;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            mdiparent = this.MdiParent as MasterForm;

            // tool serial
            string toolSerial = ddlChooseTool.SelectedValue.ToString();
            string toolName = string.Empty;

            foreach (DataRow dtRowAdd in toolsTable.Tables["tblTools"].Rows)
            {
                if (dtRowAdd["toolSerial"].ToString() == toolSerial)
                {
                    toolName = dtRowAdd["toolName"].ToString();
                }
            }

            string toolNewStatus = ddlChooseAction.Items[ddlChooseAction.SelectedIndex].ToString();
            string toolPlace = txtboxPlace.Text;
            string transactionReason = txtboxReason.Text;
            User transactionCreator = mdiparent.UserLogged;


            if (ToolTransaction.addTransaction(toolSerial, toolName, toolPlace, transactionReason, transactionCreator) &&
                TechTools.UpdateToolStatus(toolSerial, toolNewStatus))
            {
                MessageBox.Show("הכלי הושאל בהצלחה", "מידע",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);

                this.Close();
            }
            else
            {
                MessageBox.Show("הכלי לא הושאל", "מידע",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
            }
        }
    }
}
