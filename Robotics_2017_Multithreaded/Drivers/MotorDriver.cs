using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Robotics_2017.Work_Items;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Robotics_2017
{
    class MotorDriver
    {
        private const double Frequency = 490;

        private readonly OutputPort _leftCW = new OutputPort(Pins.GPIO_PIN_D7, false);
        private readonly OutputPort _leftCCW = new OutputPort(Pins.GPIO_PIN_D8, false);
        private readonly PWM _leftPWM = new PWM(PWMChannels.PWM_PIN_D5, Frequency, 1, false);
        private readonly OutputPort _rightCW = new OutputPort(Pins.GPIO_PIN_D4, false);
        private readonly OutputPort _rightCCW = new OutputPort(Pins.GPIO_PIN_D9, false);
        private readonly PWM _rightPWM = new PWM(PWMChannels.PWM_PIN_D6, Frequency, 1, false);

        public void Forward(int s)
        {
            //if (RobotState.CheckReady() && (s <= 255))// || (s > 0))
            if (true)
            {
                _leftCCW.Write(true);
                _leftCW.Write(false);

                _rightCCW.Write(false);
                _rightCW.Write(true);

                _leftPWM.DutyCycle = (s / 255);
                _rightPWM.DutyCycle = (s / 255);

                _leftPWM.Start();
                _rightPWM.Start();
            }
            else Halt();
        }

        public void Backward(int s)
        {
            if (s <= 255 && RobotState.CheckReady())
            {
                Halt();

                _leftCCW.Write(false);
                _leftCW.Write(true);

                _rightCCW.Write(true);
                _rightCW.Write(false);

                _leftPWM.DutyCycle = (s / 255);
                _rightPWM.DutyCycle = (s / 255);

                _leftPWM.Start();
                _rightPWM.Start();
            }
            else Halt();
        }

        public void Right(int s)
        {
            //if (RobotState.CheckReady())
            if (true)
            {
                _leftCCW.Write(true);
                _leftCW.Write(false);

                _rightCCW.Write(true);
                _rightCW.Write(false);

                _leftPWM.DutyCycle = (s / 255);
                _rightPWM.DutyCycle = (s / 255);

                _leftPWM.Start();
                _rightPWM.Start();
            }
            else Halt();
        }

        public void Left(int s)
        {
            //if (RobotState.CheckReady())
            if (true)
            {
                _leftCCW.Write(false);
                _leftCW.Write(true);

                _rightCCW.Write(true);
                _rightCW.Write(false);

                _leftPWM.DutyCycle = (s / 255);
                _rightPWM.DutyCycle = (s / 255);

                _leftPWM.Start();
                _rightPWM.Start();
            }
            else Halt();
        }
        public void Halt()
        {
            _leftCCW.Write(false);
            _leftCW.Write(false);

            _rightCCW.Write(false);
            _rightCW.Write(false);
            _leftPWM.Stop();
            _rightPWM.Stop();
        }
    }
}
