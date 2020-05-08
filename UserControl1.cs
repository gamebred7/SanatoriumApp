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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            PopularTreatmentPrograms();
        }

        public void PopularTreatmentPrograms()
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
                command.CommandText = "EXECUTE PopularTreatmentPrograms";

                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    int n = 0;
                    while (dataReader.Read() && n<3)
                    {
                        if (n == 0)
                        {
                            label1.Text = dataReader["ProgramName"].ToString();
                            label4.Text = "$" + dataReader["ProgramPrice"].ToString();
                            label19.Text = "Duration: "+dataReader["ProgramDuration"].ToString()+" days";
                        }
                        if (n == 1)
                        {
                            label12.Text = dataReader["ProgramName"].ToString();
                            label11.Text = "$" + dataReader["ProgramPrice"].ToString();
                            label21.Text = "Duration: "+dataReader["ProgramDuration"].ToString()+" days";
                        }
                        if (n == 2)
                        {
                            label8.Text = dataReader["ProgramName"].ToString();
                            label7.Text = "$" + dataReader["ProgramPrice"].ToString();
                            label20.Text = "Duration: "+dataReader["ProgramDuration"].ToString()+ " days";
                        }
                        n++;
                    }
                }
            }
        }
    }
}
