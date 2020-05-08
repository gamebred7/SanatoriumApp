using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

namespace FastFoodDemo
{
    public partial class FirstCustomControl : UserControl
    {
        public FirstCustomControl()
        {
            InitializeComponent();
            MinPriceNumber();
        }

        public void MinPriceNumber()
        {
            string provider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                DbCommand command = factory.CreateCommand();

                command.Connection = connection;
                command.CommandText = "SELECT RoomNumber, RoomCategory, RoomPrice FROM Room WHERE RoomPrice = (SELECT MIN(RoomPrice) From Room)";

                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        label2.Text = "$" + dataReader["RoomPrice"].ToString();
                        label4.Text = "Room №" + dataReader["RoomNumber"].ToString();
                        String category =dataReader["RoomCategory"].ToString() ; 
                        category.Replace(" ", String.Empty);

                        if (category == "Люкс        ")
                            category = "LUXURY";
                        if (category == "Стандарт")
                            category = "STANDARD";
                        if (category == "Эконом    ")
                            category = "ECONOMY";
                        label5.Text = "CATEGORY: " + category;
                    }
                }
            }
        }
    }
}
