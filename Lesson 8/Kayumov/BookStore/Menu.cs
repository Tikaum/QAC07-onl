using BookStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class Menu : IMenu
    {
        public void ShowMenu()
        {
            Console.WriteLine("Добро пожаловать в наш книжный магазин!,\n" +
                    "\n"+
                   "Выберите пункт меню и нажмите его номер:\n" +
                   "1. Просмотреть список всех доступных книг\n" +
                   "2. Просмотреть список книг по жанру\n" +
                   "3. Искать книгу по названию\n" +
                   "4. Показать книгу по ID\n" +
                   "5. Просмотреть содержимое корзины\n" +
                   "6. Купить книги добавленные в корзину\n" +
                   "7. Очистить содержимое корзины\n" +
                   "8. Завершить покупки");
        }

        public void ShowGenre()
        {
            Console.WriteLine(
                   "1. Фэнтези\n" +
                   "2. Фантастика\n" +
                   "3. Нон-фикшен\n" +
                   "4. Мемуары\n" +
                   "5. Детектив\n");
        }
    }
}
