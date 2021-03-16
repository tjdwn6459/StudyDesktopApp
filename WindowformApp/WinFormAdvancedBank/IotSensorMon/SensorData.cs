using System;

namespace IotSensorMon
{
    internal class SensorData
    {
        public DateTime Current { get; set; } //현재시간
        public int Value { get; set; }//센서값
        public bool SimulFlag { get; set; }//시뮬레이션 여부
  

        public SensorData(DateTime current, int value, bool isSimulation)
        {
            Current = current;
            Value = value;
            SimulFlag = SimulFlag;
        }
    }
}
