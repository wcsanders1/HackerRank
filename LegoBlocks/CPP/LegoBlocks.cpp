#include <iostream>
#include <string>
#include <vector>
#include <map>

using namespace std;

#define mod 1000000007;

vector<string> split_string(string);

/*
 * Complete the legoBlocks function below.
 */
int legoBlocks(int n, int m)
{
    /*
     * Write your code here.
     */
}

int main()
{
    int t;
    cin >> t;
    cin.ignore(numeric_limits<streamsize>::max(), '\n');

    for (int t_itr = 0; t_itr < t; t_itr++)
    {
        string nm_temp;
        getline(cin, nm_temp);

        string nm;
        getline(cin >> ws, nm);
        int n = stoi(nm.substr(0, nm.find(" ")));
        int m = stoi(nm.substr(nm.find(" ") + 1, nm.size() - 1));

        int result = legoBlocks(n, m);

        cout << result << "\n";
    }

    return 0;
}
