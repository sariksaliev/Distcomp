﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DistComp.Models;

public class News : BaseModel
{
    [Required]
    [MinLength(2)]
    [MaxLength(64)]
    [Column(TypeName = "text")]
    public string Title { get; set; }
    
    [Required]
    [MinLength(4)]
    [MaxLength(2048)]
    [Column(TypeName = "text")]
    public string Content { get; set; }
    
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime Created { get; set; }
    
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime Modified { get; set; }
    
    [Column("author_id")]
    public long AuthorId { get; set; }
    public virtual Author Author { get; set; }

    public virtual List<Reaction> Reactions { get; set; } = [];

    public virtual List<Label> Labels { get; set; } = [];
}