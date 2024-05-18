﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace RIS
{
    public class Reservation
    {
        private List<Table> tables;

        public Reservation(List<Table> tables)
        {
            this.tables = tables;
        }

        public void PlaceReservation(string name) // Request reservation details
        {
            Console.WriteLine("Please enter your reservation detail as this format: Party Size, Lunch/Dinner");
            string[] reservationDetail = Console.ReadLine().Split(','); // Split reservationDetail from input by a comma 
            int partySize = int.Parse(reservationDetail[0]); // partySize int on index 0
            string time = reservationDetail[1]; // time string on index 1
            MakeReservation(name, partySize, time); // Call the MakeReservation function
        }

        public void MakeReservation(string name, int partySize, string time) // Set reservation details
        {
            // Obtain partySize and time from user request
            Console.WriteLine("Glad to assist you today.");
            string requestedTime = time.ToLower();

            // Set availability constant that if a table with size greater or equal to the partySize and time (to lower case) match the user request
            var availableTables = tables.Where(t => t.Size >= partySize && t.Time.ToLower() == requestedTime && t.Occupied == "empty").ToList();

            // If there are any available table
            if (availableTables.Any())
            {
                // List table data with matching information from partySize and time preference
                Console.WriteLine("Please select one of the available table's id below:");
                foreach (var table in availableTables)
                {
                    Console.WriteLine($"id: {table.Id}, size: {table.Size}, {table.Time}");
                }

                // Request id input from customer
                string id = Console.ReadLine();

                // Parse data value of table that match the id request
                var selectedTable = availableTables.FirstOrDefault(t => t.Id == id);

                // Set reservation, return that table's occupied value to true
                if (selectedTable != null)
                {
                    selectedTable.Occupied = name;
                    Console.WriteLine($"Thank you for your reservation, {name} see you soon!");
                }
                // Case customer (accidentally) type in invalid id
                else
                {
                    Console.WriteLine("Table id does not match, try again.");
                    MakeReservation(name, partySize, time); // Call the MakeReservation function again
                }
            }
            // Case table as request is not available, request again.
            else
            {
                Console.WriteLine("Sorry, we are full. Try to reduce the party size or change your preference time.");
                MakeReservation(name, partySize, time);
            }
        }
    }
}