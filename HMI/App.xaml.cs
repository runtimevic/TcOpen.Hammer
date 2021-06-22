﻿using PlcHammerConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Serilog.Events;
using Serilog;
using Raven.Client.Documents;

namespace HMI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            TcOpen.Inxton.TcoAppDomain.Current.Builder
                .SetUpLogger(new TcOpen.Inxton.Logging.SerilogAdapter())
                .SetDispatcher(TcoCore.Wpf.Threading.Dispatcher.Get);

            Entry.PlcHammer.Connector.ReadWriteCycleDelay = 2000;
            Entry.PlcHammer.Connector.BuildAndStart();
            Entry.PlcHammer.Connector.ReadWriteCycleDelay = 150;
        }
    }
}
