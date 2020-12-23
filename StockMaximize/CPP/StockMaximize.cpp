#include <iostream>
#include <string>
#include <vector>

using namespace std;

long getProfit(vector<int> *shares)
{
    vector<int> &sharesRef = *shares;
    int shareNum = sharesRef.size();
    long result = 0;

    for (int i = 0; i < shareNum; i++)
    {
        long temp = 0;
        int share = sharesRef[i];

        for (int j = i + 1; j < shareNum; j++)
        {
            int price = sharesRef[j];
            int profit = price - share;
            if (profit > temp)
            {
                temp = profit;
            }
        }

        result += temp;
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