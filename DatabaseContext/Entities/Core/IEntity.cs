using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseContext.Entities.Core
{

    public interface IEntity
    {


        [Key]
        Guid Key { get; set; }
    }
}