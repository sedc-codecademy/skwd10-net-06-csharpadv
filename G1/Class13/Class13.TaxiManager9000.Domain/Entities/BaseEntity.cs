﻿namespace Class13.TaxiManager9000.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public abstract string Print();
    }
}
