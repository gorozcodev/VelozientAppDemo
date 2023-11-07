using VelozientAppDemo.Domain;

Drone drone1 = new Drone("Drone 1", 10);
Drone drone2 = new Drone("Drone 2", 8);
Drone drone3 = new Drone("Drone 3", 6);

List<Drone> drones = new List<Drone> { drone1, drone2, drone3 };

DeliveryLocation location1 = new DeliveryLocation() { Name = "Location A", TotalWeight = 5 };
DeliveryLocation location2 = new DeliveryLocation() { Name = "Location B", TotalWeight = 4 };
DeliveryLocation location3 = new DeliveryLocation() { Name = "Location C", TotalWeight = 3 };
DeliveryLocation location4 = new DeliveryLocation() { Name = "Location D", TotalWeight = 7 };

List<DeliveryLocation> deliveryLocations = new List<DeliveryLocation>
        {
            location1,
            location2,
            location3,
            location4
        };


foreach (var location in deliveryLocations.OrderByDescending(c => c.TotalWeight))
{
    foreach (var drone in drones)
    {
        if (location.TotalWeight <= drone.RemainingCapacity)
        {
            drone.Deliveries.Add(location);
            drone.RemainingCapacity -= location.TotalWeight;
            break;
        }
    }
}

foreach (var drone in drones)
{
    Console.WriteLine($"{drone.Name} assigned to deliveries:");
    foreach (var delivery in drone.Deliveries)
    {
        Console.WriteLine($"- {delivery.Name} ({delivery.TotalWeight} weight)");
    }
    Console.WriteLine();
}
