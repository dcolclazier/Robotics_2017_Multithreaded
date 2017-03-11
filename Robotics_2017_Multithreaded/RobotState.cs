using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Robotics_2017.Work_Items {
    public class MotorController {
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
            if(true)
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
            if(true)
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

    public static class RobotState {

        public static int PingDistance { get; private set; }
        public static int LastPingDistance { get; private set; }
        public static double IRDistance { get; private set; }
        public static double LastIRDistance { get; private set; }
        public static double LastcompassHeading { get; private set; }
        public static double CompassHeading { get; private set; }
        public static double LastRawCompassHeading { get; set; }
        public static double RawCompassHeading { get; set; }
        public static int Bearing { get; set; }
        public static int LastBearing { get; set; }
        public static bool BeaconPresent { get; set; }
        public static bool LastBeaconPresent { get; set; }

        private static readonly AnalogInput robotActivePin = new AnalogInput(AnalogChannels.ANALOG_PIN_A0 );


        static RobotState() {
            PingDistance = int.MaxValue;
            LastPingDistance = int.MaxValue;
            IRDistance = int.MaxValue;
            LastIRDistance = int.MaxValue;
            CompassHeading = double.MaxValue;
            LastcompassHeading = double.MaxValue;
            RawCompassHeading = double.MaxValue;
            LastRawCompassHeading = double.MaxValue;
            Bearing = int.MaxValue;
            LastBearing = int.MaxValue;
            BeaconPresent = false;
            LastBeaconPresent = false;
        }

        public static void SetPingDistance(int distance) {
            LastPingDistance = PingDistance;
            PingDistance = distance;
        }

        public static void SetIrDistance(double distance) {
            LastIRDistance = IRDistance;
            IRDistance = distance;
        }

        public static void SetHeading(double heading)
        {
            LastcompassHeading = CompassHeading;
            CompassHeading = heading;
        }

        public static void SetRawHeading(double rawHeading)
        {
            LastRawCompassHeading = RawCompassHeading;
            RawCompassHeading = rawHeading;
        }

        public static void SetBearing(int bearing)
        {
            LastBearing = Bearing;
            Bearing = bearing;
        }

        public static void SetBeaconHealth(bool health)
        {
            LastBeaconPresent = BeaconPresent;
            BeaconPresent = health;
        }
        public static bool CheckReady() {
            return robotActivePin.Read() >= 0.9;
        }
    }
}