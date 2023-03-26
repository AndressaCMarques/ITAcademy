using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace itacademy
{
    public class ExcelHandler
    {

        public double RetornaDistanciaCidades(string cidadeA, string cidadeB)
        {

            string fileName = "Distancias.xlsx";
            string pathExcelCidades = Path.Combine(Environment.CurrentDirectory, fileName);

            FileInfo excelCidades = new FileInfo(pathExcelCidades);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(excelCidades))
            {
                var worksheet = package.Workbook.Worksheets[0];

                int linhaPos = 0;
                int colunaPos = 0;

                for (int linhaAtual = 2; linhaAtual <= worksheet.Dimension.End.Row; linhaAtual++)
                {
                    var cidadeLinha = worksheet.Cells[linhaAtual, 1].Value;
                    if (cidadeLinha != null)
                    {
                        if (cidadeLinha.ToString() == cidadeA.ToUpper())//metodo do string para maiusculo que nem esta no excel
                        {
                            linhaPos = linhaAtual;
                            break;
                        }
                    }
                }

                for (int colunaAtual = 2; colunaAtual <= worksheet.Dimension.End.Column; colunaAtual++)
                {
                    var cidadeCol = worksheet.Cells[1, colunaAtual].Value;
                    if (cidadeCol != null)
                    {
                        if (cidadeCol.ToString() == cidadeB.ToUpper())
                        {
                            colunaPos = colunaAtual;
                            break;
                        }
                    }
                }

                double distanciaCidades;

                if (linhaPos != 0 && colunaPos != 0)
                {
                    var validacao = worksheet.Cells[linhaPos, colunaPos].Value;
                    if (validacao!= null)
                    {
                        distanciaCidades = (double)worksheet.Cells[linhaPos, colunaPos].Value;
                        return distanciaCidades;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }

            }


        }
    }
}
