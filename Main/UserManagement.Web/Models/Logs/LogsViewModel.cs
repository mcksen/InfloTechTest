using System;


namespace UserManagement.Web.Models.Logs;

public class LogsViewModel
{
    public List<LogsItemViewModel> Items { get; set; } = new();
    public DateTime MinDateTime { get; set; } = DateTime.MinValue;
    public DateTime MaxDateTime { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
}

public class LogsItemViewModel
{
    public long Id { get; set; }
    public long EntityId { get; set; }

    public string? EntityType { get; set; }
    public enum actionType { Add, Edit, View, Delete };
    public actionType ActionType { get; set; }

    public DateTime Timestamp { get; set; }


    public string? Message { get; set; }

}