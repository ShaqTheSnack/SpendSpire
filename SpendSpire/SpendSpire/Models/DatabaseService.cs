using System;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Linq;
namespace SpendSpire.Models
{
    public class DatabaseService
    {

        private static string connectionString = @"Data Source= YOUR DATABASE PATH;";

        public static void UpdateDatabase(string IsPicked, int Amount)
        {
            if (IsPicked == null)
            {
                IsPicked = "Nothing";
            }
            else
            { 
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText =   
                    $@"UPDATE PersonalBudgetData
                      SET {IsPicked} = $AmountOfMoney;
                    ";

                    command.Parameters.AddWithValue("$AmountOfMoney", Amount);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var name = reader.GetString(0);
                        }
                    }
                }
            }
        }

        public static BudgetInfoModel GetAllData()
        {
            BudgetInfoModel model = new();
            model.Budget.Clear();

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"SELECT * 
                  FROM PersonalBudgetData;";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for( int i = 4; i < reader.FieldCount; i++)
                        {
                            model.Budget.Add(reader.GetName(i), reader.GetInt32(i));
                        }
                    }
                }
            }
            return model;
        }
        public static BudgetInfoModel SeeAllData()
        {
            BudgetInfoModel SeeModel = new();
            SeeModel.Budget.Clear();

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"SELECT * 
                  FROM PersonalBudgetData;";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 1; i < reader.FieldCount; i++)
                        {
                            SeeModel.Budget.Add(reader.GetName(i), reader.GetInt32(i));
                        }
                    }
                }
            }
            return SeeModel;
        }

        public static BudgetInfoModel GetThreeData()
        {
            BudgetInfoModel threeModel = new();
            threeModel.Budget.Clear();

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"SELECT * 
                  FROM PersonalBudgetData;";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 1; i < 4 && i < reader.FieldCount; i++)
                        {
                            threeModel.Budget.Add(reader.GetName(i), reader.GetInt32(i));
                        }
                    }
                }
            }
            return threeModel;
        }

        public static void DeleteItemFromDatabase(int itemToDelete)
        {
            BudgetInfoModel budgetInfoModel = new BudgetInfoModel();

            if (itemToDelete < 0 || itemToDelete >= budgetInfoModel.AllCategory.Count)
            {
                return;
            }

            string categoryToDelete = budgetInfoModel.AllCategory[itemToDelete];

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                $@"UPDATE PersonalBudgetData
                 SET {categoryToDelete} = $AmountOfMoney
                 WHERE {categoryToDelete} IS NOT NULL;";

                command.Parameters.AddWithValue("$AmountOfMoney", 0);
                command.ExecuteNonQuery();
            }
        }

        public static void EditItemFromDatabase(int itemToDelete, int amount)
        {
            BudgetInfoModel budgetInfoModel = new BudgetInfoModel();

            if (itemToDelete < 0 || itemToDelete >= budgetInfoModel.AllCategory.Count)
            {
                return;
            }

            string categoryToDelete = budgetInfoModel.AllCategory[itemToDelete];

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                $@"UPDATE PersonalBudgetData
                 SET {categoryToDelete} = $AmountOfMoney
                 WHERE {categoryToDelete} IS NOT NULL;";

                command.Parameters.AddWithValue("$AmountOfMoney", amount);
                command.ExecuteNonQuery();
            }
        }

    }
}
