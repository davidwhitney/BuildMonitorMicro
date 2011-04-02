﻿using System;
using BuildMonitorMicro.BuildMonitoring;
using MicroUnit;

namespace BuildMonitorMicro.Test.Unit.BuildMonitoring
{
    public class BuildMonitorTests
    {
        public void Test_Ctor_PassedNullConfiguration_ThrowsArgumentNullException()
        {
            var exceptionThrown = (ArgumentNullException) Assert.Throws(typeof(ArgumentNullException), () => { new BuildMonitor(null, null, null, null, null); });

            Assert.That(exceptionThrown.ParamName, Is.StringContaining("configuration"));
        }
    }
}
