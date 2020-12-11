using iTextSharp.text.pdf;
using SpaceX.Models;
using System.Collections.Generic;

namespace SpaceX.Services.Contracts
{
    public interface ICreatePdfFileService
    {
        byte[] Report(List<LaunchPlan> launchPlans);

        void ReportHeader();

        PdfPTable SetPageTitle();

        void EmptyRow(int nCount);

        void ReportBody();
    }
}
