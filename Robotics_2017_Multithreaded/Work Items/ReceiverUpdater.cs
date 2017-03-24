using System.Threading;
using Microsoft.SPOT;
using Robotics_2017.Drivers;

namespace Robotics_2017.Work_Items
{
    public class ReceiverUpdater
    {
        private readonly Receiver _receiver;

        private readonly WorkItem _workItem;
        //private readonly WorkItem _workItem2;

        private readonly int _delay;

        //Maximum refresh rate from the HMC3883L is 14ms in continuous measurement mode
        //public ReceiverUpdater(I2CBus bus, int delay = 500)
        public ReceiverUpdater(int delay = 500)
        {
            //_receiver = new Receiver(bus);
            //_workItem = new WorkItem(ReceiverUpdate, false, true, true);
            //_workItem2 = new WorkItem(Health, false, true, true);

            _delay = delay;
        }

        private void ReceiverUpdate()
        {
            Debug.Print("Requesting data from Ardunio");
            //RobotState.SetBearing(_receiver.FindBeacon());
            Thread.Sleep(_delay);
        }

        private void Health()
        {
            RobotState.SetBeaconHealth(_receiver.BeaconPresent());
            Thread.Sleep(_delay);
        }

        public void Start()
        {
            _workItem.Start();
            //_workItem2.Start();
        }

        public void Stop()
        {
            _workItem.Stop();
            //_workItem2.Stop();
        }
    }
}