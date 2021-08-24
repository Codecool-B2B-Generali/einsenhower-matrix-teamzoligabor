using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Codecool.EinsenhowerMatrix
{
    /// <summary>
    /// Top level class for Matrix
    /// </summary>
    public class TodoMatrix
    {
        /// <summary>
        /// QuarterTypes enum
        /// </summary>
        public enum QuarterTypes
        {
            UrgentAndImportant,
            UrgentAndNotimportant,
            NotUrgentAndImportant,
            NotUrgentAndNotimportant,
        }

        /// <summary>
        /// Gets or sets dictionary with quarters
        /// </summary>
        public Dictionary<string, TodoQuarter> Quarters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoMatrix"/> class.
        /// </summary>
        public TodoMatrix()
        {
            CreateQuarters();
        }

        /// <summary>
        /// Creates new item based on given parameters
        /// </summary>
        /// <param name="title">title for new task</param>
        /// <param name="date">deadline for new task</param>
        /// <param name="isImportant">boolean value that indicates whenever task is important or not</param>
        public void AddItem(string title, DateTime date, bool isImportant = false)
        {
            DateTime nowPlus3Days = DateTime.Now.AddDays(3);
            if (date <= nowPlus3Days)
            {
                if (isImportant)
                {
                    Quarters["Urgent and Important"].AddItem(title, date, isImportant);
                }
                else
                {
                    Quarters["Urgent and Not important"].AddItem(title, date);
                }
            }
            else
            {
                if (isImportant)
                {
                    Quarters["Not urgent and Important"].AddItem(title, date, isImportant);
                }
                else
                {
                    Quarters["Not urgent and Not important"].AddItem(title, date);
                }
            }
        }

        /// <summary>
        /// Deletes all items that are marked as done
        /// </summary>
        public void ArchiveItems()
        {
            foreach (KeyValuePair<string, TodoQuarter> quarter in Quarters)
            {
                quarter.Value.ArchiveItems();
            }
        }

        /// <summary>
        /// Reads the content from given file, creates and add item to given quarter
        /// </summary>
        /// <param name="filePath">string with path leading to source file</param>
        public void AddItemsFromFile(string filePath)
        {
            var csv = File.ReadAllLines(filePath);

            foreach (var line in csv)
            {
                var fields = line.Split("|");
                AddItem(fields[0], Convert.ToDateTime(fields[1]), Convert.ToBoolean(fields[2]));
            }
        }

        /// <summary>
        /// Saves current matrix content to file
        /// </summary>
        /// <param name="filePath">file path under all task will be saved</param>
        public void SaveItemsToFile(string filePath)
        {
            var csv = new StringBuilder();

            foreach (KeyValuePair<string, TodoQuarter> quarter in Quarters)
            {
                foreach (TodoItem todoItem in quarter.Value.Items)
                {
                    var newLine = string.Format("{0}|{1}|{2}", todoItem.Title, todoItem.Deadline.ToString(), todoItem.IsImportant.ToString());
                    csv.AppendLine(newLine);
                }
            }

            File.WriteAllText(filePath, csv.ToString());
        }

        /// <summary>
        /// Returns human readable representation for one specific quarter
        /// </summary>
        /// <returns>string with all quarters and associated items</returns>
        /// <param name="quarterTypes">quartertype</param>
        public string GetSpecificQuarter(QuarterTypes quarterTypes)
        {
            string result;

            switch (quarterTypes)
            {
                case QuarterTypes.UrgentAndImportant:
                    result = Quarters["Urgent and Important"].ToString();
                    break;
                case QuarterTypes.UrgentAndNotimportant:
                    result = Quarters["Not urgent and Important"].ToString();
                    break;
                case QuarterTypes.NotUrgentAndImportant:
                    result = Quarters["Urgent and Not important"].ToString();
                    break;
                case QuarterTypes.NotUrgentAndNotimportant:
                    result = Quarters["Not urgent and Not important"].ToString();
                    break;
                default:
                    result = string.Empty;
                    break;
            }

            return result;
        }

        /// <summary>
        /// Returns human readable representation for matrix
        /// </summary>
        /// <returns>string with all quarters and associated items</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, TodoQuarter> quarter in Quarters)
            {
                sb.AppendLine(quarter.Key);
                sb.AppendLine(quarter.Value.ToString());
            }

            return sb.ToString();
        }

        private DateTime ConvertToDateFrom(string representation)
        {
            return Convert.ToDateTime(representation);
        }

        private void CreateQuarters()
        {
            Quarters = new Dictionary<string, TodoQuarter>();
            Quarters.Add("Urgent and Important", new TodoQuarter());
            Quarters.Add("Not urgent and Important", new TodoQuarter());
            Quarters.Add("Urgent and Not important", new TodoQuarter());
            Quarters.Add("Not urgent and Not important", new TodoQuarter());
        }
    }
}