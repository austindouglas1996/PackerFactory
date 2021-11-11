using CommandHandlerLib.Attributes;
using PackerControlPanel.Core;
using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackerControlPanel.Win32Console.Commands
{
    [CommandLibrary("Jobs")]
    public class JobCommands
    {
        private static IJobRepository Jobs
        {
            get
            {
                IJobRepository jobs = CommandUtility.AlkonInventory.Jobs;
                if (jobs == null)
                    throw new ArgumentNullException("Jobs");

                return jobs;
            }
        }

        [Command("AddJob", "Adds a new job into the datebase.")]
        public static IEnumerable<string> AddJob(string jobName, string partName)
        {
            return AddJob(new string[] { jobName }, new string[] { partName });
        }

        [Command("AddJob", "Adds an array of new jobs into the database.")]
        public static IEnumerable<string> AddJob(string[] jobNames, string[] partNames)
        {
            if (jobNames.Count() != partNames.Count())
                throw new IndexOutOfRangeException("Each array must contain the same amount of variables.");

            for (int i = 0; i < jobNames.Count(); i++)
            {
                string jobName = jobNames[i];
                string partName = partNames[i];

                Part part = CommandUtility.AlkonInventory.Parts.GetPartWithJobs(partName);

                if (part == null)
                    yield return string.Format("Invalid value. Failed to find a part by the name '{0}'.", partName);

                if (Jobs.GetJobByName(jobName) != null)
                    yield return "Invalid value. A job already exists by this name.";

                Job newJob = new Job();
                newJob.Name = jobName;
                newJob.PartID = part.ID;

                Jobs.Add(newJob);

                yield return string.Format("Created the new job '{0}' owned by '{1}'.", newJob.Name, part.Name);
            }
        }


        [Command("GetJob", "Gets information on a job based on id.")]
        public static string GetJob(int id, string[] args = null)
        {
            Job job = Jobs.Get(id);

            if (job == null)
                throw new ArgumentException("Invalid ID.");

            StringBuilder sb = new StringBuilder();

            var jobInfo = new Job[] { job }.ToTable();
            var entryInfo = job.Entries.ToArray().ToTable();

            sb.AppendLine(jobInfo.ToString());
            sb.AppendLine(entryInfo.ToString());

            return sb.ToString();
        }

        [Command("GetJobs", "Gets basic information on all jobs within the database.")]
        public static string GetJobs()
        {
            return Jobs.GetAll().ToArray().ToTable().ToString();
        }

        [Command("GetJobs", "Gets basic information on all jobs within the database based on owner.")]
        public static string GetJobs(string partName)
        {
            Part part = CommandUtility.AlkonInventory.Parts.GetPartWithJobs(partName);
            if (part == null)
                return string.Format("Invalid value. Failed to find a part by the name '{0}'.", partName);

            var jobArray = Jobs
                .GetAll()
                .Where(j => j.Part == part)
                .ToArray();

            if (jobArray == null)
                return string.Format("Failed to find any jobs owned by the part '{0}'.", partName);

            return jobArray.ToTable().ToString();
        }

        [Command("FindJob", "Gets information on a job based on name.")]
        public static string FindJob(string jobName)
        {
            Job job = Jobs.GetJobByName(jobName);
            if (job == null)
                return "Invalid job name. Failed to find the job " + jobName;

            return GetJob(job.ID, null);
        }

        [Command("FindJobs", "Gets information on all jobs that match a certain criteria within the database.")]
        public static string FindJob(string value, int searchType, string[] args = null)
        {
            if (searchType != 0 && searchType != 1)
                return "Invalid search type. Use 0 for start of text. Use 1 for end of text.";

            Job job = null;

            if (searchType == 0)
                job = Jobs.FirstOrDefault(j => job.Name.StartsWith(value));
            else if (searchType == 1)
                job = Jobs.FirstOrDefault(j => job.Name.EndsWith(value));

            return GetJob(job.ID, args);
        }


        [Command("RemoveJob", "Removes a job based on name from the database.")]
        public static string RemoveJob(string jobName)
        {
            Job job = Jobs.GetJobByName(jobName);
            if (job == null)
                return "Invalid job name. Failed to find the job " + jobName;

            Jobs.Remove(job);

            return string.Format("Removed the job '{0}'.", job.Name);
        }

        [Command("RemoveAll", "Removes all jobs within the database.")]
        public static string RemoveAll()
        {
            Jobs.RemoveAll();
            return "All jobs have been removed.";
        }


        [Command("SetJobOwner", "Resets the job part owner with the new provided value.")]
        public static string SetJobOwner(string jobName, string partName)
        {
            Part part = CommandUtility.AlkonInventory.Parts.GetPartWithJobs(partName);
            Job job = Jobs.GetJobByName(jobName);

            if (job == null | part == null)
            {
                return string.Format("Invalid value. Failed to find the {0} name.", part == null ? "part" : "job");
            }

            job.PartID = part.ID;

            CommandUtility.AlkonInventory.Jobs.Edit(job);

            return string.Format("Job owner has been successfully set to '{0}'.", part.Name);
        }

        [Command("SetJobStatus", "Sets a job status based on value.")]
        public static IEnumerable<string> SetJobStatus(string[] jobNames, JobStateType state)
        {
            foreach (var jobName in jobNames)
            {
                Job job = Jobs.GetJobByName(jobName);
                if (job == null)
                    yield return string.Format("Invalid value. Failed to find a job by the name of '{0}'.", jobName);

                job.SetJobState(state);

                CommandUtility.AlkonInventory.Jobs.Edit(job);

                yield return string.Format("The job {0} has been set as {1} at {2}",
                    job.Name, state.ToString(), job.CompletionTime.ToShortDateString());
            }
        }

        [Command("SetGlobalStatus", "Sets a value indicating whether a job can be assigned to any part.")]
        public static string SetGlobalStatus(string jobName, bool isGlobal)
        {
            Job job = Jobs.GetJobByName(jobName);
            if (job == null)
                return string.Format("Invalid value. Failed to a job by the name of '{0}'.", jobName);

            job.IsGlobal = isGlobal;

            CommandUtility.AlkonInventory.Jobs.Edit(job);

            return string.Format("IsGlobalStatus: " + job.IsGlobal);
        }
    }
}
