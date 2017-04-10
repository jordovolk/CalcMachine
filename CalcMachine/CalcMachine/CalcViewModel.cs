using System;

using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
namespace CalcMachine
{
    public class CalcViewModel : ViewModelBase
    {
        string currentEntry = "";
        string historyString = "";
        bool isAnswerDisplayed = false;
        double accumulatedAnswer = 0;
        double containerAnswer = 0;


        Label displayLabel;
        float num1, ans;
        int count;
        Int32 negativevalueassigned = 0;


        public CalcViewModel()
        {
            displayLabel = new Label { Text = "" };
            
            ClearCommand = new Command(
                execute: () =>
                {
                    CurrentEntry = "";
                    count = 0;
                    negativevalueassigned = 0;
                  
                    RefreshCanExecutes();
                });

            EqualsCommand = new Command(
                execute: () =>
                {
                    if (negativevalueassigned > 2)
                    {
                        CurrentEntry = "not valid";
                    }

                    else
                    {
                        compute(count);
                        
                    }

                    RefreshCanExecutes();

                });

            BackspaceCommand = new Command(
                execute: () =>
                {
                    CurrentEntry = CurrentEntry.Substring(0, CurrentEntry.Length - 1);

                    if (CurrentEntry.Length == 0)
                    {
                        CurrentEntry = "0";
                    }

                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return isAnswerDisplayed && (CurrentEntry.Length > 1 || CurrentEntry[0] != '0');
                });

            NumericCommand = new Command<string>(
                execute: (string parameter) =>
                {
                    if (isAnswerDisplayed || CurrentEntry == "0")
                        CurrentEntry = parameter;
                    else
                        CurrentEntry += parameter;

                    isAnswerDisplayed = false;
                    RefreshCanExecutes();
                },
                canExecute: (string parameter) =>
                {
                    return isAnswerDisplayed || CurrentEntry.Length < 16;
                });

            DecimalPointCommand = new Command(
                execute: () =>
                {
                    if (isAnswerDisplayed)
                        CurrentEntry = "0.";
                    else
                        CurrentEntry += ".";

                    isAnswerDisplayed = false;
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return isAnswerDisplayed || !CurrentEntry.Contains(".");
                });

            AddCommand = new Command(
                execute: () =>
                {
                    if (negativevalueassigned > 1)
                    {
                        CurrentEntry = "not valid";
                    }
                    else if (CurrentEntry != "")
                    {
                        num1 = float.Parse(CurrentEntry);
                        CurrentEntry = "";
                       
                        count = 2;
                    }
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return !isAnswerDisplayed;
                });

            SubtractCommand = new Command(
                execute: () =>
                {
                    if (negativevalueassigned > 1)
                    {
                        CurrentEntry = "not valid";
                    }

                    else if (CurrentEntry != "")
                    {
                        num1 = float.Parse(CurrentEntry);

                        CurrentEntry = "";
                  
                        count = 1;
                    }
                    RefreshCanExecutes();
                
                },
                canExecute: () =>
                {
                    return !isAnswerDisplayed;
                });

            DivideCommand = new Command(
                execute: () =>
                {
                    if (negativevalueassigned > 1)
                    {
                        CurrentEntry = "not valid";
                    }

                    else if (CurrentEntry != "")
                    {
                        num1 = float.Parse(CurrentEntry);
                        CurrentEntry = "";
                      
                        count = 4;
                    }

                    RefreshCanExecutes();




                },
                canExecute: () =>
                {
                    return !isAnswerDisplayed;
                });

            MultiplyCommand = new Command(
                execute: () =>
                {
                    if (negativevalueassigned > 1)
                    {
                        CurrentEntry = "not valid";
                    }

                    else if (CurrentEntry != "")
                    {
                        num1 = float.Parse(CurrentEntry);
                        CurrentEntry = "";
                       
                        count = 3;
                    }

                    RefreshCanExecutes();




                },
                canExecute: () =>
                {
                    return !isAnswerDisplayed;
                });


            ZeroCommand = new Command(
                execute: () =>
                {
                    CurrentEntry = currentEntry + 0;
                },
                canExecute: () =>
                {
                    return !isAnswerDisplayed;
                });

            OneCommand = new Command(
               execute: () =>
               {
                   CurrentEntry = currentEntry + 1;
               },
               canExecute: () =>
               {
                   return !isAnswerDisplayed;
               });

            TwoCommand = new Command(
               execute: () =>
               {
                   CurrentEntry = currentEntry + 2;
               },
               canExecute: () =>
               {
                   return !isAnswerDisplayed;
               });

            ThreeCommand = new Command(
               execute: () =>
               {
                   CurrentEntry = currentEntry + 3;
               },
               canExecute: () =>
               {
                   return !isAnswerDisplayed;
               });

            FourCommand = new Command(
               execute: () =>
               {
                   CurrentEntry = currentEntry + 4;
               },
               canExecute: () =>
               {
                   return !isAnswerDisplayed;
               });

            FiveCommand = new Command(
               execute: () =>
               {
                   CurrentEntry = currentEntry + 5;
               },
               canExecute: () =>
               {
                   return !isAnswerDisplayed;
               });

            SixCommand = new Command(
               execute: () =>
               {
                   CurrentEntry = currentEntry + 6;
               },
               canExecute: () =>
               {
                   return !isAnswerDisplayed;
               });

            SevenCommand = new Command(
               execute: () =>
               {
                   CurrentEntry = currentEntry + 7;
               },
               canExecute: () =>
               {
                   return !isAnswerDisplayed;
               });

            EightCommand = new Command(
               execute: () =>
               {
                   CurrentEntry = currentEntry + 8;
               },
               canExecute: () =>
               {
                   return !isAnswerDisplayed;
               });
            NineCommand = new Command(
               execute: () =>
               {
                   CurrentEntry = currentEntry + 9;
               },
               canExecute: () =>
               {
                   return !isAnswerDisplayed;
               });

           



    }

