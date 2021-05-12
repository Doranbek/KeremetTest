using KeremetTest.Data;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;
using System;
using System.IO;


namespace KeremetTest.Helper
{    
    public class ExcelHelper: IExcelHelper
    {
        private IHostingEnvironment _environment;

        public ExcelHelper(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public void Export(Client client)
        {
            var templateFile = new FileInfo( Path.Combine(_environment.WebRootPath, "Template/example.xlsx"));

            var resultPath = Path.Combine(_environment.WebRootPath, $"Result/{client.SocialNumber}.xlsx");
            var resultFile = new FileInfo(resultPath);


            using (ExcelPackage templatePackage = new ExcelPackage(templateFile))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelWorksheet worksheetTemplate = templatePackage.Workbook.Worksheets[0];

                worksheetTemplate.Cells["B1"].Value = DateTime.Today;
                worksheetTemplate.Cells["B1"].Style.Numberformat.Format = "dd.MM.yyyy";

                for (int i = 3; i <= 8; i++)
                {
                    string alpha = "BDEFGHI";
                    for (int j = 0; j < alpha.Length; j++)
                    {
                        var cell = worksheetTemplate.Cells[$"{alpha[j]}{i}"].Value?.ToString().Trim();

                        switch (cell)
                        {
                            case "[ID]":
                                worksheetTemplate.Cells[$"{alpha[j]}{i}"].Value = client.Id;
                                break;
                            case "[Name]":
                                worksheetTemplate.Cells[$"{alpha[j]}{i}"].Value = client.Name;
                                break;
                            case "[BirthDate]":
                                worksheetTemplate.Cells[$"{alpha[j]}{i}"].Value = client.BirthDate;
                                worksheetTemplate.Cells[$"{alpha[j]}{i}"].Style.Numberformat.Format = "dd.MM.yyyy";
                                break;
                            case "[PhoneNumber]":
                                worksheetTemplate.Cells[$"{alpha[j]}{i}"].Value = client.PhoneNumber;
                                break;
                            case "[Address]":
                                worksheetTemplate.Cells[$"{alpha[j]}{i}"].Value = client.Address;
                                break;
                            case "[SocialNumber]":
                                worksheetTemplate.Cells[$"{alpha[j]}{i}"].Value = client.SocialNumber;
                                break;
                        }

                    }

                }


                if (File.Exists(resultPath))
                {
                    resultFile.Delete();
                }


                using (var resultPackage = new ExcelPackage())
                {
                    var resultWorkSheet = resultPackage.Workbook.Worksheets.Add("Лист1", worksheetTemplate);

                    byte[] bin = resultPackage.GetAsByteArray();

                    File.WriteAllBytes(resultPath, bin);
                }


            }
        }
    }
}
