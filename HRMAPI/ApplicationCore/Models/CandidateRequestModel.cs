﻿using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMMVC.Models
{
    public class CandidateRequestModel
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ResumeURL { get; set; }

    }
}

