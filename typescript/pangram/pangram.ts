class Pangram {
  private _sentence: string

  constructor(sentence: string) {
    this._sentence = sentence
  }

  isPangram(): boolean {
    const sentence = this._sentence.toLowerCase()

    return "abcdefghijklmnopqrstuvwxyz"
      .split("")
      .filter((c) => sentence.indexOf(c) === -1)
      .length === 0
  }
}

export default Pangram
