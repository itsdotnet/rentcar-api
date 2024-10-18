using System;
using RentCar.Domain.Enums;

namespace RentCar.Domain.Entities;

public class Provider
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get ; set; }
    public float Longitude { get; set; }
    public float Latitude { get; set; }
    public Day Start { get; set; } = Day.Monday;
    public Day End { get; set; } = Day.Friday;
}
