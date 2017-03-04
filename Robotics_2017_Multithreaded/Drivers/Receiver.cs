using System;
using System.Net.Sockets;
using Microsoft.SPOT;
using System.Threading;
using Microsoft.SPOT.Hardware;
//using Test_Bot_Multithread;
//using Test_Bot_Multithread.Utility;
using Robotics_2017.Utility;

namespace Robotics_2017.Drivers
{
    public class Receiver
    {
        private static I2CDevice.Configuration _slaveConfig;
        private const int TransactionTimeout = 1000;
        public const byte BeaconAddress = 0x08;
        public static int clockSpeed = Program.clockSpeed;
        
       
        public bool BeaconPresent()
        {
            var bytes = new byte[2];
            I2CBus.GetInstance().ReadRegister(_slaveConfig, BeaconAddress, bytes, TransactionTimeout);

            var MSB = bytes[0];
            var LSB = bytes[1];
            int holder = (MSB << 8) | LSB;
            
            if (holder == -1 || holder == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Method to test beacon signal
        /// </summary>
        /// <returns>Returns raw location</returns>
        public int FindBeacon()
        {
            var data = new byte[2];
            I2CBus.GetInstance().ReadRegister(_slaveConfig, BeaconAddress, data, TransactionTimeout);
            var MSB = data[0];
            var LSB = data[1];
            int  location = (MSB << 8 | LSB);

            return location;
        }
        
        public void Location()
        {
            var data = new byte[2];
            I2CBus.GetInstance().ReadRegister(_slaveConfig, BeaconAddress, data, TransactionTimeout);
            var msb = Tools.Bcd2Bin(new[] { data[0] });
            var lsb = Tools.Bcd2Bin(new[] { data[1] });
            
            Debug.Print("I heard: " + msb + " : " + lsb);
        }   
    }
}

