using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
	public class Dal : DalConfig
	{
		private static string connectionString;
		private static SqlConnection Connection;
		private static readonly object padlock = new object();
		private static Dal _instance = null;

		public static Dal Instance
		{
			get
			{
				lock (padlock)
				{
					if (_instance == null)
					{
						_instance = new Dal();
					}
					return _instance;
				}
			}
		}
		private Dal()
		{
			connectionString = ConnectionString;
			Connection = new SqlConnection(connectionString);
		}

		// Get All Images

		// Create Image
		public DataSet CreateImage(string Uri, int Height, int Width)
		{
			try
			{
				Connection.Open();
				SqlCommand command = new SqlCommand("CreateImage", Connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("Uri", Uri));
				command.Parameters.Add(new SqlParameter("Height", Height));
				command.Parameters.Add(new SqlParameter("Width", Width));

				SqlDataAdapter adapter = new SqlDataAdapter(command);

				DataSet data = new DataSet();

				int rows = adapter.Fill(data);

				return data;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			finally
			{
				if (Connection != null && Connection.State == ConnectionState.Open)
				{
					Connection.Close();
				}
			}
		}


	}
}