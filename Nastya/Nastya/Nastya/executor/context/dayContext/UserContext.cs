using System;
using System.Threading;
using Nastya.Nastya.logger;

namespace Nastya.Nastya.executor.context
{
    public class UserContext
    {
        private Thread KickingThread { get; set; }

        private bool _greeted;
        public bool Greeted
        {
            get
            {
                return _greeted;
            }
            set
            {
                if (value)
                    StartThread();
                else
                    StopThread();

                _greeted = value;
            }
        }

        public UserContext(Thread kickingThread)
        {
            KickingThread = kickingThread;
            Logger.Out("Created user context(new user)", MessageType.Debug);
            Greeted = false;
        }

        private void StartThread()
        {
            if (KickingThread == null)
            {
                Logger.Out("Kicking thread started without initialization", MessageType.Error);
                return;
            }
            KickingThread.Start();
        }

        private void StopThread()
        {
            if (KickingThread?.ThreadState == ThreadState.Running)
                KickingThread?.Abort();
        }

    }
}