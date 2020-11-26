#include <iostream>
#include <string>

using namespace std;

#define mod 1000000007;

long long countArray(int n, int k, int x)
{
    long long total = 2;
    int mult = k - 1;

    long long isLast;
    long long notLast;
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
        long long m = total % mod;
        total = (m * mult) % mod;
        total %= mod;

        isLast = notLast % mod;
        notLast = (total - isLast) % mod;
    }

    return total - isLast;
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

    cout << countArray(n, k, x);

    return 0;
}