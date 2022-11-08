using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Auto
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    abstract class Avto
    {
        public string TCtype { get; set; }
        public double AvFuelCons { get; set; }
        public double TankSize { get; set; }
        public double Speed { get; set; }
        public double Fuel { get; set; }
        public double Distance { get; set; }
        public Avto(string tc_type, double av_fuel_cons, double tank_size, double speed, double fuel, double distance)
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

        public virtual double PowerReserv()
            { return TankSize / AvFuelCons; }

        public double Time()
        { return Distance / Speed; }
       

        public void Display()
        {
            Console.WriteLine($"Avto Type: {TCtype}, Average fuel consumption: {AvFuelCons} , Tank size: {TankSize} , Speed: {Speed}");
        }

    }
    class PassengerCar : Avto
    {

        public int Passengers { get; set; }
        public PassengerCar(string tc_type, double av_fuel_cons, double tank_size, double speed, double fuel, double distance, int passengers)
            : base(tc_type,av_fuel_cons, tank_size, speed, fuel, distance)
        {
            Passengers = passengers;
            
        }
        public override sealed double PowerReserv()
        {
            base.PowerReserv();
            return TankSize / AvFuelCons;
        }

    }
    class Truck : Avto
    {

        public double Tonnage { get; set; }
        public Truck(string tc_type, double av_fuel_cons, double tank_size, double speed, double fuel,double distance,  double tonnage)
            : base(tc_type, av_fuel_cons, tank_size, speed, fuel, distance)
        {
            Tonnage = tonnage;

        }
        public override sealed double PowerReserv()
        {
            base.PowerReserv();
            return TankSize / AvFuelCons;
        }

    }
    class SportCar : Avto
    {

        
        public SportCar(string tc_type, double fuel_cons, double tank_size, double speed, double fuel, double distance)
            : base(tc_type, fuel_cons, tank_size, speed, fuel, distance)
        {

            
        }

    }
}


// в Легковом авто проверка на допустимое кол-во пассажиров, переопределение метода для расчпета запаса хода
// в Грузовом авто проверка на полный загруз, переопределение метода расчета запаса хода
// Создание объектов классов в Main
