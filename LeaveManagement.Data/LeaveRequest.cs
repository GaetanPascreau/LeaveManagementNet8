﻿using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementNet8.Data
{
    public class LeaveRequest : BaseEntity
    {
        public DateTime StartDate { get; set; }

        public string StartTime { get; set; }

        public DateTime EndDate { get; set; }

        public string EndTime { get; set; }

        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; }

        public int LeaveTypeId { get; set; }

        public DateTime DateRequested {  get; set; }  

        public string? RequestComments { get; set; }

        public bool? Approved { get; set; }

        public bool Cancelled { get; set; }

        public string RequestingEmployeeId { get; set; }

        public double RequestedDaysNumber { get; set; }

    }
}
