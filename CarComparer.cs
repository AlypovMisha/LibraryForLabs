using LibraryForLabs;
using System;
using System.Collections;

public class CarComparer : IComparer
{
    private string sortBy;

    public CarComparer(string sortBy)
    {
        this.sortBy = sortBy;
    }

    public int Compare(object x, object y)
    {
        Cars carX = x as Cars;
        Cars carY = y as Cars;

        if (carX != null && carY != null)
        {
            if (sortBy == "Год")
            {
                // Сортировка по году выпуска
                return carX.ReleaseYear.CompareTo(carY.ReleaseYear);
            }
            else if (sortBy == "Цена")
            {
                // Сортировка по цене
                return carX.Cost.CompareTo(carY.Cost);
            }
            else
            {
                throw new ArgumentException("Недопустимый параметр сортировки");
            }
        }
        else
        {
            throw new ArgumentException("Объекты не относятся к типу Car");
        }
    }
}
