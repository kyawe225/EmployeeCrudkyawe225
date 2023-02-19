using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Employee.DBA;
using X15 = DocumentFormat.OpenXml.Office2010.Excel;
namespace Employee.Api.Services
{
    public class GenerateExcel
    {
        public byte[] Generate(IList<EmployeeDto> data)
        {
            MemoryStream memory = new MemoryStream();
            SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(
                memory,
                SpreadsheetDocumentType.Workbook
            );
            // Add a WorkbookPart to the document.
            WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
            workbookpart.Workbook = new Workbook();
            // Add a WorksheetPart to the WorkbookPart.
            WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            SheetData sheetData = new SheetData();
            Row headerRow = new Row()
            {
                RowIndex = (uint)1
            };
            Cell cell1h = new Cell()
            {
                CellValue = new CellValue("Id"),
                CellReference = "A" + 1,
                DataType = new EnumValue<CellValues>(CellValues.String)
            };
            headerRow.Append(cell1h);
            Cell cell2h = new Cell()
            {
                CellValue = new CellValue("Name"),
                CellReference = "B" + ( 1),
                DataType = new EnumValue<CellValues>(CellValues.String)
            };

            headerRow.Append(cell2h);
            Cell cellFathernameh = new Cell()
            {
                CellValue = new CellValue("FatherName"),
                CellReference = "C" + ( 1),
                DataType = new EnumValue<CellValues>(CellValues.String)
            };

            headerRow.Append(cellFathernameh);
            Cell cellDateofBirthh = new Cell()
            {
                CellValue = new CellValue("Date Of Birth"),
                CellReference = "E" + ( 1),
                DataType = new EnumValue<CellValues>(CellValues.String)
            };

            headerRow.Append(cellDateofBirthh);
            Cell cellEmailh = new Cell()
            {
                CellValue = new CellValue("Email"),
                CellReference = "D" + ( 1),
                DataType = new EnumValue<CellValues>(CellValues.String),
            };
            headerRow.Append(cellEmailh);
            Cell cellPositionh = new Cell()
            {
                CellValue = new CellValue("PositionNames"),
                CellReference = "G" + ( 1),
                DataType = new EnumValue<CellValues>(CellValues.String),
            };
            headerRow.Append(cellPositionh);
            Cell cellDepartmentNameh = new Cell()
            {
                CellValue = new CellValue("DepartmentNames"),
                CellReference = "F" + ( 1),
                DataType = new EnumValue<CellValues>(CellValues.String),
            };
            headerRow.Append(cellDepartmentNameh);
            sheetData.Append(headerRow);

            if (data.Count() > 0)
            {
                for (int i= 0; i < data.Count(); i++)
                {
                    Row row = new Row()
                    {
                        RowIndex = (uint)i+2
                    };
                    Cell cell1 = new Cell()
                    {
                        CellValue = new CellValue(data[i].Id.ToString()),
                        CellReference = "A"+(i+2),
                        DataType = new EnumValue<CellValues>(CellValues.String)
                    };
                    row.Append(cell1);
                    Cell cell2 = new Cell()
                    {
                        CellValue = new CellValue(data[i].FirstName + data[i].LastName),
                        CellReference = "B"+ (i+2),
                        DataType = new EnumValue<CellValues>(CellValues.String)
                    };

                    row.Append(cell2);
                    Cell cellFathername = new Cell()
                    {
                        CellValue = new CellValue(data[i].FatherName),
                        CellReference = "C" + (i+2),
                        DataType = new EnumValue<CellValues>(CellValues.String)
                    };

                    row.Append(cellFathername);
                    Cell cellDateofBirth = new Cell()
                    {
                        CellValue = new CellValue(data[i].DOB.ToShortDateString()),
                        CellReference = "E" + (i+2),
                        DataType = new EnumValue<CellValues>(CellValues.String)
                    };

                    row.Append(cellDateofBirth);
                    Cell cellEmail = new Cell()
                    {
                        CellValue = new CellValue(data[i].Email),
                        CellReference = "D"+(i+2),
                        DataType = new EnumValue<CellValues>(CellValues.String),
                    };
                    row.Append(cellEmail);
                    Cell cellPosition = new Cell()
                    {
                        CellValue = new CellValue(data[i].PositionNames),
                        CellReference = "G"+(i+2),
                        DataType = new EnumValue<CellValues>(CellValues.String),
                    };
                    row.Append(cellPosition);
                    Cell cellDepartmentName = new Cell()
                    {
                        CellValue = new CellValue(data[i].DepartmentNames),
                        CellReference = "F"+(i+2),
                        DataType = new EnumValue<CellValues>(CellValues.String),
                    };
                    row.Append(cellDepartmentName);
                    sheetData.Append(row);  
                }
            }
            worksheetPart.Worksheet = new Worksheet(sheetData);
            // Add Sheets to the Workbook.
            Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.
            AppendChild<Sheets>(new Sheets());
            // Append a new worksheet and associate it with the workbook.
            Sheet sheet = new Sheet()
            {
                Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                SheetId = 1,
                Name = "sheet1"
            };
            sheets.Append(sheet);
            //Save & close
            workbookpart.Workbook.Save();
            spreadsheetDocument.Close();
            return memory.ToArray();
        }
    }
}

