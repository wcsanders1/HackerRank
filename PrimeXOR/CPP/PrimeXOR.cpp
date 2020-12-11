#include <iostream>
#include <string>
#include <vector>

using namespace std;

const int mod = 1000000007;
const int primeSize = 100000;

bool primes[primeSize];

void setPrimes()
{
    for (int i = 0; i < primeSize; i++)
    {
        primes[i] = true;
    }

    int prime = 2;

    while (prime < primeSize)
    {
        int start = pow(prime, 2);

        if (start >= primeSize)
        {
            return;
        }

        while (start < primeSize)
        {
            primes[start] = false;
            start += prime;
        }

        for (int i = prime + 1; i < mod; i++)
        {
            if (primes[i])
            {
                prime = i;
                break;
            }
        }
    }
}

long getResult(vector<int> &nums)
{
    int result = 0;

    for (int i : nums)
    {
        result ^= i;
    }

    return 0;
}

int main()
{
    setPrimes();

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