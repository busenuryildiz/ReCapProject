using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.Runtime.ConstrainedExecution;

//CarManager carManager = new CarManager(new EfCarDal());
//Car Car = new Car() { Id = 5, BrandId = 5, ColorId = 5,Name = "Porsche",DailyPrice = 3500, Description = "new", ModelYear = 2023 };
//carManager.Add(Car);

//foreach (var car in carManager.GetAll())
//{
//    Console.WriteLine("Car Id: " + car.Id);
//    Console.WriteLine("Brand Id: " + car.BrandId);
//    Console.WriteLine("Car Color " + car.ColorId);
//    Console.WriteLine("Car Name: " + car.Name);
//    Console.WriteLine("Car Description: " + car.Description);
//    Console.WriteLine("Car Model Year: " + car.ModelYear);
//    Console.WriteLine("Car Daily Price: " + car.DailyPrice);
//    Console.WriteLine("----------------------");

//}


//Console.WriteLine("GetCarsByBrandId");

//foreach (var car in carManager.GetCarsByBrandId(2))
//{
//    Console.WriteLine(car.BrandId);
//    Console.WriteLine(car.Description);
//    Console.WriteLine("----------------------");

//}


//Console.WriteLine("GetCarsByColorId");

//foreach (var car in carManager.GetCarsByColorId(3))
//{
//    Console.WriteLine(car.ColorId);
//    Console.WriteLine(car.Description);
//    Console.WriteLine("----------------------");

//}

CarManager carManager = new CarManager(new EfCarDal());
var result = carManager.GetCarDetails();
if (result.Success == true)
{
    foreach (var car in carManager.GetCarDetails().Data)
    {
        Console.WriteLine("Car Name: " + car.CarName);
        Console.WriteLine("Brand Name: " + car.BrandName);
        Console.WriteLine("Color Name: " + car.ColorName);
        Console.WriteLine("Car Daily Price: " + car.DailyPrice);
        Console.WriteLine("----------------------");
    }
}
else
{
    Console.WriteLine(result.Message);
}
