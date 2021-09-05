using System;
using System.Collections.Generic;
using System.Text;
using DocOperator.Common;
using Serilog;

namespace DocOperator.OfficeOper
{
    class WordConverter
    {
        static public bool ToPDF(string sourcePath, string targetPath)
        {
            bool result = false;
            Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document document = null;

            try
            {
                application.Visible = false;
                document = application.Documents.Open(sourcePath);
                document.ExportAsFixedFormat(targetPath, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
                result = true;
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
            }
            finally
            {
                document.Close();
            }
            return result;
        }
    }

}
