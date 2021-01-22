namespace CaptainHook
{
    public static class CaptainHookConsts
    {
        public const string DbTablePrefix = "App";

        public const string DbSchema = null;

        /// <summary>
        /// https://docs.microsoft.com/en-us/azure/devops/service-hooks/events?view=azure-devops
        /// </summary>
        public static class EventTypes
        {
            public static class Code
            {
                /// <summary>
                /// <para>
                /// A changeset is checked into TFVC.
                /// </para>
                /// https://docs.microsoft.com/en-us/azure/devops/service-hooks/events?view=azure-devops#code-checked-in
                /// </summary>
                public const string CodeCheckedIn = "tfvc.checkin";

                /// <summary>
                /// <para>
                /// Code is pushed to a Git repository
                /// </para>
                /// https://docs.microsoft.com/en-us/azure/devops/service-hooks/events?view=azure-devops#code-pushed
                /// </summary>
                public const string CodePushed = "git.push";

                /// <summary>
                /// <para>
                /// Pull request is created in a Git repository
                /// </para>
                /// https://docs.microsoft.com/en-us/azure/devops/service-hooks/events?view=azure-devops#pull-request-created
                /// </summary>
                public const string PullRequestCreated = "git.pullrequest.created";

                /// <summary>
                /// <para>
                /// Pull request - Created merge commit
                /// </para>
                /// https://docs.microsoft.com/en-us/azure/devops/service-hooks/events?view=azure-devops#pull-request-merge-commit-created
                /// </summary>
                public const string PullRequestMergeCommitCreated = "git.pullrequest.merged";

                /// <summary>
                /// <para>
                /// Pull request is updated; status, review list, reviewer vote changed or the source branch is updated with a push
                /// </para>
                /// https://docs.microsoft.com/en-us/azure/devops/service-hooks/events?view=azure-devops#pull-request-updated
                /// </summary>
                public const string PullRequestUpdated = "git.pullrequest.updated";
            }

            public static class WorkItem
            {
                /// <summary>
                /// <para>
                /// Filter events to include only newly created work items.
                /// </para>
                /// https://docs.microsoft.com/en-us/azure/devops/service-hooks/events?view=azure-devops#work-item-created
                /// </summary>
                public const string Created = "workitem.created";

                /// <summary>
                /// <para>
                /// Filter events to include only newly created work items.
                /// </para>
                /// https://docs.microsoft.com/en-us/azure/devops/service-hooks/events?view=azure-devops#work-item-deleted
                /// </summary>
                public const string Deleted = "workitem.deleted";
            }

        }
    }
}
