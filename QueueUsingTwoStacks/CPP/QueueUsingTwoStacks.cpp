#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
#include <string>

using namespace std;

class Stack
{
private:
    class Node
    {
    public:
        int Value;
        Node *Next;
        Node *Previous;

        Node(){};
        Node(int value)
        {
            Value = value;
        }
    };

    Node Root;
    Node *Current;

public:
    int Count;
    void Push(int value)
    {
        if (Count == 0)
        {
            Root.Value = value;
            Current = &Root;
        }
        else
        {
            Node *Temp = Current;
            Current = new Node(value);
            Current->Previous = Temp;
            Temp->Next = Current;
        }

        Count++;
    }

    int Pop()
    {
        if (Count == 0)
        {
            return -1;
        }

        Count--;
        int value = Current->Value;
        Current = Current->Previous;
        delete Current->Next;

        return value;
    }

    int Peek()
    {
        if (Count == 0)
        {
            return -1;
        }

        return Current->Value;
    }
};

int main()
{
    int cases;
    cin >> cases;

    Stack stackOne;

    for (int i = 0; i < cases; i++)
    {
        string c;
        getline(cin >> ws, c);

        int f = stoi(c.substr(0, c.find(" ")));

        switch (f)
        {
        case 1:
        {
            int num = stoi(c.substr(c.find(" ") + 1, c.size() - 1));
            stackOne.Push(num);
        }
        break;
        case 2:
            cout << stackOne.Pop();
            break;
        case 3:
            cout << stackOne.Peek();
            break;
        }
    }

    return 0;
}
