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
    public partial class MySecondCustmControl : UserControl
    {
        private List<Panel> Numbers = new List<Panel>();

        public MySecondCustmControl()
        {
            InitializeComponent();
        }
    }
}
