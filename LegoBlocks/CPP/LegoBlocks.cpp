#include <iostream>
#include <string>
#include <vector>
#include <map>
#include <math.h>

using namespace std;

#define mod 1000000007;

int legoBlocks(int height, int width)
{
    vector<int> rowCombinations;
    rowCombinations.push_back(0);
    rowCombinations.push_back(1);
    if (width > 1)
    {
        rowCombinations.push_back(2);
    }
    if (width > 2)
    {
        rowCombinations.push_back(4);
    }
    if (width > 3)
    {
        rowCombinations.push_back(8);
    }

    if (width > 4)
    {
        for (int i = 5; i <= width; i++)
        {
            int c = (rowCombinations[i - 1] + rowCombinations[i - 2] + rowCombinations[i - 3] + rowCombinations[i - 4]) % mod;
            rowCombinations.push_back(c);
        }
    }

    vector<int> heightCombinations;
    for (int i = 0; i < (int)rowCombinations.size(); i++)
    {
        int h = (int)(pow(rowCombinations[i], height)) % mod;
        heightCombinations.push_back(h);
    }

    vector<int> result(width + 1);
    result[0] = 0;
    result[1] = 1;

    for (int i = 2; i <= width; i++)
    {
        result[i] = heightCombinations[i];
        for (int j = 1; j < i; j++)
        {
            result[i] = (result[i] - result[j] * heightCombinations[i - j]) % mod;
        }
    }

    return (result[result.size() - 1]) % mod;
}

int main()
{
    int t;
    cin >> t;

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
