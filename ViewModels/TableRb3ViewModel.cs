using Microsoft.EntityFrameworkCore;  
using SocialSciencesEF2024.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using SocialSciencesEF2024.PopUp;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace SocialSciencesEF2024.ViewModels
{
    public class TableRb3ViewModel : INotifyPropertyChanged
    {
        Popup popUp = new Popup();

        TableRb3Model currentQuestion;
        public TableRb3Model CurrentQuestion
        {
            get { return currentQuestion; }


            set { currentQuestion = value; }
        }


        private int? indexOfSelectedRb;
        public int? IndexOfSelectedRb
        {
            get { return indexOfSelectedRb; }
            set
            {
                indexOfSelectedRb = value;


                OnPropertyChanged("[CallerMemberName] ");//в этот параметр передастся название метода, который вызвал этот метод. Надо назвать этот метод для проверки кнопки - нажата ли радиокнопка или нет - метод CallerMemberName с помощью атрибута
                //я, к сожалению, не понял, как мы должны применить этот атрибут с названием метода, поэтому делаю этот комментарий
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;


        public ICommand radioButtonIsCheckedCommand;
        public ICommand RadioButtonIsCheckedCommand
        {
            get
            {
                return radioButtonIsCheckedCommand ??
                 (radioButtonIsCheckedCommand = new Command(commandParameter =>
               {
                   var _indexOfSelectedRb = commandParameter;
                   int indexOfSelectedRb = Convert.ToInt32(_indexOfSelectedRb);


               }));
            }
        }


        public ICommand buttonConfirmClickedCommand;
        public ICommand ButtonConfirmClickedCommand
        {
            get
            {
                return buttonConfirmClickedCommand ??
                 (buttonConfirmClickedCommand = new Command(obj =>
                 {
                     if (indexOfSelectedRb.HasValue)
                     {
                         if (indexOfSelectedRb == CurrentQuestion.AnswerNr)
                         {
                             ShowPopupIfRight();

                         }

                         else
                         {
                             
                             ShowPopupIfWrong();
                         }

                     }

                     else
                     {
                         //Button IsEnable = false

                     }
                 }));
            }
        }



        public ICommand buttonNextQuestionPopup;
        private object obj;

        public ICommand ButtonNextQuestionPopup
        {
            get
            {
                return buttonNextQuestionPopup ??
                 (buttonNextQuestionPopup = new Command(obj =>
                 {
                     //что нам прописать в эту логику?

                 }));
            }
        }



        private void ShowPopupIfWrong()
        {

            var popup = new PopupIfRightPage();
            Shell.Current.CurrentPage.ShowPopup(popup);



        }

        private void ShowPopupIfRight()
        {
            var popup = new PopupIfWrongPage();
            Shell.Current.CurrentPage.ShowPopup(popup);
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public TableRb3ViewModel()
        {
            //что нам нужно во ViewModel помещать в конструктор ?

        }

        public void QuizActivity()
        {
            TableRB3Context db = new TableRB3Context();
            var itemOfQuestions = db.questionList.ToList();

            foreach (var item in itemOfQuestions)
            {
                //как мне вызвать здесь команды ?
                //Я смог сделать только так:

                _ = radioButtonIsCheckedCommand;

                _ = buttonConfirmClickedCommand;


                if (buttonNextQuestionPopup.CanExecute(obj) && currentQuestion.id < itemOfQuestions.Count) //тут два условия, одно из которых - проверка нажатия на кнопку в popup
                {
                    continue;
            
                }
                else
                {
                    FinishQuiz();
                }

            }
        }

        private async void FinishQuiz()
        {           
            //логика закрытия quiz - переход к новому экрану, где кнопки либо возврат в главное меню, либо к след уровню, это можно потом сделать...
        }
    }
}



    






















/*Просто для себя закомментил свой прошлый код для сравнения на предмет ошибок
 * 
            ButtonConfirmClickedCommand = new Command((object? args) =>
            {
               
                if (IndexOfSelectedRb.HasValue)
                {
                    if (IndexOfSelectedRb == CurrentQuestion.AnswerNr)
                    {
                        //PopUp => set content FROM currentQuestion.IfRight

                    }

                    else
                    {
                        //PopUp => set content FROM currentQuestion.IfWrong
                    }


                }

                else
                {
                    //Button IsEnable = false

                }

            });

        }
*/
