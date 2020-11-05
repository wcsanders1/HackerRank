#!/bin/python3

import math
import os
import random
import re
import sys
from enum import Enum

MOD = 1000000007


class Safety(Enum):
    safe = 1,
    unsafe = 2


def get_divisions(roads_map, visited, divisions, index=0):
    visited[index] = True
    sf = 1
    usf = 1

    for i in roads_map[index]:
        if visited[i]:
            continue
        get_divisions(roads_map, visited, divisions, i)

        usf = usf * divisions[i][Safety.safe]
        usf = usf % MOD

        sf = sf * (divisions[i][Safety.safe] * 2) + divisions[i][Safety.unsafe]
        sf = sf % MOD

    sf = sf - usf
    sf = sf + MOD
    sf = sf % MOD
    divisions[index][Safety.safe] = sf
    divisions[index][Safety.unsafe] = usf


def kingdom_division(n, roads):
    roads_map = [[]] * n
    for road in roads:
        road[0] -= 1
        road[1] -= 1
        roads_map[road[0]].append(road[1])
        roads_map[road[1]].append(road[0])

    divisions = [[] * 2] * n

    return 0


if __name__ == '__main__':
    n = int(input())

    roads = []

    for _ in range(n-1):
        roads.append(list(map(int, input().rstrip().split())))

    result = kingdom_division(n, roads)

    print(str(result) + '\n')
