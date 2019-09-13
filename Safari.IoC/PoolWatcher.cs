using Safari.Services;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.IoC
{
    public class PoolWatcher
    {
        //Properties
        private INotificationAction _action;
        public INotificationAction Action
        {
            get
            {
                return _action;
            }
            set
            {
                _action = value;
            }
        }


        //Constructors

        public PoolWatcher() { }

        public PoolWatcher(INotificationAction action)
        {
            _action = action;
        }


        public void Notify(string message)
        {
            if (_action == null)
            {
                _action = new EventLogWriter();
            }

            _action.ActOnNotification(message);
        }

        public void Notify(INotificationAction action, string message)
        {
            this._action = @action;
            action.ActOnNotification(message);
        }
    }
}
