using System;
using System.Timers;

namespace DpUtils
{
	public class UndefinedTimer
	{
		const long MIN_INTERVAL = 1;
		private long interval;
		private long intervalTemp;
		System.Timers.Timer timer;

		public UndefinedTimer (long interval)
		{
			this.intervalTemp = Math.Abs (interval);
			IntervalConfig ();
			TimerConfig ();
		}

		abstract void OnElapsedTime(Object source, System.Timers.ElapsedEventArgs e);


		private void IntervalConfig() {

			if (interval < MIN_INTERVAL) {
				this.interval = MIN_INTERVAL;
			} 
			else {
				this.interval = intervalTemp;
			}
		}
		private void TimerConfig() {

			if (this.timer == null) {
				this.timer = new System.Timers.Timer (interval);
				this.timer.Elapsed += new ElapsedEventHandler (OnElapsedTime);
			}
		}

		public sealed void Stop() {
			this.timer.Stop ();
		}

		public sealed void Cancel() {
			Stop ();
			this.timer.Close ();
		}

		public sealed void Start() {
			this.timer.Start();
		}
	}
}



