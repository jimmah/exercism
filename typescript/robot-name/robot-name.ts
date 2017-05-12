class RobotName {
  private _name: string
  private _names: Set<string> = new Set<string>()

  get name(): string {
    return this._name
  }

  constructor() {
    this.resetName()
  }

  resetName() {
    this._name = this.generateName()
  }

  private generateName(): string {
    const digits = this.digits(3).toString()
    let name = this.letters(2) + digits
    while (this._names.has(name)) {
      name = this.letters(2) + digits
    }

    this._names.add(name)
    return name
  }

  private digits(length: number): number {
    let digits = ""
    for (let i = 0; i < length; i++) {
      let digit = Math.floor(Math.random() * 10)
      if (i === 0 && digit === 0) {
        digit = this.digits(1)
      }
      digits += digit
    }

    return parseInt(digits, 10)
  }

  private letters(length: number): string {
    let letters = ""
    const alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

    for (let i = 0; i < length; i++) {
      const index = this.digits(2) % (alphabet.length - 1)
      letters += alphabet[index]
    }

    return letters
  }
}

export default RobotName
