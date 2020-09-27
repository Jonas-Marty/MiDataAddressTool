using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace MiDataAddressTool
{
	public class ExcelDocument : IDisposable
	{
		private static ExcelPackage _excel;
		private readonly MemoryStream _memoryStream;

		//http://epplus.codeplex.com/wikipage?title=WebapplicationExample
		protected ExcelDocument()
		{
			_memoryStream = new MemoryStream();
		}

		public static ExcelDocument CreateWithSimpleHeader<T>(IEnumerable<T> itemsToPrint, bool printHeaders, string sheetname)
		{
			var document = new ExcelDocument();
			_excel = new ExcelPackage();
			ExcelWorksheet worksheet = _excel.Workbook.Worksheets.Add(sheetname);
			worksheet.Cells[1, 1].LoadFromCollection(itemsToPrint, printHeaders, TableStyles.Light8);

			Type typeOfT = typeof(T);

			var members = typeOfT.GetMembers().Where(member => member is FieldInfo || member is PropertyInfo).ToArray();

			for (int i = 0; i < members.Length; i++)
			{
				var member = members[i];
				Type memberType = null;
				if (member is FieldInfo)
				{
					var fieldInfo = member as FieldInfo;
					memberType = fieldInfo.FieldType;
				}
				else if (member is PropertyInfo)
				{
					var propertyInfo = member as PropertyInfo;
					memberType = propertyInfo.PropertyType;
				}

				if (memberType != null)
				{
					if (memberType == typeof(DateTime?) || memberType == typeof(DateTime))
					{
						worksheet.Column(i + 1).Style.Numberformat.Format = Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern;
					}
				}
			}

			worksheet.Cells.AutoFitColumns();

			return document;
		}

		public void CloseDocumentAndSaveToFile(FileInfo file)
		{
			_excel.SaveAs(file);
		}

		public virtual void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				_memoryStream.Dispose();
				_excel.Dispose();
			}
		}

		~ExcelDocument()
		{
			Dispose(false);
		}
	}
}