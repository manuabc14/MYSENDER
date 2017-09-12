using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MYSENDER.Models
{
    public class SmsModeModel
    {
        [Required]
        [Display(Name = "Emetteur")]
        public string ReceiverNumber { get; set; }


        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; }

    }


    public class ResponseSms
    {
        public string StatusCode { get; set; }
        public string Description { get; set; }
        public string SmsId { get; set; }
    }

    public enum StatutCode
    {
        AcceptedMessageProcessed = 0,
        InternalError = 31,
        AuthenticationError = 32,
        InsufficientAccountBalance = 33,
        MissingMandatoryParameter = 35,
        TemporarilyUnavailable = 50
    }
}
