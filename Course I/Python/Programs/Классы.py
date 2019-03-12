#class Arr:
#    def __init__(self, a, b):
#        self.__a = a
#        self.__b = b
#        self.__val = [0] * (self.__b - self.__a + 1)
#    @property
#    def a(self):
#        return self.__a
#    @property
#    def b(self):
#        return self.__b
#    def __str__(self):
#        return " ".join(map(str, self.__val))
#    def range(self):
#        return range(self.__a, self.__b + 1)
#    def get(self, i):
#        if self.__a <= i <= self.__b:
#            return self.__val[i - self.__a]
#        else:
#            print('Недопустимый индекс ', i)
#    def put(self, i, x):
#        if self.__a <= i <= self.__b:
#            self.__val[i - self.__a] = x
#        else:
#            print('Недопустимый индекс ', i)

# Z = Arr(-5, 5)
# print(Z.a, Z.b)
# print(Z)
# for i in Z.range():
#     Z.put(i, Z.get(i) + i)
# print(Z)


# class Test:
#    a = 1
#    b = 2
#    def summ(self):
#        return self.a + self.b

# print(Test().summ())

# class Person:
#     name = ""
#     money = 0
 
# bob = Person()
# bob.name = "Bob"
# print (bob.name, "has", bob.money, "dollars.")

# class Dog():
#     age = 0
#     name = ""
#     weight = 0
 
#     def bark(self):
#         print( "Woof", self.name ) 
    
# myDog = Dog()
 
# myDog.name="Spot"
# myDog.weight=20
# myDog.age=3
 
# myDog.bark()

# def giveMoney1(money):
#     money += 100
 
# class Person:
#     name=""
#     money=0
 
# bob = Person()
# bob.name="Bob"
# bob.money=100
 
# giveMoney1(bob.money)
# print(bob.money)


# class Dog():
#     name=""
 
#     # Конструктор
#     # Вызывается в момент создания объекта этого типа
#     def __init__(self):
#         print("A new dog is born!")
 
# # Создался класс Dog
# myDog = Dog()

class Animal:
    name = ''
    def __init__(self):
        print('Родилось животное') 
    def eat(self):
        print('Ням ням')
    def makeNoise(self):
        print(f'{self.name} говорит Гррр\n')
class Cat(Animal):
    def __init__(self):
        Animal()
        print('Родился кот\n')
    def makeNoise(self):
        print(f'{self.name} говорит мяу\n')
class Dog(Animal):
    def __init__(self):
        Animal()
        print('Родилась собака\n')
    def makeNoise(self):
        print(f'{self.name} говорит гав\n')

catOne = Cat()
dogOne = Dog()
dogTwo = Dog()
animal = Animal()
catOne.name = 'Вася'
dogOne.name = 'Шир'
dogTwo.name = 'Дзета'
animal.name = 'Роза'
catOne.eat()
catOne.makeNoise()
dogOne.eat()
dogOne.makeNoise()
dogTwo.eat()
dogTwo.makeNoise()
animal.eat()
animal.makeNoise()

