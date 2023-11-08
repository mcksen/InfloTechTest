using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using Microsoft.EntityFrameworkCore;

namespace UserManagement.Models;

public class Log
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public long EntityId { get; set; }

    public string? EntityType { get; set; }
    public enum actionType { Add, Edit, View, Delete };
    public actionType ActionType { get; set; }

    public DateTime Timestamp { get; set; }

    public string? Message { get; set; }
    public Log() { }

    public Log(ILoggable entity, actionType ActionType)
    {
        EntityId = entity.Id;
        EntityType = entity.GetType().Name;

        this.ActionType = ActionType;
        Timestamp = DateTime.Now;


        switch (ActionType)
        {
            case actionType.Add:
                Message = $"Entity of type {this.EntityType} was created under id {this.EntityId} at {this.Timestamp}";
                break;
            case actionType.Edit:
                Message = $"Entity of type {this.EntityType} with id {this.EntityId} was updated at {this.Timestamp}";
                break;
            case actionType.Delete:
                Message = $"Entity of type {this.EntityType} with id {this.EntityId} was deleted at {this.Timestamp}";
                break;

        }

    }


}
