using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitnessApp.Models
{
    public class CountdownTimer : CancellationTokenSource
    {
        private readonly Action _callback;
        private int _millisecondsDueTime;
        private readonly int _millisecondsPeriod;

        public CountdownTimer(Action callback, int millisecondsDueTime)
        {
            _callback = callback;
            _millisecondsDueTime = millisecondsDueTime;
            _millisecondsPeriod = -1;
            Start();
        }

        public CountdownTimer(Action callback, int millisecondsDueTime, int millisecondsPeriod)
        {
            _callback = callback;
            _millisecondsDueTime = millisecondsDueTime;
            _millisecondsPeriod = millisecondsPeriod;
            Start();
        }

        private void Start()
        {
            Task.Run(() => {
                if (_millisecondsDueTime <= 0)
                {
                    _millisecondsDueTime = 1;
                }
                Task.Delay(_millisecondsDueTime, Token).Wait();
                while (!IsCancellationRequested)
                {

                    //TODO handle Errors - Actually the Callback should handle the Error but if not we could do it for the callback here
                    _callback();

                    if (_millisecondsPeriod <= 0) break;

                    if (_millisecondsPeriod > 0 && !IsCancellationRequested)
                    {
                        Task.Delay(_millisecondsPeriod, Token).Wait();
                    }
                }
            });
        }

        public void Stop()
        {
            Cancel();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Cancel();
            }
            base.Dispose(disposing);
        }
    }
}
