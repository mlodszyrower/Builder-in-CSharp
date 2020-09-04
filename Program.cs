using System;
using System.Collections.Generic;

namespace PatternDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car;
            Car.Builder builder = new Car.Builder();
                builder.SetBagageCapacity(2)
                .AddWheel(5)
                .SetColor("masno");
            if(true) 
                builder.SetColor("nie jest masno");
            car = builder.Build();
            Car car1 = new Car.Builder()
                .SetBagageCapacity(2)
                .AddWheel(5)
                .SetColor("masno")
                .Build();

            car.Print();
        }
    }

    class Car {
        private int[] wheels;
        private string color;
        private int bagageCapacity;

        private Car() {

        }

        public void Print() {
            Console.Write("Wheels: ");
            for(int i = 0; i < wheels.Length; i++) {
                Console.Write(wheels[i]);
                Console.Write(", ");
            }
            Console.WriteLine("");
            Console.WriteLine("Color: " + color);
            Console.WriteLine("Bagage capacity: " + bagageCapacity.ToString());
        }

        public class Builder {
            Car car;
            private string defaultColor = "white";
            bool isCustomWheels = false;
            bool isBagageCapacitySet = false;
            List<int> wheels = new List<int>();
            public Builder() {
                car = new Car();
            }

            public Car Build() {
                if(!isBagageCapacitySet) return null;
                if(isCustomWheels) car.wheels = wheels.ToArray();
                else car.wheels = new int[] { 1, 1 };
                if(car.color == null) car.color = defaultColor;
                return car;
            }

            public Builder AddWheel(int wheel) {
                wheels.Add(wheel);
                isCustomWheels = true;
                return this;
            }

            public Builder RemoveWheel(int wheel) {
                wheels.Remove(wheel);
                return this;
            }

            public Builder SetColor(string name) {
                car.color = name;
                return this;
            }

            public Builder SetBagageCapacity(int capacity) {
                if(capacity < 0) return this;
                isBagageCapacitySet = true;
                car.bagageCapacity = capacity;
                return this;
            }
        }
    }
}
