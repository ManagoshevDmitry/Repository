using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Dissertation: ICatalogue
    {
        public string Name
        {
            get
            {
                return "Диссертация";
            }
        }

        private string _author;
        public string Author
        {
            get
            { return _author; }
            set
            {
                _author = value;
            }
        }

        /// <summary>
        /// Заглавие
        /// </summary>
        private string _titleDissertation;
        public string TitleDissertation
        {
            get
            { return _titleDissertation; }
            set
            {
                _titleDissertation = value;
            }
        }

        /// <summary>
        ///  сведения, относящиеся к заглавию
        /// </summary>
        private string _informationToTitle;
        public string InformationToTitle
        {
            get
            { return _informationToTitle; }
            set
            {
                _informationToTitle = value;
            }
        }

        /// <summary>
        /// шифр номенклатуры специальностей научных работников
        /// </summary>
        private string _nomenclatureСipher;
        public string NomenclatureСipher
        {
            get
            { return _nomenclatureСipher; }
            set
            {
                _nomenclatureСipher = value;
            }
        }

        /// <summary>
        /// сведения об ответственности (коллектив)
        /// </summary>
        private string _collective;
        public string Collective
        {
            get
            { return _collective; }
            set
            {
                _collective = value;
            }
        }

        /// <summary>
        /// Место написания
        /// </summary>
        private string _writingSpace;
        public string WritingSpace
        {
            get
            { return _writingSpace; }
            set
            {
                _writingSpace = value;
            }
        }

        /// <summary>
        /// Год издания
        /// </summary>
        private int _yearPublishing;
        public int YearPublishing
        {
            get
            { return _yearPublishing; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Введите положительное число");
                }
                _yearPublishing = value;
            }
        }

        /// <summary>
        /// Объем
        /// </summary>
        private int _volume;

        public int Volume
        {
            get
            { return _volume; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Введите положительное число");
                }
                _volume = value;
            }
        }

        /// <summary>
        /// Метод, позволяющий получить описание диссертации
        /// </summary>
        /// <returns></returns>
        public string GetDescription()
        {
            return string.Format("{0}. {1} : {2} : {3} / {4}. - {5}, {6}. - {7} c.", _author, _titleDissertation, _informationToTitle, _nomenclatureСipher, _collective, _writingSpace, _yearPublishing, _volume);
        }

        public Dissertation(string author, string titleDissertation, string informationToTitle, string nomenclatureCipher, string collective, string writingSpace, int yearPublishing, int volume)
        {
            _author = author;
            _titleDissertation = titleDissertation;
            _informationToTitle = informationToTitle;
            _nomenclatureСipher = nomenclatureCipher;
            _collective = collective;
            _writingSpace = writingSpace;
            _yearPublishing = yearPublishing;
            _volume = volume;
        }

    }
}
