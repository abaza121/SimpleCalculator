# SimpleCalculator
Simple calculator instruction machine made as a console app using C#


[Task Discription]
A simple calculator
 
Write a program that can convert simple mathematical equations (using numbers, +, -, * and / only) into a set of instructions that can be executed by a simple stack machine, which then prints the result. The input should be provided as a string.
 
The instructions to be supported by the machine:
 
PUSH X   : Push the number X onto the stack
ADD         : Pop 2 values off the stack. Add them, and push the result on the stack
MUL         : Pop 2 values off the stack. Multiply them, and push the result on the stack
SUB         : Pop 2 values off the stack. Subtract the second value from the first, and push the result on the stack
DIV           : Pop 2 values off the stack. Divide the first value by the second, and push the result on the stack
PRINT      : Print the top value on the stack once there is only one value left, i.e the result
 
For instance:
 
a)
 
"1 + 2 - 3" would convert into the following, internal instructions:
 
PUSH 1
PUSH 2
ADD
PUSH 3
SUB
PRINT
 
b)
 
"1 / 2"
 
PUSH 1
PUSH 2
DIV
PRINT
 
The goal of this exercise is structure and testability. Provide some simple test cases to verify that the implementation works. Test that bad input is handled correctly without crashing the application or incorrectly running the algorithm. This can be exemplified by
 
a) "1 -+ 3"
b) "* 9"