        void RefreshCanExecutes()
        {
            ((Command)BackspaceCommand).ChangeCanExecute();
            ((Command)NumericCommand).ChangeCanExecute();
            ((Command)DecimalPointCommand).ChangeCanExecute();
            ((Command)AddCommand).ChangeCanExecute();
            ((Command)SubtractCommand).ChangeCanExecute();
            ((Command)MultiplyCommand).ChangeCanExecute();
            ((Command)DivideCommand).ChangeCanExecute();
            ((Command)ZeroCommand).ChangeCanExecute();
            ((Command)OneCommand).ChangeCanExecute();
            ((Command)TwoCommand).ChangeCanExecute();
            ((Command)ThreeCommand).ChangeCanExecute();
            ((Command)FourCommand).ChangeCanExecute();
            ((Command)FiveCommand).ChangeCanExecute();
            ((Command)SixCommand).ChangeCanExecute();
            ((Command)SevenCommand).ChangeCanExecute();
            ((Command)EightCommand).ChangeCanExecute();
            ((Command)NineCommand).ChangeCanExecute();
            ((Command)EqualsCommand).ChangeCanExecute();

        }

        public string CurrentEntry
        {
            private set { SetProperty(ref currentEntry, value); }
            get { return currentEntry; }
        }

        public string HistoryString
        {
            private set { SetProperty(ref historyString, value); }
            get { return historyString; }
        }

  



        public ICommand ClearCommand { private set; get; }

        public ICommand ClearEntryCommand { private set; get; }

        public ICommand BackspaceCommand { private set; get; }

        public ICommand NumericCommand { private set; get; }

        public ICommand DecimalPointCommand { private set; get; }

        public ICommand AddCommand { private set; get; }

        public ICommand SubtractCommand { private set; get; }

        public ICommand MultiplyCommand { private set; get; }

        public ICommand DivideCommand { private set; get; }

        public ICommand ZeroCommand { private set; get; }

        public ICommand OneCommand { private set; get; }

        public ICommand TwoCommand { private set; get; }

        public ICommand ThreeCommand { private set; get; }

        public ICommand FourCommand { private set; get; }

        public ICommand FiveCommand { private set; get; }

        public ICommand SixCommand { private set; get; }

        public ICommand SevenCommand { private set; get; }

        public ICommand EightCommand { private set; get; }

        public ICommand NineCommand { private set; get; }

        public ICommand EqualsCommand { private set; get; }







        public void SaveState(IDictionary<string, object> dictionary)
        {
            dictionary["CurrentEntry"] = CurrentEntry;
            dictionary["HistoryString"] = HistoryString;
            dictionary["isSumDisplayed"] = isAnswerDisplayed;
            dictionary["accumulatedSum"] = accumulatedAnswer;
        }

        public void compute(int count)
        {
            switch (count)
            {
                case 1:
                    ans = num1 - float.Parse(CurrentEntry);
                    CurrentEntry = ans.ToString();
                    break;
                case 2:
                    ans = num1 + float.Parse(CurrentEntry);
                    CurrentEntry = ans.ToString();
                    break;
                case 3:
                    ans = num1 * float.Parse(CurrentEntry);
                    CurrentEntry = ans.ToString();
                    break;
                case 4:

                    ans = num1 / float.Parse(CurrentEntry);
                    CurrentEntry = ans.ToString();
                    break;

                default:
                    break;



            }
        }

        public void RestoreState(IDictionary<string, object> dictionary)
        {
            CurrentEntry = GetDictionaryEntry(dictionary, "CurrentEntry", "0");
            HistoryString = GetDictionaryEntry(dictionary, "HistoryString", "");
            isAnswerDisplayed = GetDictionaryEntry(dictionary, "isSumDisplayed", false);
            accumulatedAnswer = GetDictionaryEntry(dictionary, "accumulatedSum", 0.0);

            RefreshCanExecutes();
        }

        public T GetDictionaryEntry<T>(IDictionary<string, object> dictionary,
                                        string key, T defaultValue)
        {
            if (dictionary.ContainsKey(key))
                return (T)dictionary[key];

            return defaultValue;
        }
    }
}

