#!/bin/python3

MOD = 1000000007

if __name__ == '__main__':
    n = input()
    result = 0
    frequency = 1

    for i in range(len(n), 0, -1):
        result = (result + (int(n[i - 1])) * frequency * i) % MOD
        frequency = (frequency * 10 + 1) % MOD

    print(str(result))
