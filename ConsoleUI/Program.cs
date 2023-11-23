//Kampımızla beraber paralelde geliştireceğimiz bir projemiz daha olacak. Araba kiralama sistemi yazıyoruz.
// Yepyeni bir proje oluşturunuz. Adı ReCapProject olacak. (Tekrar ve geliştirme projesi)
// Entities, DataAccess, Business ve Console katmanlarını oluşturunuz.
// Bir araba nesnesi oluşturunuz. "Car"
// Özellik olarak : Id, BrandId, ColorId, ModelYear, DailyPrice, Description alanlarını ekleyiniz. (Brand = Marka)
// InMemory formatta GetById, GetAll, Add, Update, Delete oprasyonlarını yazınız.
// Consolda test ediniz.


using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;
using Entities.Concrete;

CarManager carManager = new CarManager(new InMemoryCarDal());
Car Car = new Car() { Id = 5, BrandId = 5, ColorId = 5, DailyPrice = 3500, Description = "Porsche", ModelYear = 2023 };
carManager.Add(Car);

foreach (var car in carManager.GetAll())
{
    Console.WriteLine("Car Id: " + car.Id);
    Console.WriteLine("Brand Id: " + car.BrandId);
    Console.WriteLine("Car Color " + car.ColorId);
    Console.WriteLine("Car Description: " + car.Description);
    Console.WriteLine("Car Model Year: " + car.ModelYear);
    Console.WriteLine("Car Daily Price: " + car.DailyPrice);
    Console.WriteLine("----------------------");

}


Console.WriteLine("GetCarsByBrandId");

foreach (var car in carManager.GetCarsByBrandId(2))
{
    Console.WriteLine(car.BrandId);
    Console.WriteLine(car.Description);
    Console.WriteLine("----------------------");

}


Console.WriteLine("GetCarsByColorId");

foreach (var car in carManager.GetCarsByColorId(1))
{
    Console.WriteLine(car.ColorId);
    Console.WriteLine(car.Description);
    Console.WriteLine("----------------------");

}