using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Asset
{

    public partial class Product : Form
    {
        Models.DatabaseContext oDatabaseContext = null;
        #region frmMain()
        Models.DateControlClass oDateControlClass = null;
        Models.CurencyRate oCurencyRate = null;
        string showResultDate = "";
        double getCurency;

        private Models.lapTopDB db;
        private Models.MobileDB mdb;
        public Product()
        {
            InitializeComponent();
            db = new Models.lapTopDB();
            mdb = new Models.MobileDB();
        }

        #endregion frmMain()


        #region frmMain_Load(object sender, EventArgs e)




        private void frmMain_Load(object sender, EventArgs e)
        {
            this.DisplayLaptop();
            this.DisplayMobile();
            BindDGV(db.LapTops.ToList());
            BindDGVM(mdb.Mobile.ToList());
           
        }

        #endregion frmMain_Load(object sender, EventArgs e)


        #region btnAddNewCountry_Click(object sender, System.EventArgs e)


        private void btnAddNewCountry_Click(object sender, System.EventArgs e)
        {

        }

        #endregion btnAddNewCountry_Click(object sender, System.EventArgs e)





       
        private void btnSaveLaptop_Click(object sender, EventArgs e)
        {



            Models.LapTopClass oLapTopClass = null;
            Models.DatabaseContext oDatabaseContext = null;
            Models.DateControlClass oDateControlClass = null;
            Models.CurencyRate oCurencyRate = null;
            try
            {

                oDatabaseContext = new Models.DatabaseContext();
                oLapTopClass = new Models.LapTopClass();




                oLapTopClass.Office = txtOffice.Text.Trim();
                oLapTopClass.Brand = txtBrand.Text.Trim();
                oLapTopClass.Model = txtModel.Text.Trim();
                oLapTopClass.PurchaseDate = DateTime.Parse(dtpL.Text);
                ///////////////////////////////////////////////////////////////////////
                oDateControlClass = new Models.DateControlClass();

                bool validateDate = oDateControlClass.GetGetDate(DateTime.Parse(dtpL.Text));
                if (validateDate == true)
                {
                    showResultDate = "This Product Got Expired";

                }
                else
                {
                    showResultDate = oDateControlClass.CalctDate(DateTime.Parse(dtpL.Text));
                }

                oLapTopClass.ExpirationDate = showResultDate;

                oLapTopClass.PurchasePrice = System.Convert.ToDouble(txtPrice.Text.Trim());
                ////////////////////////////////////////////////////////////////////////////////

                oLapTopClass.Currency = cmdLCurency.SelectedItem.ToString();

                oCurencyRate = new Models.CurencyRate();
                int selectedIndex = cmdLCurency.SelectedIndex;
                Object selectedItem = cmdLCurency.SelectedItem;




                //MessageBox.Show("Selected Item Text: " + selectedItem.ToString() + "\n" +
                //                 "Index: " + selectedIndex.ToString());


                //////////////////////////////////////////////////////////
                //oCurencyRate = new Models.CurencyRate();
                //double getCurenc= 

                oLapTopClass.ExchangeRate = oCurencyRate.CurencyGet(cmdLCurency.SelectedItem.ToString(), System.Convert.ToDouble(txtPrice.Text.Trim())).ToString();


                oDatabaseContext.LapTop.Add(oLapTopClass);




                oDatabaseContext.SaveChanges();




                txtOffice.Text = string.Empty;
                txtBrand.Text = string.Empty;
                txtModel.Text = string.Empty;
                txtPrice.Text = string.Empty;



            }

            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            finally
            {
                if (oDatabaseContext != null)
                {
                    oDatabaseContext.Dispose();
                    oDatabaseContext = null;

                }
            }
            this.DisplayLaptop();
            this.DisplayMobile();

            BindDGV(db.LapTops.ToList());
            BindDGVM(mdb.Mobile.ToList());

        }

        private void btnSaveMobile_Click(object sender, EventArgs e)
        {
            Models.MobileClass oMobileClass = null;
            Models.DatabaseContext oDatabaseContext = null;
            Models.DateControlClass oDateControlClass = null;
            Models.CurencyRate oCurencyRate = null;

            try
            {

                oDatabaseContext =
                    new Models.DatabaseContext();



                // #################################################


                oMobileClass = new Models.MobileClass();


                oMobileClass.Office = txtmOffice.Text.Trim();
                oMobileClass.Brand = txtmBrand.Text.Trim();
                oMobileClass.Model = txtmModel.Text.Trim();
                oMobileClass.PurchaseDate = DateTime.Parse(dtpM.Text);
                oDateControlClass = new Models.DateControlClass();

                bool validateDate = oDateControlClass.GetGetDate(DateTime.Parse(dtpM.Text));
                if (validateDate == true)
                {
                    showResultDate = "This Product Got Expired";

                }
                else
                {
                    showResultDate = oDateControlClass.CalctDate(DateTime.Parse(dtpM.Text));
                }

                oMobileClass.ExpirationDate = showResultDate;

                oMobileClass.PurchasePrice = System.Convert.ToDouble(txtmPurchasePrice.Text.Trim());




                oMobileClass.Currency = cmdMCurency.SelectedItem.ToString();

                oCurencyRate = new Models.CurencyRate();
                int selectedIndex = cmdMCurency.SelectedIndex;
                Object selectedItem = cmdMCurency.SelectedItem;




                //MessageBox.Show("Selected Item Text: " + selectedItem.ToString() + "\n" +
                //                 "Index: " + selectedIndex.ToString());


                oCurencyRate = new Models.CurencyRate();


                oMobileClass.ExchangeRate = oCurencyRate.CurencyGet(cmdMCurency.SelectedItem.ToString(), System.Convert.ToDouble(txtmPurchasePrice.Text.Trim())).ToString();











                oDatabaseContext.Mobile.Add(oMobileClass);




                oDatabaseContext.SaveChanges();




                txtmOffice.Text = string.Empty;
                txtmBrand.Text = string.Empty;
                txtmModel.Text = string.Empty;

                txtmPurchasePrice.Text = string.Empty;




            }

            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            finally
            {
                if (oDatabaseContext != null)
                {
                    oDatabaseContext.Dispose();
                    oDatabaseContext = null;
                }
            }
            this.DisplayLaptop();
            this.DisplayMobile();

            BindDGV(db.LapTops.ToList());
            BindDGVM(mdb.Mobile.ToList());

        }






        private void DisplayLaptop()
        {

            Models.DatabaseContext oDatabaseContext = null;

            try
            {

                oDatabaseContext =
                    new Models.DatabaseContext();

                var varLapTop =
                    oDatabaseContext.LapTop
                    .ToList();






                lstlProdouct.DataSource = varLapTop;

                lstlProdouct.ValueMember = "ID";
                lstlProdouct.DisplayMember = "Office";
                lstlProdouct.ValueMember = "Brand";
                lstlProdouct.DisplayMember = "PurchaseDate";
                lstlProdouct.ValueMember = "PurchasePrice";
                lstlProdouct.DisplayMember = "Currency";
                lstlProdouct.DisplayMember = "ExchangeRate";

                lstlProdouct.DisplayMember = "mDisplayName";
            }


            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            finally
            {
                if (oDatabaseContext != null)
                {
                    oDatabaseContext.Dispose();
                    oDatabaseContext = null;
                }
            }
        }


        private void DisplaymMobile()
        {

            Models.DatabaseContext oDatabaseContext = null;

            try
            {

                oDatabaseContext =
                    new Models.DatabaseContext();



                var varMobile =
                   oDatabaseContext.Mobile
                   .ToList();




                lstlProdouct.DataSource = varMobile;

                lstlProdouct.ValueMember = "ID";
                lstlProdouct.DisplayMember = "Office";
                lstlProdouct.ValueMember = "Brand";
                lstlProdouct.DisplayMember = "PurchaseDate";
                lstlProdouct.ValueMember = "PurchasePrice";
                lstlProdouct.DisplayMember = "Currency";
                lstlProdouct.DisplayMember = "ExchangeRate";

              lstlProdouct.DisplayMember = "lDisplayName";
            }

            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            finally
            {
                if (oDatabaseContext != null)
                {
                    oDatabaseContext.Dispose();
                    oDatabaseContext = null;
                }
            }
        }



        private void DisplayLabtop()
        {



            try
            {

                oDatabaseContext =
                    new Models.DatabaseContext();

                var varLabtop =
                    oDatabaseContext.LapTop
                    .ToList();


                lstlProdouct.DataSource = varLabtop;

                lstlProdouct.ValueMember = "ID";
                lstlProdouct.DisplayMember = "Office";
                lstlProdouct.DisplayMember = "Brand";
                lstlProdouct.ValueMember = "Model";
                lstlProdouct.DisplayMember = "PurchaseDate";
                lstlProdouct.DisplayMember = "PurchasePrice";
                lstlProdouct.DisplayMember = "Currency";
                lstlProdouct.DisplayMember = "ExchangeRate";
            }

            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            finally
            {
                if (oDatabaseContext != null)
                {
                    oDatabaseContext.Dispose();
                    oDatabaseContext = null;
                }
            }
        }


        private void DisplayMobile()
        {



            try
            {

                oDatabaseContext =
                    new Models.DatabaseContext();

                var varLabtop =
                    oDatabaseContext.LapTop
                    .ToList();


                lstlProdouct.DataSource = varLabtop;

                lstlProdouct.ValueMember = "ID";
                lstlProdouct.DisplayMember = "Office";
                lstlProdouct.DisplayMember = "Brand";
                lstlProdouct.ValueMember = "Model";
                lstlProdouct.DisplayMember = "PurchaseDate";
                lstlProdouct.DisplayMember = "PurchasePrice";
                lstlProdouct.DisplayMember = "Currency";
                lstlProdouct.DisplayMember = "ExchangeRate";
            }

            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            finally
            {
                if (oDatabaseContext != null)
                {
                    oDatabaseContext.Dispose();
                    oDatabaseContext = null;
                }
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 0 && ch != 13)
            {
                e.Handled = true;
            }
        }

        private void btnDeleteL_Click(object sender, EventArgs e)
        {




            Models.DatabaseContext oDatabaseContext =
              new Models.DatabaseContext();



            oDatabaseContext.LapTop
                .Where(current => current.Model == txtModel.Text)
                .Load();




            if (oDatabaseContext.LapTop.Local.Count == 0)
            {
                System.Windows.Forms.MessageBox
                    .Show("There is no labtop with this name!");
            }

            else
            {



                Models.LapTopClass oLapTopClass =
                    oDatabaseContext.LapTop.Local[0];




                oDatabaseContext.LapTop.Remove(oLapTopClass);



                oDatabaseContext.SaveChanges();


                System.Windows.Forms.MessageBox
                    .Show("The Labtop deleted succefully!");
            }
            txtModel.Text = string.Empty;
        }

        private void btnDeleteM_Click(object sender, EventArgs e)
        {


            Models.DatabaseContext oDatabaseContext =
              new Models.DatabaseContext();



            oDatabaseContext.Mobile
                .Where(current => current.Model == txtmModel.Text)
                .Load();




            if (oDatabaseContext.Mobile.Local.Count == 0)
            {
                System.Windows.Forms.MessageBox
                    .Show("There is no Mobile with this name!");
            }

            else
            {



                Models.MobileClass oMobileClass =
                    oDatabaseContext.Mobile.Local[0];




                oDatabaseContext.Mobile.Remove(oMobileClass);



                oDatabaseContext.SaveChanges();


                System.Windows.Forms.MessageBox
                    .Show("The Mobile deleted succefully!");
            }
            txtmModel.Text= string.Empty;
        }

        private void BindDGV(List<Models.LapTopClass> lapTopClasses)
        {
            grdL.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grdL.DataSource = lapTopClasses;

        }

        private void BindDGVM(List<Models.MobileClass> MobileClasses)
        {
            dvgM.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dvgM.DataSource = MobileClasses;

        }

        private void grdL_DoubleClick(object sender, EventArgs e)
        {
            Models.LapTopClass oLapTopClass = new Models.LapTopClass();
            //if (grdL.CurrentRow.Index != -1)
            //{
            //    oLapTopClass.ID = System.Convert.ToInt32((grdL.CurrentRow.Cells["Id"].Value));

            //    using (Models.DatabaseContext dbl = new Models.DatabaseContext())
            //    {
            //        //Guid Dh = Guid.Parse(oLapTopClass.Model);
            //        oLapTopClass = dbl.LapTop.Where(x => x.ID == oLapTopClass.ID).FirstOrDefault();
            //        txtOffice.Text = oLapTopClass.Office;
            //        txtBrand.Text = oLapTopClass.Brand;
            //        txtModel.Text = oLapTopClass.Model;
            //        txtPrice.Text = oLapTopClass.PurchasePrice.ToString();
            //        btnSaveLaptop.Text = "Update";
            //    }
            //}
        }
    }
}
