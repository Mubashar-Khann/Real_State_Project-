// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using RealState.Core.DTOs;
using RealState.Core.Repository;
using RealState.Core.Service;
using RealState.Repository;
using RealState.Service;
using Microsoft.EntityFrameworkCore;


internal class Program
{
    private static async Task Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureService(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        Console.WriteLine("Hello .Net Developers");
        while (true)
        {

            Console.WriteLine("\nPress 1 for   Society " +
                              "\nPress 2 For Building " +
                              "\nPress 3 For Room " +
                              "\nPress 4 For  Parking" +
                              "\nPress 5 For ADO.net");
            var option = Convert.ToByte(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine(" 1 For Add \n 2 for Remove\n 3 For Update \n 4 For Get Values");
                    var choice = Convert.ToByte(Console.ReadLine());
                    ISocietyService soietyService = serviceProvider.GetService<ISocietyService>();
                    switch (choice)
                    {

                        case 1:
                            Console.WriteLine("Enter The Name of Society ");
                            var Name = Console.ReadLine();
                            Console.WriteLine("Enter The Description of Society ");
                            var Description = Console.ReadLine();
                            Console.WriteLine("Enter The Location of Society ");
                            var Location = Console.ReadLine();
                            SocietyDTO society = new SocietyDTO()
                            {
                                Society_Name = Name,
                                Society_Description = Description,
                                Society_Location = Location
                            };

                            soietyService.AddSocietyAsync(society);
                            break;
                        case 2:
                            Console.WriteLine("Enter The Id For Society To be Removed");
                            var removeId = Convert.ToInt16(Console.ReadLine());

                            soietyService.RemoveSocietyAsync(removeId);
                            break;
                        case 3:
                            Console.WriteLine("Enter The Id For Society To be Removed");
                            var updateId = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("Enter The Name To Update ");
                            var S_Name = Console.ReadLine();
                            Console.WriteLine("Enter The  Description To Update ");
                            var S_Description = Console.ReadLine();
                            Console.WriteLine("Enter The Location ");
                            var S_Location = Console.ReadLine();
                            SocietyDTO s = new SocietyDTO()
                            { Id = updateId, Society_Name = S_Name, Society_Description = S_Description, Society_Location = S_Location };

                            soietyService.UpdateSocietyAsync(s);
                            break;
                        case 4:

                            List<SocietyDTO> Values = await soietyService.GetAllSocietyAsync();
                            foreach (var a in Values)
                            {
                                Console.WriteLine(a.Id + "  " + a.Society_Name + "   " + a.Society_Location);
                            }
                            break;
                        default:
                            Console.WriteLine("You Select Invalid Choice");
                            break;

                    }
                break;

                case 2:
                    Console.WriteLine(" 1 For Add \n 2 for Remove\n 3 For Update \n 4 For Get Values");
                    var choice2 = Convert.ToByte(Console.ReadLine());
                    IBuildingService buildingService = serviceProvider.GetService<IBuildingService>();

                    switch (choice2)
                    {
                        case 1:
                            Console.WriteLine("Enter The Name of Building ");
                            var Name = Console.ReadLine();
                            Console.WriteLine("Enter The Description of Building ");
                            var Description = Console.ReadLine();
                            Console.WriteLine("Enter The Admin of Society ");
                            var Admin = Console.ReadLine();
                            var buildingDto = new BuildingDTO()
                            {
                                Building_Name = Name,
                                Building_Description = Description,
                                Admin_Name = Admin
                            };

                            buildingService.AddBuildingAsync(buildingDto);
                            ; break;

                        case 2:
                            Console.WriteLine("Enter The Id For Building To be Removed");
                            var removeId = Convert.ToInt16(Console.ReadLine());
                            buildingService.RemoveBuildingAsync(removeId);
                            break;
                        case 3:
                            Console.WriteLine("Enter The Id For Building To be Update");
                            var updateId = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("Enter The Name Of Building To Update ");
                            var B_Name = Console.ReadLine();
                            Console.WriteLine("Enter The  Description of Building To Update ");
                            var B_Description = Console.ReadLine();
                            Console.WriteLine("Enter The Admin Name ");
                            var B_Admin = Console.ReadLine();
                            var UpdateBuilding = new BuildingDTO()
                            { Building_Name = B_Name, Building_Description = B_Description, Admin_Name = B_Admin, Id = updateId };

                            buildingService.UpdateBuildingAsync(UpdateBuilding);
                            break;
                        case 4:

                            List<BuildingDTO> BuildingStoredData = await buildingService.GetAllBuildingAsync();
                            foreach (var item in BuildingStoredData)
                            {
                                Console.WriteLine(item.Id + "  " + item.Building_Name + "  " + item.Admin_Name + "  " + item.Building_Description);

                            }
                            break;
                        default:
                            Console.WriteLine("You Select Invalid Choice");
                            break;
                    }

                    break;

                case 3:
                    Console.WriteLine(" 1 For Add \n 2 for Remove\n 3 For Update \n 4 For Get Values");
                    var choice3 = Convert.ToByte(Console.ReadLine());

                    IRoomService roomService = serviceProvider.GetService<IRoomService>();

                    switch (choice3)
                    {
                        case 1:
                            Console.WriteLine("Enter The Name of Room ");
                            var Room_Name = Console.ReadLine();
                            Console.WriteLine("Enter The Room At Which Floor ");
                            var No_OF_Floor = Console.ReadLine();
                            Console.WriteLine("Enter The Id Of Building ");
                            var BuildingId = Convert.ToInt16(Console.ReadLine());
                            var roomDto = new RoomDTO()
                            {
                                Room_Name = Room_Name,
                                No_Of_Floor = No_OF_Floor,
                                BuildingId = BuildingId
                            };

                            roomService.AddRoomAsync(roomDto);
                            break;
                        case 2:
                            Console.WriteLine("Enter The Id For Room To be Removed");
                            var removeId = Convert.ToInt16(Console.ReadLine());

                            roomService.RemoveRoomAsync(removeId);
                            break;
                        case 3:
                            Console.WriteLine("Enter The Id of Room To be Update");
                            var updateId = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("Enter The Name Of Room To Update ");
                            var R_Name = Console.ReadLine();
                            Console.WriteLine("Enter The  Floor Number To Update ");
                            var R_Floor = Console.ReadLine();
                            Console.WriteLine("Enter The Building Id ");
                            var B_BuildingId = Convert.ToInt16(Console.ReadLine());
                            var UpdateRoom = new RoomDTO()
                            {
                                Room_Name = R_Name,
                                No_Of_Floor = R_Floor,
                                BuildingId = B_BuildingId
                            };

                            roomService.UpdateRoomAsync(UpdateRoom);
                            break;
                        case 4:

                            List<RoomDTO> values = await roomService.GetAllRoomAsync();

                            foreach (var a in values)
                            {
                                Console.WriteLine(a.Id + "  " + a.Room_Name + "  " + a.No_Of_Floor + "   " + a.BuildingId);

                            }
                            break;
                        default:
                            Console.WriteLine("You Select Invalid Choice");
                            break;
                    }
                    break;

                case 4:
                    Console.WriteLine(" 1 For Add \n 2 for Remove\n 3 For Update \n 4 For Get Values");
                    var choice4 = Convert.ToByte(Console.ReadLine());
                    IParkingService parkingService = serviceProvider.GetService<IParkingService>();
                    switch (choice4)
                    {
                        case 1:
                            Console.WriteLine("Enter The Name of Parking ");
                            var Parking_Name = Console.ReadLine();
                            Console.WriteLine("Enter The Capacity of Parking ");
                            var Capacity = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("Enter The Id Of Room ");
                            var RoomId = Convert.ToInt16(Console.ReadLine());
                            var parkingDto = new ParkingDTO()
                            {
                                Parking_Name = Parking_Name,
                                Capacity = Capacity,
                                RoomId = RoomId
                            };

                            parkingService.AddParkingAsync(parkingDto);

                            break;
                        case 2:
                            Console.WriteLine("Enter The Id For Parking To be Removed");
                            var remove = Convert.ToInt16(Console.ReadLine());

                            parkingService.RemoveParkingAsync(remove);
                            break;
                        case 3:
                            Console.WriteLine("Enter The Id For Parking To be Update");
                            var updateId = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("Enter The Name Of Parking To Update ");
                            var P_Name = Console.ReadLine();
                            Console.WriteLine("Enter The  Capacity ot update ");
                            var capacity = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("Enter The Room Id ");
                            var Room_ID = Convert.ToInt16(Console.ReadLine());
                            var UpdateParking = new ParkingDTO()
                            { Parking_Name = P_Name, Capacity = capacity, RoomId = Room_ID };

                            parkingService.UpdateParkingAsync(UpdateParking);
                            break;
                        case 4:

                            List<ParkingDTO> values = await parkingService.GetAllParkingAsync();

                            foreach (var a in values)
                            {
                                Console.WriteLine(a.Id + "  " + a.Parking_Name + "  " + a.Capacity + "  " + a.RoomId);

                            }

                            break;
                        default:
                            Console.WriteLine("You Select Invalid Choice");
                            break;

                    }
                    break;

            }
        }
    }

    private static void ConfigureService(ServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IBuildingRepository, BuildingRepository>();
        serviceCollection.AddTransient<IBuildingService, BuildingService>();

        serviceCollection.AddTransient<IParkingRepository,ParkingRepository>();   
        serviceCollection.AddTransient<IParkingService, ParkingService>();
        
        serviceCollection.AddTransient<ISocietyRepository, SocietyRepository>();
        serviceCollection.AddTransient<ISocietyService,SocietyService>();
        
        serviceCollection.AddTransient<IRoomRepository, RoomRepository>();
        serviceCollection.AddTransient<IRoomService, RoomService>();

        //serviceCollection.AddTransient<>(DbContext,DbContext);
    }
}
