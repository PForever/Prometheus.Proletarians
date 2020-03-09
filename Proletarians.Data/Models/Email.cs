using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Prometheus.Infrastructure;

namespace Proletarians.Data.Models
{
    [Owned]
    public class Email : BaseVo<Email>
    {
        public string Alias { get; protected set; }
        public string Host { get; protected set; }

        public Email(string @alias, string host) : this()
        {
            Alias = alias;
            Host = host;
        }
        protected Email() : base(new EmailValidator())
        {
        }
    }

    class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
        }
    }
}
