#include <iostream>
#include <string>
#include <vector>

using namespace std;

#define mod 1000000007;

long getResult(vector<int> &nums)
{
    return 0;
}

int main()
{
    int q;
    cin >> q;

    for (int i = 0; i < q; i++)
    {
        int c;
        cin >> c;

        vector<int> nums;
        for (int j = 0; j < c; j++)
        {
            int num;
            cin >> num;
            nums.push_back(num);
        }

        cout << getResult(nums);
    }
}