using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delmon_Managment_System.Forms
{
    public partial class AssetFrm : Form
    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        SQLCONNECTION SQLCONN3= new SQLCONNECTION();
        int AssetDetialsID;
        int AssetDetialsInfoID;
        int LoggedEmployeeID;
        public AssetFrm()
        {
            InitializeComponent();
        }

        private void cmbemployee_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Generatebtn_Click(object sender, EventArgs e)
        {

        }

        private void AssetFrm_Load(object sender, EventArgs e)
        {
            this.timer1.Interval = 1000;
            timer1.Start();

            lblusername.Text = CommonClass.LoginUserName;
            lblemail.Text = CommonClass.Email;
            LoggedEmployeeID = CommonClass.EmployeeID;
            lblFullname.Text = CommonClass.LoginEmployeeName;
            lblPC.Text = Environment.MachineName;
            SQLCONN.OpenConection3();
            cmbtype.ValueMember = "AssetTypeID";
            cmbtype.DisplayMember = "AssettypeValue";
            cmbtype.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT AssetTypeID,AssettypeValue FROM AssetType");
            cmbdeviceatt.ValueMember = "DeviceDetilasID";
            cmbdeviceatt.DisplayMember = "DeviceDetialsValue";
            cmbdeviceatt.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT DeviceDetilasID ,DeviceDetialsValue FROM DeviceDetialsInfo ");

            SQLCONN.CloseConnection();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            lblusername.Text = CommonClass.LoginUserName;
          //  lblusertype.Text = CommonClass.Usertype;
            lblemail.Text = CommonClass.Email;
           // LoggedEmployeeID = CommonClass.EmployeeID;
            lblFullname.Text = CommonClass.LoginEmployeeName;
            lblPC.Text = Environment.MachineName;
        }

        private void cmbtype_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRow dr;
            SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.8;Initial Catalog=DelmonGroupAssests;User ID=sa;password=Ram72763@");


            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT [AssetBrandID],[AssetBrandValue] FROM [DelmonGroupAssests].[dbo].[AssetBrand] where AssetTypeID=@C1 ";


            cmd.Parameters.Add(new SqlParameter("@C1", SqlDbType.Int));
            cmd.Parameters["@C1"].Value = cmbtype.SelectedValue;


            //Creating Sql Data Adapter
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            dr = dt.NewRow();


            if (dt != null && dt.Rows.Count >= 0)
            {

                cmbbrand.ValueMember = "AssetBrandID";
                cmbbrand.DisplayMember = "AssetBrandValue";
                cmbbrand.DataSource = dt;
                cmbbrand.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbbrand.AutoCompleteSource = AutoCompleteSource.ListItems;





            }

            conn.Close();
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            addbtn.Visible = true;
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramcmbtype = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramcmbtype.Value = cmbtype.SelectedValue;
            SqlParameter paramcmbrand = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramcmbrand.Value = cmbbrand.SelectedValue;
            SqlParameter paramassetmodel = new SqlParameter("@C3", SqlDbType.NVarChar);
            paramassetmodel.Value = Assetmodeltxt.Text;



            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = CommonClass.EmployeeID;
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;


            SqlDataReader dr;
            if ((int)cmbtype.SelectedValue != 0 && (int)cmbbrand.SelectedValue != 0 && Assetmodeltxt.Text != "")
            {
                SQLCONN3.OpenConection3();
                dr = SQLCONN3.DataReader("select  * from AssetMainInfo  where " +
                    " brand=@C2 or model = @C3", paramcmbrand, paramassetmodel);
                dr.Read();


                if (dr.HasRows)
                {
                    MessageBox.Show("This 'Asset'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {


                        dr.Dispose();
                        dr.Close();
                     
                         
                        SQLCONN3.ExecuteQueries("insert into AssetMainInfo ( [type] ,[brand],[model]) values (@C1,@C2,@C3)",
                                                     paramcmbtype, paramcmbrand, paramassetmodel);
                            MessageBox.Show("Record saved Successfully");

                            btnnew.Visible = true;



                        dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"
                             select AssetMainInfo.AssetDetailsID ,AssetType.AssettypeValue, AssetBrand.AssetBrandValue,AssetMainInfo.Model
from AssetMainInfo ,AssetBrand,AssetType
  where  Brand = AssetBrand.AssetBrandID
  and AssetMainInfo.Type = AssetType.AssetTypeID and type= @C1 and brand=@C2 and model=@C3", paramcmbtype, paramcmbrand, paramassetmodel);




                    }
                    else
                    {

                        dr.Dispose();
                        dr.Close();
                    }
                }



            }
            else
            {
                MessageBox.Show("Please Fill the missing fields  ");

            }
            SQLCONN3.CloseConnection();
            cmbtype.Text = cmbbrand.Text = "Select";
            Assetmodeltxt.Text = "";
        }

        private void seratchassettxt_TextChanged(object sender, EventArgs e)
        {
            SqlParameter paramAssetSearch = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramAssetSearch.Value = Assetmodeltxt.Text;
            SQLCONN3.OpenConection3();
         
            dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"
 select AssetMainInfo.AssetDetailsID ,AssetType.AssettypeValue, AssetBrand.AssetBrandValue,AssetMainInfo.Model from AssetMainInfo ,AssetBrand,AssetType
  where  Brand=AssetBrand.AssetBrandID
  and AssetMainInfo.Type= AssetType.AssetTypeID", paramAssetSearch);
           
            SQLCONN3.CloseConnection();
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addbtn.Visible = false;
            btnnew.Visible = updatebtn.Visible = deletebtn.Visible = true;
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

                        AssetDetialsID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                        cmbtype.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        cmbbrand.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        Assetmodeltxt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();


                    







                        ////CurrentEmployeeIDtxt.Text = EmployeeID.ToString();
                        ////addbtn.Visible = false;
                        //btnNew.Visible = DeleteBTN.Visible = Updatebtn.Visible = true;
                        //firstnametxt.Enabled = secondnametxt.Enabled = thirdnametxt.Enabled = lastnametxt.Enabled = true;
                        //cmbMartialStatus.Enabled = cmbGender.Enabled = cmbCompany.Enabled = cmbempdepthistory.Enabled = cmbEmployJobHistory.Enabled = cmbPersonalStatusStatus.Enabled = true;
                        //StartDatePicker.Enabled = true;

                    }
                }

            }

        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramcmbtype = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramcmbtype.Value = cmbtype.SelectedValue;
            SqlParameter paramcmbrand = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramcmbrand.Value = cmbbrand.SelectedValue;
            SqlParameter paramassetmodel = new SqlParameter("@C3", SqlDbType.NVarChar);
            paramassetmodel.Value = Assetmodeltxt.Text;
            SqlParameter paramIDD = new SqlParameter("@idd", SqlDbType.NVarChar);
            paramIDD.Value = AssetDetialsID;


            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = CommonClass.EmployeeID;
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;


            if (AssetDetialsID != 0)
            {

                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {

                    if (cmbtype.Text == "Select")

                    {
                        MessageBox.Show("Please Select a Type !!");


                    }
                    else if (cmbbrand.Text == "")
                    {
                        MessageBox.Show("Please Select Brand !!");
                    }
                    else if (Assetmodeltxt.Text == "")

                    {
                        MessageBox.Show("Please insert Asset Model !!");


                    }
                  
                    else
                    {
                        SQLCONN3.OpenConection3();
                        SQLCONN.OpenConection3();

                        // MessageBox.Show(EMPID.ToString());

                        /**logtable */
                     

                        if ((int)cmbtype.SelectedIndex == -1)
                        {
                            SQLCONN3.ExecuteQueries("update AssetMainInfo set brand=@C2,model=@C3 where  AssetDetailsID=@idd  ", paramIDD, paramcmbrand, paramassetmodel);

                        }
                        else if ((int)cmbbrand.SelectedIndex == -1)
                        {
                            SQLCONN3.ExecuteQueries("update AssetMainInfo set type=@C1,model=@C3 where  AssetDetailsID=@idd  ", paramIDD, paramcmbtype, paramassetmodel);

                        }

                        else 
                        {
                            SQLCONN3.ExecuteQueries("update AssetMainInfo set type=@C1,brand=@C2,model=@C3 where  AssetDetailsID=@idd  ", paramIDD, paramcmbtype, paramcmbrand, paramassetmodel);

                        }





                        MessageBox.Show("Record Updated Successfully");
                        // dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" SELECT id_History,[EmployeeID],NewID,StatusTBL.StatusValue,[JOBS].JobTitleEN, DeptTypes.Dept_Type_Name,[StartDate],[EndDate],[UserID],[DatetimeLog]  FROM[DelmonGroupDB].[dbo].[EmploymentStatus], JOBS, DEPARTMENTS, StatusTBL, DeptTypes  where   StatusTBL.StatusID = EmploymentStatus.EmploymentStatusID and DEPARTMENTS.DeptName = EmploymentStatus.DeptID   and DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID  and JOBS.JobID = EmploymentStatus.JobID  and  NEWID = @C14  ", paramNewID);
                        dataGridView1.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@"
                             select AssetMainInfo.AssetDetailsID AssetDetailsID,AssetType.AssettypeValue, AssetBrand.AssetBrandValue,AssetMainInfo.Model 
from AssetMainInfo , AssetBrand, AssetType
  where  Brand=AssetBrand.AssetBrandID
  and AssetMainInfo.Type = AssetType.AssetTypeID and AssetDetailsID= @idd ", paramIDD);



                     
                        SQLCONN.CloseConnection();
                    }

                }
                else
                {
                }

            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
                tabControl1.Enabled = false;
            }
            SQLCONN.CloseConnection();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lbldatetime.Text = DateTime.Now.ToString("dd-MMM-yyyy  hh:mm:ss tt");

        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramIDD = new SqlParameter("@idd", SqlDbType.NVarChar);
            paramIDD.Value = AssetDetialsID;


          

            if (AssetDetialsID == 0)
            {
                MessageBox.Show("Please select  Asset first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN3.OpenConection3();
                    SQLCONN3.ExecuteQueries("delete  AssetMainInfo where AssetDetailsID=@idd", paramIDD);
                    SQLCONN3.ExecuteQueries(" declare @max int select @max = max([AssetDetailsID]) from [AssetMainInfo] if @max IS NULL    SET @max = 0 DBCC CHECKIDENT('[AssetMainInfo]', RESEED, @max)");
                    dataGridView1.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("select * from AssetMainInfo where AssetDetailsID=@idd", paramIDD);
                    MessageBox.Show("Record has been deleted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SQLCONN3.CloseConnection();
                    cmbtype.Text = "Select";
                    cmbbrand.Text = "";
                    Assetmodeltxt.Text = "";



                }

            }
        }

        private void tabControl2_MouseClick(object sender, MouseEventArgs e)
        {
            SQLCONN3.OpenConection3();
            SqlParameter paramID = new SqlParameter("@ID", SqlDbType.NVarChar);
            paramID.Value = AssetDetialsID;
            if (AssetDetialsID == 0)
            {
                MessageBox.Show("Please Choose A Record !  ");

            }
            else
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages[0])
                {
                    dataGridView5.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@" select ad.AssetDetialsInfoID, ad.AssetDetailsID ,
at.AssettypeValue,ab.AssetBrandValue,am.Model,dd.DeviceDetialsValue,ad.Value from AssetMainInfo am,AssetDetialsInfo ad ,DeviceDetialsInfo dd ,AssetBrand ab,AssetType at
 where am.Brand=ab.AssetBrandID and am.Type=at.AssetTypeID
 and am.AssetDetailsID= ad.AssetDetailsID
 and dd.DeviceDetilasID= ad.DeviceDetilasID
 and am.AssetDetailsID=@ID", paramID);
                                     
                    cmbdeviceatt.Text = "Select";
                    txtvalue.Text = "";
                    dataGridView5.Columns[6].Width = 200;
                    dataGridView5.Columns[5].Width = 200;
                    dataGridView5.Columns[4].Width = 200;
                    dataGridView5.Columns[3].Width = 200;
                    dataGridView5.Columns[1].Width = 200;
                }


            }
            SQLCONN3.CloseConnection();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (AssetDetialsID != 0 & (int)cmbdeviceatt.SelectedValue!=0)
            {
                SqlParameter paramDeviceatt = new SqlParameter("@C1", SqlDbType.Int);
                paramDeviceatt.Value = cmbdeviceatt.SelectedValue;
                SqlParameter paramValue = new SqlParameter("@C2", SqlDbType.NVarChar);
                paramValue.Value = txtvalue.Text;

                SqlParameter paramID = new SqlParameter("@ID", SqlDbType.NVarChar);
                paramID.Value = AssetDetialsID;

                         if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN3.OpenConection3();

                  //  SqlDataReader dr = SQLCONN3.DataReader("select * from [AssetDetialsInfo] where  AssetDetailsID= " + AssetDetialsID + " and DeviceDetilasID= " + cmbdeviceatt.SelectedValue + " and value= " + txtvalue.Text + " ");
                    SqlDataReader dr = SQLCONN3.DataReader("select * from [AssetDetialsInfo] where  AssetDetailsID=@ID  and DeviceDetilasID=@C1  and value=@C2 ",paramID,paramDeviceatt,paramValue);

                    dr.Read();

                    if (dr.HasRows)
                    {
                        MessageBox.Show("This ' Value For This Asset '  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                    else
                    {
                        dr.Dispose();
                        dr.Close();
                        if ((int)cmbdeviceatt.SelectedValue == 3)
                        { txtvalue.Text = txtvalue.Text + " " + "Houres Per Day "; }
                        if ((int)cmbdeviceatt.SelectedValue == 4)
                        { txtvalue.Text = txtvalue.Text + " " + "Days Per Week "; }
                        if ((int)cmbdeviceatt.SelectedValue == 5)
                        { txtvalue.Text = txtvalue.Text + " " + "Months"; }
                        if ((int)cmbdeviceatt.SelectedValue == 6)
                        { txtvalue.Text = txtvalue.Text + " " + "Months"; }
                        if ((int)cmbdeviceatt.SelectedValue == 8)
                        {
                            if (txtvalue.Text.Contains("yes") || txtvalue.Text.Contains("YES"))
                            {
                                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                                TextInfo textInfo = cultureInfo.TextInfo;
                                txtvalue.Text = textInfo.ToTitleCase(txtvalue.Text);
                                txtvalue.Text = "Provided By Company";

                            }
                        }
                        if ((int)cmbdeviceatt.SelectedValue == 9)
                        {
                            if (txtvalue.Text.Contains("yes") || txtvalue.Text.Contains("YES") || txtvalue.Text.Contains("Yes") || txtvalue.Text.Contains("YEs"))
                            {
                                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                                TextInfo textInfo = cultureInfo.TextInfo;
                                txtvalue.Text = textInfo.ToTitleCase(txtvalue.Text);
                                txtvalue.Text = "Provided By Company";

                            }
                        }
                        if ((int)cmbdeviceatt.SelectedValue == 10)
                        {
                            if (txtvalue.Text.Contains("yes") || txtvalue.Text.Contains("YES") || txtvalue.Text.Contains("Yes") || txtvalue.Text.Contains("YEs"))
                            {
                                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                                TextInfo textInfo = cultureInfo.TextInfo;
                                txtvalue.Text = textInfo.ToTitleCase(txtvalue.Text);
                                txtvalue.Text = "Provided By Company";

                            }
                        }
                        if ((int)cmbdeviceatt.SelectedValue == 11)
                        {
                            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                            TextInfo textInfo = cultureInfo.TextInfo;
                            txtvalue.Text = textInfo.ToTitleCase(txtvalue.Text);
                            txtvalue.Text = txtvalue.Text + " " + "Days/Year after finish Contract Period";
                        }
                        if ((int)cmbdeviceatt.SelectedValue == 12)
                        {
                            if (txtvalue.Text.Contains("yes") || txtvalue.Text.Contains("YES") || txtvalue.Text.Contains("Yes") || txtvalue.Text.Contains("YEs"))
                            {
                                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                                TextInfo textInfo = cultureInfo.TextInfo;
                                txtvalue.Text = textInfo.ToTitleCase(txtvalue.Text);
                                txtvalue.Text = "Provided By Company";

                            }
                        }



                      paramValue.Value = txtvalue.Text;
                      SQLCONN3.ExecuteQueries("insert into AssetDetialsInfo (AssetDetailsID,DeviceDetilasID,Value) values (@ID,@C1,@C2)",
                                                   paramID, paramDeviceatt, paramValue);
                        MessageBox.Show("Record saved Successfully");
                        cmbdeviceatt.SelectedValue = 0;
                        txtvalue.Text = "";


                        dataGridView5.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@" select ad.AssetDetialsInfoID, ad.AssetDetailsID ,
at.AssettypeValue,ab.AssetBrandValue,am.Model,dd.DeviceDetialsValue,ad.Value from AssetMainInfo am,AssetDetialsInfo ad ,DeviceDetialsInfo dd ,AssetBrand ab,AssetType at
 where am.Brand=ab.AssetBrandID and am.Type=at.AssetTypeID
 and am.AssetDetailsID= ad.AssetDetailsID
 and dd.DeviceDetilasID= ad.DeviceDetilasID
 and am.AssetDetailsID=@ID", paramID);
                        
                        this.dataGridView5.Columns["AssetDetailsID"].Visible = false;
                        dataGridView5.Columns[6].Width = 200;
                        dataGridView5.Columns[5].Width = 200;
                        dataGridView5.Columns[4].Width = 200;
                        dataGridView5.Columns[3].Width = 200;
                        dataGridView5.Columns[1].Width = 200;
                        dataGridView5.Columns[0].Width = 200;
                        // ClearTextBoxes();
                        cmbdeviceatt.Text = "Select";
                        txtvalue.Text = "";
                        SQLCONN3.CloseConnection();

                    }
                }
                else
                {

                }
            //    paramemployee.Value = EmployeeID;
            }
            else
            {
                MessageBox.Show("Please Select Record or Device attribute!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlParameter paramDeviceatt = new SqlParameter("@C1", SqlDbType.Int);
            paramDeviceatt.Value = cmbdeviceatt.SelectedValue;
            SqlParameter paramValue = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramValue.Value = txtvalue.Text;

            SqlParameter paramID = new SqlParameter("@ID", SqlDbType.NVarChar);
            paramID.Value = AssetDetialsInfoID;
            SqlParameter paramIDD = new SqlParameter("@IDD", SqlDbType.NVarChar);
            paramIDD.Value = AssetDetialsID;


            if (AssetDetialsInfoID!=0)
            {
             

                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN3.OpenConection3();

                  
                   
                        if ((int)cmbdeviceatt.SelectedValue == 3)
                        { txtvalue.Text = txtvalue.Text + " " + "Houres Per Day "; }
                        if ((int)cmbdeviceatt.SelectedValue == 4)
                        { txtvalue.Text = txtvalue.Text + " " + "Days Per Week "; }
                        if ((int)cmbdeviceatt.SelectedValue == 5)
                        { txtvalue.Text = txtvalue.Text + " " + "Months"; }
                        if ((int)cmbdeviceatt.SelectedValue == 6)
                        { txtvalue.Text = txtvalue.Text + " " + "Months"; }
                        if ((int)cmbdeviceatt.SelectedValue == 8)
                        {
                            if (txtvalue.Text.Contains("yes") || txtvalue.Text.Contains("YES"))
                            {
                                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                                TextInfo textInfo = cultureInfo.TextInfo;
                                txtvalue.Text = textInfo.ToTitleCase(txtvalue.Text);
                                txtvalue.Text = "Provided By Company";

                            }
                        }
                        if ((int)cmbdeviceatt.SelectedValue == 9)
                        {
                            if (txtvalue.Text.Contains("yes") || txtvalue.Text.Contains("YES") || txtvalue.Text.Contains("Yes") || txtvalue.Text.Contains("YEs"))
                            {
                                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                                TextInfo textInfo = cultureInfo.TextInfo;
                                txtvalue.Text = textInfo.ToTitleCase(txtvalue.Text);
                                txtvalue.Text = "Provided By Company";

                            }
                        }
                        if ((int)cmbdeviceatt.SelectedValue == 10)
                        {
                            if (txtvalue.Text.Contains("yes") || txtvalue.Text.Contains("YES") || txtvalue.Text.Contains("Yes") || txtvalue.Text.Contains("YEs"))
                            {
                                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                                TextInfo textInfo = cultureInfo.TextInfo;
                                txtvalue.Text = textInfo.ToTitleCase(txtvalue.Text);
                                txtvalue.Text = "Provided By Company";

                            }
                        }
                        if ((int)cmbdeviceatt.SelectedValue == 11)
                        {
                            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                            TextInfo textInfo = cultureInfo.TextInfo;
                            txtvalue.Text = textInfo.ToTitleCase(txtvalue.Text);
                            txtvalue.Text = txtvalue.Text + " " + "Days/Year after finish Contract Period";
                        }
                        if ((int)cmbdeviceatt.SelectedValue == 12)
                        {
                            if (txtvalue.Text.Contains("yes") || txtvalue.Text.Contains("YES") || txtvalue.Text.Contains("Yes") || txtvalue.Text.Contains("YEs"))
                            {
                                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                                TextInfo textInfo = cultureInfo.TextInfo;
                                txtvalue.Text = textInfo.ToTitleCase(txtvalue.Text);
                                txtvalue.Text = "Provided By Company";

                            }
                        }



                        paramValue.Value = txtvalue.Text;
                        SQLCONN3.ExecuteQueries("update  AssetDetialsInfo set AssetDetailsID=@IDD,DeviceDetilasID=@C1,Value=@C2 where AssetDetialsInfoID=@ID ",
                                                     paramID, paramDeviceatt, paramValue,paramIDD);

                     MessageBox.Show("Record updated Successfully");
                        cmbdeviceatt.SelectedValue = 0;
                        txtvalue.Text = "";


                        dataGridView5.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@" select ad.AssetDetialsInfoID, ad.AssetDetailsID ,
at.AssettypeValue,ab.AssetBrandValue,am.Model,dd.DeviceDetialsValue,ad.Value from AssetMainInfo am,AssetDetialsInfo ad ,DeviceDetialsInfo dd ,AssetBrand ab,AssetType at
 where am.Brand=ab.AssetBrandID and am.Type=at.AssetTypeID
 and am.AssetDetailsID= ad.AssetDetailsID
 and dd.DeviceDetilasID= ad.DeviceDetilasID
 and am.AssetDetailsID=@ID", paramID);

                        this.dataGridView5.Columns["AssetDetailsID"].Visible = false;
                        dataGridView5.Columns[6].Width = 200;
                        dataGridView5.Columns[5].Width = 200;
                        dataGridView5.Columns[4].Width = 200;
                        dataGridView5.Columns[3].Width = 200;
                        dataGridView5.Columns[1].Width = 200;
                        dataGridView5.Columns[0].Width = 200;
                        // ClearTextBoxes();
                        cmbdeviceatt.Text = "Select";
                        txtvalue.Text = "";
                        SQLCONN3.CloseConnection();

                    }
               
                else
                {

                }
                //    paramemployee.Value = EmployeeID;
            }
            else
            {
                MessageBox.Show("Please Select Record !!");
            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addbtn.Visible = false;
            btnnew.Visible = updatebtn.Visible = deletebtn.Visible = true;
            if (e.RowIndex == -1) return;

            foreach (DataGridViewRow rw in this.dataGridView5.Rows)
            {
                for (int i = 0; i < rw.Cells.Count; i++)
                {
                    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                    {
                        //   MessageBox.Show("ogg");       
                    }
                    else
                    {

                        AssetDetialsInfoID = Convert.ToInt32(dataGridView5.Rows[e.RowIndex].Cells[0].Value.ToString());
                        cmbdeviceatt.Text = dataGridView5.Rows[e.RowIndex].Cells[5].Value.ToString();
                        txtvalue.Text = dataGridView5.Rows[e.RowIndex].Cells[6].Value.ToString();


                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlParameter paramIDD = new SqlParameter("@idd", SqlDbType.NVarChar);
            paramIDD.Value = AssetDetialsInfoID;




            if (AssetDetialsInfoID == 0)
            {
                MessageBox.Show("Please select  Asset first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN3.OpenConection3();
                    SQLCONN3.ExecuteQueries("delete AssetDetialsInfo where AssetDetialsInfoID =@idd", paramIDD);
                    SQLCONN3.ExecuteQueries(" declare @max int select @max = max([AssetDetialsInfoID]) from [AssetDetialsInfo] if @max IS NULL    SET @max = 0 DBCC CHECKIDENT('[AssetDetialsInfo]', RESEED, @max)");
                    dataGridView5.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("select * from AssetDetialsInfo where AssetDetialsInfoID=@idd", paramIDD);
                    MessageBox.Show("Record has been deleted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SQLCONN3.CloseConnection();
                    cmbtype.Text = "Select";
                    cmbbrand.Text = "";
                    Assetmodeltxt.Text = "";



                }

            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
    }

