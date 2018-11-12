using System;

namespace StopWatch
{
    public class StopWatch
    {
        private TimeSpan _startTime;
        private TimeSpan _duration;
        private bool _isRunning = false;

        public void Start()
        {
            if (this._isRunning)
                throw new InvalidOperationException("Stopwatch is already running");

            this._startTime = DateTime.Now.TimeOfDay;
            this._isRunning = true;

            Console.WriteLine("Stop watch has begun, enter (p) to pause the watch or (e) to exit");
            var input = Console.ReadLine();

            while (this._isRunning)
            {
                if (input == "e")
                {
                    Stop();
                    break;
                }
                else if (input == "p")
                {
                    Pause();
                    break;
                }
                Console.WriteLine("Invalid input. Please try again and enter (p) to pause or (e) to exit.");
                input = Console.ReadLine();
            }


        }

        public void Pause()
        {
            this._isRunning = false;
            this._duration = this._duration + (DateTime.Now.TimeOfDay - this._startTime);

            Console.WriteLine("Stop watch paused. Current Tracked Time: {0:D2}:{1:D2} \nEnter (c) to continue or (e) to exit", this._duration.Minutes, this._duration.Seconds);
            var input = Console.ReadLine();

            while (!this._isRunning)
            {
                if (input == "c")
                {
                    Start();
                    break;
                }
                else if (input == "e")
                {
                    Stop();
                    break;
                }

                Console.WriteLine("Invalid input. Please try again and press (c) to continue or (e) to exit.");
                input = Console.ReadLine();
            }
        }

        public void Stop()
        {
            this._isRunning = false;
            var time = this._duration == TimeSpan.Zero ? DateTime.Now.TimeOfDay - this._startTime : this._duration;
            Console.WriteLine("Ending the stopwatch, finished time is: {0:D2}:{1:D2}", time.Minutes, time.Seconds);
            Reset();
        }

        public void Reset()
        {
            Console.WriteLine("Would you like to reset the stopwatch? (Y/N)");
            var input = Console.ReadLine();
            switch (input.ToLower())
            {
                case "y":
                    Start();
                    break;
                case "n":
                    Console.WriteLine("Closing the program, bye now. (Press enter to close window)");
                    break;
                default:
                    Console.WriteLine("Invalid input, try again");
                    Reset();
                    break;
            }
        }
    }
}
