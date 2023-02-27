using System;
using System.ComponentModel;
using System.Windows;
using DateShower.Models;
using DateShower.Tools;

namespace DateShower.ViewModels
{
    public class DatePickViewModel: INotifyPropertyChanged
    {
        #region Fields
        private UserDateModel _datePickChoice = new UserDateModel();
        private RelayCommand<object> _chooseDateCommand;
        private string _ageString;
        private string _westZodiac;
        private string _chineseZodiac;
        public event PropertyChangedEventHandler PropertyChanged;  
        #endregion

        #region Properties
        public DateTime DateTimeField
        {
            get
            {
                return _datePickChoice.DateTime;
            }
            set
            {
                _datePickChoice.DateTime = value;
            }
        }

        public int Age
        {
            get
            {
                return _datePickChoice.Age;
            }
            set
            {
                _datePickChoice.Age = value;
            }
            
        }

        public string AgeString
        {
            get
            {
                return _ageString;
            }
            set
            {
                _ageString = value;
                NotifyPropertyChanged("AgeString");
            }
        }

        public string WestZodiac
        {
            get
            {
                return $"Your west zodiac is: {_westZodiac}";
            }
            set
            {
                _westZodiac = value;
                NotifyPropertyChanged("WestZodiac");
            }
        }
        
        public string ChineseZodiac
        {
            get
            {
                return $"Your chinese zodiac is: {_chineseZodiac}";
            }
            set
            {
                _chineseZodiac = value;
                NotifyPropertyChanged("ChineseZodiac");
            }
        }

        public RelayCommand<object> ChooseDateCommand
        {
            get
            {
                return _chooseDateCommand ??= new RelayCommand<object>(_ => ChooseDate());
            }
        }
        #endregion

        private void NotifyPropertyChanged(String propertyName = "")  
        {  
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string GetWestZodiac()
        {
            int day = DateTimeField.Day;
            int month = DateTimeField.Month;
            
            if((day>=21&&month==3)||(day<=20&&month==4))
                return "Aries";
            if((day>=24&&month==9)||(day<=23&&month==10))
                return "Libra";
            if((day>=21&&month==4)||(day<=21&&month==5))
                return "Taurus";
            if((day>=24&&month==10)||(day<=22&&month==11))
                return "Scorpio";
            if((day>=22&&month==5)||(day<=21&&month==6))
                return "Gemini";
            if((day>=23&&month==11)||(day<=21&&month==12))
                return "Sagittarius";
            if((day>=21&&month==6)||(day<=23&&month==7))
                return "Cancer";
            if((day>=22&&month==12)||(day<=20&&month==1))
                return "Capricorn";
            if((day>=24&&month==7)||(day<=23&&month==8))
                return "Leo";
            if((day>=21&&month==1)||(day<=19&&month==2))
                return "Aquarius";
            if((day>=24&&month==8)||(day<=23&&month==9))
                return "Virgo";
            if((day>=20&&month==2)||(day<=20&&month==3))
                return "Pisces";
            return "Something went wrong;";
        }

        private string GetChineseZodiac()
        {
            int year = DateTimeField.Year;
            
            if(year % 12 == 0) { return "Monkey";}
            else if (year % 12 == 1) {return "Rooster";}
            else if (year % 12 == 2) {return "Dog";}
            else if (year % 12 == 3) {return "Pig";}
            else if (year % 12 == 4) {return "Rat";}
            else if (year % 12 == 5) {return "Ox";}
            else if (year % 12 == 6) {return "Tiger";}
            else if (year % 12 == 7) {return "Rabbit";}
            else if (year % 12 == 8) {return "Dragon";}
            else if (year % 12 == 9) {return "Snake";}
            else if (year % 12 == 10) {return "Horse";}
            else { return "Sheep"; }
        }
        private int GetYearsFromBirthDate()
        {
            var today = DateTime.Today; 
            var age = today.Year - DateTimeField.Year;
            if (DateTimeField.Date > today.AddYears(-age)) age--;
            return age;
        }

        private void ChooseDate()
        {
            int age = GetYearsFromBirthDate();
            if (age < 0 || age > 135)
            {
                MessageBox.Show("Your age is impossible!");
            }
            else
            {
                Age = age;
                if (DateTimeField.Day == DateTime.Today.Day && DateTimeField.Month == DateTime.Today.Month)
                {
                    MessageBox.Show("Happy birthday! It's your lucky day!");
                }
                
                AgeString = $"Your age is: {Age}";
                WestZodiac = GetWestZodiac();
                ChineseZodiac = GetChineseZodiac();
            }
        }
    }
}