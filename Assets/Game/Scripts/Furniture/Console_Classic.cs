using HoloToolkit.Sharing.Spawning;
using HoloToolkit.Sharing.SyncModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


[SyncDataClass]
public class Console_Classic : SyncSpawnedObject
{

    /// <summary>
    /// Transform (position, orientation and scale) for the object.
    /// </summary>
    [SyncData] public SyncInteger postAction;
}

