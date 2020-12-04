#include <iostream>
#include <string>

using namespace std;

#define mod 1000000007;

string getResult(string &a, string &b)
{
    int bStart = 0;
    int bEnd = b.size() - 1;

    int aStart = 0;
    int aEnd = a.size() - 1;

    while (bStart <= bEnd && aStart <= aEnd)
    {
    }
}

int main()
{
    int q;
    cin >> q;

    for (int i = 0; i < q; i++)
    {
        string a;
        string b;

        cin >> a;
        cin >> b;

        cout << getResult(a, b);
    }

    return 0;
}