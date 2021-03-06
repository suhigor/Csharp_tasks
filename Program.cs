using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace searchColumnInsideFile
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string searchableFolder = @"C:\Users\suhigor\Downloads\дичь\txt";
                string columnsToBeSearched = @"C:\Users\suhigor\Downloads\дичь\columnsToBeSearched.txt";
                            
                string[] columns = File.ReadAllLines(columnsToBeSearched);
                
                foreach (string f in Directory.EnumerateFiles(searchableFolder, "*.txt", SearchOption.AllDirectories))
                {
                    string filename = Path.GetFileName(f);
                    var unusedColumns = new List<string>();
                    var usedColumns = new List<string>();
                    int counterUsed = 0;
                    int counterUnused = 0;

                    foreach (string searchedColumn in columns)
                    {
                        string textdata = File.ReadAllText(f);

                        if (textdata.Contains(searchedColumn))
                        {
                            Console.WriteLine("В файле " + filename + " найден столбец: " + searchedColumn);
                            usedColumns.Add(searchedColumn);
                            ++counterUsed;
                        }
                        else
                        {
                            Console.WriteLine("В файле " + filename + " не найден столбец: " + searchedColumn);
                            unusedColumns.Add(searchedColumn);
                            ++counterUnused;
                           
                        }
                    }
                    Console.WriteLine("                                                                     ");
                    Console.WriteLine("Найдено " + counterUsed + " столбцов из процедуры в файле " + filename);
                    foreach (string value in usedColumns)
                    {
                        Console.WriteLine(value);
                    }
                    Console.WriteLine("                                                                     ");
                    Console.WriteLine("Не найдено " + counterUnused + " столбцов из процедуры в файле " + filename);
                    foreach (string value in unusedColumns)
                    {
                        Console.WriteLine(value);
                    }
                    Console.WriteLine("---------------------------------------------------------------------");
                    Console.WriteLine("---------------------------------------------------------------------");
                }
                    Console.ReadKey();
            }
            catch (UnauthorizedAccessException uAEx)
            {
              Console.WriteLine(uAEx.Message);
            }
            catch (PathTooLongException pathEx)
            {
              Console.WriteLine(pathEx.Message);
            }
        }
    }
}
