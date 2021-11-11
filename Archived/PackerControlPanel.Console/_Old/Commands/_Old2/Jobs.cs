using CommandHandlerLib;
using PackerControlPanel.Core.Domain;
using PackerControlPanel.Core.Repository;
using PackerControlPanel.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PackerControlPanel.PanelConsole.Commands
{
    public class JobCommands
    {
        private static IJobRepository Jobs = CommandHelper.AlkonInventory.Jobs;

        public static string Create(string jobName, object owner)
        {
            Job job = new Job();
            job.Name = jobName;

            Part jobOwner = null;
            
            if (((string)owner).IsID())
            {
                jobOwner = CommandHelper.AlkonInventory.Parts.Get(Convert.ToInt32(owner));

                if (owner == null)
                    throw new IndexOutOfRangeException(string.Format("Unable to find a job by the ID of '{0}", owner));
            }
            else
            {
                jobOwner = CommandHelper.AlkonInventory.Parts.GetPartByName((string)owner);

                if (owner == null)
                    throw new InvalidOperationException(string.Format(CommandHelper.ERROR_PART_NOT_FOUND, owner));
            }

            job.Part = jobOwner;
                
            if (Jobs.FirstOrDefault(j => j.Name == jobName) != null)
                return "<r>A job already exists by this name. Failed to create job.";

            Jobs.Add(job);

            return string.Format("<g>The job #'{0}' and the owner of {1} was successfully created.", jobName, jobOwner.Name);
        }

        public static string GetAll()
        {
            var jobArray = Jobs.GetAll().ToArray();
            ConsoleTable jobs = jobArray.ToTable();
            return jobs.ToString();
        }

        public static string Get(string jobName)
        {
            Job job = job = Jobs.FirstOrDefault(j => j.Name == (string)value);

            if (job == null)
                throw new InvalidOperationException(string.Format(CommandHelper.ERROR_ORDER_NOT_FOUND, value));

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("--- Job Information --- ");
            sb.AppendLine(new Job[] { job }.ToTable().ToString());

            sb.AppendLine("--- Job Entrys --- ");
            sb.AppendLine(job.Entrys.ToArray().ToTable().ToString());

            return sb.ToString();
        }

        public static string RemoveAll(bool skipQuestions = false)
        {
            if (CommandHelper.AskQuestion("Are you sure you want to delete all jobs?"))
            {
                Jobs.RemoveAll();
                return "<g>All Jobs have been removed.";
            }
            else
                return "<y>Command cancelled.";
        }

        public static string Remove(string value, bool skipQuestions = false)
        {
            Job job = GetJob(value);

            if (!skipQuestions)
            {
                if (!CommandHelper.AskQuestion(string.Format("Are you sure you want to delete the job '{0}'?", job.Name)))
                {
                    return "<r>command cancelled.";
                }
            }

            Jobs.Remove(job);

            return string.Format("The job '{0}' has been removed successfully.", job.Name);
        }

        private static Job GetJob(string value)
        {
            Job job = null;

            if (value.StartsWith("id:"))
            {
                value.Replace("id:", "");

                job = Jobs.Get(Convert.ToInt32(value));

                if (job == null)
                    throw new IndexOutOfRangeException(String.Format(CommandHelper.ERROR_ORDER_ID_NOT_FOUND, value));
            }
            else
            {
                job = Jobs.FirstOrDefault(j => j.Name == (string)value);

                if (job == null)
                    throw new InvalidOperationException(string.Format(CommandHelper.ERROR_ORDER_NOT_FOUND, value));
            }

            return job;
        }
    }
}
