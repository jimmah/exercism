class Anagram {
  private _word: string

  constructor(word: string) {
    this._word = word
  }

  matches(...input: string[]): string[] {
    const result: string[] = []
    for (const item of input) {
      if (this.sort(item) === this.sort(this._word)) {
        if (item.toLowerCase() === this._word.toLowerCase()) {
          continue
        }

        result.push(item)
      }
    }

    return result
  }

  private sort(input: string): string {
    return input.toLowerCase().split("").sort().join("")
  }
}

export default Anagram
