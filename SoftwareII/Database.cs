using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SoftwareII
{
    public static class Database
    {


        // Make the connection to the database
        public static MySqlConnection connection { get; set; }
        public static List<User> DatabaseUsers { get; set; }

        public static List<Customer> DatabaseCustomers { get; set; }

        public static User loggedInUser { get; set; }


        


        
        public static void Connect()
        {
            try
            {

                // Get the connection string from the config
                string connectionString = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;


                connection = new MySqlConnection(connectionString);
                connection.Open();

             
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void Disconnect()
        {
            try
            {
                if (connection != null)
                {
                    connection.Close();
                }
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static List<User> GetUsers()
        {
            var users = new List<User>();

            try
            {
                // Ensure the database connection is open
                if (connection.State != System.Data.ConnectionState.Open)
                    Connect();

                var command = new MySqlCommand("SELECT * FROM user", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            UserId = Convert.ToInt32(reader["userId"]),
                            UserName = Convert.ToString(reader["userName"]),
                            Password = Convert.ToString(reader["password"]),
                            Active = Convert.ToInt32(reader["active"])
                        });
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return users;
        }


        public static List<Customer> GetCustomers()
        {
            var customers = new List<Customer>();

            try
            {
                // Ensure the database connection is open
                if (connection.State != System.Data.ConnectionState.Open)
                    Connect();

                var command = new MySqlCommand(@"
            SELECT customer.customerId, customer.customerName, address.address, address.address2, city.city, address.postalCode, address.phone, country.country, customer.active
            FROM customer
            JOIN address ON customer.addressId = address.addressId
            JOIN city ON address.cityId = city.cityId
            JOIN country ON city.countryId = country.countryId", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            CustomerId = Convert.ToInt32(reader["customerId"]),
                            CustomerName = Convert.ToString(reader["customerName"]),
                            Address = Convert.ToString(reader["address"]),
                            Address2 = Convert.ToString(reader["address2"]),
                            City = Convert.ToString(reader["city"]),
                            PostalCode = Convert.ToString(reader["postalCode"]),
                            Phone = Convert.ToString(reader["phone"]),
                            Country = Convert.ToString(reader["country"]),
                            Active = Convert.ToInt32(reader["active"])
                        });
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return customers;
        }

        public static void AddCustomer(Customer customer)
        {
            try
            {
                // Ensure the database connection is open
                if (connection.State != System.Data.ConnectionState.Open)
                    Connect();

                // Get the current UTC time
                DateTime utcTime = DateTime.UtcNow;
                string formattedUtcTime = utcTime.ToString("yyyy-MM-dd HH:mm:ss");
                string currentUser = loggedInUser.UserName;

                // Insert into the country table if the country does not exist
                var countryCommand = new MySqlCommand(@"
            INSERT IGNORE INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy)
            VALUES (@country, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)", connection);
                countryCommand.Parameters.AddWithValue("@country", customer.Country);
                countryCommand.Parameters.AddWithValue("@createDate", formattedUtcTime);
                countryCommand.Parameters.AddWithValue("@createdBy", currentUser);
                countryCommand.Parameters.AddWithValue("@lastUpdate", formattedUtcTime);
                countryCommand.Parameters.AddWithValue("@lastUpdateBy", currentUser);
                countryCommand.ExecuteNonQuery();

                // Insert into the city table if the city does not exist
                var cityCommand = new MySqlCommand(@"
            INSERT IGNORE INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy)
            VALUES (@city, (SELECT countryId FROM country WHERE country = @country), @createDate, @createdBy, @lastUpdate, @lastUpdateBy)", connection);
                cityCommand.Parameters.AddWithValue("@city", customer.City);
                cityCommand.Parameters.AddWithValue("@country", customer.Country);
                cityCommand.Parameters.AddWithValue("@createDate", formattedUtcTime);
                cityCommand.Parameters.AddWithValue("@createdBy", currentUser);
                cityCommand.Parameters.AddWithValue("@lastUpdate", formattedUtcTime);
                cityCommand.Parameters.AddWithValue("@lastUpdateBy", currentUser);
                cityCommand.ExecuteNonQuery();

                // Insert into the address table
                var addressCommand = new MySqlCommand(@"
            INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy)
            VALUES (@address, @address2, (SELECT cityId FROM city WHERE city = @city), @postalCode, @phone, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)", connection);
                addressCommand.Parameters.AddWithValue("@address", customer.Address);
                addressCommand.Parameters.AddWithValue("@address2", customer.Address2);
                addressCommand.Parameters.AddWithValue("@city", customer.City);
                addressCommand.Parameters.AddWithValue("@postalCode", customer.PostalCode);
                addressCommand.Parameters.AddWithValue("@phone", customer.Phone);
                addressCommand.Parameters.AddWithValue("@createDate", formattedUtcTime);
                addressCommand.Parameters.AddWithValue("@createdBy", currentUser);
                addressCommand.Parameters.AddWithValue("@lastUpdate", formattedUtcTime);
                addressCommand.Parameters.AddWithValue("@lastUpdateBy", currentUser);
                addressCommand.ExecuteNonQuery();

                // Insert into the customer table
                var customerCommand = new MySqlCommand(@"
            INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy)
            VALUES (@customerName, LAST_INSERT_ID(), @active, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)", connection);
                customerCommand.Parameters.AddWithValue("@customerName", customer.CustomerName);
                customerCommand.Parameters.AddWithValue("@active", customer.Active);
                customerCommand.Parameters.AddWithValue("@createDate", formattedUtcTime);
                customerCommand.Parameters.AddWithValue("@createdBy", currentUser);
                customerCommand.Parameters.AddWithValue("@lastUpdate", formattedUtcTime);
                customerCommand.Parameters.AddWithValue("@lastUpdateBy", currentUser);
                customerCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void DeleteCustomer(Customer customer)
        {
            try
            {
                // Confirm deletion with the user
                var confirmResult = MessageBox.Show("Are you sure you want to delete the customer record?", "Confirmation", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.No)
                {
                    return;
                }

                // Ensure the database connection is open
                if (connection.State != System.Data.ConnectionState.Open)
                    Connect();

                // Delete from the customer table
                var customerCommand = new MySqlCommand(@"
                DELETE FROM customer 
                WHERE customerId = @customerId", connection);
                customerCommand.Parameters.AddWithValue("@customerId", customer.CustomerId);
                customerCommand.ExecuteNonQuery();

                // Delete unassociated records from the address table
                var deleteUnassociatedAddressCommand = new MySqlCommand(@"
                DELETE FROM address
                WHERE addressId NOT IN (SELECT addressId FROM customer)", connection);
                deleteUnassociatedAddressCommand.ExecuteNonQuery();

                // Delete unassociated records from the city table
                var deleteUnassociatedCityCommand = new MySqlCommand(@"
                DELETE FROM city
                WHERE cityId NOT IN (SELECT cityId FROM address)", connection);
                deleteUnassociatedCityCommand.ExecuteNonQuery();

                // Delete unassociated records from the country table
                var deleteUnassociatedCountryCommand = new MySqlCommand(@"
                DELETE FROM country
                WHERE countryId NOT IN (SELECT countryId FROM city)", connection);
                deleteUnassociatedCountryCommand.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void UpdateCustomer(Customer customer)
        {
            try
            {
                // Ensure the database connection is open
                if (connection.State != System.Data.ConnectionState.Open)
                    Connect();

                // Get the current UTC time
                DateTime utcTime = DateTime.UtcNow;
                string formattedUtcTime = utcTime.ToString("yyyy-MM-dd HH:mm:ss");
                string currentUser = loggedInUser.UserName;

                // Check if the country exists
                var countryIdCommand = new MySqlCommand("SELECT countryId FROM country WHERE country = @country", connection);
                countryIdCommand.Parameters.AddWithValue("@country", customer.Country);
                var countryIdObj = countryIdCommand.ExecuteScalar();
                int countryId;

                // If country doesn't exist, create new country
                if (countryIdObj == null)
                {
                    var insertCountryCommand = new MySqlCommand("INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@country, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)", connection);
                    insertCountryCommand.Parameters.AddWithValue("@country", customer.Country);
                    insertCountryCommand.Parameters.AddWithValue("@createDate", formattedUtcTime);
                    insertCountryCommand.Parameters.AddWithValue("@createdBy", currentUser);
                    insertCountryCommand.Parameters.AddWithValue("@lastUpdate", formattedUtcTime);
                    insertCountryCommand.Parameters.AddWithValue("@lastUpdateBy", currentUser);
                    insertCountryCommand.ExecuteNonQuery();

                    countryId = Convert.ToInt32(insertCountryCommand.LastInsertedId);
                }
                else
                {
                    countryId = Convert.ToInt32(countryIdObj);
                }

                // Similar process for the city
                var cityIdCommand = new MySqlCommand("SELECT cityId FROM city WHERE city = @city AND countryId = @countryId", connection);
                cityIdCommand.Parameters.AddWithValue("@city", customer.City);
                cityIdCommand.Parameters.AddWithValue("@countryId", countryId);
                var cityIdObj = cityIdCommand.ExecuteScalar();
                int cityId;

                if (cityIdObj == null)
                {
                    var insertCityCommand = new MySqlCommand("INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@city, @countryId, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)", connection);
                    insertCityCommand.Parameters.AddWithValue("@city", customer.City);
                    insertCityCommand.Parameters.AddWithValue("@countryId", countryId);
                    insertCityCommand.Parameters.AddWithValue("@createDate", formattedUtcTime);
                    insertCityCommand.Parameters.AddWithValue("@createdBy", currentUser);
                    insertCityCommand.Parameters.AddWithValue("@lastUpdate", formattedUtcTime);
                    insertCityCommand.Parameters.AddWithValue("@lastUpdateBy", currentUser);
                    insertCityCommand.ExecuteNonQuery();

                    cityId = Convert.ToInt32(insertCityCommand.LastInsertedId);
                }
                else
                {
                    cityId = Convert.ToInt32(cityIdObj);
                }


                // Update the address table
                var addressCommand = new MySqlCommand(@"
            UPDATE address
            SET address = @address, address2 = @address2, postalCode = @postalCode, phone = @phone, lastUpdate = @lastUpdate, lastUpdateBy = @lastUpdateBy, cityId = @cityId
            WHERE addressId = (SELECT addressId FROM customer WHERE customerId = @customerId)", connection);
                addressCommand.Parameters.AddWithValue("@address", customer.Address);
                addressCommand.Parameters.AddWithValue("@address2", customer.Address2);
                addressCommand.Parameters.AddWithValue("@postalCode", customer.PostalCode);
                addressCommand.Parameters.AddWithValue("@phone", customer.Phone);
                addressCommand.Parameters.AddWithValue("@lastUpdate", formattedUtcTime);
                addressCommand.Parameters.AddWithValue("@lastUpdateBy", currentUser);
                addressCommand.Parameters.AddWithValue("@cityId", cityId);
                addressCommand.Parameters.AddWithValue("@customerId", customer.CustomerId);
                addressCommand.ExecuteNonQuery();

                // Update the customer table
                var customerCommand = new MySqlCommand(@"
            UPDATE customer
            SET customerName = @customerName, active = @active, lastUpdate = @lastUpdate, lastUpdateBy = @lastUpdateBy
            WHERE customerId = @customerId", connection);
                customerCommand.Parameters.AddWithValue("@customerName", customer.CustomerName);
                customerCommand.Parameters.AddWithValue("@active", customer.Active);
                customerCommand.Parameters.AddWithValue("@lastUpdate", formattedUtcTime);
                customerCommand.Parameters.AddWithValue("@lastUpdateBy", currentUser);
                customerCommand.Parameters.AddWithValue("@customerId", customer.CustomerId);
                customerCommand.ExecuteNonQuery();




                // Delete unassociated records from the address table
                var deleteUnassociatedAddressCommand = new MySqlCommand(@"
                DELETE FROM address
                WHERE addressId NOT IN (SELECT addressId FROM customer)", connection);
                deleteUnassociatedAddressCommand.ExecuteNonQuery();

                // Delete unassociated records from the city table
                var deleteUnassociatedCityCommand = new MySqlCommand(@"
                DELETE FROM city
                WHERE cityId NOT IN (SELECT cityId FROM address)", connection);
                deleteUnassociatedCityCommand.ExecuteNonQuery();

                // Delete unassociated records from the country table
                var deleteUnassociatedCountryCommand = new MySqlCommand(@"
                DELETE FROM country
                WHERE countryId NOT IN (SELECT countryId FROM city)", connection);
                deleteUnassociatedCountryCommand.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static List<Appointment> GetAppointments()
        {
            var appointments = new List<Appointment>();

            try
            {
                // Ensure the database connection is open
                if (connection.State != System.Data.ConnectionState.Open)
                    Connect();

                var command = new MySqlCommand(@"
            SELECT appointmentId, customerId, userId, type, start, end, createDate, createdBy, lastUpdate, lastUpdateBy 
            FROM appointment", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        appointments.Add(new Appointment
                        {
                            AppointmentId = Convert.ToInt32(reader["appointmentId"]),
                            CustomerId = Convert.ToInt32(reader["customerId"]),
                            UserId = Convert.ToInt32(reader["userId"]),
                            Type = Convert.ToString(reader["type"]),
                            Start = Convert.ToDateTime(reader["start"]).ToLocalTime(),
                            End = Convert.ToDateTime(reader["end"]).ToLocalTime(),
                            CreateDate = Convert.ToDateTime(reader["createDate"]).ToLocalTime(),
                            CreatedBy = Convert.ToString(reader["createdBy"]),
                            LastUpdate = Convert.ToDateTime(reader["lastUpdate"]).ToLocalTime(),
                            LastUpdateBy = Convert.ToString(reader["lastUpdateBy"])
                        });
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return appointments;
        }

        public static void AddAppointment(Appointment appointment)
        {
            try
            {
                // Ensure the database connection is open
                if (connection.State != System.Data.ConnectionState.Open)
                    Connect();

                // Get the current UTC time
                DateTime utcTime = DateTime.UtcNow;
                string formattedUtcTime = utcTime.ToString("yyyy-MM-dd HH:mm:ss");
                string currentUser = loggedInUser.UserName;

                // Convert local times to UTC
                string startUtcTime = appointment.Start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss");
                string endUtcTime = appointment.End.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss");

                // Insert into the appointment table
                var appointmentCommand = new MySqlCommand(@"
        INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy)
        VALUES (@customerId, @userId, @title, @description, @location, @contact, @type, @url, @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)", connection);

                appointmentCommand.Parameters.AddWithValue("@customerId", appointment.CustomerId);
                appointmentCommand.Parameters.AddWithValue("@userId", appointment.UserId);
                appointmentCommand.Parameters.AddWithValue("@title", "Not needed");
                appointmentCommand.Parameters.AddWithValue("@description", "Not needed");
                appointmentCommand.Parameters.AddWithValue("@location", "Not needed");
                appointmentCommand.Parameters.AddWithValue("@contact", "Not needed");
                appointmentCommand.Parameters.AddWithValue("@type", appointment.Type);
                appointmentCommand.Parameters.AddWithValue("@url", "Not needed");
                appointmentCommand.Parameters.AddWithValue("@start", startUtcTime);
                appointmentCommand.Parameters.AddWithValue("@end", endUtcTime);
                appointmentCommand.Parameters.AddWithValue("@createDate", formattedUtcTime);
                appointmentCommand.Parameters.AddWithValue("@createdBy", currentUser);
                appointmentCommand.Parameters.AddWithValue("@lastUpdate", formattedUtcTime);
                appointmentCommand.Parameters.AddWithValue("@lastUpdateBy", currentUser);

                appointmentCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public static void UpdateAppointment(Appointment appointment)
        {
            try
            {
                // Ensure the database connection is open
                if (connection.State != System.Data.ConnectionState.Open)
                    Connect();

                // Get the current UTC time
                DateTime utcTime = DateTime.UtcNow;
                string formattedUtcTime = utcTime.ToString("yyyy-MM-dd HH:mm:ss");
                string currentUser = loggedInUser.UserName;

                // Set appointment local time to UTC
                appointment.Start = appointment.Start.ToUniversalTime();
                appointment.End = appointment.End.ToUniversalTime();

                // Prepare the SQL command to update the appointment
                var appointmentCommand = new MySqlCommand(@"
            UPDATE appointment
            SET customerId = @customerId, userId = @userId, type = @type, start = @start, end = @end, 
            lastUpdate = @lastUpdate, lastUpdateBy = @lastUpdateBy
            WHERE appointmentId = @appointmentId", connection);

                // Fill in the parameters with the data from the appointment object
                appointmentCommand.Parameters.AddWithValue("@customerId", appointment.CustomerId);
                appointmentCommand.Parameters.AddWithValue("@userId", appointment.UserId);
                appointmentCommand.Parameters.AddWithValue("@type", appointment.Type);
                appointmentCommand.Parameters.AddWithValue("@start", appointment.Start.ToString("yyyy-MM-dd HH:mm:ss"));
                appointmentCommand.Parameters.AddWithValue("@end", appointment.End.ToString("yyyy-MM-dd HH:mm:ss"));
                appointmentCommand.Parameters.AddWithValue("@lastUpdate", formattedUtcTime);
                appointmentCommand.Parameters.AddWithValue("@lastUpdateBy", currentUser);
                appointmentCommand.Parameters.AddWithValue("@appointmentId", appointment.AppointmentId);

                // Execute the command
                appointmentCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void DeleteAppointment(Appointment appointment)
        {
            try
            {
                // Ensure the database connection is open
                if (connection.State != System.Data.ConnectionState.Open)
                    Connect();

                // Create the delete command
                var deleteAppointmentCommand = new MySqlCommand("DELETE FROM appointment WHERE appointmentId = @appointmentId", connection);

                // Add the appointmentId parameter
                deleteAppointmentCommand.Parameters.AddWithValue("@appointmentId", appointment.AppointmentId);

                // Execute the command
                deleteAppointmentCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




    }
}
