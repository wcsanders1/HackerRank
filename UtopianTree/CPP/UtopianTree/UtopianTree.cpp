#include "pch.h"
#include <iostream>

using namespace std;

int utopianTree(int n) 
{
	int height = 1;
	bool doubleInHeight = true;
	for (int i = 0; i < n; i++)
	{
		if (doubleInHeight)
		{
			height *= 2;
			doubleInHeight = false;
			continue;
		}
		height++;
		doubleInHeight = true;
	}

	return height;
}

int main()
{
	int t;
	cin >> t;
	cin.ignore(numeric_limits<streamsize>::max(), '\n');

	for (int t_itr = 0; t_itr < t; t_itr++) {
		int n;
		cin >> n;
		cin.ignore(numeric_limits<streamsize>::max(), '\n');

		int result = utopianTree(n);

		cout << result;
	}

	return 0;
}
