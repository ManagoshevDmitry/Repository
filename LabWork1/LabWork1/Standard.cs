using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Standard : ICatalogue
    {
        public string Name
        {
            get
            {
                return "ГОСТ";
            }
        }

        #region - Fields -

        /// <summary>
        /// Заглавие нормативно-технического документа
        /// </summary>
        private string _title;
        public string Title
        {
            get
            { return _title; }
            set
            {
                _title = value;
            }
        }

        /// <summary>
        /// сведения, относящиеся к заглавию
        /// </summary>
        private string _informationTitle;
        public string InformationTitle
        {
            get
            { return _informationTitle; }
            set
            {
                _informationTitle = value;
            }
        }

        #endregion

        //**********************************************************************************

        /// <summary>
        /// обозначения ранее действующего документа
        /// </summary>
        private string _referDocument;
        public string ReferDocument
        {
            get
            { return _referDocument; }
            set
            {
                _referDocument = value;
            }
        }

        /// <summary>
        /// дата введения
        /// </summary>
        private string _introductionDate;
        public string IntroductionDate
        {
            get
            { return _introductionDate; }
            set
            {
                _introductionDate = value;
            }
        }

        /// <summary>
        /// Место издание: издательство
        /// </summary>
        private string _publishing;
        public string Publishing
        {
            get
            { return _publishing; }
            set
            {
                _publishing = value;
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
        /// Метод, позволяющий получить описание стандарта
        /// </summary>
        /// <returns></returns>
        public String GetDescription()
        {
            return string.Format("{0}. {1}. - {2}; {3}. - {4}, {5}. - {6} c.", _title, _informationTitle, _referDocument, _introductionDate, _publishing, _yearPublishing, _volume);
        }

        public Standard(string title, string informationTitle, string referDocument, string introductionDate, string publishing, int yearPublishing, int volume)
        {
            _title = title;
            _informationTitle = informationTitle;
            _referDocument = referDocument;
            _introductionDate = introductionDate;
            _publishing = publishing;
            _yearPublishing = yearPublishing;
            _volume = volume;
        }
    }
}
