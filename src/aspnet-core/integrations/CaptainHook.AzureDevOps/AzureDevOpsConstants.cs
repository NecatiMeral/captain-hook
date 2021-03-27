namespace CaptainHook.AzureDevOps
{
    /// <summary>
    /// Well-known names used in Azure DevOps receivers and handlers.
    /// </summary>
    public static class AzureDevOpsConstants
    {
        /// <summary>
        /// Gets the JSON path of the property in an Azure DevOps WebHook request body containing the Azure DevOps event
        /// type.
        /// </summary>
        public static string EventBodyPropertyPath => "$['eventType']";

        /// <summary>
        /// Gets the name of the Azure DevOps WebHook receiver.
        /// </summary>
        public static string ReceiverName => "AzureDevOps";

        public static class EventType
        {
            public static class BuildAndRelease
            {
                /// <summary>
                /// A build completes
                /// </summary>
                public const string BuildCompleted = "build.complete";

                /// <summary>
                /// A release was abandoned
                /// </summary>
                public const string ReleaseAbandoned = "ms.vss-release.release-abandoned-event";

                /// <summary>
                /// A release was created
                /// </summary>
                public const string ReleaseCreated = "ms.vss-release.release-created-event";

                /// <summary>
                /// A deployment approval has been completed
                /// </summary>
                public const string ReleaseDeploymentApprovalCompleted = "ms.vss-release.deployment-approval-completed-event";

                /// <summary>
                /// A deployment approval has been requested
                /// </summary>
                public const string ReleaseDeploymentApprovalPending = "ms.vss-release.deployment-approval-pending-event";

                /// <summary>
                /// A deployment completed
                /// </summary>
                public const string ReleaseDeploymentCompleted = "ms.vss-release.deployment-completed-event";

                /// <summary>
                /// A deployment was started
                /// </summary>
                public const string ReleaseDeploymentStarted = "ms.vss-release.deployment-started-event";
            }

            public static class Pipelines
            {
                /// <summary>
                /// Overall status of a pipeline run changed. A new run has started, or a run has transitioned to canceling, canceled, failed, partially succeeded or succeeded state.
                /// </summary>
                public const string RunStateChanged = "ms.vss-pipelines.run-state-changed-event";

                /// <summary>
                /// A new stage has started, or a stage has transitioned to canceling, canceled, failed, partially succeeded or succeeded.
                /// </summary>
                public const string RunStageStateChanged = "ms.vss-pipelines.stage-state-changed-event";

                /// <summary>
                /// An approval is created for a run stage
                /// </summary>
                public const string RunStageWaitingForApproval = "ms.vss-pipelinechecks-events.approval-pending";

                /// <summary>
                /// An approval completed for a run stage
                /// </summary>
                public const string RunStageApprovalCompleted = "ms.vss-pipelinechecks-events.approval-completed";
            }

            public static class Code
            {
                /// <summary>
                /// A changeset is checked into TFVC.
                /// </summary>
                public const string CodeCheckedIn = "tfvc.checkin";

                /// <summary>
                /// Code is pushed to a Git repository
                /// </summary>
                public const string CodePushed = "git.push";

                /// <summary>
                /// Pull request is created in a Git repository
                /// </summary>
                public const string PullRequestCreated = "git.pullrequest.created";

                /// <summary>
                /// Pull request - Created merge commit
                /// </summary>
                public const string PullRequestMerged = "git.pullrequest.merged";

                /// <summary>
                /// Pull request is updated; status, review list, reviewer vote changed or the source branch is updated with a push
                /// </summary>
                public const string PullRequestUpdated = "git.pullrequest.updated";

                /// <summary>
                /// Pull request is commented
                /// </summary>
                public const string PullRequestCommented = "ms.vss-code.git-pullrequest-comment-event";
            }
        }
    }
}
