using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.NetworkInformation;

namespace ArhivSizeInfoLib
{
    public class ArhivSizeInfoMethod  
    {

        private struct SizeInfo
        {
            public int OutInfo;
            public int InInfo;

            public SizeInfo(int a1, int a2)
            {
                OutInfo = a1;
                InInfo = a2;
            }

        }

        private static string RoundThs(int number)
        {
            int rezult = (int)Math.Round((double)number / 1000, MidpointRounding.ToEven) * 1000;
            return (rezult / 1000).ToString();

        }

        private static SizeInfo GetSizeInfoFromFile(string filename)
        {
            string line;

            const string outLabel = "--Out";
            const string inLabel = "--In";

            var outInfo = 0;
            var inInfo = 0;

            var file = new StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {

                var outSizeInd = line.IndexOf(outLabel, StringComparison.Ordinal);
                var inSizeInd = line.IndexOf(inLabel, StringComparison.Ordinal);

                try
                {
                    if (outSizeInd > 0)
                    {
                        outInfo += int.Parse(line.Substring(outSizeInd + 5, line.Length - outSizeInd - 5).Trim());
                    }

                    if (inSizeInd > 0)
                    {
                        inInfo += int.Parse(line.Substring(inSizeInd + 4, line.Length - inSizeInd - 4).Trim());
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("{0} {1} {2}", exception.Message, line, Environment.NewLine);
                }
            }

            file.Close();

            return new SizeInfo(outInfo, inInfo);
        }

        public static string GetInfoFromFolder(string monthFolder)
        {
            var directorySizeInfo = new Dictionary<string, SizeInfo>();
            var dayInMonth = 0;
            var indt = DateTime.Now;

            //вычисляем год
            var yearFolder = indt.Year.ToString().Substring(2, 2);
            

            // если папка архива не задана то ставим по умолчанию 
            var arhivFolder = ConfigurationManager.AppSettings["arhivFolder"] ?? "C:\\ARXIV";

            // строим путь к папке с месяцами
            string arhivMonthPath = arhivFolder + "\\" + yearFolder + "\\" + monthFolder;


            if (!Directory.Exists(arhivMonthPath))
            {
                return "Нет данных за текущий месяц(нет папки с номером текущего месяца)" +
                     Environment.NewLine + "Папка с архивом " + arhivMonthPath;
            }

            // сканируем папку с месяцами
            foreach (var dayPath in Directory.GetDirectories(arhivMonthPath))
            {
                int day;

                //выдергиваем из маршрута номер дня
                string parseDayPath = dayPath.Substring(dayPath.LastIndexOf("\\", StringComparison.Ordinal) + 1);


                var parseResult = int.TryParse(parseDayPath, out day);

                if (!parseResult)
                {
                    //не прошел парсинг ;
                    continue;
                }
                else
                {
                    if (day > 31)
                    {
                        //не подошел день;
                        continue;
                    }
                }

                // считаем дни в текущем месяце
                dayInMonth++;

                //ищем в каждой папке месяца файлы 
                foreach (var fullFileName in Directory.GetFiles(dayPath, "*.gnl"))
                {
                    var fileNameKey = Path.GetFileName(fullFileName);

                    var sizeInfoFromFile = GetSizeInfoFromFile(fullFileName);

                    if (directorySizeInfo.ContainsKey(fileNameKey))
                    {
                        var existingSizeInfo = directorySizeInfo[fileNameKey];

                        existingSizeInfo.OutInfo = existingSizeInfo.OutInfo + sizeInfoFromFile.OutInfo;
                        existingSizeInfo.InInfo = existingSizeInfo.InInfo + sizeInfoFromFile.InInfo;

                        directorySizeInfo[fileNameKey] = existingSizeInfo;
                    }
                    else
                    {
                        directorySizeInfo.Add(fileNameKey, sizeInfoFromFile);
                    }

                }
            }

            int monthOutInfo = 0, monthIninfo = 0;

            foreach (var daySizeInfo in directorySizeInfo)
            {
                monthOutInfo += daySizeInfo.Value.OutInfo;
                monthIninfo += daySizeInfo.Value.InInfo;
            }

            directorySizeInfo.Clear();


            return string.Format(
            @"Данные за {0} месяц {1} года. Посчитанных дней= {2}  
            Итого: Входные данные {3} тыс. зн.  Среднее за сутки {4} тыс. зн.
            Выходные данные {5} тыс. зн.  Среднее за сутки {6}  тыс. зн.",
                    monthFolder, yearFolder, dayInMonth,
                    RoundThs(monthIninfo), RoundThs(monthIninfo / dayInMonth),
                    RoundThs(monthOutInfo), RoundThs(monthOutInfo / dayInMonth));
        

        }

        public static string GetInfoForMohtn(int month)
        {
            var monthFolder = month.ToString().Length == 1
                ? ("0" + month)
                : (month.ToString());

            return GetInfoFromFolder(monthFolder);
        }

        public static string GetInfoThisMohtn()
        {
            var indt = DateTime.Now;

            //вычисляем месяц
            var monthFolder = indt.Month.ToString().Length == 1
                ? ("0" + indt.Month)
                : (indt.Month.ToString());

            return GetInfoFromFolder(monthFolder);

        }

    }
}
