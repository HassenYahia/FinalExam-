using PBP.DataAccess;
using PBP.Pocos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PBP.BusinessLogic
{
    public class Calendar : BaseLogic<CalendarPoco>
    {
        public Calendar(IDataRepository<CalendarPoco> repository) : base(repository)
        {

        }

        protected override void Verify(CalendarPoco[] pocos)
        {
            base.Verify(pocos);
        }
        public override void Add(CalendarPoco[] pocos)
        {
            base.Add(pocos);
        }
        public override void Update(CalendarPoco[] pocos)
        {
            base.Update(pocos);
        }
    }
}
