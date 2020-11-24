#include <iostream>
#include <string>

using namespace std;

#define mod 1000000007;

long countArray(int n, int k, int x)
{
    long total = 2;
    int mult = k - 1;

    long isLast;
    long notLast;
    if (x == 1)
    {
        isLast = 0;
        notLast = mult;
    }
    else
    {
        isLast = 1;
        notLast = mult - 1;
    }

    for (int i = 3; i < n; i++)
    {
        total *= mult;
        total %= mod;
    }

    return 0;
}

int main()
{
    string input;
    getline(cin >> ws, input);

    string partOne = input.substr(0, input.find(" "));
    string partTwo = input.substr(input.find(" ") + 1, input.size() - 1);

    int n = stoi(partOne);
    int k = stoi(partTwo.substr(0, partTwo.find(" ")));
    int x = stoi(partTwo.substr(partTwo.find(" ") + 1, partTwo.size() - 1));

    countArray(n, k, x);
}