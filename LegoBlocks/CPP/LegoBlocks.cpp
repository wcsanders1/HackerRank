#include <iostream>
#include <string>
#include <vector>
#include <map>

using namespace std;

#define mod 1000000007;

int legoBlocks(int height, int width)
{
    int rowCombinations = 1;
    for (int i = 1; i <= width; i++)
    {
        rowCombinations = (rowCombinations * 2) - 1;
        if (i > 1 && i < 5)
        {
            rowCombinations++;
        }
    }

    return 0;
}

int main()
{
    int t;
    cin >> t;
    cin.ignore(numeric_limits<streamsize>::max(), '\n');

    for (int t_itr = 0; t_itr < t; t_itr++)
    {
        string nm;
        getline(cin >> ws, nm);
        int n = stoi(nm.substr(0, nm.find(" ")));
        int m = stoi(nm.substr(nm.find(" ") + 1, nm.size() - 1));

        int result = legoBlocks(n, m);

        cout << result << "\n";
    }

    return 0;
}
