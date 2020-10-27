#!/bin/python3


class Node:
    value = 0
    total_children = 0
    children = []

    def __init__(self, value):
        self.value = value
        self.children = []
        self.total_children = 0


def get_or_create_node(value, nodes_map):
    if value not in nodes_map:
        new_node = Node(value)
        nodes_map[value] = new_node
    return nodes_map[value]


def get_even_subtrees(node):
    if node is None:
        return 0

    if not node.children:
        node.total_children = 0
        return 0

    even_subtrees = 0
    total_children = 0

    for subnode in node.children:
        even_subtrees += get_even_subtrees(subnode)

    for subnode in node.children:
        children = subnode.total_children + 1
        if children > 1 and children % 2 == 0:
            subnode.total_children = 0
            even_subtrees += 1
        else:
            total_children += children

    node.total_children += total_children

    return even_subtrees


def even_forest(t_nodes, t_edges, t_from, t_to):
    root = Node(1)
    nodes_map = {1: root}

    for i in range(len(t_from)):
        child = get_or_create_node(t_from[i], nodes_map)
        parent = get_or_create_node(t_to[i], nodes_map)

        parent.children.append(child)

    return get_even_subtrees(root)


if __name__ == '__main__':
    t_nodes, t_edges = map(int, input().rstrip().split())

    t_from = [0] * t_edges
    t_to = [0] * t_edges

    for i in range(t_edges):
        t_from[i], t_to[i] = map(int, input().rstrip().split())

    res = even_forest(t_nodes, t_edges, t_from, t_to)

    print(str(res) + '\n')
