﻿using System;
using System.Runtime.Serialization;
using System.Data;
using System.ComponentModel.DataAnnotations;


namespace WinFormReports.Models
{
    [Serializable]
    [DataContract(Name = "kafPaymentInvoiceEntity", Namespace = "http://www.KAF.com/types")]
    public partial class kafPaymentInvoiceEntity
    {
        [DataMember]
        public string Key { get; set; }
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Extension { get; set; }

    }
}