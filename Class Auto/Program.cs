using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Auto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Auto passengerCar = new PassengerCar("Passenger", 8.0, 50.0, 85.0, 30.0, 270.0, 2 );
            Auto truck = new Truck("Truck", 11.2, 100.0, 73.0, 50.0, 50.5, 6.0);
            Auto sportcar = new SportCar("Sport", 10.0, 70.0, 120.0, 30.0, 50.0);
            passengerCar.DistanceMethod();
            passengerCar.PowerReserv();
            passengerCar.Display();

            truck.DistanceMethod();
            truck.PowerReserv();
            truck.Display();

            sportcar.DistanceMethod();
            sportcar.PowerReserv();
            sportcar.Display();

            Console.ReadKey();
        }
    }
    abstract class Auto
    {
        protected string TCtype { get; set; } //тип ТС
        protected double AvFuelCons { get; set; } //Средний расход топлива
        protected double TankSize { get; set; }// Объем бака
        protected double Speed { get; set; } //Скорость
        protected double Fuel { get; set; } //Остаток топлива
        protected double Distance { get; set; } //Расстояние
        public Auto(string tc_type, double av_fuel_cons, double tank_size, double speed, double fuel, double distance)
        {
            TCtype = tc_type;
            AvFuelCons = av_fuel_cons;
            TankSize = tank_size;
            Speed = speed;
            Fuel = fuel;
            Distance = distance;
        }
        public double DistanceMethod()
        {
            if (TankSize == Fuel)
            
                return TankSize / AvFuelCons;
            
            else
                return Fuel / AvFuelCons;
        }

        public virtual void PowerReserv()
            { double result = TankSize / AvFuelCons; }

        public double Time()
        { return Distance / Speed; }
       

        public void Display()
        {
            Console.WriteLine($"Auto Type: {TCtype}, Average fuel consumption: {AvFuelCons} , Tank size: {TankSize} , Speed: {Speed}");
        }

    }
    class PassengerCar : Auto
    {

        protected int Passengers { get; set; }
       
        public PassengerCar(string tc_type, double av_fuel_cons, double tank_size, double speed, double fuel, double distance, int passengers)
            :base(tc_type, av_fuel_cons, tank_size, speed, fuel, distance)
        {
            Passengers = passengers;
            
        }
        
        public override void PowerReserv()
        {
            base.PowerReserv();

            if (Passengers <= 4)
            {
                
                double result = (TankSize / AvFuelCons) - (TankSize / AvFuelCons) * 6 / 100 * Passengers;
                Console.WriteLine($"Запас хода легкового авто при {Passengers} пассажирах равен {result}");


            }
            else
            {
                Console.WriteLine("Количество пассажиров превышает допустимое для легкового авто"); 
                
            }

        }

    }
    class Truck : Auto
    {

        protected double Tonnage { get; set; }
        public Truck(string tc_type, double av_fuel_cons, double tank_size, double speed, double fuel,double distance,  double tonnage)
            :base(tc_type, av_fuel_cons, tank_size, speed, fuel, distance)
        {
            Tonnage = tonnage;

        }
        public override void PowerReserv()
        {
            if (Tonnage <= 20000)
            {
                base.PowerReserv();
                double result =  (TankSize / AvFuelCons) - (TankSize / AvFuelCons) * 6 / 100 * Tonnage/200;
                Console.WriteLine($"Запас хода грузового авто при {Tonnage} тоннаже равен {result}");
            }
            else
            {
                Console.WriteLine("Количество пассажиров превышает допустимое для легкового авто");

            }
        }

    }
    class SportCar : Auto
    {

        
        public SportCar(string tc_type, double fuel_cons, double tank_size, double speed, double fuel, double distance)
            : base(tc_type, fuel_cons, tank_size, speed, fuel, distance)
        {

            
        }

    }
}



// Создание объектов классов в Main
