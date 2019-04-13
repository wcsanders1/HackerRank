#pragma once

#include "pch.h"
#include <iostream>
#include <list>
#include <string>

using namespace std;

std::list<int> numberToDigits(int number)
{
	std::list<int> digitList;
	auto numberString = std::to_string(number);
	for (auto &digitChar : numberString)
	{
		auto digitString = std::string(1, digitChar);
		digitList.push_front(std::stoi(digitString));
	}

	return digitList;
}

void extraLongFactorials(int n) 
{
	auto solutionTracker = numberToDigits(n);

	while (--n > 1)
	{
		std::list<int> tempList;
		auto carry = 0;
		for (auto &num : solutionTracker)
		{
			auto tempSum = (num * n) + carry;
			auto newNums = numberToDigits(tempSum);
			if (newNums.size() == 1)
			{
				tempList.push_back(*newNums.begin());
				carry = 0;
				continue;
			}
			
			auto tempSumAsString = std::to_string(tempSum);
			tempList.push_back(std::stoi(std::string(1, tempSumAsString.back())));
			carry = std::stoi(tempSumAsString.substr(0, tempSumAsString.length() - 1));
		}

		if (carry > 0)
		{
			auto newCarry = numberToDigits(carry);
			tempList.insert(tempList.end(), newCarry.begin(), newCarry.end());
		}

		solutionTracker = tempList;
	}

	solutionTracker.reverse();

	std::list<int>::iterator it;
	for (it = solutionTracker.begin(); it != solutionTracker.end(); it++)
	{
		cout << *it;
	}
}

int main()
{
	int t;
	cin >> t;
	cin.ignore(numeric_limits<streamsize>::max(), '\n');
	
	extraLongFactorials(t);
	
	return 0;
}