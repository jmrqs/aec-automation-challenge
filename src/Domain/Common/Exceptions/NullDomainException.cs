﻿
namespace AeC.AutomationChallenge.Domain.Common.Exceptions
{
    public class NullDomainException : DomainException
    {
        public NullDomainException(string msg) : base(msg)
        {

        }
    }
}