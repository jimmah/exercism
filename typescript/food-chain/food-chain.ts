class FoodChain {
  private static _animals: string[] = [
    "fly",
    "spider",
    "bird",
    "cat",
    "dog",
    "goat",
    "cow",
    "horse"
  ]

  static verse(n: number): string {
    let result: string = ""

    let index = n - 1
    result += `I know an old lady who swallowed a ${this._animals[index]}.\n`

    switch (n) {
      case 2: result += "It wriggled and jiggled and tickled inside her.\n"
        break
      case 3: result += "How absurd to swallow a bird!\n"
        break
      case 4: result += "Imagine that, to swallow a cat!\n"
        break
      case 5: result += "What a hog, to swallow a dog!\n"
        break
      case 6: result += "Just opened her throat and swallowed a goat!\n"
        break
      case 7: result += "I don't know how she swallowed a cow!\n"
        break
      case 8: result += "She's dead, of course!\n"
        return result
      default:
        break
    }

    while (index >= 1) {
      result += `She swallowed the ${this._animals[index]} to catch the ${this._animals[index - 1]}`
      if (index === 2) {
        result += " that wriggled and jiggled and tickled inside her"
      }
      result += ".\n"
      index -= 1
    }
    result += "I don't know why she swallowed the fly. Perhaps she'll die."

    return result + "\n"
  }

  static verses(start = 1, end = 8): string {
    const verses: string[] = []

    for (let i = start; i <= end; i++) {
      let verse = this.verse(i)
      if (i !== end) {
        verse += "\n"
      }
      verses.push(verse)
    }

    return verses.join("")
  }
}

export default FoodChain
