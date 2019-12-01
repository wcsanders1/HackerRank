#include <string>
#include <iostream>
#include <fstream>
#include <stdlib.h>
#include <stdio.h>
#include <algorithm>
#include <sstream>

using namespace std;

string encryption(string s) {
	auto _isSpace = [](unsigned char const c) {return isspace(c); };
	s.erase(remove_if(s.begin(), s.end(), _isSpace), s.end());
	auto spacelessStringLength = s.length();
	auto squareRoot = sqrt(spacelessStringLength);

	auto rows = (int)floor(squareRoot);
	auto columns = (int)ceil(squareRoot);

	ostringstream result;
	for (int row = 0; row <= rows; row++)
	{
		for (int column = row; column < spacelessStringLength; column += columns)
		{
			auto resultLength = (int)result.tellp();
			if (column < spacelessStringLength && resultLength < spacelessStringLength + rows)
			{
				result << s[column];
			}
		}
		result << " ";
	}

	return result.str();
}

int main()
{
	string s;
	getline(cin, s);

	auto result = encryption(s);

	cout << result;
	return 0;
}