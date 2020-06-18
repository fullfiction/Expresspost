using System;

namespace api.Core.Store.Entities
{
    public abstract class Entity
    {
        public long Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        public override bool Equals(object obj)
        {
            if (!(obj is Entity))
            {
                return false;
            }
            return ((Entity)obj).Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
