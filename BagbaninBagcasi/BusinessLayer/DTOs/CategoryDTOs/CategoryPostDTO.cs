﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.CategoryDTOs;

public class CategoryPostDTO
{
    public string Title { get; set; }
    public IFormFile Image { get; set; }
    public string Description { get; set; } = string.Empty;

}
