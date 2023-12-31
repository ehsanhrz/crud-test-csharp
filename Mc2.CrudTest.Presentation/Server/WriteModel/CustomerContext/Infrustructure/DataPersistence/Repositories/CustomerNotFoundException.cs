﻿using System.Runtime.Serialization;

namespace Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Infrustructure.DataPersistence.Repositories
{
    [Serializable]
    internal class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException()
        {
        }

        public CustomerNotFoundException(string? message) : base(message)
        {
        }

        public CustomerNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CustomerNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => "Customer Not Found";
    }
}