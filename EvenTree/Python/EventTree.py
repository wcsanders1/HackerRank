#!/bin/python3

import math
import os
import random
import re
import sys


class Node:
    value = 0
    total_children = 0
    children = []

    def __init__(self, value):
        self.value = value


def get_or_create_node(value, nodes_map):
    if value not in nodes_map:
        new_node = Node(value)
        nodes_map[value] = new_node
    return nodes_map[value]


def even_forest(t_nodes, t_edges, t_from, t_to):
    root = Node(1)
    nodes_map = {1: root}

    for i in range(t_from):
        child = get_or_create_node(t_from[i], nodes_map)
        parent = get_or_create_node(t_to[i], nodes_map)

        parent.children.append(child)

    return 0


if __name__ == '__main__':
    t_nodes, t_edges = map(int, input().rstrip().split())

    t_from = [0] * t_edges
    t_to = [0] * t_edges

    for i in range(t_edges):
        t_from[i], t_to[i] = map(int, input().rstrip().split())

    res = even_forest(t_nodes, t_edges, t_from, t_to)

    print(str(res) + '\n')
