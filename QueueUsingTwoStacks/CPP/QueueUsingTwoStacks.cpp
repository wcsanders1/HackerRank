#include <iostream>
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

    Node *Current;

public:
    int Count;

    Stack()
    {
        Count = 0;
        Current = nullptr;
    }

    void Push(int value)
    {
        if (Count == 0)
        {
            Current = new Node(value);
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

        if (!Count)
        {
            delete Current;
        }
        else
        {
            Current = Current->Previous;
            delete Current->Next;
        }

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

    Stack pushStack;
    Stack popStack;

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
            pushStack.Push(num);
        }
        break;
        case 2:
            if (!popStack.Count)
            {
                while (pushStack.Count)
                {
                    popStack.Push(pushStack.Pop());
                }
            }
            popStack.Pop();
            break;
        case 3:
            if (!popStack.Count)
            {
                while (pushStack.Count)
                {
                    popStack.Push(pushStack.Pop());
                }
            }
            cout << popStack.Peek() << "\n";
            break;
        }
    }

    return 0;
}
