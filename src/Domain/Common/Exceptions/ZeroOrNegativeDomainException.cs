﻿namespace AeC.AutomationChallenge.Domain.Common.Exceptions
{
    public class ZeroOrNegativeDomainException : DomainException
    {
        public ZeroOrNegativeDomainException(string msg) : base(msg)
        {

        }
    }
}