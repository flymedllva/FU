import UIKit

// 3. Strings and Characters


// String
let someString = "Some string literal value"

// Multiline String Literals
let quotation = """
Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut iaculis ut dui in commodo. Proin ac nunc nec libero congue porta. Maecenas et ultrices purus. Aliquam consequat gravida metus. Quisque pretium vulputate turpis, id rhoncus quam scelerisque non. Quisque elementum tellus in eros lobortis euismod. Nulla facilisi.
"""

// Line Breaks
let lineBreaks = """

This string starts with a line break.
It also ends with a line break.

"""

// Special Characters in String Literals
let wiseWords = "\"Imagination is more important than knowledge\" - Einstein"
// "Imagination is more important than knowledge" - Einstein
let dollarSign = "\u{24}"        // $,  Unicode scalar U+0024
let blackHeart = "\u{2665}"      // ♥,  Unicode scalar U+2665
let sparklingHeart = "\u{1F496}" // 💖, Unicode scalar U+1F496
print(dollarSign, blackHeart, sparklingHeart)

// String Mutability
var variableString = "Horse"
variableString += " and carriage"
print(variableString)

var constantString = "Highlander"
constantString += " and another Highlander"
print(constantString)

//  Working with Characters
for word in wiseWords {
    print(word)
}
let catCharacters: [Character] = ["C", "a", "t", "!", "🐱"]
let catString = String(catCharacters)
print(catString)

//Concatenating Strings and Characters
let string1 = "hello"
let string2 = " there"
var welcome = string1 + string2
print(welcome)

// Counting Characters
let unusualMenagerie = "Koala 🐨, Snail 🐌, Penguin 🐧, Dromedary 🐪"
print("unusualMenagerie has \(unusualMenagerie.count) characters")
var word = "cafe"
print("the number of characters in \(word) is \(word.count)")
// Prints "the number of characters in cafe is 4"

word += "\u{301}"    // COMBINING ACUTE ACCENT, U+0301

print("the number of characters in \(word) is \(word.count)")
// Prints "the number of characters in café is 4"

// Accessing and Modifying a String
let greeting = "Guten Tag!"
greeting[greeting.startIndex]
// G
greeting[greeting.index(before: greeting.endIndex)]
// !
greeting[greeting.index(after: greeting.startIndex)]
// u
let index = greeting.index(greeting.startIndex, offsetBy: 7)
greeting[index]
// a

for index in greeting.indices {
    print("\(greeting[index]) ", terminator: "")
}

//Inserting and Removing
var welcomeS = "hello"
welcomeS.insert("!", at: welcomeS.endIndex)
// welcome now equals "hello!"
print(welcomeS)

welcome.insert(contentsOf: " there", at: welcomeS.index(before: welcomeS.endIndex))
// welcomeS now equals "hello there!"
print(welcomeS)

//Prefix and Suffix Equality
let romeoAndJuliet = [
    "Act 1 Scene 1: Verona, A public place",
    "Act 1 Scene 2: Capulet's mansion",
    "Act 1 Scene 3: A room in Capulet's mansion",
    "Act 1 Scene 4: A street outside Capulet's mansion",
    "Act 1 Scene 5: The Great Hall in Capulet's mansion",
    "Act 2 Scene 1: Outside Capulet's mansion",
    "Act 2 Scene 2: Capulet's orchard",
    "Act 2 Scene 3: Outside Friar Lawrence's cell",
    "Act 2 Scene 4: A street in Verona",
    "Act 2 Scene 5: Capulet's mansion",
    "Act 2 Scene 6: Friar Lawrence's cell"
]

var act1SceneCount = 0
for scene in romeoAndJuliet {
    if scene.hasPrefix("Act 1 ") {
        act1SceneCount += 1
    }
}
print("There are \(act1SceneCount) scenes in Act 1")
