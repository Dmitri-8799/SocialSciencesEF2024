using System;
using System.ComponentModel;

namespace SocialSciencesEF2024.Models
{
	public class TableRb3Model:INotifyPropertyChanged
	{
        //я перенес все свойства с таблицы сюда, реализовал INotifyPropertyChanged, но у меня вопрос - нам надо в модели создавать поля для получения value у кадждого определенного в модели свойства ?

        public int Id { get; set; }

       

        public string? Option1
        {
            get { return Option1; }
            set
            {
                _ = value;
                OnPropertyChanged("Option1");
            }
        }

        public string Option2
        {
            get { return Option2; }
            set
            {

                _ = value;
                OnPropertyChanged("Option2");
            }

        }
        public string Option3
        {
            get { return Option3; }
            set
            {

                _ = value;
                OnPropertyChanged("Option3");
            }
        }

        public int AnswerNr
        {
            get { return AnswerNr; }
            set
            {

                _ = value;
                OnPropertyChanged("AnswerNr");
            }
        }

        public string IfRight
        {
            get { return IfRight; }
            set
            {

                _ = value;
                OnPropertyChanged("_ifRight");
            }
        }

        public string IfWrong
        {
            get { return IfWrong; }
            set
            {

                _ = value;
                OnPropertyChanged("_ifWrong");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


	}
}

