using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using UnityEditor;
using UnityEngine;

public class SaveXlsx : EditorWindow
{
    static readonly string headerPath = "Assets/MapTableHeader.xlsx";
    static readonly string excelPath  = "Assets/OutputTable.xlsx";

    [MenuItem ("Tools/SaveXLS")]
    public static void Exec()
    {
        IWorkbook book;

        using (FileStream stream = new FileStream(headerPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            book = new XSSFWorkbook(stream);
            stream.Close();
        }

        var data = MapTable.Rows;

        var sheet = book.GetSheet("MapTable");

        int lastrow  = sheet.LastRowNum+1;
        int rowIndex = lastrow;

        for (int i = 0; i < data.Count; i++)
        {
            var erow    = new ExcelRow(sheet, rowIndex);
            var dataRow = data[i];
            // —ñA ‚É ID
            erow.CellValue(0, dataRow.ID);
            // —ñB ‚É Type
            erow.CellValue(1, dataRow.Type.ToString());
            // —ñC ‚É StageNo
            erow.CellValue(2, dataRow.StageNo);

            rowIndex++;
        }

        File.Delete(excelPath);

        using (FileStream stream = new FileStream(excelPath, FileMode.OpenOrCreate, FileAccess.Write))
        {
            book.Write(stream);
            stream.Close();
        }
        AssetDatabase.ImportAsset(excelPath);

        EditorUtility.DisplayDialog($"SAVE DATA", $"path: {excelPath}", "ok");
    }
}

public class ExcelRow
{
    IRow row;

    public ExcelRow(ISheet sheet, int rowIndex)
    {
        row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
    }

    public void CellValue(int columnIndex, bool value)
    {
        getCell(columnIndex).SetCellValue(value);
    }

    public void CellValue(int columnIndex, System.DateTime value)
    {
        getCell(columnIndex).SetCellValue(value);
    }

    public void CellValue(int columnIndex, int value)
    {
        getCell(columnIndex).SetCellValue(value);
    }

    public void CellValue(int columnIndex, float value)
    {
        getCell(columnIndex).SetCellValue(value);
    }

    public void CellValue(int columnIndex, string value)
    {
        getCell(columnIndex).SetCellValue(value);
    }

    ICell getCell(int columnIndex)
    {
        return row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);
    }
}
