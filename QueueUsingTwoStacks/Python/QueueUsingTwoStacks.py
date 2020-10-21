#!/bin/python3


class Stack:
    class __Node:
        value = None
        next = None
        previous = None

        def __init__(self, value):
            self.value = value

    __current = None
    count = None

    def __init__(self):
        self.count = 0

    def push(self, value):
        if self.count == 0:
            self.__current = self.__Node(value)
        else:
            temp = self.__current
            self.__current = self.__Node(value)
            self.__current.previous = temp
            temp.next = self.__current

        self.count += 1

    def pop(self):
        if self.count == 0:
            return -1

        self.count -= 1
        value = self.__current.value

        if self.count == 0:
            self.__current = None
        else:
            self.__current = self.__current.previous
            self.__current.next = None

        return value

    def peek(self):
        if self.count == 0:
            return -1

        return self.__current.value


if __name__ == '__main__':
    cases = int(input())

    pushStack = Stack()
    popStack = Stack()

    for case in range(cases):
        c = input()
        split = c.split(' ')
        f = int(split[0])

        if f == 1:
            pushStack.push(int(split[1]))
        elif f == 2:
            if popStack.count == 0:
                while pushStack.count > 0:
                    popStack.push(pushStack.pop())
            popStack.pop()
        elif f == 3:
            if popStack.count == 0:
                while pushStack.count > 0:
                    popStack.push(pushStack.pop())
            print(popStack.peek())
