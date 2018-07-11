using UnityEngine;

namespace bType
{

    public class Timer
    {
        public Timer() { }

        public Timer(uint milliseconds)
        {
            _milli = milliseconds;
            _start = (uint)(Time.time * 1000);
            _set = true;
        }

        public void Start(uint milliseconds)
        {
            _milli = milliseconds;
            _start = (uint)(Time.time * 1000);
            _set = true;
        }

        public void Reset()
        {
            _start = (uint)(Time.time * 1000);
        }

        public bool Passed()
        {
            return ((Time.time * 1000) >= _start + _milli) && _set;
        }

        public uint StartTime()
        {
            return _start;
        }

        public uint Milli()
        {
            return _milli;
        }

        public bool IsSet()
        {
            return _set;
        }

        public float Seconds()
        {
            return (float)(_start + _milli) / 1000 - Time.time;
        }

        public int Milliseconds()
        {
            return (int)(_start + _milli) - (int)(Time.time * 1000);
        }

        public int Progress()
        {
            return 100 - (Milliseconds() * 100) / (int)_milli;
        }

        private uint _milli;
        private uint _start;
        private bool _set = false;
    }
}