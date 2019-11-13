using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing;

namespace EMFPrintTest
{
    /// <summary>
    /// 참고 사이트: https://social.msdn.microsoft.com/Forums/sqlserver/en-US/cd00ce1f-b391-4435-bb35-51d160f3da66/printing-rdlc-report-directly-to-a-specific-printer-c?forum=csharpgeneral
    /// </summary>
    public class EMFPrinter
    {
        public static string printerName = "Microsoft Print to PDF";
        public static string fileName="기본트레이.emf";

        private static void PrintPage2(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = null;
            try
            {
                pageImage = new Metafile(fileName);
            }
            catch
            {
                throw new Exception($"파일 {fileName}을 찾지 못했습니다.");
            }

            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            ev.Graphics.DrawImage(pageImage, adjustedRect);

        }
        public static void Run(string _printerName, string _fileName)
        {
            printerName = _printerName;
            fileName = _fileName;
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception($"Error: cannot find the printer {printerName}.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage2);
                printDoc.Print();
            }
        }
    }
}
