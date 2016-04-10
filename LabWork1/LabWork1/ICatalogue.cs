using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface ICatalogue
    {
        string Name { get; }

        /// <summary>
        /// Год издания
        /// </summary>
        int YearPublishing { get; set; }

        /// <summary>
        /// Получить описание издания
        /// </summary>
        /// <returns></returns>
        string GetDescription();
    }
}
