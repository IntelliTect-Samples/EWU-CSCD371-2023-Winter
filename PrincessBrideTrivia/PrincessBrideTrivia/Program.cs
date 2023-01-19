using System;
using System.IO;

namespace PrincessBrideTrivia
{
    public class Program
    {
        private static int Hints = 0;
        public static int _Hints { get => Hints; set => Hints = value; }

        public static void Main(string[] args)
        {
            string filePath = GetFilePath();
            Question[] questions = LoadQuestions(filePath);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Type ? to use a hint! (Only works once per question) \n");
            Console.ForegroundColor = ConsoleColor.White;
            int numberCorrect = 0;
            for (int i = 0; i < questions.Length; i++)
            {
                bool result = AskQuestion(questions[i], (i + 1), questions.Length);
                if (result)
                {
                    numberCorrect++;
                } 
            }
            string hintTxt = GetHintTxt(_Hints);
            Console.WriteLine("You got " + GetPercentCorrect(numberCorrect, questions.Length) + " correct and " + hintTxt);
        }

        public static string GetHintTxt(int h)
        {
            if (h == 0)
            {
                return "you didn't use any hints!";
            }
            else if (h == 1)
            {
                return "you only used 1 hint!";
            }
            else
            {
                return "you only used " + h + " hints!";
            }
        }

        public static string GetPercentCorrect(int numberCorrectAnswers, int numberOfQuestions)
        {
            return ((int)((double)numberCorrectAnswers / (double)numberOfQuestions * 100)) + "%";
        }

        public static bool AskQuestion(Question question, int numQ, int total)
        {
            DisplayQuestionPt1(numQ, total);
            DisplayQuestionPt2(question);

            string userGuess = GetGuessFromUser();
            return DisplayResult(userGuess, question);
        }

        public static bool AskQuestionHint(Question question)
        {
            DisplayQuestionHint(question);

            string userGuess = GetGuessFromUser();
            return DisplayResult(userGuess, question);
        }

        public static string GetGuessFromUser()
        {
            return Console.ReadLine();
        }

        public static bool DisplayResult(string userGuess, Question question)
        {
            if (userGuess == "?")
            {
                _Hints++;
                return AskQuestionHint(question);
            }
            if (userGuess == question.CorrectAnswerIndex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct \n");
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrect \n");
            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }
        public static void DisplayQuestionPt1(int numberDone, int numberTotal)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Question " + numberDone + " / " + numberTotal);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void DisplayQuestionPt2(Question question)
        {
            Console.WriteLine(question.Text + "\n");
            for (int i = 0; i < question.Answers.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + question.Answers[i]);
            }
        }
        public static void DisplayQuestionHint(Question question)
        {
            Console.WriteLine("\n" + question.Text + "\n");
            if (question.CorrectAnswerIndex == "1" || question.CorrectAnswerIndex == "2")
            {
                for (int i = 0; i < question.Answers.Length - 1; i++)
                {
                    Console.WriteLine((i + 1) + ": " + question.Answers[i]);
                }
            } else
            {
                for (int i = 1; i < question.Answers.Length; i++)
                {
                    Console.WriteLine((i + 1) + ": " + question.Answers[i]);
                }
            }
        }

        public static string GetFilePath()
        {
            return "Trivia.txt";
        }

        public static Question[] LoadQuestions(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            Question[] questions = new Question[lines.Length / 5];
            for (int i = 0; i < questions.Length; i++)
            {
                int lineIndex = i * 5;
                string questionText = lines[lineIndex];

                string answer1 = lines[lineIndex + 1];
                string answer2 = lines[lineIndex + 2];
                string answer3 = lines[lineIndex + 3];

                string correctAnswerIndex = lines[lineIndex + 4];

                Question question = new Question();
                question.Text = questionText;
                question.Answers = new string[3];
                question.Answers[0] = answer1;
                question.Answers[1] = answer2;
                question.Answers[2] = answer3;
                question.CorrectAnswerIndex = correctAnswerIndex;

                questions[i] = question;
            }
            return questions;
        }
    }
}
