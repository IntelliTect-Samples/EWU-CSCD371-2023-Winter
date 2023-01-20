using System;
using System.Collections.Generic;
using System.IO;

namespace PrincessBrideTrivia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = GetFilePath();
            Question[] questions = LoadQuestions(filePath);

            int numberCorrect = 0;
            for (int i = 0; i < questions.Length; i++)
            {
                bool result = AskQuestion(questions[i]);
                if (result)
                {
                    numberCorrect++;
                }
            }
            Console.WriteLine("You got " + GetPercentCorrect(numberCorrect, questions.Length) + " correct");
        }

        public static string GetPercentCorrect(int numberCorrectAnswers, int numberOfQuestions)
        {
            return (numberCorrectAnswers * 100 / numberOfQuestions) + "%";
        }

        public static bool AskQuestion(Question question)
        {
            DisplayQuestion(question);

            string userGuess = GetGuessFromUser();
            return DisplayResult(userGuess, question);
        }

        // Modified for EC
        public static string GetGuessFromUser()
        {
            string guess = Console.ReadLine();
            while (CheckGuess(guess) == false)
            {
                Console.WriteLine("Invalid guess, please try again.");
                guess = Console.ReadLine();
            }
            return guess;
        }

        public static bool DisplayResult(string userGuess, Question question)
        {
            if (userGuess == question.CorrectAnswerIndex)
            {
                Console.WriteLine("Correct");
                return true;
            }

            Console.WriteLine("Incorrect");
            return false;
        }

        public static void DisplayQuestion(Question question)
        {
            Console.WriteLine("Question: " + question.Text);
            for (int i = 0; i < question.Answers.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + question.Answers[i]);
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

        public static bool CheckGuess(string guess)
        {
            List<string> allowedGuesses = new() { "1", "2", "3" };
            if (allowedGuesses.Contains(guess))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
