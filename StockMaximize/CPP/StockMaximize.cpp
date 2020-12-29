#include <iostream>
#include <string>
#include <vector>

using namespace std;

long long getProfit(vector<int> *shares)
{
    vector<int> &sharesRef = *shares;
    int shareNum = sharesRef.size();

    if (shareNum < 2)
    {
        return 0;
    }

    long long result = 0;

    int greatest = sharesRef[shareNum - 1];
    for (int i = shareNum - 2; i >= 0; i--)
    {
        int price = sharesRef[i];
        if (price > greatest)
        {
            greatest = price;
        }
        else
        {
            result += (greatest - price);
        }
    }

    return result;
}

int main()
{
    int t;
    cin >> t;

    for (int i = 0; i < t; i++)
    {
        int n;
        cin >> n;

        vector<int> *shares = new vector<int>();
        for (int j = 0; j < n; j++)
        {
            int share;
            cin >> share;
            shares->push_back(share);
        }

        cout << getProfit(shares) << "\n";

        delete shares;
    }
}