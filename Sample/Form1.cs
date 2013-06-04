using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate.Cfg;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Data.Metadata.Edm;
using OrderManagement.DTO;

namespace Sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var configuration = new Configuration();

            configuration.Properties.Add("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
            configuration.Properties.Add("connection.isolation", "ReadCommitted");
            configuration.Properties.Add("proxyfactory.factory_class", "NHibernate.ByteCode.LinFu.ProxyFactoryFactory, NHibernate.ByteCode.LinFu");
            configuration.Properties.Add("connection.connection_string", @"data source=.\SQLEXPRESS;attachdbfilename=|DataDirectory|\Northwind.mdf;integrated security=True;user instance=True;multipleactiveresultsets=True;App=EntityFramework&quot;");
            configuration.Properties.Add("connection.driver_class", "NHibernate.Driver.SqlClientDriver");
            configuration.Properties.Add("dialect", "NHibernate.Dialect.MsSql2008Dialect");
            configuration.AddAssembly(this.GetType().Assembly);

            using (var sessionFactory = configuration.BuildSessionFactory())
            {
                using (var session = sessionFactory.OpenSession())
                {
                    var criteria = session.CreateCriteria(typeof(Customer));
                    criteria.SetResultTransformer(NHibernate.Transform.Transformers.DistinctRootEntity);
                    var list = criteria.List<Customer>();

                    customerDataGridView.DataSource = list;
                }
            }
        }
    }
}
