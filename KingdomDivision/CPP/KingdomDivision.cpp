#include <iostream>
#include <string>
#include <vector>
#include <map>

using namespace std;

// Complete the kingdomDivision function below.
int kingdomDivision(int n, vector<vector<int>> roads)
{
    return 0;
}

int main()
{
    int n;
    cin >> n;
    cin.ignore(numeric_limits<streamsize>::max(), '\n');

    vector<vector<int>> roads(n - 1);
    for (int i = 0; i < n - 1; i++)
    {
        roads[i].resize(2);

        for (int j = 0; j < 2; j++)
        {
            cin >> roads[i][j];
        }

        cin.ignore(numeric_limits<streamsize>::max(), '\n');
    }

    int result = kingdomDivision(n, roads);

    cout << result << "\n";

    return 0;
}
