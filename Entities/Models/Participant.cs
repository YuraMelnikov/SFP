﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Participant")]
    public class Participant : EntityId
    {
        [Required(ErrorMessage = "Grand prix is required")]
        public Guid IdGrandPrixResult { get; set; }
        [Required(ErrorMessage = "Number is required")]
        public string Number { get; set; }
        [Required(ErrorMessage = "Team is required")]
        public Guid IdTeam { get; set; }
        [Required(ErrorMessage = "Chassis is required")]
        public Guid IdChassis { get; set; }
        [Required(ErrorMessage = "Engine is required")]
        public Guid IdEngine { get; set; }
        [Required(ErrorMessage = "Racer is required")]
        public Guid IdRacer { get; set; }
        [Required(ErrorMessage = "Tyre is required")]
        public Guid IdTyre { get; set; }

        [ForeignKey("IdGrandPrixResult")]
        public  GrandPrix GrandPrix { get; set; }
        [ForeignKey("IdTeam")]
        public  Team Team { get; set; }
        [ForeignKey("IdChassis")]
        public  Chassis Chassis { get; set; }
        [ForeignKey("IdEngine")]
        public  Engine Engine { get; set; }
        [ForeignKey("IdRacer")]
        public  Racer Racer { get; set; }
        [ForeignKey("IdTyre")]
        public  Tyre Tyre { get; set; }
    }
}
