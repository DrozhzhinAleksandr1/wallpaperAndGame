using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallpaper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ширину обоев");
            //Double.TryParse
            double wallpaperWidth = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите высоту обоев");
            double wallpaperHeight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите шаг обоев");
            double wallpaperStep = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите высоту комнаты");
            double roomHeight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите периметр комнаты");
            double roomPerimeter = Convert.ToDouble(Console.ReadLine());

            double numberFullPartWallpaper; // число полных кусков обоев с одного рулона
            double percentRoll; // процент порезаных рулонов
            double remnantFromOneRoll; // остаток обрезков с одного рулона
            double heightFullPartWallpaper;  // высота полного куска обоев (с обрезком или без)

            if(roomHeight % wallpaperStep == 0)
            {
                heightFullPartWallpaper = roomHeight;
                if (wallpaperHeight % heightFullPartWallpaper == 0)
                {
                    numberFullPartWallpaper = wallpaperHeight / heightFullPartWallpaper;
                    remnantFromOneRoll = 0;
                    percentRoll = 0;
                }
                else
                {
                    numberFullPartWallpaper = Math.Floor(wallpaperHeight / heightFullPartWallpaper);
                    remnantFromOneRoll = wallpaperHeight - numberFullPartWallpaper * roomHeight;
                    percentRoll = 100;
                }
            }
            else
            {
                heightFullPartWallpaper = Math.Ceiling(roomHeight / wallpaperStep) * wallpaperStep;
                numberFullPartWallpaper = Math.Floor(wallpaperHeight / heightFullPartWallpaper);
                if(wallpaperHeight > numberFullPartWallpaper * heightFullPartWallpaper + roomHeight)
                {
                    numberFullPartWallpaper += 1;
                }
                remnantFromOneRoll = wallpaperHeight - numberFullPartWallpaper * roomHeight;   
                percentRoll = 100;
            }
            
            // ширина всех полных частей с одного рулона
            double widthUsedRollPart = numberFullPartWallpaper * wallpaperWidth;
            // количество рулонов обоев
            double numberRollWalpaper;
            // остаток со всех рулонов
            double remantFrommAllRolls;
            // ширина последнего использованого полного куска обоев
            double widthLastPartLastRoll = wallpaperWidth;
            if (roomPerimeter % widthUsedRollPart == 0)
            {
                numberRollWalpaper = roomPerimeter / widthUsedRollPart;
                remantFrommAllRolls = remnantFromOneRoll * numberRollWalpaper;
            }
            else
            {
                numberRollWalpaper = Math.Floor(roomPerimeter / widthUsedRollPart);
                // остаток ширины которую не залепили обоями
                double remnantPerimeter = roomPerimeter - numberRollWalpaper * widthUsedRollPart;
                // количество использованых полных частей с поледнего рулона - 1
                double numberNotAllUsedPartFromLastRoll = Math.Floor(remnantPerimeter / wallpaperWidth);
                // ширина последнего использованого полного куска обоев
                widthLastPartLastRoll = remnantPerimeter - numberNotAllUsedPartFromLastRoll * wallpaperWidth;
                // количество неиспользованых полных частей с поледнего рулона 
                double numberRemnantFullPartWallpaper = numberFullPartWallpaper - (numberNotAllUsedPartFromLastRoll + 1);
                numberRollWalpaper += 1;
                remantFrommAllRolls = remnantFromOneRoll * numberRollWalpaper + numberRemnantFullPartWallpaper * roomHeight;
            }
            double remantFrommAllRollsM2 = remantFrommAllRolls * wallpaperWidth;
            double allRemantM2 = (wallpaperWidth - widthLastPartLastRoll) * roomHeight + remantFrommAllRollsM2;
            double percentRemantFrommAllRolls = allRemantM2 / (numberRollWalpaper * wallpaperHeight * wallpaperWidth / 100);
            if (widthLastPartLastRoll != wallpaperWidth && percentRoll == 0)
            {
                percentRoll =  1.0 / (numberRollWalpaper * 0.01);
            }
            Console.WriteLine($"Количество нужных рулонов: {numberRollWalpaper}");
            Console.WriteLine($"Процент обрезаных рулонов: {percentRoll}%");
            Console.WriteLine($"Процент потерь обоев: {percentRemantFrommAllRolls}%");
            
            Console.ReadLine();
        }
    }
}
