﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    public interface INotificationAction
    {
        void ActOnNotification(string message);
    }
}
