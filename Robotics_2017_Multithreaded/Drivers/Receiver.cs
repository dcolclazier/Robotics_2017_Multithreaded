using System;
using System.Net.Sockets;
using Microsoft.SPOT;
using System.Threading;
using Microsoft.SPOT.Hardware;
//using Test_Bot_Multithread;
//using Test_Bot_Multithread.Utility;
using Robotics_2017.Utility;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Robotics_2017.Drivers
{
    public class Receiver
    {
        //private static I2CDevice.Configuration _slaveConfig;
        private static OutputPort _reset =  new OutputPort(Pins.GPIO_PIN_D12, true);
        private const int TransactionTimeout = 1000;
        public const byte BeaconAddress = 0x08;
        //private I2CBus _bus;
        public static int ClockRate = Program.clockSpeed;


        public Receiver()//I2CBus bus)
        {
            //_bus = bus;
            _reset.Write(false);
            Thread.Sleep(50);
            _reset.Write(true);
            Thread.Sleep(2000);
            //_slaveConfig = new I2CDevice.Configuration(BeaconAddress, ClockRate);
        }


        /// <summary>
        /// Method to test beacon signal
        /// </summary>
        /// <returns>Returns raw location</returns>
        public bool BeaconPresent()
        {
            var bytes = new byte[2];
            //I2CBus.GetInstance().ReadRegister(_slaveConfig, BeaconAddress, bytes, TransactionTimeout);
            //_bus.ReadRegister(_slaveConfig, BeaconAddress, bytes, TransactionTimeout);

            var MSB = bytes[0];
            var LSB = bytes[1];
            int holder = (MSB << 8) | LSB;
            
            if (holder == -1 || holder == 0)
            {
                return false;
            }
            return true;
        }

        
        public int FindBeacon()
        {
            var data = new byte[2];
            //I2CBus.GetInstance().ReadRegister(_slaveConfig, BeaconAddress, data, TransactionTimeout);
            //_bus.ReadRegister(_slaveConfig, (byte) 0x00, data, TransactionTimeout);
            //_bus.WriteRead(_slaveConfig,new []{(byte) BeaconAddress}, data, TransactionTimeout);
            var MSB = data[0];
            var LSB = data[1];
            int  location = (MSB << 8 | LSB);

            return location;
        }
        
        //Used for debugging Not needed.
        public void Location()
        {
            var data = new byte[2];
            //I2CBus.GetInstance().ReadRegister(_slaveConfig, BeaconAddress, data, TransactionTimeout);
            //_bus.ReadRegister(_slaveConfig, BeaconAddress, data, TransactionTimeout);
            var msb = Tools.Bcd2Bin(new[] { data[0] });
            var lsb = Tools.Bcd2Bin(new[] { data[1] });
            
            Debug.Print("I heard: " + msb + " : " + lsb);
        }   
    }
}

