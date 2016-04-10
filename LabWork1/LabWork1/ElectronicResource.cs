using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// класс Электронный ресурс
    /// </summary>
    public class ElectronicResource : ICatalogue
    {
        public string Name
        {
            get
            {
                return "Электронный ресурс";
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
        /// Заглавие [Электронный ресурс]
        /// </summary>
        private string _titleElectronicResource;

        public string TitleElectronicResource
        {
            get
            { return _titleElectronicResource; }
            set
            {
                _titleElectronicResource = value;
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
        ///  сведения об отвественности (авторы)
        /// </summary>
        private string _informationToResponsibility;
        public string InformationToResponsibility
        {
            get
            { return _informationToResponsibility; }
            set
            {
                _informationToResponsibility = value;
            }
        }

        /// <summary>
        ///  Обозначение вида ресурса («электрон. дан.» и/или «электрон. прогр.»)
        /// </summary>
        private string _viewResource;
        public string ViewResource
        {
            get
            { return _viewResource; }
            set
            {
                _viewResource = value;
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
        /// Обозначение материала и количество физических единиц
        /// </summary>
        private string _materialDesignation;
        public string MaterialDesignation
        {
            get
            { return _materialDesignation; }
            set
            {
                _materialDesignation = value;
            }
        }

        /// <summary>
        /// Метод, позволяющий получить описание электронного ресурса
        /// </summary>
        /// <returns></returns>
        public string GetDescription()
        {
            return string.Format("{0}. {1}: {2}. - / {3}. - {4}. - {5}, {6}. - {7}.", _author, _titleElectronicResource, _informationToTitle, _informationToResponsibility, _viewResource, _publishing, _yearPublishing, _materialDesignation);
        }

        public ElectronicResource(string author, string titleElectronicResource, string informationToTitle, string informationToResponsibility, string viewResource, string publishing, int yearPublishing, string materialDesignation)
        {
            _author = author;
            _titleElectronicResource = titleElectronicResource;
            _informationToTitle = InformationToTitle;
            _informationToResponsibility = informationToResponsibility;
            _viewResource = viewResource;
            _publishing = publishing;
            _yearPublishing = yearPublishing;
            _materialDesignation = materialDesignation;
         }
    }
}
