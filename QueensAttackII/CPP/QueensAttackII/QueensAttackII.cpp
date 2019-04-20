#include "pch.h"
#include <iostream>
#include <vector>
#include <string>
#include <list>
#include <algorithm>

using namespace std;

vector<string> split_string(string);

enum ObstaclePosition
{
	Irrelevant,
	Above,
	AboveRight,
	Right,
	BelowRight,
	Below,
	BelowLeft,
	Left,
	AboveLeft
};

class Queen
{
public:
	int x;
	int y;
	Queen(int x, int y)
		:
		x(x),
		y(y)
	{}
};

class Obstacle
{
public:
	int x;
	int y;
	Obstacle(int x, int y)
		:
		x(x),
		y(y)
	{}
};

class AttackPointsCalculator
{
private:
	Queen &queen;

	int topDist;
	int rightDist;
	int bottomDist;
	int leftDist;
	int topRightDist;
	int bottomRightDist;
	int bottomLeftDist;
	int topLeftDist;
	ObstaclePosition GetObstaclePosition(Obstacle &obstacle)
	{
		if (obstacle.x == queen.x && obstacle.y > queen.y)
		{
			return Above;
		}

		if (obstacle.y - obstacle.x == queen.y - queen.x && obstacle.y > queen.y)
		{
			return AboveRight;
		}

		if (obstacle.y == queen.y && obstacle.x > queen.x)
		{
			return Right;
		}

		if (obstacle.x > queen.x && obstacle.x - queen.x == queen.y - obstacle.y)
		{
			return BelowRight;
		}

		if (obstacle.x == queen.x && obstacle.y < queen.y)
		{
			return Below;
		}

		if (obstacle.y - obstacle.x == queen.y - queen.x && obstacle.y < queen.y)
		{
			return BelowLeft;
		}

		if (obstacle.y == queen.y && obstacle.x < queen.x)
		{
			return Left;
		}

		if (obstacle.x < queen.x && queen.x - obstacle.x == obstacle.y - queen.y)
		{
			return AboveLeft;
		}

		return Irrelevant;
	};
	void Calculate(ObstaclePosition obstaclePosition, Obstacle &obstacle)
	{
		int distanceFromObstacle = 0;
		switch (obstaclePosition)
		{
		case Above:
			distanceFromObstacle = obstacle.y - queen.y - 1;
			if (distanceFromObstacle < topDist)
			{
				topDist = distanceFromObstacle;
			}
			break;
		case Below:
			distanceFromObstacle = queen.y - obstacle.y - 1;
			if (distanceFromObstacle < bottomDist)
			{
				bottomDist = distanceFromObstacle;
			}
			break;
		case Right:
			distanceFromObstacle = obstacle.x - queen.x - 1;
			if (distanceFromObstacle < rightDist)
			{
				rightDist = distanceFromObstacle;
			}
			break;
		case Left:
			distanceFromObstacle = queen.x - obstacle.x - 1;
			if (distanceFromObstacle < leftDist)
			{
				leftDist = distanceFromObstacle;
			}
			break;
		case AboveRight:
			distanceFromObstacle = obstacle.y - queen.y - 1;
			if (distanceFromObstacle < topRightDist)
			{
				topRightDist = distanceFromObstacle;
			}
			break;
		case BelowLeft:
			distanceFromObstacle = queen.y - obstacle.y - 1;
			if (distanceFromObstacle < bottomLeftDist)
			{
				bottomLeftDist = distanceFromObstacle;
			}
			break;
		case BelowRight:
			distanceFromObstacle = obstacle.x - queen.x - 1;
			if (distanceFromObstacle < bottomRightDist)
			{
				bottomRightDist = distanceFromObstacle;
			}
			break;
		case AboveLeft:
			distanceFromObstacle = queen.x - obstacle.x - 1;
			if (distanceFromObstacle < topLeftDist)
			{
				topLeftDist = distanceFromObstacle;
			}
			break;
		default:
			break;
		}
	};

public:
	AttackPointsCalculator(Queen &queen, int boardSize)
		:
		queen(queen),
		topDist(boardSize - queen.y),
		rightDist(boardSize - queen.x),
		bottomDist(queen.y - 1),
		leftDist(queen.x - 1),
		topRightDist(min(topDist, rightDist)),
		bottomRightDist(min(bottomDist, rightDist)),
		bottomLeftDist(min(bottomDist, leftDist)),
		topLeftDist(min(topDist, leftDist))
	{};
	int GetTotalAttackPoints()
	{
		return
			topDist +
			rightDist +
			bottomDist +
			leftDist +
			topRightDist +
			bottomRightDist +
			bottomLeftDist +
			topLeftDist;
	};
	void UpdateAttackPoints(Obstacle &obstacle)
	{
		auto obstaclePosition = GetObstaclePosition(obstacle);
		Calculate(obstaclePosition, obstacle);
	};
};

int queensAttack(int n, int r_q, int c_q, vector<vector<int>> obstacles) 
{
	auto queen = Queen(c_q, r_q);
	auto calculator = AttackPointsCalculator(queen, n);

	for (auto o : obstacles)
	{
		auto obstacle = Obstacle(o[1], o[0]);
		calculator.UpdateAttackPoints(obstacle);
	}

	return calculator.GetTotalAttackPoints();
}

int main()
{
	string nk_temp;
	getline(cin, nk_temp);

	vector<string> nk = split_string(nk_temp);

	int n = stoi(nk[0]);

	int k = stoi(nk[1]);

	string r_qC_q_temp;
	getline(cin, r_qC_q_temp);

	vector<string> r_qC_q = split_string(r_qC_q_temp);

	int r_q = stoi(r_qC_q[0]);

	int c_q = stoi(r_qC_q[1]);

	vector<vector<int>> obstacles(k);
	for (int i = 0; i < k; i++) {
		obstacles[i].resize(2);

		for (int j = 0; j < 2; j++) {
			cin >> obstacles[i][j];
		}

		cin.ignore(numeric_limits<streamsize>::max(), '\n');
	}

	int result = queensAttack(n, r_q, c_q, obstacles);

	cout << result;

	return 0;
}

vector<string> split_string(string input_string) {
	string::iterator new_end = unique(input_string.begin(), input_string.end(), [](const char &x, const char &y) {
		return x == y and x == ' ';
		});

	input_string.erase(new_end, input_string.end());

	while (input_string[input_string.length() - 1] == ' ') {
		input_string.pop_back();
	}

	vector<string> splits;
	char delimiter = ' ';

	size_t i = 0;
	size_t pos = input_string.find(delimiter);

	while (pos != string::npos) {
		splits.push_back(input_string.substr(i, pos - i));

		i = pos + 1;
		pos = input_string.find(delimiter, i);
	}

	splits.push_back(input_string.substr(i, min(pos, input_string.length()) - i + 1));

	return splits;
}
