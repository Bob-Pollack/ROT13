using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//this program is designed to take the input of a text file and output it as a new text file
//that has the letters switched with the letter 13 away
//this same routine can decrypt the text into standard english simply by being used again

namespace ROT13
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a dictionary that stores each of the 26 letters as a character.
            //this allows us to easily add to the number and get output via modulo
            //this was originally done with characters but converted to string 
            //as a result of a mistyping elsewhere that has since been corrected
            //may be converted back to char if program runs slowly
            Dictionary<string, int> LettersToNumbers = new Dictionary<string, int>();
            LettersToNumbers.Add("a", 1);
            LettersToNumbers.Add("b", 2);
            LettersToNumbers.Add("c", 3);
            LettersToNumbers.Add("d", 4);
            LettersToNumbers.Add("e", 5);
            LettersToNumbers.Add("f", 6);
            LettersToNumbers.Add("g", 7);
            LettersToNumbers.Add("h", 8);
            LettersToNumbers.Add("i", 9);
            LettersToNumbers.Add("j", 10);
            LettersToNumbers.Add("k", 11);
            LettersToNumbers.Add("l", 12);
            LettersToNumbers.Add("m", 13);
            LettersToNumbers.Add("n", 14);
            LettersToNumbers.Add("o", 15);
            LettersToNumbers.Add("p", 16);
            LettersToNumbers.Add("q", 17);
            LettersToNumbers.Add("r", 18);
            LettersToNumbers.Add("s", 19);
            LettersToNumbers.Add("t", 20);
            LettersToNumbers.Add("u", 21);
            LettersToNumbers.Add("v", 22);
            LettersToNumbers.Add("w", 23);
            LettersToNumbers.Add("x", 24);
            LettersToNumbers.Add("y", 25);
            LettersToNumbers.Add("z", 0);


            //first we're going to set it up so that it automatically converts input into rot13
            //then worry about text files later
          
            //define variable
            string userInput = " ";

            while (userInput != "")
            {
                //get user input
                userInput = Console.ReadLine();

                //function below
                string outputString = Rot13Convert(LettersToNumbers, userInput);

                Console.WriteLine(outputString);
                //as long as user's last input wasn't blank, repeat
            }

            //next step: file I/O instead of simply taking user input in the console window.

        }

        private static string Rot13Convert(Dictionary<string, int> LettersToNumbers, string userInput)
        {
            string outputString = "";
            int convertedChar = 0;
            string newChar = " ";

            //loop through userInput string
            for (int i = 0; i < userInput.Length; i++)
            {
                //converts an uncapitalized character to its equivalent rot13 modifier, adds it to outputstring
                if (LettersToNumbers.ContainsKey(userInput.Substring(i, 1)))
                {
                    //get the int value of the character
                    convertedChar = LettersToNumbers[userInput.Substring(i, 1)];
                    //add 13
                    convertedChar = convertedChar + 13;
                    //modulo 26 to get it down to the 0-25 range
                    convertedChar = convertedChar % 26;
                    //convert it back to a char
                    //note: this only works because each value has a unique key
                    //this is somehwat inefficient, but the dictionary is only 26 characters in size
                    foreach (KeyValuePair<string, int> pair in LettersToNumbers)
                    {
                        if (convertedChar == pair.Value)
                        {
                            //if values were not unique, only the last key would show up here
                            newChar = pair.Key;
                        }
                    }
                    //append the new character to the outputstring, return to start of loop
                    outputString = outputString + newChar;
                }
                //converts a capital letter to its equivalent rot13 modifier, adds it to outputstring
                else if (LettersToNumbers.ContainsKey(userInput.Substring(i, 1).ToLower()))
                {
                    //do the same as above, then convert back to capital letter 
                    convertedChar = LettersToNumbers[userInput.Substring(i, 1).ToLower()];
                    convertedChar = convertedChar + 13;
                    convertedChar = convertedChar % 26;
                    foreach (KeyValuePair<string, int> pair in LettersToNumbers)
                    {
                        if (convertedChar == pair.Value)
                        {
                            newChar = pair.Key;
                        }
                    }
                    outputString = outputString + newChar.ToUpper();
                }
                //if not a letter or capital, add it unmodified to the outputstring
                else
                {
                    outputString = outputString + userInput[i];
                    //this is done as a char and works fine
                }
            }

            return outputString;
        }
    }
}

