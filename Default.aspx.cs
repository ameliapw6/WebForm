using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using Npgsql;

namespace WebForm
{
    public partial class _Default : Page
    {
        protected void btnInsertion_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["koneksiku"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "INSERT INTO MathKids(materi_id, mata_pelajaran, materi) VALUES (@materi_id, @mata_pelajaran, @materi)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@materi_id", Convert.ToInt32(txtMateriID.Text)));
                    cmd.Parameters.Add(new NpgsqlParameter("@mata_pelajaran", txtMataPelajaran.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@materi", txtMateri.Text));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                    txtMateriID.Text = "";
                    txtMataPelajaran.Text = "";
                    txtMateri.Text = "";
                    lblmsg.Text = "Data telah ditambahkan";
                }

            }
            catch (Exception ex) { }
        }
        protected void btnSelection_Click(object sender, EventArgs e)
        {
            try /* Select After Validations*/
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["koneksiku"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT * FROM MathKids";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex) { }
        }
        protected void btnUpdation_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["koneksiku"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "UPDATE MathKids SET mata_pelajaran=@mata_pelajaran, materi=@materi WHERE materi_id=@materi_id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@materi_id", Convert.ToInt32(txtMateriID.Text)));
                    cmd.Parameters.Add(new NpgsqlParameter("@mata_pelajaran", txtMataPelajaran.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@materi", txtMateri.Text));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                    txtMateriID.Text = "";
                    txtMataPelajaran.Text = "";
                    txtMateri.Text = "";
                    lblmsg.Text = "Data telah diupdate";

                }
            }
            catch (Exception ex) { }
        }
        protected void btnDeletion_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["koneksiku"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "DELETE FROM MathKids WHERE materi_id=@materi_id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@materi_id", Convert.ToInt32(txtMateriIDDel.Text)));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                    txtMateriIDDel.Text = "";
                    lblmessage.Text = "Data telah dihapus";

                }
            }
            catch (Exception ex) { }
        }
    }
}