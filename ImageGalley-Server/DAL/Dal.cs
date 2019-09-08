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
		public DataTable GetImages()
		{
			try
			{
				Connection.Open();
				SqlCommand command = new SqlCommand("GetImages", Connection);
				SqlDataAdapter adapter = new SqlDataAdapter(command);

				DataSet data = new DataSet();

				adapter.Fill(data);

				DataTable images = data.Tables[0];

				return images;
			}
			catch (Exception)
			{
				//throw new Exception(e.Message);
				return null;
			}
			finally
			{
				if (Connection != null && Connection.State == ConnectionState.Open)
				{
					Connection.Close();
				}
			}
		}

		// Create Image
		public DataSet InsertImage(string ImageId, string Uri, int Height, int Width, string Format, string CreatedAt)
		{
			try
			{
				Connection.Open();
				
				SqlCommand command = new SqlCommand("CreateImage", Connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("ImageId", ImageId));
				command.Parameters.Add(new SqlParameter("Uri", Uri));
				command.Parameters.Add(new SqlParameter("Height", Height));
				command.Parameters.Add(new SqlParameter("Width", Width));
				command.Parameters.Add(new SqlParameter("Format", Format));
				command.Parameters.Add(new SqlParameter("CreatedAt", CreatedAt));

				SqlDataAdapter adapter = new SqlDataAdapter(command);

				DataSet data = new DataSet();

				int rowsAffected = adapter.Fill(data);

				return rowsAffected == 0 ? null : data;
			}
			catch (Exception)
			{
				return null;
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