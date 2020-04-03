using PBP.DataAccess;
using PBP.Pocos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace PBP.BusinessLogic
{
   public class Reservation : BaseLogic<ReservationPoco>
    {
        public Reservation(IDataRepository<ReservationPoco> repository) :base(repository)
        {

        }
        protected override void Verify(ReservationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (ReservationPoco poco in pocos)
            {
                // Car plate validation
                if (string.IsNullOrEmpty(poco.CarPlateNumber))
                {
                    exceptions.Add(new ValidationException(700,$"Cannot be empty"));
                }
                else if (poco.CarPlateNumber.Length < 5 || poco.CarPlateNumber.Length > 8)
                {
                    exceptions.Add(new ValidationException(700,$"Cannot be Less than 5 Charactors or greater than 8 charactors"));
                }


                // Phone Validation
                if (string.IsNullOrEmpty(poco.Phone))
                {
                    exceptions.Add(new ValidationException(702, $"PhoneNumber for SecurityLogin {poco.Id} is required"));
                }
                else
                {
                    string[] phoneComponents = poco.Phone.Split('-');
                    if (phoneComponents.Length != 3)
                    {
                        exceptions.Add(new ValidationException(702, $"Phone Number for Reservatin {poco.Id} is not in the required format."));
                    }
                    else
                    {
                        if (phoneComponents[0].Length != 3)
                        {
                            exceptions.Add(new ValidationException(702, $"Phone Number for Reservation {poco.Id} is not in the required format."));
                        }
                        else if (phoneComponents[1].Length != 3)
                        {
                            exceptions.Add(new ValidationException(702, $"Phone Number for Reservation {poco.Id} is not in the required format."));
                        }
                        else if (phoneComponents[2].Length != 4)
                        {
                            exceptions.Add(new ValidationException(702, $"Phone Number for Reservatin {poco.Id} is not in the required format."));
                        }
                    }
                }
                // E-mail validation
                if (string.IsNullOrEmpty(poco.Email))
                {
                    exceptions.Add(new ValidationException(704, "E-mail for Reservation {poco.Id} can not be empty"));
                }
                else if (!Regex.IsMatch(poco.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                {
                    exceptions.Add(new ValidationException(704,"E-mail for Reservation {poco.Id} is not a valid E-mail address format."));
                }
                // Full Name Validatin
                if (string.IsNullOrEmpty(poco.FullName))
                {
                    exceptions.Add(new ValidationException(705, "Full Name for Reservation {poco.Id} is required."));
                }
                // Date validation
                if (poco.Date < DateTime.Now)
                {
                    exceptions.Add(new ValidationException(108, $"Invalid Date, Please select a date starting today"));
                }
            }   
            if (exceptions.Count > 0)
                {
                    throw new AggregateException(exceptions);
                }
            }
        public override void Add(ReservationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(ReservationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
    }
}
