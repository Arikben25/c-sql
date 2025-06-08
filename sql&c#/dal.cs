using System;
using MySql.Data.MySqlClient;

internal class DAL
{
    private string connStr = "server=localhost;username=root;password=;database=classicmodels";
    private MySqlConnection conn;

    internal DAL()
    {

        conn = new MySqlConnection(connStr);
    }





    public void Agent_nformation()
    {
        //using (MySqlConnection conn = new MySqlConnection(connStr)){}

        try
        {
            conn.Open();
            string query = "SELECT agentName,code_agent FROM agent";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string agentName = reader.GetString("agentName");
                string code_agent = reader["code_agent"].ToString();

                Console.WriteLine($"name is: {agentName} code agent is {code_agent}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"err: {ex}");
        }
        finally
        {
            conn.Close();
        }

    }


    public void add_agent(int code, string name, string loction, int sum_tasks)
    {
        try
        {
            conn.Open();
            string query = $"INSERT INTO agent (`code_agent`,`agentName`,`localAgent`,`amount_of_tasks` ) VALUES({code} {name} {loction} {sum_tasks})";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            var into = cmd.ExecuteNonQuery();

        }
    }
}
