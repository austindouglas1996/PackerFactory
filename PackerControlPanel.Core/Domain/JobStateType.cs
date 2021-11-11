namespace PackerControlPanel.Core.Domain
{
    using System;
    using System.ComponentModel;

    public enum JobStateType
    {
        [Description("The job is currently not running with 0 entries tied to it.")]
        NotRunning = -1,

        [Description("The job is currently in progress.")]
        InProgress = 0,

        [Description("The job has been marked as paused due to no entries found within the last 30 days.")]
        Paused = 2,

        [Description("The job has been set as complete.")]
        Complete = 1,

        [Description("The job has been set as complete but with insufficent results such as waiting on rework.")]
        CompleteWithInSufficentResults = 3
    }
}