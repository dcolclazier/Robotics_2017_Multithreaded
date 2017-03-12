using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Robotics_2017.Work_Items {

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