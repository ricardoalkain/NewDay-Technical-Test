using System.Collections.Immutable;
using System.Text;

namespace diamond;

internal class Program
{
    /// <summary>
    /// Given a character from the alphabet, print a diamond of its output with that character being the midpoint of the diamond.
    ///
    ///  Examples
    ///
    ///  diamond.exe A
    ///    A
    ///
    ///  diamond.exe B
    ///     A
    ///    B B
    ///     A
    ///
    ///  diamond.exe C
    ///      A
    ///     B B
    ///    C   C
    ///     B B
    ///      A
    ///  It may be helpful visualise the whitespace in your rendering like this:
    ///
    ///  diamond.exe C
    ///  _ _ A _ _
    ///  _ B _ B _
    ///  C _ _ _ C
    ///  _ B _ B _
    ///  _ _ A _ _
    /// </summary>
    static int Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Prints a sequence of letters, starting with 'A', forming a diamond shape.");
            Console.WriteLine();
            Console.WriteLine("Usage:");
            Console.WriteLine("     diamond <char>");
            Console.WriteLine();
            Console.WriteLine("Example:");
            Console.WriteLine("     diamond C");
            Console.WriteLine("       A  ");
            Console.WriteLine("      B B ");
            Console.WriteLine("     C   C");
            Console.WriteLine("      B B ");
            Console.WriteLine("       A  ");
            Console.WriteLine();
            return -1;
        }

        if (args[0].Length != 1 || !char.IsLetter(args[0][0]))
        {
            Console.WriteLine("> Invalid input. Please enter a single letter (A - Z).");
            return -2;
        }

        const char FIRST_LETTER = 'A';

        var finalLetter = char.ToUpperInvariant(args[0][0]);
        var indent = finalLetter - FIRST_LETTER;
        var currentLetter = FIRST_LETTER;

        // Allocates memory for the diamond shape (half of it, as it's symmetrical)
        var size = indent * 2 + 1;
        var output = new char[size][];

        for (int i = 0; i < size; i++)
        {
            output[i] = new char[size];
            Array.Fill(output[i], ' ');
        }

        // First row is a special case
        output[0][indent] = FIRST_LETTER;
        Console.WriteLine(output[0]);

        // Builds the rest of the half-diamond
        for (int i = 1; i <= indent; i++)
        {
            currentLetter++;
            output[i][indent - i] = currentLetter;
            output[i][indent + i] = currentLetter;

            Console.WriteLine(output[i]);
        }

        // Reverses the half-diamond to complete the diamond shape
        for (int i = indent -1; i >= 0; i--)
        {
            Console.WriteLine(output[i]);
        }

        return 0;
    }
}
