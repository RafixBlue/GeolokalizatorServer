using FluentValidation;
using GeolokalizatorSerwer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Models.Validators
{
    public class SynchronizationTimeZoneDtoValidator : AbstractValidator<SynchronizationTimeZoneDto>
    {
        public SynchronizationTimeZoneDtoValidator(GeolokalizatorDbContext dbContext)
        {
            //RuleFor()


                /*.Custom((value, context) =>
                {
                    var emailInUse = dbContext.Users.Any(u => u.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "Email is already in use");
                    }
                });*/
        }
    }
}
