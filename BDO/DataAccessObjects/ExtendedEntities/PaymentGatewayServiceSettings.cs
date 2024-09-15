using System;
using System.Collections.Generic;
using System.Text;

namespace BDO.DataAccessObjects.ExtendedEntities
{
    public class PaymentGatewayServiceSettings
    {
        public string PaymentGatewayService { get; set; }
        public string PaymentGatewayServiceStepOne { get; set; }
        public string Merchantreturnsuccessurl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


        public string GTUserName { get; set; }
        public string GTPassword { get; set; }
    }
}
