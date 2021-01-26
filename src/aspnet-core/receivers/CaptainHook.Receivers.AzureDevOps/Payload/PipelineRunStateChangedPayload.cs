using System;
using System.Collections.Generic;
using System.Text;

namespace CaptainHook.Receivers.AzureDevOps.Payload
{
    /// <summary>
    /// Describes the entire payload of event '<c>ms.vss-pipelines.run-state-changed-event</c>'.
    /// </summary>
    public class PipelineRunStateChangedPayload : BasePayload<PipelineRunStateChangedResource>
    {
    }
}
