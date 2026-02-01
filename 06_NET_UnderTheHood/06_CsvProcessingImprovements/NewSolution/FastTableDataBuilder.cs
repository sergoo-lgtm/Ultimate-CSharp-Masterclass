using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;

namespace CsvDataAccess.NewSolution;

public class FastTableDataBuilder : ITableDataBuilder
{
    public ITableData Build(CsvData csvData)
    {
        int rowCount = csvData.Rows.Count();
        int columnCount = csvData.Columns.Length;

        var data = new object[rowCount, columnCount];

        int rowIndex = 0;
        foreach (var row in csvData.Rows)
        {
            for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
            {
                data[rowIndex, columnIndex] =
                    ConvertValueToTargetType(row[columnIndex]);
            }
            rowIndex++;
        }

        return new FastTableData(csvData.Columns, data);
    }

    private object ConvertValueToTargetType(string value)
    {
        if (string.IsNullOrEmpty(value))
            return null;

        if (value == "TRUE")
            return true;

        if (value == "FALSE")
            return false;

        if (value.Contains('.') &&
            decimal.TryParse(value, out var d))
            return d;

        if (int.TryParse(value, out var i))
            return i;

        return value;
    }
}
