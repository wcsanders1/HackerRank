#include <iostream>
#include <string>
#include <vector>

using namespace std;

#define mod 1000000007;

int substrings(string n)
{
    long long result = 0;
    long long frequency = 1;

    for (int i = n.size() - 1; i >= 0; i--)
    {
        result = (result + (n[i] - '0') * frequency * (i + 1)) % mod;
        frequency = (frequency * 10 + 1) % mod;
    }

    return result;
}

int main()
{
    string n;
    cin >> n;

    int result = substrings(n);

    cout << result << "\n";

    return 0;
}