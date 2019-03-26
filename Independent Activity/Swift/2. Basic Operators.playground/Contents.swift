import UIKit

let b = 10
var a = 5
a = b
print(a)

let (x, y) = (3, -23.3)
print(x, y)

//1 + 2       // equals 3
//5 - 3       // equals 2
//2 * 3       // equals 6
//10.0 / 2.5  // equals 4.0
print("hello, " + "world")

print(9 % 4) // equals 1

// Unary Minus Operator
let three = 3
let minusThree = -three       // minusThree equals -3
let plusThree = -minusThree   // plusThree equals 3, or "minus minus three"
print(minusThree, plusThree)

// Unary Plus Operator
let minusSix = -6
let alsoMinusSix = +minusSix  // alsoMinusSix equals -6
print(alsoMinusSix)

// Compound Assignment Operators
var g = 1
g += 2
print(g)
// Comparison Operators:
// Equal to (a == b)
// Not equal to (a != b)
// Greater than (a > b)
// Less than (a < b)
// Greater than or equal to (a >= b)
// Less than or equal to (a <= b)

let name = "world"
if name == "world" {
    print("hello, world")
} else {
    print("I'm sorry \(name), but I don't recognize you")
}
(1, "zebra") < (2, "apple")   // true because 1 is less than 2; "zebra" and "apple" are not compared
(3, "apple") < (3, "bird")    // true because 3 is equal to 3, and "apple" is less than "bird"
(4, "dog") == (4, "dog")      // true because 4 is equal to 4, and "dog" is equal to "dog"


let contentHeight = 40
let hasHeader = true
let rowHeight: Int
if hasHeader {
    rowHeight = contentHeight + 50
} else {
    rowHeight = contentHeight + 20
}
print(rowHeight)

// Range Operators
for index in 1...5 {
    print("\(index) times 5 is \(index * 5)")
}

// Half-Open Range Operator
let names = ["Anna", "Alex", "Brian", "Jack"]
let count = names.count
for i in 0..<count {
    print("Person \(i + 1) is called \(names[i])")
}
for name in names {
    print(name)
}
for name in names[2...] {
    print(name)
}

let range = ...5
print(range.contains(7))   // false
print(range.contains(4))   // true
print(range.contains(-1))  // true

// Logical Operators

// Logical NOT (!a)
let allowedEntry = false
if !allowedEntry {
    print("ACCESS DENIED")
}
// Prints "ACCESS DENIED"

// Logical AND (a && b)
let enteredDoorCode = true
let passedRetinaScan = false
if enteredDoorCode && passedRetinaScan {
    print("Welcome!")
} else {
    print("ACCESS DENIED")
}
// Prints "ACCESS DENIED"

// Logical OR (a || b)
let hasDoorKey = false
let knowsOverridePassword = true
if hasDoorKey || knowsOverridePassword {
    print("Welcome!")
} else {
    print("ACCESS DENIED")
}
// Prints "Welcome!"

// Combining Logical Operators
if enteredDoorCode && passedRetinaScan || hasDoorKey || knowsOverridePassword {
    print("Welcome!")
} else {
    print("ACCESS DENIED")
}
// Prints "Welcome!"

// Explicit Parentheses
if (enteredDoorCode && passedRetinaScan) || hasDoorKey || knowsOverridePassword {
    print("Welcome!")
} else {
    print("ACCESS DENIED")
}
// Prints "Welcome!"

