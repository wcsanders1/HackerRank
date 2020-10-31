#include <iostream>
#include <string>
#include <vector>
#include <map>

using namespace std;

class Kingdom
{
public:
    Kingdom(int label)
    {
        Label = label;
        Value = 0;
        Visited = false;
    }
    int Label;
    int Value;
    bool Visited;
    vector<Kingdom *> Neighbors;
};

Kingdom *getOrCreateNode(int value, map<int, Kingdom *> &nodesMap)
{
    map<int, Kingdom *>::iterator it;
    it = nodesMap.find(value);

    if (it == nodesMap.end())
    {
        Kingdom *newNode = new Kingdom(value);
        nodesMap[value] = newNode;

        return newNode;
    }

    return it->second;
}

void getDivisions(Kingdom *node)
{
    if (!node || node->Visited)
    {
        return;
    }

    node->Visited = true;

    if (node->Neighbors.empty())
    {
        node->Value = 0;

        return;
    }

    bool hasChildren = false;
    for (Kingdom *subnode : node->Neighbors)
    {
        if (subnode->Visited)
        {
            continue;
        }

        hasChildren = true;
        getDivisions(subnode);

        if (subnode->Value)
        {
            if (!node->Value)
            {
                node->Value = subnode->Value;
            }
            else
            {
                int newValue = (node->Value * subnode->Value) % 100000007;
                node->Value = newValue;
            }
        }
    }

    if (hasChildren)
    {
        node->Value += 2;
    }
}

// Complete the kingdomDivision function below.
int kingdomDivision(int n, vector<vector<int>> roads)
{
    map<int, Kingdom *> nodesMap;
    vector<vector<int>>::iterator roadsIterator;
    for (roadsIterator = roads.begin(); roadsIterator != roads.end(); roadsIterator++)
    {
        vector<int> road = *roadsIterator;
        Kingdom *kingdomOne = getOrCreateNode(road[0], nodesMap);
        Kingdom *kingdomTwo = getOrCreateNode(road[1], nodesMap);

        kingdomOne->Neighbors.push_back(kingdomTwo);
        kingdomTwo->Neighbors.push_back(kingdomOne);
    }

    getDivisions(nodesMap[1]);

    return nodesMap[1]->Value;
}

int main()
{
    int n;
    cin >> n;

    vector<vector<int>> roads(n - 1);
    for (int i = 0; i < n - 1; i++)
    {
        roads[i].resize(2);

        for (int j = 0; j < 2; j++)
        {
            cin >> roads[i][j];
        }
    }

    int result = kingdomDivision(n, roads);

    cout << result << "\n";

    return 0;
}
