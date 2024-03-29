﻿using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementNet8.Data
{
    public class LeaveAllocation : BaseEntity
    {
        public double NumberOfDays { get; set; }

        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; }

        public int LeaveTypeId { get; set; }

        public string EmployeeId { get; set; }

        public int Period {  get; set; }
    }
}
