#include <iostream>
#include <string>
#include <vector>
#include <map>

using namespace std;

class Node
{
public:
    Node(int value)
    {
        Value = value;
        TotalChildren = 0;
    }
    int Value;
    vector<Node *> Children;
    int TotalChildren;
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

int getEvenSubtrees(Node *node)
{
    if (!node)
    {
        return 0;
    }

    if (node->Children.empty())
    {
        node->TotalChildren = 0;

        return 0;
    }

    int evenSubtrees = 0;
    int totalChildren = 0;

    for (Node *subnode : node->Children)
    {
        evenSubtrees += getEvenSubtrees(subnode);
    }

    for (Node *subnode : node->Children)
    {
        int children = subnode->TotalChildren + 1;
        if (children > 1 && children % 2 == 0)
        {
            subnode->TotalChildren = 0;
            evenSubtrees++;
        }
        else
        {
            totalChildren += children;
        }
    }

    node->TotalChildren += totalChildren;

    return evenSubtrees;
}

int evenForest(int nodes, int edges, vector<int> &from, vector<int> &to)
{
    map<int, Node *> nodesMap;

    Node *root = new Node(1);
    nodesMap[1] = root;

    int index = 0;
    vector<int>::iterator intIterator;
    for (intIterator = from.begin(); intIterator != from.end(); intIterator++, index++)
    {
        Node *child = getOrCreateNode(from[index], nodesMap);
        Node *parent = getOrCreateNode(to[index], nodesMap);

        parent->Children.push_back(child);
    }

    return getEvenSubtrees(root);
}

int main()
{
    string nodesEdges;
    getline(cin, nodesEdges);

    int space = nodesEdges.find(" ");
    int nodes = stoi(nodesEdges.substr(0, space));
    int edges = stoi(nodesEdges.substr(space + 1, nodesEdges.size() - 1));

    vector<int> from(edges);
    vector<int> to(edges);

    for (int i = 0; i < edges; i++)
    {
        string fromTo;
        getline(cin, fromTo);

        space = fromTo.find(" ");
        from[i] = stoi(fromTo.substr(0, space));
        to[i] = stoi(fromTo.substr(space + 1, fromTo.size() - 1));
    }

    int res = evenForest(nodes, edges, from, to);

    cout << res << "\n";

    return 0;
}
