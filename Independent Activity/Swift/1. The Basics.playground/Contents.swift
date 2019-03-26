import UIKit

// 1. The Basics

// Variable
var str = "Hello, Variable"
// Const
let strL = "Hello, const"

var x = 1, y = 2, z = 3

//var strTest: String
//var red, green, blue: Double

// Unicode
let pi = 3.14159
let 🐶🐮 = "dogcow"

//let languageName = "Swift"
//languageName = "Swift++" Error

print(pi)

let cat = "🐱"; print(cat)

let minValue = UInt8.min  // minValue is equal to 0, and is of type UInt8
let maxValue = UInt8.max
let floatTest = 9.98765
print(minValue, maxValue, floatTest)
print(3 + floatTest)
let decimalInteger = 17
let binaryInteger = 0b10001       // 17 in binary notation
let octalInteger = 0o21           // 17 in octal notation
let hexadecimalInteger = 0x11     // 17 in hexadecimal notation
print(binaryInteger, octalInteger, hexadecimalInteger)

//let tooBig: Int8 = Int8.max + 1
//print(tooBig) Error

typealias AudioSample = UInt16
var maxAmplitudeFound = AudioSample.max
print(maxAmplitudeFound)

// Booleans
let orangesOne = true
let orangesTwo = false

if orangesOne {
    print("orangesOne: " + String(orangesOne))
} else {
    print("orangesTwo: " + String(orangesTwo))
}

// Tuples

let http404Error = (404, "Not Found")
print(http404Error)
let (statusCode, statusMessage) = http404Error
print("Code: \(statusCode)")
print("Code: \(http404Error.0)")


// Optionals
let possibleNumber = "123"
let convertedNumber = Int(possibleNumber)
print(convertedNumber, type(of: convertedNumber))
var surveyAnswer: String?
surveyAnswer = "4"
print(surveyAnswer)
if surveyAnswer != nil {
    print("surveyAnswer has an integer value of \(surveyAnswer!).")
}
func canThrowAnError() throws {
    // this function may or may not throw an error
}
do {
    try canThrowAnError()
    // no error was thrown
    print("No error")
} catch {
    // an error was thrown
    print("Error")
}
// Debugging with Assertions
do {
    let age = -3
    print("Ok, \(age)")
    
} catch {
    print("Error")
}

