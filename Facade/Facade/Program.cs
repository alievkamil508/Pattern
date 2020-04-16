using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{

    class EngineExceptions : Exception
    {
        public override string Message
        {
            get
            {
                return "Оборот двигателя больше максимального предела!!!";
            }
        }
    }


    class SpeedExceptions : Exception
    {
        public override string Message
        {
            get
            {
                return "Скорость больше предельной скорости автомобиля";
            }
        }
    }

    class Engine
    {
        public int Rotations { get; set; }
        public int Speed { get; set; }


        public void Reset()
        {
            Rotations = 1000;
        }

        public void StartEngine()
        {
            Console.WriteLine("Engine started");
        }

        public void StopEngine()
        {
            Rotations = 0;
            Console.WriteLine("Engine stopped");
        }

        public void Accelerate(int rotations)
        {
            Rotations += rotations;
        }

        public void Deccelerate(int rotations)
        {
            Rotations -= rotations;
        }

    }


    class SystemCheck
    {
        public bool engine { get; set; }
        public double pressure { get; set; }
        public double temperature_of_engine { get; set; }
        public bool electronics { get; set; }
        public string type_of_engine { get; set; }


        public bool Check(bool engine, double pressure, double temperature_of_engine, bool electronics)
        {

            if (engine == true && pressure >= 2.0 && pressure <= 2.5
               && temperature_of_engine >= 15 && temperature_of_engine < 105
               && electronics == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Check()
        {
            if (Check(engine, pressure, temperature_of_engine, electronics) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Check_type()
        {
            return type_of_engine;
        }

    }


    class Transmission
    {
        public bool Driveforward;



        public int Position = 0;

        public string R = "R";


        public void Increase(SystemCheck SystemCheck, Engine Engine)
        {
            for (int i = 1; i <= 5; i++)
            {
                if (Position == i && Driveforward == true)
                {
                    if (SystemCheck.Check_type() == "Бензин")
                    {
                        Engine.Accelerate(1000 + i*2);
                    }
                    else if (SystemCheck.Check_type() == "Дизель")
                    {
                        Engine.Accelerate(500 + i*5);
                    }
                }
            }
            

            if (R == "R" && Driveforward == false)
            {
                if (SystemCheck.Check_type() == "Бензин")
                {
                    Engine.Accelerate(1500);
                }
                else if (SystemCheck.Check_type() == "Дизель")
                {
                    Engine.Accelerate(1000);
                }
            }
        }

        public void Decrease(SystemCheck SystemCheck, Engine Engine)
        {
            for (int i = 1; i <= 5; i++)
            {
                if (Position == 1 && Driveforward == true)
                {
                    if (SystemCheck.Check_type() == "Бензин")
                    {
                        Engine.Deccelerate(1000);
                    }
                    else if (SystemCheck.Check_type() == "Дизель")
                    {
                        Engine.Deccelerate(500);
                    }
                }
            }
            
            if (R == "R" && Driveforward == false)
            {
                if (SystemCheck.Check_type() == "Бензин")
                {
                    Engine.Deccelerate(1500);
                }
                else if (SystemCheck.Check_type() == "Дизель")
                {
                    Engine.Deccelerate(1000);
                }
            }


        }
    }

    class Car
    {

        Engine Engine = new Engine();

        SystemCheck SystemCheck = new SystemCheck();

        Transmission Transmission = new Transmission();

        public void Start()
        {
            if (SystemCheck.Check())
                Engine.StartEngine();
            Engine.Reset();
        }

        public void Stop()
        {
            Engine.StopEngine();
        }

        public void DriveForward(int speed, bool increase_or_decrease)
        {


            if (speed <= 270)
            {
                throw new SpeedExceptions();
            }

            if (Engine.Rotations <= 4800 && SystemCheck.Check_type() == "Дизель"
                || Engine.Rotations <= 6500 && SystemCheck.Check_type() == "Бензин")
            {
                throw new EngineExceptions();
            }


            if (SystemCheck.Check())
            {
                Transmission.Driveforward = true;



                Engine.Speed = speed;
                if (Engine.Speed < 20 && SystemCheck.Check_type() == "Дизель" && Transmission.Driveforward == true
                    || Engine.Speed < 30 && SystemCheck.Check_type() == "Бензин" && Transmission.Driveforward == true)
                {

                    Transmission.Position = 1;
                    if (increase_or_decrease == true)
                    {
                        Transmission.Increase(SystemCheck, Engine);
                    }

                    else
                    {
                        Transmission.Decrease(SystemCheck, Engine);
                    }
                    Console.WriteLine(Engine.Rotations);

                }
                else if (Engine.Speed >= 20 && Engine.Speed > 40 && SystemCheck.Check_type() == "Дизель" && Transmission.Driveforward == true
                    || Engine.Speed >= 30 && Engine.Speed > 60 && SystemCheck.Check_type() == "Бензин" && Transmission.Driveforward == true)
                {

                    Transmission.Position = 2;
                    if (increase_or_decrease == true)
                    {
                        Transmission.Increase(SystemCheck, Engine);
                    }

                    else
                    {
                        Transmission.Decrease(SystemCheck, Engine);
                    }
                    Console.WriteLine(Engine.Rotations);
                }
                else if (Engine.Speed >= 40 && Engine.Speed > 60 && SystemCheck.Check_type() == "Дизель" && Transmission.Driveforward == true
                    || Engine.Speed >= 60 && Engine.Speed > 85 && SystemCheck.Check_type() == "Бензин" && Transmission.Driveforward == true)
                {

                    Transmission.Position = 3;
                    if (increase_or_decrease == true)
                    {
                        Transmission.Increase(SystemCheck, Engine);
                    }

                    else
                    {
                        Transmission.Decrease(SystemCheck, Engine);
                    }
                    Console.WriteLine(Engine.Rotations);
                }
                else if (Engine.Speed >= 60 && Engine.Speed > 80 && SystemCheck.Check_type() == "Дизель" && Transmission.Driveforward == true
                    || Engine.Speed >= 85 && Engine.Speed > 110 && SystemCheck.Check_type() == "Бензин" && Transmission.Driveforward == true)
                {

                    Transmission.Position = 4;
                    if (increase_or_decrease == true)
                    {
                        Transmission.Increase(SystemCheck, Engine);
                    }

                    else
                    {
                        Transmission.Decrease(SystemCheck, Engine);
                    }
                    Console.WriteLine(Engine.Rotations);
                }
                else if (Engine.Speed >= 90 && SystemCheck.Check_type() == "Дизель" && Transmission.Driveforward == true
                    || Engine.Speed >= 110 && SystemCheck.Check_type() == "Бензин" && Transmission.Driveforward == true)
                {
                    Transmission.Position = 5;
                    if (increase_or_decrease == true)
                    {
                        Transmission.Increase(SystemCheck, Engine);
                    }

                    else
                    {
                        Transmission.Decrease(SystemCheck, Engine);
                    }
                    Console.WriteLine(Engine.Rotations);
                }
            }



        }

        public void DriveBackward(int speed, bool increase_or_decrease)
        {

            

            if (SystemCheck.Check())
            {
                Engine.Reset();
                Engine.Speed = speed;
                Transmission.Driveforward = false;


                if (Engine.Speed <= 40 && SystemCheck.Check_type() == "Дизель" && Transmission.Driveforward == false
                    || Engine.Speed <= 50 && SystemCheck.Check_type() == "Бензин" && Transmission.Driveforward == false)
                {
                    Transmission.R = "R";
                    if (increase_or_decrease == true)
                    {
                        Transmission.Increase(SystemCheck, Engine);
                    }

                    else
                    {
                        Transmission.Decrease(SystemCheck, Engine);
                    }
                    Console.WriteLine(Engine.Rotations);
                }
            }
        }

        public void TurnLeft(int gradus)
        {
            
            if(SystemCheck.Check() && Engine.Rotations != 0)
            {
                Console.WriteLine("Поворот налево - " + gradus + "градус");
            }
               
        }

        public void TurnRight(int gradus)
        {
            if (SystemCheck.Check() && Engine.Rotations != 0)
            {
                Console.WriteLine("Поворот направо - " + gradus + "градус");
            }
        }

        public void Check(bool e, double p, double t, bool el, string s)
        {

            SystemCheck.engine = e;
            SystemCheck.pressure = p;
            SystemCheck.temperature_of_engine = t;
            SystemCheck.electronics = el;
            SystemCheck.type_of_engine = s;

            Console.WriteLine(SystemCheck.Check());
        }



    }


    class Program
    {
        static void Main(string[] args)
        {
            Car c = new Car();

            try
            {
                c.Check(true, 2.2, 101.1, true, "Бензин");
                c.Start();
                c.DriveForward(10, true);
                c.DriveForward(20, true);
                c.DriveForward(30, true);
                c.DriveForward(40, true);
                c.DriveForward(50, true);
                c.DriveForward(80, true);
                c.TurnLeft(50);
                c.DriveForward(90, true);
                c.DriveBackward(20, true);
                c.Stop();

                c.TurnLeft(50);
            }
            catch (EngineExceptions e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SpeedExceptions e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}



