#include <iostream>
#include <string>
#include <vector>
#include <map>

using namespace std;

#define mod 1000000007;

enum
{
    safe,
    unsafe
};

void getDivisions(vector<vector<long> *> *roadsMap, vector<bool> *visited, vector<vector<long> *> *divisions, int index = 0)
{
    (*visited)[index] = true;
    long sf = 1;
    long usf = 1;

    for (long i : *(*roadsMap)[index])
    {
        if ((*visited)[i])
        {
            continue;
        }

        getDivisions(roadsMap, visited, divisions, i);

        usf *= (*(*divisions)[i])[safe];
        usf %= mod;

        sf *= ((*(*divisions)[i])[safe] * 2) + (*(*divisions)[i])[unsafe];
        sf %= mod;
    }

    sf -= usf;
    sf += mod;
    sf %= mod;
    (*(*divisions)[index])[safe] = sf;
    (*(*divisions)[index])[unsafe] = usf;
}

int kingdomDivision(int n, vector<vector<int>> &roads)
{
    vector<vector<long> *> *roadsMap = new vector<vector<long> *>(n);

    vector<vector<long> *>::iterator it;
    int i = 0;
    for (it = roadsMap->begin(); it != roadsMap->end(); it++, i++)
    {
        (*roadsMap)[i] = new vector<long>();
    }

    for (vector<int> road : roads)
    {
        road[0]--;
        road[1]--;
        (*roadsMap)[road[0]]->push_back(road[1]);
        (*roadsMap)[road[1]]->push_back(road[0]);
    }

    vector<vector<long> *> *divisions = new vector<vector<long> *>(n, new vector<long>(2));

    getDivisions(roadsMap, new vector<bool>(n), divisions);

    return (2 * (*(*divisions)[0])[safe]) % mod;
}

int main()
{
    int n;
    cin >> n;

    vector<vector<int>> roads(n - 1);
    for (int i = 0; i < n - 1; i++)
    {
        roads[i] = vector<int>(2);

        for (int j = 0; j < 2; j++)
        {
            cin >> roads[i][j];
        }
    }

    int result = kingdomDivision(n, roads);

    cout << result << "\n";

    return 0;
}
