#include <iostream>
#include <string>
#include <vector>

using namespace std;

#define mod 1000000007;

string getResult(string &a, string &b)
{
    vector<vector<bool>> dp;
    int aSize = a.size();
    int bSize = b.size();

    for (int i = 0; i <= bSize; i++)
    {
        dp.push_back(vector<bool>(aSize));
    }

    dp[0][0] = true;

    for (int bi = 0; bi <= bSize; bi++)
    {
        for (int ai = 0; ai <= aSize; ai++)
        {
            if (bi == 0 && ai != 0)
            {
                dp[bi][ai] = islower(a[ai - 1]) && dp[bi][ai - 1];
            }
            else if (bi != 0 && ai != 0)
            {
                if (a[ai - 1] == b[bi - 1])
                {
                    dp[bi][ai] = dp[bi - 1][ai - 1];
                }
                else if (toupper(a[ai - 1]) == b[bi - 1])
                {
                    dp[bi][ai] = dp[bi - 1][ai - 1] || dp[bi][ai - 1];
                }
                else if (!isupper(a[ai - 1]))
                {
                    dp[bi][ai] = dp[bi][ai - 1];
                }
            }
        }
    }

    return dp[bSize][aSize] ? "YES" : "NO";
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

        cout << getResult(a, b) << "\n";
    }

    return 0;
}