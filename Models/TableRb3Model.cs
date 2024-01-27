using System;
using System.ComponentModel;

namespace SocialSciencesEF2024.Models
{
	public class TableRb3Model:INotifyPropertyChanged
	{
        //я перенес все свойства с таблицы сюда, реализовал INotifyPropertyChanged, но у меня вопрос - нам надо в модели создавать поля для получения value у кадждого определенного в модели свойства ?

//нам надо как-то устанавливать свойства id? Указывать первичный ключ и тд с помощью атрибута / аннотации ?
        public int Id { get; set; }

       
	public string? option1;
        public string Option1
        {
            get { return option1; }
            set
            {
                option1 = value;
                OnPropertyChanged("Option1");
            }
        }
	
	public string? option2;
	public string Option2
        {
            get { return option2; }
            set
            {

                option2 = value;
                OnPropertyChanged("Option2");
            }

        }
	public string? option3;
        public string Option3
        {
            get { return option3; }
            set
            {

                option3 = value;
                OnPropertyChanged("Option3");
            }
        }

	private int? answerNr;
        public int AnswerNr
        {
            get { return (int)answerNr; }
            set
            {

                answerNr = value;
                OnPropertyChanged("AnswerNr");
            }
        }

        
	public string ifRight;
 	public string IfRight
        {
            get { return ifRight; }
            set
            {

                ifRight = value;
                OnPropertyChanged("IfRight");
            }
        }

	public string ifWrong;        
	public string IfWrong
        {
            get { return ifWrong; }
            set
            {

                ifWrong = value;
                OnPropertyChanged("IfWrong");
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

