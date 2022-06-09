using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.SQLite;
using System.Data.SQLite.Linq;

namespace Soundboard
{
    class DBAdapter
    {
        /// <summary>
        /// Opens Connection
        /// </summary>
        /// <param name="dbPath"></param>
        /// <returns></returns>
        private static SQLiteConnection openDBase(string dbPath)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
            connection.Open();

            return connection;
        }

        // ----------------------

        /// <summary>
        /// Creates database with empty tables
        /// </summary>
        /// <param name="dbPath">Path</param>
        public static void CreateDatabase(string dbPath)
        {
            SQLiteConnection.CreateFile(dbPath);

            SQLiteConnection connection = openDBase(dbPath);
            SQLiteCommand command = new SQLiteCommand(connection);

            command.CommandText = @"CREATE TABLE IF NOT EXISTS [Library] (
                [name] NVARCHAR(256) NOT NULL,
                [hotkey] NVARCHAR(256)
                )";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE IF NOT EXISTS [Settings] (
                        [name] NVARCHAR(256) NOT NULL UNIQUE,
                        [value] NVARCHAR(256) NOT NULL
                        )";
            command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();
        }

        /// <summary>
        /// Gets all Audio Files located in the database
        /// </summary>
        /// <param name="dbPath"></param>
        /// <returns></returns>
        public static List<string> GetAllFiles(string dbPath)
        {
            SQLiteConnection connection = openDBase(dbPath);
            SQLiteCommand command = new SQLiteCommand(connection);

            List<string> results = new List<string>();

            command.CommandText = String.Format("SELECT * FROM Library");

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                results.Add(reader["name"].ToString());
            }

            command.Dispose();
            connection.Close();

            return results;
        }

        /// <summary>
        /// Adds an audio file to the library
        /// </summary>
        /// <param name="dbPath"></param>
        /// <param name="filename"></param>
        public static void AddAudioFile(string dbPath, string filename)
        {
            SQLiteConnection connection = openDBase(dbPath);
            SQLiteCommand command = new SQLiteCommand(connection);

            command.CommandText = String.Format("INSERT INTO Library (name, hotkey) VALUES ('{0}', '')", filename);
            command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();
        }

        /// <summary>
        /// Deletes an audio file fron the database
        /// </summary>
        /// <param name="dbPath"></param>
        /// <param name="filename"></param>
        public static void DeleteAudioFile(string dbPath, string filename)
        {
            SQLiteConnection connection = openDBase(dbPath);
            SQLiteCommand command = new SQLiteCommand(connection);

            command.CommandText = String.Format("DELETE FROM Library WHERE name='{0}'", filename);
            command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();
        }

        /// <summary>
        /// Gets the value from specific setting
        /// </summary>
        /// <param name="dbPath"></param>
        /// <param name="valueName"></param>
        /// <returns></returns>
        public static string GetSetting(string dbPath, string valueName)
        {
            SQLiteConnection connection = openDBase(dbPath);
            SQLiteCommand command = new SQLiteCommand(connection);

            string result = null;

            command.CommandText = String.Format("SELECT * FROM Settings WHERE name='{0}'", valueName);

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result = reader["value"].ToString();
            }

            command.Dispose();
            connection.Close();

            return result;
        }

        /// <summary>
        /// Updates a specific setting if already exists and creates a new Value if not
        /// </summary>
        /// <param name="dbPath"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void UpdateOrSetSetting(string dbPath, string name, string value)
        {
            SQLiteConnection connection = openDBase(dbPath);
            SQLiteCommand command = new SQLiteCommand(connection);

            command.CommandText = String.Format("INSERT OR IGNORE INTO Settings (name, value) VALUES ('{0}', '{1}')", name, value);
            command.ExecuteNonQuery();

            command.CommandText = String.Format("UPDATE Settings SET value='{0}' WHERE name='{1}'", value, name);
            command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();
        }

        /// <summary>
        /// Updates or sets hotkey
        /// </summary>
        /// <param name="dbPath"></param>
        /// <param name="name"></param>
        /// <param name="hotkey"></param>
        public static void UpdateOrSetHotkey(string dbPath, string name, string hotkey)
        {
            SQLiteConnection connection = openDBase(dbPath);
            SQLiteCommand command = new SQLiteCommand(connection);

            command.CommandText = String.Format("UPDATE Library SET hotkey = '{0}' WHERE name = '{1}'", hotkey, name);
            command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();
        }

        /// <summary>
        /// Gets all Pairs where hotkey is not NULL.
        /// </summary>
        /// <param name="dbPath"></param>
        /// <returns></returns>
        public static Dictionary<string, Keys> GetAllHotkeys(string dbPath)
        {
            SQLiteConnection connection = openDBase(dbPath);
            SQLiteCommand command = new SQLiteCommand(connection);

            Dictionary<string, Keys> results = new Dictionary<string, Keys>();

            command.CommandText = String.Format("SELECT * FROM Library WHERE hotkey!=''");

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Keys key = (Keys)Enum.Parse(typeof(Keys), reader["hotkey"].ToString());
                string name = reader["name"].ToString();
                results.Add(name, key);
            }

            command.Dispose();
            connection.Close();

            return results;
        }

        /// <summary>
        /// Gets single hotkey from name
        /// </summary>
        /// <param name="dbPath"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Keys GetSingleHotkey(string dbPath, string name)
        {
            SQLiteConnection connection = openDBase(dbPath);
            SQLiteCommand command = new SQLiteCommand(connection);

            Keys result  = new Keys();

            command.CommandText = String.Format("SELECT * FROM Library WHERE name='{0}'", name);

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result = (Keys)Enum.Parse(typeof(Keys), reader["hotkey"].ToString());
            }

            command.Dispose();
            connection.Close();

            return result;
        }
    }
}
