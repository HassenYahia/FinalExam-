using PBP.DataAccess;
using PBP.Pocos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PBP.BusinessLogic
{
   public  class Transaction : BaseLogic<TransactionPoco>
    {
        public Transaction(IDataRepository<TransactionPoco> repository) :base(repository)
        {

        }
        protected override void Verify(TransactionPoco[] pocos)
        {
            base.Verify(pocos);
        }
        public override void Add(TransactionPoco[] pocos)
        {
            base.Add(pocos);
        }
        public override void Update(TransactionPoco[] pocos)
        {
            base.Update(pocos);
        }
    }
}
