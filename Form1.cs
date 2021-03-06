using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Rent
{
    public partial class Video_Rent : Form
    {
        Database_Class mydata = new Database_Class();  // connetion database string 
        
        public Video_Rent()
        {

            InitializeComponent();
            cust_loaddata();
            Movies_loaddata();  // load functions 
            Rental_loaddata();
            
        }
        public void cust_loaddata()  // customer load 
        {
            customer_view.DataSource = null;
            try
            {
                customer_view.DataSource = mydata.FillCustomer_Data();
                customer_view.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Movies_loaddata() // load movies 
        {
            movie_view.DataSource = null;
            try
            {
                movie_view.DataSource = mydata.FillMovies_Data();
                movie_view.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Rental_loaddata() // load data 
        {
            rental_rental.DataSource = null;
            try
            {
                rental_rental.DataSource = mydata.FillRental_Data();
                rental_rental.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ADD_CA_Click(object sender, EventArgs e) // add customer 
        {
            if (FirstName_tb.Text != "" && LastName_tb.Text != "" && Address_tb.Text != "" && Phone_tb.Text != "")
            {
                string message = mydata.CustomerInsert(FirstName_tb.Text, LastName_tb.Text, Phone_tb.Text, Address_tb.Text);
                MessageBox.Show(message);
                FirstName_tb.Text = "";
                LastName_tb.Text = "";
                Phone_tb.Text = "";
                Address_tb.Text = "";
                cust_loaddata();
            }
            else
            {
                MessageBox.Show("Fill required details then move ahead");
            }
        }

        private void video_rental_system_Load(object sender, EventArgs e)
        {

        }

        private void UPDATE_CL_Click(object sender, EventArgs e)  // update customer 
        {
            if (FirstName_tb.Text != "" && LastName_tb.Text != "" && Address_tb.Text != "" && Phone_tb.Text != "")
            {
                string message = mydata.CustomerUpdate(FirstName_tb.Text, LastName_tb.Text, Phone_tb.Text, Address_tb.Text);
                MessageBox.Show(message);
                FirstName_tb.Text = "";
                LastName_tb.Text = "";
                Phone_tb.Text = "";
                Address_tb.Text = "";
                cust_loaddata();
                
            }
            else
            {
                MessageBox.Show("please select the data which you want to update");
            }
        }

        private void grid_customer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string addvalue = customer_view.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                this.Text = "Row : " + e.RowIndex.ToString() + " Col : " + e.ColumnIndex.ToString() + " Value = " + addvalue;
                mydata.CustomerID = Convert.ToInt32(customer_view.Rows[e.RowIndex].Cells[0].Value);
                FirstName_tb.Text = customer_view.Rows[e.RowIndex].Cells[1].Value.ToString();
                LastName_tb.Text = customer_view.Rows[e.RowIndex].Cells[2].Value.ToString();
                Phone_tb.Text = customer_view.Rows[e.RowIndex].Cells[4].Value.ToString();
                Address_tb.Text = customer_view.Rows[e.RowIndex].Cells[3].Value.ToString();
                CustName_tb.Text = customer_view.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + customer_view.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message);
            }
        }


        private void DELETE_CL_Click(object sender, EventArgs e)
        {
            string message = mydata.CustomerDelete();
            MessageBox.Show(message);
            FirstName_tb.Text = "";
            LastName_tb.Text = "";
            Phone_tb.Text = "";
            Address_tb.Text = "";
            cust_loaddata();
        }

        private void ADD_btn_Click(object sender, EventArgs e)  // add button 
        {
            if (Rating_tb.Text != "" && Title_tb.Text != "" && Year_tb.Text != "" && Rental_Cost.Text != "" && Copies_tb.Text != "" && Plot_tb.Text != "" && Genre_tb.Text != "")
            {
                string message = mydata.MovieInsert(Rating_tb.Text, Title_tb.Text, Year_tb.Text, Rental_Cost.Text, Copies_tb.Text, Plot_tb.Text, Genre_tb.Text);
                MessageBox.Show(message);
                Rating_tb.Text = "";
                Title_tb.Text = "";
                Year_tb.Text = "";
                Rental_Cost.Text = "";
                Copies_tb.Text = "";
                Plot_tb.Text = "";
                Genre_tb.Text = "";
                Movies_loaddata();
            }
            else
            {
                MessageBox.Show("Fill required details then move ahead");
            }
        }

        private void Issue_Movie_Click(object sender, EventArgs e) // issue movie 
        {
            if (movie_tb.Text != "" && CustName_tb.Text != "")
            {
                string message = mydata.IssueMovie(Convert.ToDateTime(dateRented_tb.Text));
                MessageBox.Show(message);
                Rating_tb.Text = "";
                Title_tb.Text = "";
                Year_tb.Text = "";
                Rental_Cost.Text = "";
                Copies_tb.Text = "";
                Plot_tb.Text = "";
                Genre_tb.Text = "";
                movie_tb.Text = "";
                FirstName_tb.Text = "";
                LastName_tb.Text = "";
                Address_tb.Text = "";
                Phone_tb.Text = "";
                CustName_tb.Text = "";

                Rental_loaddata();
            }
            else
            {
                // code to show the message if user did not fill all the details
                MessageBox.Show("Please fill all the required details and add the new details with the help of ADD button");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        // grid views 
        private void grid_movie_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                string addvalue = movie_view.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                this.Text = "Row : " + e.RowIndex.ToString() + " Col : " + e.ColumnIndex.ToString() + " Value = " + addvalue;
                mydata.MovieID = Convert.ToInt32(movie_view.Rows[e.RowIndex].Cells[0].Value);
                Rating_tb.Text = movie_view.Rows[e.RowIndex].Cells[1].Value.ToString();
                Title_tb.Text = movie_view.Rows[e.RowIndex].Cells[2].Value.ToString();
                Year_tb.Text = movie_view.Rows[e.RowIndex].Cells[3].Value.ToString();
                Rental_Cost.Text = movie_view.Rows[e.RowIndex].Cells[4].Value.ToString();
                Copies_tb.Text = movie_view.Rows[e.RowIndex].Cells[5].Value.ToString();
                Plot_tb.Text = movie_view.Rows[e.RowIndex].Cells[6].Value.ToString();
                Genre_tb.Text = movie_view.Rows[e.RowIndex].Cells[7].Value.ToString();
                movie_tb.Text = movie_view.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {

                // code to show the message if user did not fill all the details
                MessageBox.Show("Something is wrong", ex.Message);
            }

        }

       
        private void Return_Movie_Click(object sender, EventArgs e)  // return movies 
        {
            if (movie_tb.Text != "" && CustName_tb.Text != "")
            {
                string message = mydata.ReturnMovie(Convert.ToDateTime(dateReturned_tb.Text));
                MessageBox.Show(message);
                Title_tb.Text = "";
                Rating_tb.Text = "";
               
                Year_tb.Text = "";
                Rental_Cost.Text = "";
                Copies_tb.Text = "";
                Plot_tb.Text = "";
                Genre_tb.Text = "";
                movie_tb.Text = "";
                FirstName_tb.Text = "";
                LastName_tb.Text = "";
                Phone_tb.Text = "";
                Address_tb.Text = "";
                CustName_tb.Text = "";
                Rental_loaddata();
            }
            else
            {
                // code to show the message if user did not fill all the details
                MessageBox.Show("Please fill all the required details and add new detail with the help of ADD button ");
            }
        }

        private void UPDATE_btn_Click(object sender, EventArgs e)  // update button 
        {
            if (Rating_tb.Text != "" && Title_tb.Text != "" && Year_tb.Text != "" && Rental_Cost.Text != "" && Copies_tb.Text != "" && Plot_tb.Text != "" && Genre_tb.Text != "")
            {
                string message = mydata.MovieUpdate( Title_tb.Text, Rating_tb.Text, Year_tb.Text, Rental_Cost.Text, Copies_tb.Text, Plot_tb.Text, Genre_tb.Text);
                MessageBox.Show(message);
                Rating_tb.Text = "";
                Title_tb.Text = "";
                Year_tb.Text = "";
                Rental_Cost.Text = "";
                Copies_tb.Text = "";
                Plot_tb.Text = "";
                Genre_tb.Text = "";
                Movies_loaddata();
            }
            else
            {
                // code to show the message if user did not fill all the details
                MessageBox.Show("fullfill the all givin detail then move ahead");
            }

        }

        private void DELET_btn_Click(object sender, EventArgs e)  // delete button for movies 
        {
            string message = mydata.MovieDelete();
            MessageBox.Show(message);
            Rating_tb.Text = "";
            Title_tb.Text = "";
            Year_tb.Text = "";
            Rental_Cost.Text = "";
            Copies_tb.Text = "";
            Plot_tb.Text = "";
            Genre_tb.Text = "";
            movie_tb.Text = "";
            Movies_loaddata();
        }

        private void AllMovies_Click(object sender, EventArgs e)  // all movies 
        {
            Rental_loaddata();
        }

        private void Video_Rent_Load(object sender, EventArgs e)
        {

        }

        private void popular_movie_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    
        private void RentedOut_Click(object sender, EventArgs e)
        {

        }

        private void popularcust_Click(object sender, EventArgs e)
        {

        }

        private void popularmov_Click(object sender, EventArgs e)
        {

        }

        private void rental_rental_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}





