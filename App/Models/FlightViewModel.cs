﻿using App.Models.Utils;
using Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class FlightViewModel : BaseViewModel
    {
        public Guid Id { get; set; }
        public string Airline { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public byte Rating { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Departure { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Return { get; set; }
        public int AvailableSpots { get; set; }

        public string Image { get; set; }
        public bool Active { get; set; } = true;
        public Guid CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<Flight> Itens { get; set; } = new List<Flight>();
    }
}
