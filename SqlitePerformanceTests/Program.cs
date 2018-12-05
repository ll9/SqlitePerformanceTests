using Microsoft.Data.Sqlite;
using SqlitePerformanceTests.Models;
using System;
using System.Collections.Generic;

namespace SqlitePerformanceTests
{
    class Program
    {
        private const int Insertions = 500000;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MeasureTime("insert Transaction", () => InsertTransaction(Insertions));
            //MeasureTime("Insert", () => Insert(Insertions));
            MeasureTime("Map", () => Map());
            Console.ReadLine();
        }

        private static void MeasureTime(string msg, Action action)
        {
            var start = DateTime.Now;
            action();

            var duration = DateTime.Now.Subtract(start);
            Console.WriteLine($"{msg} took {{0:D2}}:{{1:D2}}", duration.Seconds, duration.Milliseconds);
        }

        private static SqliteConnection GetConnection()
        {
            var connection = new SqliteConnection("Data Source=bla.db");
            connection.Open();
            return connection;
        }

        private static void Insert(int n)
        {
            var query = "INSERT INTO Lichtpunkt(ort, straße, hausnummer) VALUES (@ort, @straße, @hausnummer)";
            var lichtpunkt = new Lichtpunkt { Hausnummer = 1, Ort = "Prien", Straße = "Seestraße" };

            using (var connection = GetConnection())
            using (var command = new SqliteCommand(query, connection))
            {
                command.Parameters.Add("@ort", SqliteType.Text);
                command.Parameters.Add("@straße", SqliteType.Integer);
                command.Parameters.Add("@hausnummer", SqliteType.Text);
                for (int i = 0; i < n; i++)
                {
                    command.Parameters["@ort"].Value = lichtpunkt.Ort;
                    command.Parameters["@straße"].Value = lichtpunkt.Straße;
                    command.Parameters["@hausnummer"].Value = lichtpunkt.Hausnummer;
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void InsertTransaction(int n)
        {
            var query = "INSERT INTO Lichtpunkt(ort, straße, hausnummer) VALUES (@ort, @straße, @hausnummer)";
            var lichtpunkt = new Lichtpunkt { Hausnummer = 1, Ort = "Prien", Straße = "Seestraße" };

            using (var connection = GetConnection())
            using (var transaction = connection.BeginTransaction())
            using (var command = new SqliteCommand(query, connection, transaction))
            {
                command.Parameters.Add("@ort", SqliteType.Text);
                command.Parameters.Add("@straße", SqliteType.Integer);
                command.Parameters.Add("@hausnummer", SqliteType.Text);
                for (int i = 0; i < n; i++)
                {
                    command.Parameters["@ort"].Value = lichtpunkt.Ort;
                    command.Parameters["@straße"].Value = lichtpunkt.Straße;
                    command.Parameters["@hausnummer"].Value = lichtpunkt.Hausnummer;
                    command.ExecuteNonQuery();
                }
                transaction.Commit();
            }
        }

        private static IEnumerable<Lichtpunkt> Map()
        {
            IList<Lichtpunkt> lps = new List<Lichtpunkt>();
            var query = "SELECT ort, straße, hausnummer FROM Lichtpunkt";

            using (var connection = GetConnection())
            using (var command = new SqliteCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    lps.Add(new Lichtpunkt { Ort = reader.GetString(0), Hausnummer = reader.GetInt32(1), Straße = reader.GetString(2) });
                }
            }
            return lps;
        }
    }
}
