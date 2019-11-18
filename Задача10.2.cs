using System;

namespace Задача10._1
{
    class Program
    {
        public delegate void Del();
        class Plane
        {
            protected int currentSpeed;
            protected double currentHeight;
            public Plane()
            {
                currentSpeed = 0;
                currentHeight = 0;
            }
            public Plane(int currentSpeed,double currentHeight)
            {
                this.currentSpeed = currentSpeed;
                this.currentHeight = currentHeight;
            }
            public int CurrentSpeed
            {
                set { currentSpeed = value;}
                get { return currentSpeed; }
            }
            public double CurrentHeight
            {
                set { currentHeight = value;}
                get { return currentHeight; }
            }
        }
        class FightPlane:Plane
        {
            public const int MaxSpeed = 2000;
            public const int MaxHeight = 10000;
            public event Del Event1;
            public event Del Event2;
            private int currentRockets;
            public FightPlane(int currentSpeed,double currentHeight,int currentRockets):base( currentSpeed, currentHeight)
            {
                this.currentRockets = currentRockets;
            }
            public int CurrentRockets
            {
                set { currentRockets= value; }
                get { return currentRockets; }
            }
            public void checkSpeed()
            {
                if(Event1!=null)
                {
                    Event1();
                }
                else
                {
                    Console.WriteLine("Max Speed for fight plane is not reached yet");
                }
            }
            public void checkHeight()
            {
                if(Event2!=null)
                {
                    Event2();
                }
                else
                {
                    Console.WriteLine("Max Height for fight plane is not reached yet");
                }
            }
        }
        class PassengersPlane:Plane
        {
            public const int MaxSpeed= 1500;
            public const int MaxHeight = 8000;
            public event Del Event1;
            public event Del Event2;
            private int passengers;
            public PassengersPlane(int currentSpeed,double currentHeight,int passengers):base(currentSpeed,currentHeight)
            {
                this.passengers = passengers;
            }
            public int Passengers
            {
                set { passengers = value; }
                get { return passengers; }
            }
            public void checkSpeed()
            {
                if(Event1!=null)
                {
                    Event1();
                }
                else
                {
                    Console.WriteLine("Max Speed for passengers plane  is not reached yet");
                }
            }
            public void checkHeight()
            {
                if(Event2!=null)
                {
                    Event2();
                }
                else
                {
                    Console.WriteLine("Max Height for passengers plane is not reached yet");
                }
            }
        }
        static void FightPlaneSpeedMessage()
        {
            Console.WriteLine("Max Speed for fight plane is reached!");
        }
        static void FightPlaneHeightMessage()
        {
            Console.WriteLine("Max Height for fight plane is reached!");
        }
        static void PassengersPlaneSpeedMessage()
        {
            Console.WriteLine("Max Speed for passengers plane is reached!");
        }
        static void PassengersPlaneHeightMessage()
        {
            Console.WriteLine("Max Height for passengers plane is reached!");
        }
        static void CheckFightPlane(FightPlane plane)
        {
            if (plane.CurrentSpeed == FightPlane.MaxSpeed)
            {
                plane.Event1 += new Del(FightPlaneSpeedMessage);
            }
            if (plane.CurrentHeight == FightPlane.MaxHeight)
            {
                plane.Event2 += new Del(FightPlaneHeightMessage);
            }
        }
        static void CheckPassengersPlane(PassengersPlane plane)
        {
            if (plane.CurrentSpeed ==PassengersPlane.MaxSpeed)
            {
                plane.Event1 += new Del(FightPlaneSpeedMessage);
            }
            if (plane.CurrentHeight == PassengersPlane.MaxHeight)
            {
                plane.Event2 += new Del(FightPlaneHeightMessage);
            }
        }
        static void Main()
        {
            FightPlane plane1 = new FightPlane(2000,5500, 15);
            CheckFightPlane(plane1);
            plane1.checkSpeed();
            plane1.checkHeight();
            PassengersPlane plane2 = new PassengersPlane(1000, 8000, 150);
            CheckPassengersPlane(plane2);
            plane2.checkSpeed();
            plane2.checkHeight();

        }

    }
}
