using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public delegate void TimeIsUp(object sender, OnCompletEventArgs e);
    public delegate void Ticks(object sender, ProgressEventArgs e);

    public class Timer
    {
        public event TimeIsUp Complete;
        public event Ticks Tick;
        private BackgroundWorker bw;

        public Timer()
        {
            bw = new BackgroundWorker();
            bw.DoWork += Dowork;
            bw.RunWorkerCompleted += OnComleted;
            bw.ProgressChanged += OnTick;
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
        }

        public void Start(int numberOfSec)
        {
            if (numberOfSec < 1)
                throw new ArgumentException(ResTimerEx.ArgumentExcString);
            if (!bw.IsBusy) 
                bw.RunWorkerAsync(numberOfSec);
        }

        public void Stop()
        {
            bw.CancelAsync();
        }

        private void Dowork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 0; i <= (int)e.Argument; i++)
            {
                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
             
                worker.ReportProgress(i / (int)e.Argument, (int)e.Argument - i);
                System.Threading.Thread.Sleep(1000);
            }
        }

        private void OnComleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool condition = false;
            if (e.Error != null) 
                condition = true; 
            if (Complete != null)
                Complete(this, new OnCompletEventArgs(condition));
        }

        private void OnTick(object sender, ProgressChangedEventArgs e)
        {
            if (Tick != null)
                Tick(this, new ProgressEventArgs((int)e.UserState));
        }
    }

    public class ProgressEventArgs : EventArgs
    {
        public ProgressEventArgs(int current)
        {
            this.Current = current;
        }

        public int Current { get; private set; }
    }

    public class OnCompletEventArgs : EventArgs
    {
        public bool Condition { get; private set; }
        public OnCompletEventArgs(bool conditionOfErr)
        {
            this.Condition = conditionOfErr;
        }
    }
}
