using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Xml;

namespace ClassWork_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string conString = "ClassWork_1.Properties.Settings.tect_sqlclient_dbConnectionString";

            Console.WriteLine("GetDataSetExample ----------------------------");
            GetDataSetExample(ConfigurationManager.ConnectionStrings[conString].ConnectionString);
            Console.WriteLine("----------------------------------------------");

            Task.Run(()=> SetXmlData(ConfigurationManager.ConnectionStrings[conString].ConnectionString));

            Console.WriteLine("WriteXmlSynk ---------------------------------");
            WriteXmlSynk(ConfigurationManager.ConnectionStrings[conString].ConnectionString);
            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("ReadXmlAsync ---------------------------------");
            Task.Run(() => ReadXmlAsync(ConfigurationManager.ConnectionStrings[conString].ConnectionString));
            Console.WriteLine("----------------------------------------------");

            Console.WriteLine();
            Console.WriteLine("Done");
            Console.ReadKey(); 
        }

        static void GetDataSetExample(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.StatisticsEnabled = true;

                string sqlstr = "SELECT * FROM courses";
                SqlDataAdapter sqladpt = new SqlDataAdapter(sqlstr, conn);
                DataSet ds = new DataSet();
                conn.Open();
                sqladpt.Fill(ds, "courses");

                IDictionary curr_Statistics = conn.RetrieveStatistics();

                Console.WriteLine("Total counters: " + curr_Statistics.Count.ToString());
                Console.WriteLine();

                long bytesReceived = (long)curr_Statistics["BytesReceived"];
                long bytesSent = (long)curr_Statistics["BytesSent"];
                long selectCount = (long)curr_Statistics["SelectCount"];
                long selectRows = (long)curr_Statistics["SelectRows"];

                Console.WriteLine("BytesReceived: " + bytesReceived.ToString());
                Console.WriteLine("BytesSent: " + bytesSent.ToString());
                Console.WriteLine("SelectCount: " + selectCount.ToString());
                Console.WriteLine("SelectRows: " + selectRows.ToString());

                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------");
                foreach (DictionaryEntry item in curr_Statistics)
                {
                    Console.WriteLine(item.Key + " - " + item.Value);
                }

                Console.WriteLine();

            }
        }

        static async Task SetXmlData(string connectionString)
        {
            string filePath = "bigdata_data.bin";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand("SELECT [bnr_clmn] FROM [course_data] WHERE [cd_id]=@id", connection))
                {
                    command.Parameters.AddWithValue("id", 4);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess))
                    {
                        if (await reader.ReadAsync())
                        {
                            if (!(await reader.IsDBNullAsync(0)))
                            {
                                using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                                {
                                    using (Stream data = reader.GetStream(0))
                                    {

                                        await data.CopyToAsync(file);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        static void WriteXmlSynk(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand("SELECT * FROM [course_data]", connection))
                {

                    SqlDataAdapter Mysqlad = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();

                    Mysqlad.Fill(ds, "course_data");
                    // Save this DataSet as XML.
                    ds.WriteXml("ds.xml");
                    ds.WriteXmlSchema("ds.xsd");
                    // Clear out DataSet.
                    ds.Clear();
                    // Load DataSet from XML file.

                    ds.ReadXml("ds.xml");
                    DataTable dt1 = ds.Tables["course_data"];
                    foreach (DataRow item in dt1.Rows)
                    {
                        Console.WriteLine(@"id: {0},  {1}, {2}, {3}:", item["cd_id"], item["course_id"], item["txt_clmn"], item["xml_clmn"]);
                        byte[] bt = (byte[])item["bnr_clmn"];
                        Console.WriteLine("Binary");
                        Console.WriteLine(System.Text.Encoding.UTF8.GetString(bt));
                    }

                }
            }
        }

        static async Task ReadXmlAsync(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand("SELECT [cd_id], [xml_clmn] FROM [course_data]", connection))
                {

                    using (SqlDataReader reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess))
                    {
                        while (await reader.ReadAsync())
                        {
                            Console.WriteLine("{0}: ", reader.GetInt32(0));

                            if (await reader.IsDBNullAsync(1))
                            {
                                Console.WriteLine("\t(NULL)");
                            }
                            else
                            {
                                using (XmlReader xmlReader = reader.GetXmlReader(1))
                                {
                                    int depth = 1;

                                    while (xmlReader.Read())
                                    {
                                        switch (xmlReader.NodeType)
                                        {
                                            case XmlNodeType.Element:
                                                Console.WriteLine("{0}<{1}>", new string('\t', depth), xmlReader.Name);
                                                depth++;
                                                break;
                                            case XmlNodeType.Text:
                                                Console.WriteLine("{0}{1}", new string('\t', depth), xmlReader.Value);
                                                break;
                                            case XmlNodeType.EndElement:
                                                depth--;
                                                Console.WriteLine("{0}</{1}>", new string('\t', depth), xmlReader.Name);
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
