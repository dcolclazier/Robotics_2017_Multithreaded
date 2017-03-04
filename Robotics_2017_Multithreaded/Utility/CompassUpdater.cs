using System.Threading;
using Microsoft.SPOT.Hardware;
using Robotics_2017.Drivers;
using Robotics_2017.Work_Items;

namespace Test_Bot_Multithread.Work_Items {
    public class CompassUpdater {
        private readonly Hmc5883L _compass;

        private readonly WorkItem _workItem;
        private readonly int _delay;

        //Maximum refresh rate from the HMC3883L is 14ms in continuous measurement mode
        public CompassUpdater(int delay = 50) {
            _compass = new Hmc5883L(1000);
            _workItem = new WorkItem(CompassUpdate, false, true, true);
            _delay = delay;
        }

        private void CompassUpdate() {
            //RobotState.SetRawHeading(_compass.readRaw());
            //RobotState.SetHeading(_compass.ReadHeading());
            RobotState.SetHeading(_compass.GetHeading());
            Thread.Sleep(_delay);
        }

        public void Start() {
            _workItem.Start();
        }

        public void Stop() {
            _workItem.Stop();
        }
    }
}