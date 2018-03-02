using MYSENDER.DatabaseModels;
using MYSENDER.Models;

namespace MYSENDER.Services
{
    public class ContactService
    {
        private MYSENDERContext _context;
        private static ContactService _intance;

        public static ContactService Instance => _intance ?? (_intance = new ContactService());

    }
}
