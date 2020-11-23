#include <iostream>
#include <string>
#include <vector>
#include <map>
#include <math.h>

using namespace std;

#define mod 1000000007;

unsigned long long power(unsigned long long num, int p)
{
    if (p == 0)
    {
        return 1;
    }

    if (p == 1)
    {
        return num;
    }

    unsigned long long number = num;
    for (int i = 2; i <= p; i++)
    {
        num *= number;
        num %= mod;
    }

    return num;
}

int legoBlocks(int height, int width)
{
    vector<long long> rowCombinations;
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

    vector<long long> powers;
    for (int i = 0; i <= width; i++)
    {
        powers.push_back((long long)power(rowCombinations[i], height));
    }

    vector<long long> result(width + 1);
    result[0] = 0;
    result[1] = 1;

    for (int i = 2; i <= width; i++)
    {
        long long sum = 0;
        for (int j = 1; j < i; j++)
        {
            sum += (result[j] * powers[i - j]) % mod;
            sum %= mod;
        }
        result[i] = (powers[i] - sum);
        result[i] = result[i] % mod;
    }

    while (result[width] < 0)
    {
        result[width] += mod;
    }

    return result[width];
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
