import math

import examples as exp

rules = {
    'a': {
        'start': 0.8, 'end': 1.11, 'dec': 0.01
    },
    'd': {
        'start': 2, 'end': 5.13, 'dec': 0.01
    },
    'f': {
        'start': 12, 'end': 144, 'dec': 12
    },
    'accuracy': 4
}
def main():
    command = ""
    while (True):
        print("Введите func, чтобы посчитать значение функции со своими аргументами или examples, чтобы просмотреть контрольные примеры. Введите exit, чтобы выйти")
        command = input("Введите команду: ")
        if (command == "func"):
            calc()
        elif (command == "examples"):
            examples()
        elif (command == "exit"): break
        else:
            print("Команда не распознана!")
def calc():
    info()

    a = inputArgument("a")
    d = inputArgument("d")
    f = inputArgument("f")

    func(a, d, f)

def func(a, d, f):
    b = 340
    c = 1.07
    x = round(3**(1/3), rules['accuracy'])

    result = round((a * x + b) / (c * x**2 + d * x + f), rules['accuracy'])

    output(a, b, c, d, f, x, result)

def inputArgument(arg):
    inputArg = 0
    while (not checkArgument(arg, inputArg)):
        inputArg = (float)(input("Введите аргумент " + arg + ": "))
    return inputArg

def checkArgument(arg, value):
    if (value < rules[arg]['start'] or 
        value > rules[arg]['end'] or 
        not checkArgumentForDecrement(value, rules[arg]['dec'])): return False
    return True

def checkArgumentForDecrement(value, d):
    if (d < 1): result = round((value / d) % 1, rules['accuracy'])
    else: result = value % d
    return not result

def info():
    print("|\tАргумент\t|\tДиапазон аргумента\t|\tДискрет аргумента\t|")
    print("|\ta\t\t|\t[0.8; 1.17]\t\t|\t0.01\t\t\t|")
    print("|\tb\t\t|\t[равно 340]\t\t|\tконстанта 340\t\t|")
    print("|\tc\t\t|\t[равно 1.07]\t\t|\tконстанта 1.07\t\t|")
    print("|\td\t\t|\t[2; 5.13]\t\t|\t0.01\t\t\t|")
    print("|\tf\t\t|\t[12; 144]\t\t|\t12\t\t\t|")
    print("|\tx\t\t|\t[равно 3^(1/3)]\t\t|\tконстанта 3^(1/3)\t|")

def output(a, b, c, d, f, x, result):
    print("|\tАргумент\t|\tЗначение аргумента\t|\tРезультат вычисления\t|")
    print("|\ta\t\t|\t{0}\t\t\t|\t\t\t\t|".format(a))
    print("|\tb\t\t|\t{0}\t\t\t|\t\t\t\t|".format(b))
    print("|\tc\t\t|\t{0}\t\t\t|\t{1}\t\t\t|".format(c, result))
    print("|\td\t\t|\t{0}\t\t\t|\t\t\t\t|".format(d))
    print("|\tf\t\t|\t{0}\t\t\t|\t\t\t\t|".format(f))
    print("|\tx\t\t|\t{0}\t\t\t|\t\t\t\t|".format(x))

def examples():
    i = 1
    for example in exp.examples:
        print("Контрольный пример №{0}".format(i))
        func(example['a'], example['d'], example['f'])
        i += 1


if __name__ == "__main__":
    main()
