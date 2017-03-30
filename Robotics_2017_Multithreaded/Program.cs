using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Robotics_2017.Drivers;
using Robotics_2017.Flight_Computer;
using Robotics_2017.Utility;
using Robotics_2017.Work_Items;
using SecretLabs.NETMF.Hardware.Netduino;
using Math = System.Math;

namespace Robotics_2017 {
    
    
    //debug packets instead of usb debug
    
    public static class Program
    {
        public static void Main() {
            //Post methods
            //THIS SECTION CREATES / INITIALIZES THE SERIAL LOGGER
            Debug.Print("Flight computer posted successfully. Beginning INIT.");
            
            //Initialize sensors, etc.
            
            Debug.Print("Starting stopwatch");
            Clock.Instance.Start();

           
            //Thread.Sleep(5000);
            Debug.Print("Flight computer INIT Complete. Continuing with boot.");

            //THIS SECTION INITIALIZES AND STARTS THE MEMORY MONITOR
            Debug.Print("Starting memory monitor...");
            MemoryMonitor.Instance.Start();
            
            var motors = new MotorDriver();

            var testCompass = new CompassUpdater();
            testCompass.Start();
            
            OutputPort ledOnboard = new OutputPort(Pins.ONBOARD_LED, false);

            //var testBeacon = new ReceiverUpdater(bus);
            //testBeacon.Start();

            //var testPing = new PingUpdater(Pins.GPIO_PIN_A0);
            //testPing.Start();

            //var testIR = new IRDistanceUpdater(AnalogChannels.ANALOG_PIN_A1,25,100);
            //testIR.Start();



            // Start sensor actions here.
            Debug.Print("Flight computer boot successful.");


            while (true)
            {
                
                //Debug.Print("Beacon: "+ RobotState.Bearing);
                

                //Debug.Print("IR: " + RobotState.IRDistance);
                //Debug.Print("\nPing: " + RobotState.PingDistance);
                //Thread.Sleep(1000);
                //var oldSenV = RobotState.LastIRDistance;
                //var currentSenV = RobotState.IRDistance;

                //GreenLED.Write(RobotState.CheckReady());

                //BlueLED.Write(currentSenV >= 1000);
                //YellowLED.Write(currentSenV >= 2000);
                //if (currentSenV >= 1000) BlueLED.Write(true);

                //motors.Forward(255);
                //Thread.Sleep(2000);
                //motors.Backward(255);
                //Thread.Sleep(2000);
                //motors.Right(255);
                //Thread.Sleep(2000);
                //motors.Left(255);
                //Thread.Sleep(2000);
                //Debug.Print("I'm in the loop! ");

                //if (Math.Abs(oldSenV - currentSenV) > .01)
                //{
                //    Debug.Print("SensorValue: " + currentSenV);

                //    RedLED.Write(false);
                //    YellowLED.Write(false);
                //    BlueLED.Write(false);

                //    if (currentSenV >= 1000) BlueLED.Write(true);
                //    if (currentSenV >= 2000) YellowLED.Write(true);
                //    if (!(currentSenV >= 3000)) continue;

                //    RedLED.Write(true);
                //    _motors.Halt();

                //    _motors.Backward(255);
                //    Thread.Sleep(100);

                //    if (currentSenV >= 2000)
                //    {
                //        //do nothing
                //        Debug.Print("Too close...");
                //        _motors.Halt();
                //        _motors.Right(255);

                //    }
                //}
            }
        }
        
    }
}

