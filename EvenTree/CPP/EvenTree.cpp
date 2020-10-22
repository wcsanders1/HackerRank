#include <iostream>
#include <string>
#include <vector>

using namespace std;

// Complete the evenForest function below.
int evenForest(int nodes, int edges, vector<int> *from, vector<int> *to)
{
    return 0;
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

    int res = evenForest(nodes, edges, &from, &to);

    cout << res << "\n";

    return 0;
}
