using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TOTVSChallenge.Domain.Entities
{
    public class Auction: EntityBase
    {
        

        public int UserId { get; private set; }
        public virtual User UserReference { get; private set; }
        public string Name { get; private set; }

        public decimal InitialValue { get; private set; }

        public Boolean Used { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public static Auction Create(
            int userId,
            string name,
            decimal initialValue,
            bool used,
            DateTime startDate,
            DateTime endDate) => new Auction()
            {
                UserId = userId,
                Name = name,
                InitialValue = initialValue,
                Used = used,
                StartDate = startDate,
                EndDate = endDate
            };

        public static Auction Create() => new Auction() { };

        public void SetUser(int userId) => this.UserId = userId;
        public void PrepareUpdate(Auction entity)  
        {
            this.UserId = entity.UserId;
            this.Name = entity.Name;
            this.InitialValue = entity.InitialValue;
            this.Used = entity.Used;
            this.StartDate = entity.StartDate;
            this.EndDate = entity.EndDate;
        }

    }
}
