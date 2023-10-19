using OfficeOpenXml;

namespace InvoiceProcess.Infrasctructure.Core.Services.FileHandler
{
    public class ExcelHandler
    {

        public List<T> GetListFromExcelFile<T>(string fileRoute, string workSheetName)
        {
            var list = new List<T>();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(new FileInfo(fileRoute)))
            {                
                var sheet = package.Workbook.Worksheets[workSheetName];
                list = GetList<T>(sheet);
            }

            return list;
        }

        private static List<T> GetList<T>(ExcelWorksheet sheet)
        {
            List<T> list = new();
            //first row is for knowing the properties of object
            var columnInfo = Enumerable.Range(1, sheet.Dimension.Columns).ToList().Select(n =>

                new { Index = n, ColumnName = sheet.Cells[1, n].Value.ToString() }
            );

            for (int row = 2; row < sheet.Dimension.Rows; row++)
            {
                T obj = (T)Activator.CreateInstance(typeof(T));//generic object
                foreach (var prop in typeof(T).GetProperties())
                {
                    int col = columnInfo.SingleOrDefault(c => c.ColumnName == prop.Name).Index;
                    var val = sheet.Cells[row, col].Value;
                    var propType = prop.PropertyType;
                    prop.SetValue(obj, Convert.ChangeType(val ?? val , propType));
                }
                list.Add(obj);
            }

            return list;
        }
    }
}
