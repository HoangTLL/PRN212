﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Location
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<Trip> TripDropOffLocations { get; set; } = new List<Trip>();

    public virtual ICollection<Trip> TripPickUpLocations { get; set; } = new List<Trip>();
}