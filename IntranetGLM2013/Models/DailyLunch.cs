using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IntranetGLM2013.Models
{
    /// <summary>
    /// 
    /// </summary>
    public enum PublishedStatus : int { Publish = 1, Edit = 2, Disable = 3,}
    /// <summary>
    /// 
    /// </summary>
    public class DailyLunch
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LunchDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String ShortDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public PublishedStatus? PublishedStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool isPublished { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsEditable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int LunchItemId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public LunchItem LunchItem { get; set; }
    }

    public class WorkingDay
    {
        public string WeekDay { get; set; }
        public DateTime Day { get; set; }
        public string NameFunc { get; set; }
        public string Style { get; set; }
        public string ShortDate { get; set; }
        public bool isToday { get; set; }
        
        // GET api/DailyLunch?GetDays=
        public static List<WorkingDay> GetDays(string GetDays)
        {
            var Style = "none";
            var NameFunc = "dailyLunch";
            DateTime today = DateTime.Today;
            DateTime currDay = DateTime.Today;
            List<WorkingDay> days = new List<WorkingDay>();
            if (!string.IsNullOrEmpty(GetDays))
                try
                {
                    currDay = Convert.ToDateTime(GetDays);
                }
                catch (Exception)
                {
                    currDay = DateTime.Today;
                    //throw;
                }

            int j = (int)currDay.DayOfWeek;

            if (j == 0)
            {
                currDay = currDay.AddDays(1);
                j = 1;
            }
            else if (j == 6)
            {
                currDay = currDay.AddDays(2);
                j = 1;
            }

            // Domingo = 0, L=1, M=2, Mc=3, J=4, V=5, S=6
            WorkingDay curr = new WorkingDay();
            curr.WeekDay = "Anterior";
            curr.Day = currDay.AddDays(1 - j - 7).Date;
            curr.NameFunc = "listDays";
            curr.Style = "special";
            curr.isToday = false;
            curr.ShortDate = currDay.AddDays(1 - j - 7).Date.ToShortDateString();
            days.Add(curr);
            for (int i = 1 - j; i < 6 - j; i++)
            {
                curr = new WorkingDay();
                curr.WeekDay = currDay.AddDays(i).DayOfWeek.ToString();
                curr.Day = currDay.AddDays(i).Date;
                curr.NameFunc = NameFunc;
                curr.isToday = today.Date == curr.Day.Date;
                curr.Style = curr.isToday ? "activeDay" : Style;
                curr.ShortDate = currDay.AddDays(i).Date.ToShortDateString();
                days.Add(curr);
            }
            curr = new WorkingDay();
            curr.WeekDay = "Siguiente";
            curr.Day = currDay.AddDays(1 - j + 7).Date;
            curr.NameFunc = "listDays";
            curr.Style = "special";
            curr.isToday = false;
            curr.ShortDate = currDay.AddDays(1 - j + 7).Date.ToShortDateString();
            days.Add(curr);

            return days;
        }
    }
}