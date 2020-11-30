#include <iostream>
#include <string>
#include <vector>

using namespace std;

#define mod 1000000007;

long long countArray(int n, int k, int x)
{
    vector<long> oneNotEnd(n + 1, 0);
    vector<long> oneEnd(n + 1, 0);

    oneNotEnd[2] = 1;
    oneEnd[2] = 0;

    for (int i = 3; i <= n; i++)
    {
        oneNotEnd[i] = oneEnd[i - 1] + (k - 2) * oneNotEnd[i - 1];
        oneEnd[i] = (k - 1) * oneNotEnd[i - 1];
        oneNotEnd[i] %= mod;
        oneEnd[i] %= mod;
    }

    return x == 1 ? oneEnd[n] : oneNotEnd[n];
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

// 761 99 1 -> 236568308