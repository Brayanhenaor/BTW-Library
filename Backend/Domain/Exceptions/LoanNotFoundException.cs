using System;
namespace Domain.Exceptions
{
	public class LoanNotFoundException : BaseException
    {
        public LoanNotFoundException() : base("Loan not found", 404)
        {
        }
    }
}

