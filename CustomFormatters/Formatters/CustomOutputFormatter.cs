﻿using CustomFormatters.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace CustomFormatters.Formatters
{

    public class VcardOutputFormatter : TextOutputFormatter

    {
        #region snippet_ctor
        public VcardOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/vcard"));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        #endregion

        #region snippet_CanWriteType
        protected override bool CanWriteType(Type type)
        {
            return typeof(Contact).IsAssignableFrom(type) ||
                typeof(IEnumerable<Contact>).IsAssignableFrom(type);
        }
        #endregion

        #region snippet_WriteResponseBodyAsync
        public override async Task WriteResponseBodyAsync(
            OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var httpContext = context.HttpContext;
            var serviceProvider = httpContext.RequestServices;

            var logger = serviceProvider.GetRequiredService<ILogger<VcardOutputFormatter>>();
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<Contact> contacts)
            {
                foreach (var contact in contacts)
                {
                    FormatVcard(buffer, contact, logger);
                }
            }
            else
            {
                FormatVcard(buffer, (Contact)context.Object, logger);
            }

            await httpContext.Response.WriteAsync(buffer.ToString(), selectedEncoding);
        }

        private static void FormatVcard(
            StringBuilder buffer, Contact contact, ILogger logger)
        {
            buffer.AppendLine("BEGIN:VCARD");
            buffer.AppendLine("VERSION:2.1");
            buffer.AppendLine($"N:{contact.LastName};{contact.FirstName}");
            buffer.AppendLine($"FN:{contact.FirstName} {contact.LastName}");
            buffer.AppendLine($"UID:{contact.Id}");
            buffer.AppendLine("END:VCARD");

            logger.LogInformation("Writing {FirstName} {LastName}",
                contact.FirstName, contact.LastName);
        }
        #endregion
    }
}
