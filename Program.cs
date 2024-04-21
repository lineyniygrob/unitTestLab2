using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    public class Program
    {
        public static void PlayGame(string word)
        {
            char[] guess = new char[word.Length];
            for (int i = 0; i < guess.Length; i++)
            {
                guess[i] = '_';
            }

            int attempts = 6;
            List<char> wrong = new List<char>();

            while (attempts > 0)
            {
                Console.WriteLine("Попытки: " + attempts);
                Console.WriteLine("Загаданное слово: " + new string(guess));
                Console.WriteLine("Неправильные буквы: " + string.Join(", ", wrong));

                Console.Write("Введите букву: ");
                char letter = Console.ReadLine().ToLower()[0];

                if (word.Contains(letter))
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == letter)
                        {
                            guess[i] = letter;
                        }
                    }

                    if (!guess.Contains('_'))
                    {
                        Console.WriteLine("Поздравляем! Вы угадали слово: " + word);
                        return;
                    }
                }
                else
                {
                    attempts--;
                    wrong.Add(letter);
                }
            }

            Console.WriteLine("К сожалению, вы проиграли. Загаданное слово было: " + word);
        }

        static void Main(string[] args)
        {
            List<string> words = new List<string> { "apple", "banana", "orange", "grape", "watermelon" };
            Random random = new Random();

            bool playAgain = true;
            while (playAgain)
            {
                string word = words[random.Next(words.Count)];
                PlayGame(word);

                Console.Write("Хотите сыграть еще раз? (да/нет): ");
                playAgain = Console.ReadLine().ToLower() == "да";
            }
        }
    }
}
