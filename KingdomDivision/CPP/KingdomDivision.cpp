#include <iostream>
#include <string>
#include <vector>
#include <map>

using namespace std;

class Node
{
public:
    Node(int label)
    {
        Label = label;
        Value = 0;
    }
    int Label;
    int Value;
    vector<Node *> Children;
};

Node *getOrCreateNode(int value, map<int, Node *> &nodesMap)
{
    map<int, Node *>::iterator it;
    it = nodesMap.find(value);

    if (it == nodesMap.end())
    {
        Node *newNode = new Node(value);
        nodesMap[value] = newNode;

        return newNode;
    }

    return it->second;
}

void getDivisions(Node *node)
{
    if (!node)
    {
        return;
    }

    if (node->Children.empty())
    {
        node->Value = 0;

        return;
    }

    for (Node *subnode : node->Children)
    {
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

    node->Value += 2;
}

// Complete the kingdomDivision function below.
int kingdomDivision(int n, vector<vector<int>> roads)
{
    map<int, Node *> nodesMap;
    vector<vector<int>>::iterator roadsIterator;
    for (roadsIterator = roads.begin(); roadsIterator != roads.end(); roadsIterator++)
    {
        vector<int> road = *roadsIterator;
        Node *parent = getOrCreateNode(road[0], nodesMap);
        Node *child = getOrCreateNode(road[1], nodesMap);

        parent->Children.push_back(child);
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
