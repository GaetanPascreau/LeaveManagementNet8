namespace LeaveManagementNet8.Data
{
    public class LeaveType : BaseEntity
    {
        public string Name { get; set; }

        public double DefaultDays { get; set; }
    }
}
