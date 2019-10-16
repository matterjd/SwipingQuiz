using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Windows.Input;

namespace SwipingQuiz
{
    class ViewModel : INotifyPropertyChanged
    {
        private string question;
        private string imageSource;
        private const int NUM_ITEMS = 4;
        private string[] questions = new string[NUM_ITEMS]{"Do you like this element?", "Do you like to do this in your free time?", "Is this a major strength for you?", "Do you identify with this animal?" };
        private string[] elements = new string[NUM_ITEMS] { "FIRE", "WIND", "WATER", "EARTH" };
        private string[] freeTime = new string[NUM_ITEMS] { "Going adventures with friends", "Let's go to the pubs!", "Doing anything outdoors", "Just being a mutha-f**K'en wizard" };
        private string[] strengths = new string[NUM_ITEMS] { "Leadership", "Action", "Wisdom", "Thoughtfulness" };
        private string[] animals = new string[NUM_ITEMS] { "EAGLE", "LION", "HOUSEFLY", "BULL" };
        private string resultText;
        private bool isResult;

        //Visiblility for Elements
        private bool isWind;
        private bool isEarth;
        private bool isFire;
        private bool isWater;

        //Visiblity for Free Time
        private bool isFreeTime1;
        private bool isFreeTime2;
        private bool isFreeTime3;
        private bool isFreeTime4;

        //Visiblity for Strengths
        private bool isStrength1;
        private bool isStrength2;
        private bool isStrength3;
        private bool isStrength4;

        //Visiblity for Animals
        private bool isAnimal1;
        private bool isAnimal2;
        private bool isAnimal3;
        private bool isAnimal4;

        //Visibility for Characters
        private bool isGimli;
        private bool isLegolas;
        private bool isAragorn;
        private bool isGandalf;

        private string followUpQ = "How about this one?"; 
        private string element;
        public int numSwipes = 0;
        public bool swiped = false;
        private int lSwipeCount = 0;
        private int point = 0;


        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand Swipecommand { get; private set; }
        public ICommand SubmitCommand { get; private set; }
        

        public ICommand ImageTapCommand { get; set; }
       
        public string GetQuestion
        {
            get { return question; }
            set
            {
                question = value;
                OnPropertyChanged("GetQuestion");
            }           
        }

