using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delmon_Managment_System.Forms
{
    public partial class FrmDocShow : Form
    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        int CompIDDoc;
        string CompNameDoc;
        string CRNUMBER;
        string destinationFilePath;
        string fileName;
        string textFilePath;
        string Shortname;
        int DocID;
        string filenameDB, documnetvalueDB;

        public FrmDocShow()
        {
            InitializeComponent();
        }

        private void FrmDocShow_Load(object sender, EventArgs e)
        {
            CompIDDoc = CommonClass.CompanyId;
            CompNameDoc = CommonClass.CompName;
            CRNUMBER = CommonClass.CRNmber;
            Shortname = CommonClass.ShortName;
            txtCompanyName.Text = CompNameDoc;
            SQLCONN.OpenConection();

            cmbdoc.ValueMember = "DocType_ID";
            cmbdoc.DisplayMember = "Doc_Type";
            cmbdoc.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT DocType_ID,Doc_Type FROM [DocumentType] where DocType_ID = 0 or DocType_ID = 5 or DocType_ID = 6 or DocType_ID = 7 or DocType_ID = 8 or DocType_ID = 9 order by DocType_ID asc ");
            cmbdoc.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbdoc.AutoCompleteSource = AutoCompleteSource.ListItems;
            dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT [Doc_id]
      ,[CR_ID]
      ,[DocTypeID]
      ,[name]    
      ,[docissuedate]
      ,[docexpiredate]
      ,[documentValue]
  FROM [DelmonGroupDB].[dbo].[Documents]
  where RefrenceID=4 and CR_ID= " + CompIDDoc+" ");


            SQLCONN.CloseConnection();
        }

        private void btnuplode_Click(object sender, EventArgs e)
        {

            string directoryPath = @"\\192.168.1.8\Companies Documents\";
            string variable = txtCompanyName.Text;

            // Get all subfolder names in the directory
            string[] subfolderNames = Directory.GetDirectories(directoryPath)
                                                .Select(Path.GetFileName)
                                                .ToArray();
            // Check if the variable matches any of the subfolder names
            if (subfolderNames.Contains(variable))
            {
                // Open file dialog to select a text file to insert into the subfolder
                OpenFileDialog openFileDialog = new OpenFileDialog();
                //  openFileDialog.Filter = "Text Files (*.txt)|*.txt";
                openFileDialog.Title = "Select a text file to insert into the subfolder";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Insert the selected text file into the matching subfolder
                    string subfolderPath = Path.Combine(directoryPath, variable);
                    textFilePath = openFileDialog.FileName;
                    fileName = Path.GetFileName(textFilePath);
                    destinationFilePath = Path.Combine(subfolderPath, fileName);

                    File.Copy(textFilePath, destinationFilePath);
                    txtpath.Text = textFilePath;
                    // MessageBox.Show(" Uploded Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtpath.Text != string.Empty)
            {
                if (fileName == null || destinationFilePath == string.Empty)
                {
                    MessageBox.Show("Please select a valid document.");
                }
                else
                {
                  
                    SqlParameter paramfilename = new SqlParameter("@C0", SqlDbType.NVarChar);
                    //string newFileName = Shortname + " - " + cmbdoc.Text + " - " + CRNUMBER + " - " + docexpirefatepicker.Text;

                    paramfilename.Value = fileName;


                    SqlParameter paramnameOFfile = new SqlParameter("@C1", SqlDbType.NVarChar);
                    paramnameOFfile.Value = destinationFilePath;
                    SqlParameter paramPID = new SqlParameter("@C2", SqlDbType.Int);
                    paramPID.Value = CompIDDoc;
                    SqlParameter paramDocType = new SqlParameter("@C3", SqlDbType.Int);
                    paramDocType.Value = cmbdoc.SelectedValue;
                    SqlParameter paramRefrenceID = new SqlParameter("@C4", SqlDbType.Int);
                    paramRefrenceID.Value = 4;
                    SqlParameter paramfileissuedate = new SqlParameter("@C7", SqlDbType.Date);
                    paramfileissuedate.Value = docissueplacepicker.Value;
                    SqlParameter paramfileexpiraydate = new SqlParameter("@C8", SqlDbType.Date);
                    paramfileexpiraydate.Value = docexpirefatepicker.Value;

                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        if (cmbdoc.Text == "Select")
                        {
                            MessageBox.Show("Please Select Document Type  . !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                      
                        else
                        {

                            SQLCONN.OpenConection();
                            SQLCONN.ExecuteQueries("insert into Documents (name,documentValue,CR_ID,DocTypeID,RefrenceID,[docissuedate],[docexpiredate])values(@C0,@C1,@C2,@C3,@C4,@C7,@C8)", paramfilename, paramnameOFfile, paramPID, paramDocType, paramRefrenceID,paramfileissuedate,paramfileexpiraydate);

                            /**/
                            SqlDataReader dr = SQLCONN.DataReader("select max(Doc_id) from Documents" );
                            //if (dr.Read())
                            //{
                            //    DocID =Convert.ToInt32( dr["Doc_id"].ToString());
                            //    CommonClass.DOCID = DocID;

                            //}

                            /**/




                            SQLCONN.CloseConnection();
                            MessageBox.Show("Document Saved.");
                            cmbdoc.Text = "Select";
                            txtpath.Text = "";
                            docissueplacepicker.Value = DateTime.Now;
                            docexpirefatepicker.Value = DateTime.Now;

                        }
                    }


                }
            }
            else
            {
                MessageBox.Show("Please Select Document !");

            }
        }

        private void cmbFile_SelectionChangeCommitted(object sender, EventArgs e)
        {

            //SqlParameter paramDOCID = new SqlParameter("@C0", SqlDbType.Int);
            //paramDOCID.Value = cmbFile.SelectedValue;

            SqlParameter paramPID = new SqlParameter("@C1", SqlDbType.Int);
            paramPID.Value = CompIDDoc;
            SqlParameter paramRefrenceID = new SqlParameter("@C2", SqlDbType.Int);
            paramRefrenceID.Value = 4;
            //SqlParameter paramFILEName = new SqlParameter("@C3", SqlDbType.NVarChar);
            //paramFILEName.Value = cmbFile.SelectedText;

            SQLCONN.OpenConection();
            SqlDataReader dr = SQLCONN.DataReader("select documentValue from Documents where Doc_id=@C0 and CR_ID=@C1 and RefrenceID=@C2 and name=@C3", paramPID, paramRefrenceID);
            if (dr.Read())
            {
                txtpath.Text = dr["documentValue"].ToString();
                
            }
            CommonClass.DocCompPath = txtpath.Text;
            SQLCONN.CloseConnection();
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            foreach (DataGridViewRow rw in this.dataGridView1.Rows)
            {
                for (int i = 0; i < rw.Cells.Count; i++)
                {
                    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                    {
                        //   MessageBox.Show("ogg");       
                    }
                    else
                    {

                        DocID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                        CompIDDoc = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                        cmbdoc.SelectedValue = Convert.ToInt32( dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                        txtFilename.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        docissueplacepicker.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        docexpirefatepicker.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                        txtpath.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                        CommonClass.DocCompPath = txtpath.Text;
                    }
                }

            }

        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            string fileName = CommonClass.DocCompPath;

            try
            {

                if (File.Exists(fileName))
                {
                    // Open the PDF document using the default PDF viewer application
                    Process.Start(fileName);
                }
                else
                {
                    MessageBox.Show("File not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }


           
        }
    }
}
