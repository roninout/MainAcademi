using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Hello_DataSets
{
    class DB_work
    {
        // declare    Common_db MyDBtest
        Common_db MyDBtest;
        // implement DB_work(string conn) constructor to initiate MyDBtest
        //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="D:\С#\MainAcademy\MA\Basics\Module 5\Lesson_4\ado_net_174\Hello_DataSets\tect_common_db.mdf";Integrated Security=True;Connect Timeout=30

        public DB_work(string conn)
        {
            //Common_db MyDBtest = new Common_db(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\""D:\С#\MainAcademy\MA\Basics\Module 5\Lesson_4\ado_net_174\Hello_DataSets\tect_common_db.mdf\"";Integrated Security=True;Connect Timeout=30");
            MyDBtest = new Common_db(conn);
        }


        // implement  void DB_conn() to check the MyDBtest
        public void DB_conn()
        {
            // try check connection using MyConnect() and MyDisConnect()
            MyDBtest.MyConnect();

        }



        // implement void Courses_Update_ds(string table_name, string key, string key_value, string clmn, string clmn_value)
        // to update table_name using MyDBtest.MyTable_update_ds method with parameters in try-catch block



        // implement void Courses_Insert_bldr(string table_name, string key,  string [] clmn, string[] clmn_value)
        // to insert into table_name using MyDBtest.MyTable_insert_bldr method with parameters in try-catch block



        // implement void Courses_Update_bldr(string table_name, string key, string key_value, string clmn, string clmn_value)
        // to update table_name using MyDBtest.MyTable_update_bldr method with parameters in try-catch block



        // implement void Courses_Update(string table_name, string key, string key_value, string clmn, string clmn_value)
        // to update table_name using MyDBtest.MyTable_update method with parameters in try-catch block

        //create new DataTable object and define its TableName property

        //call MyDBtest.MyTable_update with parameters



        // implement void Courses_Read(string table_name) method
        // to read table_name using MyDBtest.MyTable_read method with parameters in try-catch block

        //create new DataTable object and define its TableName property

        //call MyDBtest.MyTable_read with parameter
        //foreach DataRow item  write its value to the console



        // implement Courses_Delete(string table_name, string key, string key_value) method
        // to delete row from the table_name using MyDBtest.MyTable_delete method with parameters in try-catch block

        //create new DataTable object and define its TableName property

        //call MyDBtest.MyTable_delete with parameters


    }
}
