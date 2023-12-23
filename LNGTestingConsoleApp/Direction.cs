using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNGTestingConsoleApp;
public record Direction(string key, string Left, string Right)
{
    public static Direction New(string inputLine)
    {
        return new(inputLine.Substring(0,3),GetStringBetweenCharacters(inputLine, "(", ","),
        GetStringBetweenCharacters(inputLine, ", ", ")"));
    }

    public static string GetStringBetweenCharacters(string input, string charFrom, string charTo) {
        int posFrom = input.IndexOf(charFrom);
        if(posFrom != -1) //if found char
        {
            int posTo = input.IndexOf(charTo, posFrom + 1);
            if(posTo != -1) //if found char
            {
                return input.Substring(posFrom + charFrom.Length, posTo - posFrom - charFrom.Length);
            }
        }

        return string.Empty;
    }

    public string GetNewPoint(char direction) {
        if(direction == 'l' || direction =='L') {
            return Left;
        }
        else if(direction == 'r' || direction == 'R') {
            return Right;
        }
        else
        {
            throw new Exception("wrong input");
        }
    }
}

