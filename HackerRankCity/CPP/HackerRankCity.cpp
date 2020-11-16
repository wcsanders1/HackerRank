#include <iostream>
#include <ios>

const int mod = 1000000007;

int add(int a, int b)
{
    return static_cast<int>((0L + a + b) % mod);
}

int mul(int a, int b)
{
    return static_cast<int>((1L * a * b) % mod);
}

int main()
{
    int steps = 0;
    std::cin >> steps;
    int weight = 0, cornerSum = 0, sum = 0, longestPath = 0, nodes = 1;

    for (int i = 0; i < steps; ++i)
    {
        int priorCornerSum = cornerSum;
        int priorSum = sum;
        int priorLongestPath = longestPath;
        int priorNodes = nodes;

        std::cin >> weight;
        nodes = add(2, mul(4, priorNodes));
        longestPath = add(3 * weight, mul(2, priorLongestPath));
        cornerSum = mul(priorNodes, add(8 * weight, mul(3, priorLongestPath)));
        int cornerTemp[] = {mul(4, priorCornerSum), 3 * weight, mul(2, priorLongestPath)};
        for (int term : cornerTemp)
            cornerSum = add(cornerSum, term);
        sum = mul(mul(12, priorNodes), add(weight, priorCornerSum));
        int sumTemp[] = {weight, mul(4, priorSum), mul(8, priorCornerSum), mul(16 * weight, mul(priorNodes, priorNodes))};
        for (int term : sumTemp)
            sum = add(sum, term);
    }

    std::cout << sum;
}
