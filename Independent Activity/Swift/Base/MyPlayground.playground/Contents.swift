import UIKit

//var groupOne = 23
//groupOne = 46
//let groupFour = "Swift"
//
//var a = 3, b = 2
//
//print(groupFour)
//let name = "Dima"
//
//
///**
// This func say hello to user
// - parameter name:String Name of user
// - returns: Absolutelly nothingw
// - throws: Error when name is array.
// - authors: Bilbo Baggins
// - bug: This is very simple function
// */
//func sayHello(name: String) {
//    print("Hello, \(name)")
//}
//
//let nameTwo: String = "TwoDima"
//var nameTree: String
//nameTree = "TreeDima"
//sayHello(name: nameTwo)
//sayHello(name: nameTree)
//
//let c: Float = 3.14
//var d = Float(a) / Float(b)
//var e = 1_000_000
//print(c, e, nameTree.count)
//
//let testC = ("TestC", 1, true)
//
//if testC.2 == true {
//    print(testC.0)
//}
//
//let possibleString = "1945"
//let converString = Int(possibleString)
//var optionalVar = Optional ("stringValue")
//print(optionalVar)
//
//var trollAge: Int? = 95
//trollAge = trollAge! + 10
//
//let q = 1
//let r = 2
//q <= r ? print("A <= B"): print("A > B")
//
//var testt: Int? = 8
//print(testt)
//if testt == nil {
//    print("!")
//} else {
//    print(testt!)
//}
//
//for i in 4...8 {
//    print(i)
//}
//
//var gg = [44, 22, 55]
//print(gg[0])


//struct MyStruct {
//    static var helloWorld = "HelloWorld"
//    var name: String
//    var age: Int
//}
//let a = MyStruct(name: "James", age: 25)
//print(a.helloWorld)


//func testMethod(_ a: Int?) -> Int {
//    guard var a = a else {
//        return 0
//    }
//    a += 10
//    return a
//}
//var a: Int? = nil
//let b = testMethod(a) * 2
//
//print(b)

//func someFunction(a: Bool) -> (Int) -> Int {
//    func someFunction1(a: Int) -> Int { return a + 1 }
//    func someFunction2(a: Int) -> Int { return a - 1 }
//    return a ? someFunction1 : someFunction2
//}
//let function = someFunction(a: true)
//let a = function(3)
//print(a)

//let numbers = [1, 2, 3].flatMap{[$0, $0]}
//print(numbers)

//var foo: Float = 32
//var bar: Double = 32
//bar = foo
//print(foo)

//enum MyError: Error {
//    case broken
//    case busted
//    case badgered
//}
//func willThrowAnError() throws {
//    throw MyError.busted
//}
//do {
//    try willThrowAnError()
//} catch MyError.busted {
//    print("Code was busted!")
//} catch {
//    print("Code just didn't work")
//}

let names: [String?] = ["Barbara", nil, "Janet", nil, "Peter", nil,
                        "George"]
if let firstName = names.first {
    print(firstName)
}
