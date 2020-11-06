#!/bin/python3

MOD = 1000000007
SAFE = 0
UNSAFE = 1


def get_divisions(roads_map, visited, divisions, index=0):
    visited[index] = True
    sf = 1
    usf = 1

    for i in roads_map[index]:
        if visited[i]:
            continue

        get_divisions(roads_map, visited, divisions, i)

        usf = usf * divisions[i][SAFE]
        usf = usf % MOD

        sf = sf * ((divisions[i][SAFE] * 2) + divisions[i][UNSAFE])
        sf = sf % MOD

    sf = sf - usf
    sf = sf + MOD
    sf = sf % MOD
    divisions[index][SAFE] = sf
    divisions[index][UNSAFE] = usf


def kingdom_division(n, roads):
    roads_map = [None] * n
    divisions = [None] * n

    for i in range(n):
        roads_map[i] = []
        divisions[i] = [0] * 2

    for road in roads:
        road[0] -= 1
        road[1] -= 1
        roads_map[road[0]].append(road[1])
        roads_map[road[1]].append(road[0])

    visited = [False] * n

    get_divisions(roads_map, visited, divisions)

    return (2 * divisions[0][SAFE]) % MOD


if __name__ == '__main__':
    n = int(input())

    roads = []

    for _ in range(n-1):
        roads.append(list(map(int, input().rstrip().split())))

    result = kingdom_division(n, roads)

    print(str(result) + '\n')
