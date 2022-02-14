using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Datos.General
{
    public class DLogEvent
    {
        public void RegistrarEvento(string sMensaje, string sSource)
        {
            EventLog oLog = new EventLog("SISU", Environment.MachineName, sSource);
            EventLog.WriteEntry(sSource, sMensaje, EventLogEntryType.Error);
            oLog.Dispose();
        }
    }
}
