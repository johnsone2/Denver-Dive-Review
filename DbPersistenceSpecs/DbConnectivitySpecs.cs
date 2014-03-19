using System.Configuration;
using Npgsql;
using NUnit.Framework;

namespace DbPersistenceSpecs
{
    [TestFixture]
    public class DbConnectivitySpecs
    {
        private static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["diveDb"].ConnectionString;

        [Test]
        public void We_should_be_able_to_connect_to_the_db()
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "select 1;";
                command.ExecuteNonQuery();
                connection.Close();
            }
            
            // passes if no exception thrown.
        }
    }
}
