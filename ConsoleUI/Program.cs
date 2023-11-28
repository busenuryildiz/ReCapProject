using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;



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


//CarManager carManager = new CarManager(new EfCarDal());
//var result = carManager.GetCarDetails();
//if (result.Success == true)
//{
//    foreach (var car in carManager.GetCarDetails().Data)
//    {
//        Console.WriteLine("Car Name: " + car.CarName);
//        Console.WriteLine("Brand Name: " + car.BrandName);
//        Console.WriteLine("Color Name: " + car.ColorName);
//        Console.WriteLine("Car Daily Price: " + car.DailyPrice);
//        Console.WriteLine("----------------------");
//    }
//}
//else
//{
//    Console.WriteLine(result.Message);
//}





public class Program
{
    public static void Main(string[] args)
    {
        //AddCar();

        //AddBrand();

        AddRental();

        //AddUser();

        //AddCustomer();
    }

    private static void AddCustomer()
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        Customer customer = new Customer()
        {
            UserId = 1,
            CompanyName = "KKK"
        };
        customerManager.Add(customer);
    }

    private static void AddUser()
    {
        IUserService userService = new UserManager(new EfUserDal());
        User user = new User()
        {
            FirstName = "Buse",
            LastName = "Yıldız",
            Email = "busenurryildiz@gmail.com",
            Password = "asdasd",
            Status = true
        };
        userService.Add(user);
    }


    private static void AddBrand()
    {
        BrandManager brandManager = new BrandManager(new EfBrandDal());
        Brand newBrand = new Brand
        {
            BrandName = "BMW",
        };
        brandManager.Add(newBrand);
    }


    private static void AddCar()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        Car Car = new Car()
        {
            Id = 5,
            BrandId = 5,
            ColorId = 5,
            Name = "Porsche",
            DailyPrice = 3500,
            Description = "new",
            ModelYear = 2023
        };
        carManager.Add(Car);
    }
    //UPDATE
    //newCar.Id = 2002;
    //newCar.BrandId = 5;
    //newCar.ColorId = 1;
    //newCar.Name = "burak";
    //newCar.DailyPrice = 1500;
    //newCar.Description = "Yeni araba";
    //newCar.ModelYear = 2015;
    //carManager.Update(newCar);

    private static void AddRental()
    {
        RentalManager rentalManager = new RentalManager(new EfRentalDal());
        rentalManager.Add(new Rental
        {
            CarId = 3,
            CustomerId = 2,
            RentDate = new DateTime(2023, 05, 17),
            ReturnDate = new DateTime(2023, 06, 28)
        });
    }
}