        public string GetImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                OnPropertyChanged("GetImageSource");
            }
        }

        public string GetElement
        {
            get { return element; }
            set
            {
                element = value;
                OnPropertyChanged("GetElement");
            }
        }

        public bool IsWindVisible
        {
            get { return isWind; }
            set
            {
                isWind = value;
                if (isWind)
                    point = 4;
                OnPropertyChanged("IsWindVisible");
            }
        }

        public bool IsEarthVisible
        {
            get { return isEarth; }
            set
            {
                isEarth = value;
                if (isEarth)
                    point = 1;
                OnPropertyChanged("IsEarthVisible");
            }
        }

        public bool IsFireVisible
        {
            get { return isFire; }
            set
            {
                isFire = value;
                if (isFire)
                    point = 3;
                OnPropertyChanged("IsFireVisible");
            }
        }

        public bool IsWaterVisible
        {
            get { return isWater; }
            set
            {
                isWater = value;
                if (isWater)
                    point = 2;
                OnPropertyChanged("IsWaterVisible");
            }
        }

        public bool IsFreeTime1
        {
            get { return isFreeTime1; }
            set
            {
                isFreeTime1 = value;
                if (isFreeTime1)
                    point = 3;
                OnPropertyChanged("IsFreeTime1");
            }
        }

        public bool IsFreeTime2
        {
            get { return isFreeTime2; }
            set
            {
                isFreeTime2 = value;
                if (isFreeTime2)
                    point = 1;
                OnPropertyChanged("IsFreeTime2");
            }
        }

        public bool IsFreeTime3
        {
            get { return isFreeTime3; }
            set
            {
                isFreeTime3 = value;
                if (isFreeTime3)
                    point = 2;
                OnPropertyChanged("IsFreeTime3");
            }
        }

        public bool IsFreeTime4
        {
            get { return isFreeTime4; }
            set
            {
                isFreeTime4 = value;
                if (isFreeTime4)
                    point = 4;
                OnPropertyChanged("IsFreeTime4");
            }
        }

        public bool IsStrength1
        {
            get { return isStrength1; }
            set
            {
                isStrength1 = value;
                if (isStrength1)
                    point = 3;
                OnPropertyChanged("IsStrength1");
            }
        }

        public bool IsStrength2
        {
            get { return isStrength2; }
            set
            {
                isStrength2 = value;
                if (isStrength2)
                    point = 1;
                OnPropertyChanged("IsStrength2");
            }
        }

        public bool IsStrength3
        {
            get { return isStrength3; }
            set
            {
                isStrength3 = value;
                if (isStrength3)
                    point = 4;
                OnPropertyChanged("IsStrength3");
            }
        }

        public bool IsStrength4
        {
            get { return isStrength4; }
            set
            {
                isStrength4 = value;
                if (isStrength4)
                    point = 2;
                OnPropertyChanged("IsStrength4");
            }
        }

        public bool IsAnimal1
        {
            get { return isAnimal1; }
            set
            {
                isAnimal1 = value;
                if (isAnimal1)
                    point = 4;
                OnPropertyChanged("IsAnimal1");
            }
        }

        public bool IsAnimal2
        {
            get { return isAnimal2; }
            set
            {
                isAnimal2 = value;
                if (isAnimal2)
                    point = 3;
                OnPropertyChanged("IsAnimal2");
            }
        }

        public bool IsAnimal3
        {
            get { return isAnimal3; }
            set
            {
                isAnimal3 = value;
                if (isAnimal3)
                    point = 2;
                OnPropertyChanged("IsAnimal3");
            }
        }

        public bool IsAnimal4
        {
            get { return isAnimal4; }
            set
            {
                isAnimal4 = value;
                if (isAnimal4)
                    point = 1;
                OnPropertyChanged("IsAnimal4");
            }
        }

        public bool IsGimli
        {
            get { return isGimli; }
            set
            {
                isGimli = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsGimli"));
            }
        }
        public bool IsLegolas
        {
            get { return isLegolas; }
            set
            {
                isLegolas = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsLegolas"));
            }
        }
        public bool IsAragorn
        {
            get { return isAragorn; }
            set
            {
                isAragorn = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsAragorn"));
            }
        }
        public bool IsGandalf
        {
            get { return isGandalf; }
            set
            {
                isGandalf = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsGandalf"));
            }
        }

        public string ResultText
        {
            get { return resultText; }
            set
            {
                resultText = value;
                OnPropertyChanged("ResultText");
            }
        }

        public bool IsResult
        {
            get { return isResult; }
            set
            {
                isResult = value;
                OnPropertyChanged("IsResult");
            }
        }


        protected virtual void OnPropertyChanged(string myProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(myProperty));
        }

        private void SetElementNonVisible()
        {
            IsWindVisible = false;
            IsEarthVisible = false;
            IsFireVisible = false;
            IsWaterVisible = false;
        }

        private void SetFreeTimeNonVisible()
        {
            IsFreeTime1 = false;
            IsFreeTime2 = false;
            IsFreeTime3 = false;
            IsFreeTime4 = false;
        }

        private void SetStrengthsNonVisible()
        {
            IsStrength1 = false;
            IsStrength2 = false;
            IsStrength3 = false;
            IsStrength4 = false;
        }

        private void SetAnimalsNonVisible()
        {
            IsAnimal1 = false;
            IsAnimal2 = false;
            IsAnimal3 = false;
            IsAnimal4 = false;
        }

        private void SetCharacterVisiblity()
        {
            IsResult = false;
            ResultText = "";
            IsGimli = false;
            IsLegolas = false;
            IsAragorn = false;
            IsGandalf = false;
        }

        private void SetVisiblity()
        {
            switch (GetElement)
            {
                case "WIND":
                    IsWindVisible = true;
                    IsEarthVisible = false;
                    IsFireVisible = false;
                    IsWaterVisible = false;
                    SetFreeTimeNonVisible();
                    SetStrengthsNonVisible();
                    SetAnimalsNonVisible();
                    break;
                case "EARTH":
                    IsWindVisible = false;
                    IsEarthVisible = true;
                    IsFireVisible = false;
                    IsWaterVisible = false;
                    SetFreeTimeNonVisible();
                    SetStrengthsNonVisible();
                    SetAnimalsNonVisible();
                    break;
                case "FIRE":
                    IsWindVisible = false;
                    IsEarthVisible = false;
                    IsFireVisible = true;
                    IsWaterVisible = false;
                    SetFreeTimeNonVisible();
                    SetStrengthsNonVisible();
                    SetAnimalsNonVisible();
                    break;
                case "WATER":
                    IsWindVisible = false;
                    IsEarthVisible = false;
                    IsFireVisible = false;
                    IsWaterVisible = true;
                    SetFreeTimeNonVisible();
                    SetStrengthsNonVisible();
                    SetAnimalsNonVisible();
                    break;
                case "Going adventures with friends":
                    IsFreeTime1 = true;
                    IsFreeTime2 = false;
                    IsFreeTime3 = false;
                    IsFreeTime4 = false;
                    SetElementNonVisible();
                    SetStrengthsNonVisible();
                    SetAnimalsNonVisible();
                    break;
                case "Let's go to the pubs!":
                    IsFreeTime1 = false;
                    IsFreeTime2 = true;
                    IsFreeTime3 = false;
                    IsFreeTime4 = false;
                    SetElementNonVisible();
                    SetStrengthsNonVisible();
                    SetAnimalsNonVisible();
                    break;
                case "Doing anything outdoors":
                    IsFreeTime1 = false;
                    IsFreeTime2 = false;
                    IsFreeTime3 = true;
                    IsFreeTime4 = false;
                    SetElementNonVisible();
                    SetStrengthsNonVisible();
                    SetAnimalsNonVisible();
                    break;
                case "Just being a mutha-f**K'en wizard":
                    IsFreeTime1 = false;
                    IsFreeTime2 = false;
                    IsFreeTime3 = false;
                    IsFreeTime4 = true;
                    SetElementNonVisible();
                    SetStrengthsNonVisible();
                    SetAnimalsNonVisible();
                    break;

                case "Leadership":
                    IsStrength1 = true;
                    IsStrength2 = false;
                    IsStrength3 = false;
                    IsStrength4 = false;
                    SetElementNonVisible();
                    SetFreeTimeNonVisible();
                    SetAnimalsNonVisible();
                    break;
                case "Action":
                    IsStrength1 = false;
                    IsStrength2 = true;
                    IsStrength3 = false;
                    IsStrength4 = false;
                    SetElementNonVisible();
                    SetFreeTimeNonVisible();
                    SetAnimalsNonVisible();
                    break;
                case "Wisdom":
                    IsStrength1 = false;
                    IsStrength2 = false;
                    IsStrength3 = true;
                    IsStrength4 = false;
                    SetElementNonVisible();
                    SetFreeTimeNonVisible();
                    SetAnimalsNonVisible();
                    break;
                case "Thoughtfulness":
                    IsStrength1 = false;
                    IsStrength2 = false;
                    IsStrength3 = false;
                    IsStrength4 = true;
                    SetElementNonVisible();
                    SetFreeTimeNonVisible();
                    SetAnimalsNonVisible();
                    break;
                case "EAGLE":
                    IsAnimal1 = true;
                    IsAnimal2 = false;
                    IsAnimal3 = false;
                    IsAnimal4 = false;
                    SetElementNonVisible();
                    SetFreeTimeNonVisible();
                    SetStrengthsNonVisible();
                    break;
                case "LION":
                    IsAnimal1 = false;
                    IsAnimal2 = true;
                    IsAnimal3 = false;
                    IsAnimal4 = false;
                    SetElementNonVisible();
                    SetFreeTimeNonVisible();
                    SetStrengthsNonVisible();
                    break;
                case "HOUSEFLY":
                    IsAnimal1 = false;
                    IsAnimal2 = false;
                    IsAnimal3 = true;
                    IsAnimal4 = false;
                    SetElementNonVisible();
                    SetFreeTimeNonVisible();
                    SetStrengthsNonVisible();
                    break;
                case "BULL":
                    IsAnimal1 = false;
                    IsAnimal2 = false;
                    IsAnimal3 = false;
                    IsAnimal4 = true;
                    SetElementNonVisible();
                    SetFreeTimeNonVisible();
                    SetStrengthsNonVisible();
                    break;
                default:
                    SetElementNonVisible();
                    SetFreeTimeNonVisible();
                    SetStrengthsNonVisible();
                    SetAnimalsNonVisible();
                    break;
            }
        }
       
        public ViewModel()
        {
            Model model = new Model();
            
            GetQuestion = questions[numSwipes].ToString();
            //GetImageSource = model.GetRandomImage(images);
            GetElement = elements[numSwipes].ToString();

            SetCharacterVisiblity();
            SetVisiblity();

            SubmitCommand = new Command(
                execute: () =>
                {
                    model = new Model();

                    GetQuestion = questions[numSwipes].ToString();
                    //GetImageSource = model.GetRandomImage(images);
                    GetElement = elements[numSwipes].ToString();

                    SetCharacterVisiblity();
                    SetVisiblity();
                });

            Swipecommand = new Command<string>(
            execute: (string direction) =>
            {
                string myDirection = "";
                if (direction != "")
                {
                    if (direction.Equals("Left"))
                    {
                        // Handle the swipe
                        myDirection = "left";
                        swiped = true;
                    }
                    else if (direction.Equals("Right"))
                    {
                        myDirection = "right";
                        swiped = true;
                    }
                    else
                    {
                        myDirection = "";
                        swiped = false;
                    }
                }
                else
                    return;
                if (numSwipes < 5)
                {
                    if (myDirection.Equals("left") && swiped)
                    {
                        lSwipeCount++;
                        if (lSwipeCount == 4)
                            lSwipeCount = 0;
                        if (numSwipes == 0)
                        {
                            GetElement = elements[lSwipeCount].ToString();
                        }
                        else if (numSwipes == 1)
                        {
                            GetElement = freeTime[lSwipeCount].ToString();
                        }
                        else if (numSwipes == 2)
                        {
                            GetElement = strengths[lSwipeCount].ToString();
                        }
                        else if (numSwipes == 3)
                        {
                            GetElement = animals[lSwipeCount].ToString();
                        }
                        SetVisiblity();
                        GetQuestion = followUpQ;
                    }
                    else
                    {
                        lSwipeCount = 0;
                        numSwipes++;
                        model.Add(point);
                        if (numSwipes <= 4)
                        {
                            switch (numSwipes)
                            {
                                case 1:
                                    GetElement = freeTime[lSwipeCount];
                                    break;
                                case 2:
                                    GetElement = strengths[lSwipeCount];
                                    break;
                                case 3:
                                    GetElement = animals[lSwipeCount];
                                    break;
                                default:
                                    break;
                            }
                            if (numSwipes < 4)
                            {
                                GetQuestion = questions[numSwipes].ToString();
                                SetVisiblity();
                            }
                        }
                    }

                    if (numSwipes == 4)
                    {
                        char code = ' ';
                        int points = model.GetTotalPoints();
                        code = model.GetCode(points);
                        SetElementNonVisible();
                        SetFreeTimeNonVisible();
                        SetStrengthsNonVisible();
                        SetAnimalsNonVisible();

                        switch (code)
                        {
                            case 'G':
                                ResultText = "Gimli";
                                IsGimli = true;
                                IsLegolas = false;
                                IsAragorn = false;
                                IsGandalf = false;
                                break;
                            case 'L':
                                ResultText = "Legolas";
                                IsGimli = false;
                                IsLegolas = true;
                                IsAragorn = false;
                                IsGandalf = false;
                                break;
                            case 'A':
                                ResultText = "Aragorn";
                                IsGimli = false;
                                IsLegolas = false;
                                IsAragorn = true;
                                IsGandalf = false;
                                break;
                            case 'W':
                                ResultText = "Gandalf";
                                IsGimli = false;
                                IsLegolas = false;
                                IsAragorn = false;
                                IsGandalf = true;
                                break;
                        }
                        GetQuestion = "Your LOTR character is:";
                        IsResult = true;
                        numSwipes = 0;

                    }
                }
                else
                {
                    model = new Model();

                    GetQuestion = questions[numSwipes].ToString();
                    //GetImageSource = model.GetRandomImage(images);
                    GetElement = elements[numSwipes].ToString();

                    SetCharacterVisiblity();
                    SetVisiblity();


                }
                    
            });
        }
    }
}
