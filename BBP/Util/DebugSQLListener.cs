using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Clutch.Diagnostics.EntityFramework;

namespace BBP.Util
{
    public class DebugSQLListener : IDbTracingListener
    {
        public void CommandExecuted(DbTracingContext context)
        {
            Debug.WriteLine(context.Command.CommandText);
        }

        public void CommandExecuting(DbTracingContext context)
        {
            //throw new NotImplementedException();
        }

        public void CommandFailed(DbTracingContext context)
        {
            //throw new NotImplementedException();
        }

        public void CommandFinished(DbTracingContext context)
        {
            //throw new NotImplementedException();
        }

        public void ReaderFinished(DbTracingContext context)
        {
            //throw new NotImplementedException();
        }
    }
}