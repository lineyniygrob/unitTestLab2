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
            // ���� ��������� ������, ����� ������������ ��������� ��������� ����� "apple"
            // ���������, ��� � ������ ����� ����������� ��������� "�����������! �� ������� �����: apple".

            string word = "apple";
            string input = "a\np\nl\ne\n";
            strReader = new StringReader(input);
            orInput = Console.In;
            Console.SetIn(strReader);

            Program.PlayGame(word);

            string output = strWriter.ToString();
            Assert.That(output, Does.Contain("�����������! �� ������� �����: apple"));
        }

        [Test]
        public void Test2()
        {
            // ���� ��������� ������, ����� ������������ �� ��������� ����� "banana"
            // ���������, ��� � ������ ����� ����������� ��������� "� ���������, �� ���������. ���������� ����� ����: banana".

            string word = "banana";
            string input = "x\ny\nz\nw\nv\nu\n";
            strReader = new StringReader(input);
            orInput = Console.In;
            Console.SetIn(strReader);

            Program.PlayGame(word);

            string output = strWriter.ToString();
            Assert.That(output, Does.Contain("� ���������, �� ���������. ���������� ����� ����: banana"));
        }

        [Test]
        public void Test3()
        {
            // ���� ��������� ������, ����� ������������ ������ ������ ������ ������ �����.
            // ���������, ��� � ������ ����� ����������� ��������� "����������, ������� �����.".

            string word = "orange";
            string input = "\n";
            strReader = new StringReader(input);
            orInput = Console.In;
            Console.SetIn(strReader);

            Program.PlayGame(word);

            string output = strWriter.ToString();
            Assert.That(output, Does.Contain("����������, ������� �����."));
        }

        [Test]
        public void Test4()
        {
            // ���� ��������� ������, ����� ������������ ������ ��������� ���� ������������ ("ab")

            string word = "grape";
            string input = "ab\nc\nd\ne\n";
            strReader = new StringReader(input);
            orInput = Console.In;
            Console.SetIn(strReader);

            Program.PlayGame(word);

            string output = strWriter.ToString();
            Assert.That(output, Does.Contain("�����������! �� ������� �����: grape"));
        }

        [Test]
        public void Test5()
        {
            // ���� ��������� ������, ����� ������������ ��������� ��������� ������� ����� "watermelon"
            // ���������, ��� � ������ ����� ����������� ��������� "�����������! �� ������� �����: watermelon".

            string word = "watermelon";
            string input = "w\na\nt\ne\nr\nm\nl\no\nn\nw\n";
            strReader = new StringReader(input);
            orInput = Console.In;
            Console.SetIn(strReader);

            Program.PlayGame(word);

            string output = strWriter.ToString();
            Assert.That(output, Does.Contain("�����������! �� ������� �����: watermelon"));
        }

        [Test]
        public void Test6()
        {
            // ���� ��������� ������, ����� ������������ ������ ����� "1" ������ �����
            // ���������, ��� � ������ ����� ����������� ��������� "����������, ������� �����.".

            string word = "apple";
            string input = "1\na\np\nl\ne\n";
            strReader = new StringReader(input);
            orInput = Console.In;
            Console.SetIn(strReader);

            Program.PlayGame(word);

            string output = strWriter.ToString();
            Assert.That(output, Does.Contain("����������, ������� �����."));
        }


        [Test]
        public void Test7()
        {
            // ���� ��������� ������, ����� ������������ ������ ����� � ������� ��������
            // ���������, ��� � ������ ����� ����������� ��������� "�����������! �� ������� �����: banana".

            string word = "banana";
            string input = "B\nA\nN\nA\n";
            strReader = new StringReader(input);
            orInput = Console.In;
            Console.SetIn(strReader);

            Program.PlayGame(word);

            string output = strWriter.ToString();
            Assert.That(output, Does.Contain("�����������! �� ������� �����: banana"));
        }

        [Test]
        public void Test8()
        {
            // ���� ��������� ������, ����� ������������ ������ ������������� ����� � ����� ��������� �����
            // ���������, ��� � ������ ����� ����������� ��������� "�����������! �� ������� �����: banana".

            string word = "banana";
            string input = "�\n�\na\nb\nn\n";
            strReader = new StringReader(input);
            orInput = Console.In;
            Console.SetIn(strReader);

            Program.PlayGame(word);

            string output = strWriter.ToString();
            Assert.That(output, Does.Contain("�����������! �� ������� �����: banana"));
        }

        [Test]
        public void Test9()
        {
            // ���� ��������� ������, ����� ������������ �� ��������� ����� "orange",
            // ���������, ��� � ������ ����� ����������� ��������� "� ���������, �� ���������. ���������� ����� ����: orange".

            string word = "orange";
            string input = "a\nb\nc\nd\ne\nf\n";
            strReader = new StringReader(input);
            orInput = Console.In;
            Console.SetIn(strReader);

            Program.PlayGame(word);

            string output = strWriter.ToString();
            Assert.That(output, Does.Contain("� ���������, �� ���������. ���������� ����� ����: orange"));
        }

        [Test]
        public void Test10()
        {
            // ���� ��������� ������, ����� ������������ ��������� ��������� ����� "grape" � 3 ��������
            // ���������, ��� � ������ ����� ����������� ��������� "�����������! �� ������� �����: grape".

            string word = "grape";
            string input = "a\nb\nc\ng\nr\np\ne\n";
            strReader = new StringReader(input);
            orInput = Console.In;
            Console.SetIn(strReader);

            Program.PlayGame(word);

            string output = strWriter.ToString();
            Assert.That(output, Does.Contain("�����������! �� ������� �����: grape"));
        }
    }
}