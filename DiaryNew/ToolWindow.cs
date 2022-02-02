using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Diary.Basic_Classes;

namespace Diary
{
    public partial class ToolWindow : Form
    {


        public ToolWindow()
        {

            InitializeComponent();
        }

        private void ToolWindow_Load(object sender, EventArgs e)
        {
            DateLabel.Text = DateTime.Now.ToString();

            DataBindTools();
        }

        private void ToolsGridView_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.Value != null && (e.Value.ToString() == "השאלה זמנית"  || e.Value.ToString() == "השאלה קבועה"))
            {
                SolidBrush br = new SolidBrush(Color.Red);

                e.Graphics.FillRectangle(br, e.CellBounds);
                e.PaintContent(e.ClipBounds);
                e.Handled = true;
            }
        }

        public void DataBindTools()
        {
            DataSet fillTable = TechTools.getToolsFromDB();

            if (fillTable.Tables.Count > 0)
            {
                ToolsGridView.DataSource = fillTable.Tables["tblTools"];
            }
        }

        private void ToolsGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int toolSerial        = Convert.ToInt32(ToolsGridView.Rows[e.RowIndex].Cells["toolSerial"].Value);
            string toolName       = ToolsGridView.Rows[e.RowIndex].Cells["toolName"].Value.ToString();
            string toolStatus     = ToolsGridView.Rows[e.RowIndex].Cells["toolStatus"].Value.ToString();
            DateTime dtTakingTime = new DateTime();

            if (ToolsGridView.Rows[e.RowIndex].Cells["takingTime"].Value.ToString() != string.Empty)
            {
                dtTakingTime = Convert.ToDateTime(ToolsGridView.Rows[e.RowIndex].Cells["takingTime"].Value);
            }

            TechTools newTool = new TechTools();

            newTool.TakingTime = dtTakingTime;
            newTool.ToolName = toolName;
            newTool.ToolSerial = toolSerial;

            switch (toolStatus)
            {
                case ("זמין"):
                    {
                        newTool.ToolStatus = TechTools.ToolStatusEnum.Available;

                        break;
                    };
                case ("השאלה זמנית"):
                    {
                        newTool.ToolStatus = TechTools.ToolStatusEnum.TakenTemporarly;

                        break;
                    };
                case ("השאלה קבועה"):
                    {
                        newTool.ToolStatus = TechTools.ToolStatusEnum.TakenPermanently;

                        break;
                    };

                default:
                    break;
            }

            TransactionWindow trnWindow = new TransactionWindow(newTool);
            trnWindow.MdiParent = this.MdiParent;

            trnWindow.Show();
            this.Close();
        }

    }
}
