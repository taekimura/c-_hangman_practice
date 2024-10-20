namespace program_flow
{
  class Program
  {
    static string word;
    static char[] guess;
    static int lives;

    static string[] status = new string[]
{                " _______\n"+
                 " |/     |\n"+
                 " |     (_)\n"+
                 " |     \\|/\n"+
                 " |      |\n"+
                 " |     / \\\n"+
                 " |\n"+
                "_|___\n",

                 " _______\n"+
                 " |/     |\n"+
                 " |     (_)\n"+
                 " |     \\|/\n"+
                 " |       \n"+
                 " |     \n"+
                 " |\n"+
                "_|___\n",

                 " _______\n"+
                 " |/     |\n"+
                 " |     (_)\n"+
                 " |      \n"+
                 " |       \n"+
                 " |      \n"+
                 " |\n"+
                "_|___\n",

                 " _______\n"+
                 " |/     |\n"+
                 " |      \n"+
                 " |      \n"+
                 " |       \n"+
                 " |      \n"+
                 " |\n"+
                "_|___\n",

                 " _______\n" +
                 " |/     \n"+
                 " |      \n"+
                 " |      \n"+
                 " |       \n"+
                 " |      \n"+
                 " |\n"+
                "_|___\n",

                 "  \n"+
                 " |      \n"+
                 " |      \n"+
                 " |      \n"+
                 " |      \n"+
                 " |      \n"+
                 " |\n"+
                "_|___\n",
};

    static void Main(string[] args)
    {
      Update();
    }

    static void Start()
    {
      Console.Clear();

      word = PickWord();

      BlankLetters();

      lives = 5;
    }

    static void Update()
    {
      Start();

      while (lives > 0)
      {
        PrintWord();

        PromptPlayer();

        string input = GetInput();
        CheckInput(input);

        CheckGameOver();
      }
    }

    static string PickWord()
    {
      string[] words =
      [
      "Hello",
      "World",
      "Duck",
      "Cat",
      "Dog",
      ];

      Random random = new Random();
      int index = random.Next(0, words.Length);
      return words[index].ToUpper();
    }


    static void BlankLetters()
    {
      guess = new char[word.Length];
      for (int i = 0; i < guess.Length; i++)
      {
        guess[i] = '_';
      }
    }

    static void PrintWord()
    {
      Console.WriteLine("Guess the word");
      for (int i = 0; i < guess.Length; i++)
      {
        Console.Write(guess[i] + " ");
      }

      Console.WriteLine();
    }

    static void PromptPlayer()
    {
      Console.WriteLine("Enter a letter");

      if (lives < 5)
      {
        Console.WriteLine(status[lives]);
        Console.WriteLine($"You have {lives} left");
      }
    }


    static string GetInput()
    {
      string input = Console.ReadLine();
      input = input.ToUpper();

      return input;
    }

    static void CheckInput(string input)
    {
      bool correct = false;
      for (int i = 0; i < word.Length; i++)
      {
        if (word[i] == input[0])
        {
          guess[i] = input[0];
          correct = true;
        }
      }

      if (!correct)
      {
        lives--;
      }
      Console.Clear();
    }

    static void CheckGameOver()
    {
      if (lives == 0)
      {
        Console.WriteLine("GAME OVER!\n");
        ShowEndScreen();
      }
      else if (!guess.Contains('_'))
      {
        Console.WriteLine("YOU WIN!\n");
        ShowEndScreen();
      }
    }

    static void ShowEndScreen()
    {
      Console.WriteLine($"The word was {word}");

      if (lives < 5)
      {
        Console.WriteLine(status[lives]);

      }

      Console.WriteLine("Press R to restart, press any other key to quit");
      ConsoleKeyInfo k = Console.ReadKey();
      if (k.Key == ConsoleKey.R)
      {
        Start();
      }
      else
      {
        Environment.Exit(0);
      }
    }
  }
}