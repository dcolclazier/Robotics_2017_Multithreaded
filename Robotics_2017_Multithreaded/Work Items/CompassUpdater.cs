using System.Threading;
using Robotics_2017.Drivers;
using Robotics_2017.Work_Items;

namespace Robotics_2017.Utility {
    public class CompassUpdater {
        private readonly Hmc5883L _compass;

        private readonly WorkItem _workItem;
        private readonly int _delay;

        //Maximum refresh rate from the HMC3883L is 14ms in continuous measurement mode
        public CompassUpdater(I2CBus bus,int delay = 100)
        {
            _compass = new Hmc5883L(bus);
            _workItem = new WorkItem(CompassUpdate, false, true, true);
            _delay = delay;
        }

        private void CompassUpdate() {
            //RobotState.SetRawHeading(_compass.readRaw());
            //RobotState.SetHeading(_compass.ReadHeading());
            RobotState.SetHeading(_compass.GetHeadingDegrees());
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