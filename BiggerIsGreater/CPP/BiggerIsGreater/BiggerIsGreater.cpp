#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

const string NoAnswer = "no answer";

// NOTE: This problem can easily be solved using next_permutation instead of the code below...

string biggerIsGreater(string problem)
{
    auto problemLength = problem.length();

    if (problemLength <= 1)
    {
        return NoAnswer;
    }

    vector<char> charVector(problem.begin(), problem.end());

    for (int index = problemLength - 1; index >= 0; index--)
    {
        if (index == 0)
        {
            return NoAnswer;
        }

        if (charVector[index - 1] >= charVector[index])
        {
            continue;
        }

        auto replacementIndex = index - 1;
        auto replacedChar = charVector[replacementIndex];

        vector<char> replacementVector(charVector.begin() + (replacementIndex + 1), charVector.end());
        sort(replacementVector.begin(), replacementVector.end());

        char replacementChar = 0;
        for (int replacementIndex = 0; replacementIndex < replacementVector.size(); replacementIndex++)
        {
            if (replacementVector[replacementIndex] > replacedChar)
            {
                replacementChar = replacementVector[replacementIndex];
                break;
            }
        }

        charVector[replacementIndex] = replacementChar;

        int deleteIndex = 0;
        vector<char>::iterator it;
        for (it = replacementVector.begin(); it != replacementVector.end(); it++, deleteIndex++)
        {
            if (replacementVector[deleteIndex] == replacementChar)
            {
                break;
            }
        }
 
        replacementVector.erase(replacementVector.begin() + deleteIndex);
        replacementVector.push_back(replacedChar);
        sort(replacementVector.begin(), replacementVector.end());

        vector<char> vectorAnswer(charVector.begin(), charVector.begin() + replacementIndex + 1);
        vectorAnswer.insert(vectorAnswer.end(), replacementVector.begin(), replacementVector.end());

        return string(vectorAnswer.begin(), vectorAnswer.end());
    }

    return NoAnswer;
}

int main()
{
    int cases;
    cin >> cases;

    for (int _case = 0; _case < cases; _case++)
    {
        string problem;
        cin >> problem;
        auto result = biggerIsGreater(problem);
        cout << result << "\n";
    }
}
