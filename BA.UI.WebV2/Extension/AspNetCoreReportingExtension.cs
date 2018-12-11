using AspNetCore.Reporting;
using System;
using System.Collections.Generic;
using System.IO;

namespace BA.UI.WebV2.Extension
{
    public static class AspNetCoreReportingExtension
    {

        public static MemoryStream ExecuteToMemoryStreamResult(this LocalReport localreport, RenderType rendertype) {

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            var res = localreport.Execute(rendertype);

            return new MemoryStream(res.MainStream);

        }


        public static MemoryStream ExecuteToMemoryStreamResult(this LocalReport localreport, RenderType rendertype, int index =1, Dictionary<string , string> parameters = null, string searchString ="")
        {

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            var res = localreport.Execute(rendertype, index, parameters, searchString);

            return new MemoryStream(res.MainStream);

        }
    }
}
