import UIKit

// 4. Collection Types

// Creating an Empty Array

var someInts = [Int]()
someInts.append(3)
someInts.append(4)
print("someInts is of type [Int] with \(someInts.count) items.")

//Creating an Array with a Default Value
var threeDoubles = Array(repeating: 1.0, count: 3)
print(threeDoubles)

// Creating an Array with an Array Literal
var shoppingList: [String] = ["Eggs", "Milk"]
print(shoppingList)

// Accessing and Modifying an Array
if shoppingList.isEmpty {
    print("The shopping list is empty.")
} else {
    print("The shopping list is not empty.")
}
shoppingList += ["Baking Powder"]
shoppingList += ["Chocolate Spread", "Cheese", "Butter"]

shoppingList[0] = "Six eggs"
print(shoppingList)

// Iterating Over an Array

for index in shoppingList.indices {
    print(shoppingList[index])
}

for item in shoppingList {
    print(item)
}

for (index, value) in shoppingList.enumerated() {
    print("Item \(index + 1): \(value)")
}

// Creating and Initializing an Empty Set
var letters = Set<Character>()
print("letters is of type Set<Character> with \(letters.count) items.")
letters.insert("a")
print(letters)

// Creating a Set with an Array Literal
var favoriteGenres: Set<String> = ["Rock", "Classical", "Hip hop"]
print(favoriteGenres)

// Accessing and Modifying a Set
print("I have \(favoriteGenres.count) favorite music genres.")
if favoriteGenres.isEmpty {
    print("As far as music goes, I'm not picky.")
} else {
    print("I have particular music preferences.")
}
favoriteGenres.insert("Jazz")
if let removedGenre = favoriteGenres.remove("Rock") {
    print("\(removedGenre)? I'm over it.")
} else {
    print("I never much cared for that.")
}
// Iterating Over a Set
for genre in favoriteGenres {
    print("\(genre)")
}
for genre in favoriteGenres.sorted() {
    print("\(genre)")
}

// Performing Set Operations

let oddDigits: Set = [1, 3, 5, 7, 9]
let evenDigits: Set = [0, 2, 4, 6, 8]
let singleDigitPrimeNumbers: Set = [2, 3, 5, 7]

oddDigits.union(evenDigits).sorted()
// [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
oddDigits.intersection(evenDigits).sorted()
// []
oddDigits.subtracting(singleDigitPrimeNumbers).sorted()
// [1, 9]
oddDigits.symmetricDifference(singleDigitPrimeNumbers).sorted()

// Set Membership and Equality
let houseAnimals: Set = ["🐶", "🐱"]
let farmAnimals: Set = ["🐮", "🐔", "🐑", "🐶", "🐱"]
let cityAnimals: Set = ["🐦", "🐭"]
print(houseAnimals.isSubset(of: farmAnimals))
// true
print(farmAnimals.isSuperset(of: houseAnimals))
// true
print(farmAnimals.isDisjoint(with: cityAnimals))
// true

// Dictionaries
var namesOfIntegers = [Int: String]()
namesOfIntegers[16] = "sixteen"
// namesOfIntegers now contains 1 key-value pair
namesOfIntegers = [:]
// namesOfIntegers is once again an empty dictionary of type [Int: String]
print(namesOfIntegers)

// Accessing and Modifying a Dictionary
print("The airports dictionary contains \(airports.count) items.")
if airports.isEmpty {
    print("The airports dictionary is empty.")
} else {
    print("The airports dictionary is not empty.")
}
// Prints "The airports dictionary is not empty."
