﻿namespace DeCiBlog.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public bool IsDisabled { get; set; }
    }
}