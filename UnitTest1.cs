using NUnit.Framework;
using System;
using System.IO;

namespace Hangman
{
    [TestFixture]
    public class HangmanTests
    {
        private StringWriter strWriter;
        private StringReader strReader;
        private TextWriter orOutput;
        private TextReader orInput;

        [SetUp]
        public void Setup()
        {
            strWriter = new StringWriter();
            orOutput = Console.Out;
            Console.SetOut(strWriter);
        }

        [TearDown]
        public void TearDown()
        {
            Console.SetOut(orOutput);
            Console.SetIn(orInput);
        }

        [Test]
        public void Test1()
        {
            // Тест проверяет случай, когда пользователь правильно угадывает слово "apple"
            // Ожидается, что в выводе будет содержаться сообщение "Поздравляем! Вы угадали слово: apple".

            string word = "apple";
            string input = "a\np\nl\ne\n";
            strReader = new StringReader(input);
            orInput = Console.In;
            Console.SetIn(strReader);

            Program.PlayGame(word);

            string output = strWriter.ToString();
            Assert.That(output, Does.Contain("Поздравляем! Вы угадали слово: apple"));
        }

        [Test]
        public void Test2()
        {
            // Тест проверяет случай, когда пользователь не угадывает слово "banana"
            // Ожидается, что в выводе будет содержаться сообщение "К сожалению, вы проиграли. Загаданное слово было: banana".

            string word = "banana";
            string input = "x\ny\nz\nw\nv\nu\n";
            strReader = new StringReader(input);
            orInput = Console.In;
            Console.SetIn(strReader);

            Program.PlayGame(word);

            string output = strWriter.ToString();
            Assert.That(output, Does.Contain("К сожалению, вы проиграли. Загаданное слово было: banana"));
        }

        [Test]
        public void Test3()
        {
            // Тест проверяет случай, когда пользователь вводит пустую строку вместо буквы.
            // Ожидается, что в выводе будет содержаться сообщение "Пожалуйста, введите букву.".

            string word = "orange";
            string input = "\n";
            strReader = new StringReader(input);
            orInput = Console.In;
            Console.SetIn(strReader);

            Program.PlayGame(word);

            string output = strWriter.ToString();
            Assert.That(output, Does.Contain("Пожалуйста, введите букву."));
        }

        [Test]
        public void Test4()
        {
            // Тест проверяет случай, когда пользователь вводит несколько букв одновременно ("ab")

            string word = "grape";
            string input = "ab\nc\nd\ne\n";
            strReader = new StringReader(input);
            orInput = Console.In;
            Console.SetIn(strReader);

            Program.PlayGame(word);

            string output = strWriter.ToString();
            Assert.That(output, Does.Contain("Поздравляем! Вы угадали слово: grape"));
        }

        [Test]
        public void Test5()
        {
            // Тест проверяет случай, когда пользователь правильно угадывает длинное слово "watermelon"
            // Ожидается, что в выводе будет содержаться сообщение "Поздравляем! Вы угадали слово: watermelon".

            string word = "watermelon";
            string input = "w\na\nt\ne\nr\nm\nl\no\nn\nw\n";
            strReader = new StringReader(input);
            orInput = Console.In;
            Console.SetIn(strReader);

            Program.PlayGame(word);

            string output = strWriter.ToString();
            Assert.That(output, Does.Contain("Поздравляем! Вы угадали слово: watermelon"));
        }

        [Test]
        public void Test6()
        {
            // Тест проверяет случай, когда пользователь вводит цифру "1" вместо буквы
            // Ожидается, что в выводе будет содержаться сообщение "Пожалуйста, введите букву.".

            string word = "apple";
            string input = "1\na\np\nl\ne\n";
            strReader = new StringReader(input);
            orInput = Console.In;
            Console.SetIn(strReader);

            Program.PlayGame(word);

            string output = strWriter.ToString();
            Assert.That(output, Does.Contain("Пожалуйста, введите букву."));
        }


        [Test]
        public void Test7()
        {
            // Тест проверяет случай, когда пользователь вводит буквы в верхнем регистре
            // Ожидается, что в выводе будет содержаться сообщение "Поздравляем! Вы угадали слово: banana".

            string word = "banana";
            string input = "B\nA\nN\nA\n";
            strReader = new StringReader(input);
            orInput = Console.In;
            Console.SetIn(strReader);

            Program.PlayGame(word);

            string output = strWriter.ToString();
            Assert.That(output, Does.Contain("Поздравляем! Вы угадали слово: banana"));
        }

        [Test]
        public void Test8()
        {
            // Тест проверяет случай, когда пользователь вводит кириллические буквы и после угадывает слово
            // Ожидается, что в выводе будет содержаться сообщение "Поздравляем! Вы угадали слово: banana".

            string word = "banana";
            string input = "й\nг\na\nb\nn\n";
            strReader = new StringReader(input);
            orInput = Console.In;
            Console.SetIn(strReader);

            Program.PlayGame(word);

            string output = strWriter.ToString();
            Assert.That(output, Does.Contain("Поздравляем! Вы угадали слово: banana"));
        }

        [Test]
        public void Test9()
        {
            // Тест проверяет случай, когда пользователь не угадывает слово "orange",
            // Ожидается, что в выводе будет содержаться сообщение "К сожалению, вы проиграли. Загаданное слово было: orange".

            string word = "orange";
            string input = "a\nb\nc\nd\ne\nf\n";
            strReader = new StringReader(input);
            orInput = Console.In;
            Console.SetIn(strReader);

            Program.PlayGame(word);

            string output = strWriter.ToString();
            Assert.That(output, Does.Contain("К сожалению, вы проиграли. Загаданное слово было: orange"));
        }

        [Test]
        public void Test10()
        {
            // Тест проверяет случай, когда пользователь правильно угадывает слово "grape" с 3 ошибками
            // Ожидается, что в выводе будет содержаться сообщение "Поздравляем! Вы угадали слово: grape".

            string word = "grape";
            string input = "a\nb\nc\ng\nr\np\ne\n";
            strReader = new StringReader(input);
            orInput = Console.In;
            Console.SetIn(strReader);

            Program.PlayGame(word);

            string output = strWriter.ToString();
            Assert.That(output, Does.Contain("Поздравляем! Вы угадали слово: grape"));
        }
    }
}